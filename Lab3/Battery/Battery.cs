using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Battery
{
    class Battery
    {
        public const string OnlineStatus = "Online";
        public const string OfflineStatus = "Offline";
        private const string ProgramName = "cmd.exe";

        //свойство, которое описывает заряд батареи на текущий момент
        public int Power { get; set; }

        //свойство, которое описывает оставшееся время работы от батареи
        public int Time { get; set; }

        //свойство, которое описывает тип питания (батарея/сеть)
        public string PowerType { get; set; }

        //время отключения экрана 
        private int ScreenTime { get; set; }

        public Battery()
        {
            GetTime();
        }

        public string GetPowerType()
        {
            PowerType = SystemInformation.PowerStatus.PowerLineStatus.ToString();
            switch(PowerType)
            {
                case OnlineStatus: return "Подключено к сети";
                case OfflineStatus: return "Питание от батареи";
                default: return "Неизвестно";
            }
        }

        //метод получает возможное время работы от батареи 
        public string GetTime()
        {
            Time = SystemInformation.PowerStatus.BatteryLifeRemaining;
            if (Time != -1 && PowerType == OfflineStatus)
            {
                return new TimeSpan(0, Time / 60, 0).ToString();
            }
            if (Time == -1 && PowerType == OnlineStatus)
            {
                return "Заряжается";
            }
            return "Подождите... Идёт подсчёт";
        }

        //метод получения оставшего заряда аккумулятора в процентах
        public int GetPower()
        {
            return Power = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
        }

        //метод, меняющий время отключения экрана
        public void DisableScreen(int newTime)
        {
            const string command = "/c pwoercfg /x -monitor-timeout-dc";
            Process cmd = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = ProgramName,
                    Arguments = command + newTime
                }
            };
            cmd.Start();
        }

        //получение исходного времени отключения экрана
        private void GetScreenTime()
        {
            const string command = "c powercfg /q";
            Process cmd = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = ProgramName,
                    Arguments = command
                }
            };
            cmd.Start();

            var powerSchemes = cmd.StandardOutput.ReadToEnd();
            var someString = new Regex("VIDEOIDLE.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*");
            var videoidle = someString.Match(powerSchemes).Value;
            ScreenTime = Convert.ToInt32(videoidle.Substring(videoidle.Length - 11).TrimEnd(), 16) / 60;
        }

        public void ReturnOldTime()
        {
            DisableScreen(ScreenTime);
        }
    }
}
