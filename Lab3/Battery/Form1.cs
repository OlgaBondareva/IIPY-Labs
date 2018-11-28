using System;
using System.Windows.Forms;

namespace Battery
{
    public partial class Form1 : Form
    {
        private readonly Battery battery = new Battery();
        private readonly Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();

            powerType.Text = battery.GetPowerType();
            powerLeft.Minimum = 0;
            powerLeft.Maximum = 100;
            powerLeft.Value = battery.GetPower();            
            powerLeft.Step = 1;

            powerValue.Text = Convert.ToString(battery.GetPower()) + " %";

            timer.Interval = 1000;
            timer.Tick += TimerEvent;
            timer.Start();

            screenOffLabel.Enabled = battery.PowerType != Battery.OnlineStatus;
            button.Enabled = battery.PowerType != Battery.OnlineStatus;

            FormClosing += AppClose;
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            powerType.Text = battery.GetPowerType();
            powerLeft.Value = battery.GetPower();
            timeLeft.Text = battery.GetTime();
            powerValue.Text = Convert.ToString(battery.GetPower()) + " %";

            screenOffLabel.Enabled = battery.PowerType != Battery.OnlineStatus;
            button.Enabled = battery.PowerType != Battery.OnlineStatus;

            if (battery.PowerType == Battery.OnlineStatus) battery.ReturnOldTime();
        }

        private void AppClose(object sender, EventArgs e)
        {
            timer.Stop();
            battery.ReturnOldTime();
        }

        private void button_Click(object sender, EventArgs e)
        {
            battery.DisableScreen(Convert.ToInt32(screenOffLabel.Text));
        }


    }
}
