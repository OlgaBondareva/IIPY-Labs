using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Lab5
{
    class DeviceInformationSearcher
    {
        private ManagementObjectSearcher searcher;
        private static readonly SelectQuery query = new SelectQuery("SELECT * FROM Win32_PnPEntity");
        private static ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");

        public DeviceInformationSearcher()
        {
            searcher = new ManagementObjectSearcher(scope, query);
        }

        public List<DeviceManager> GetDevices()
        {
            List<DeviceManager> devices = new List<DeviceManager>();
            foreach (ManagementObject device in searcher.Get())
            {
                if (device["Name"] == null ||
                    device["ClassGuid"] == null ||
                    device["Manufacturer"] == null ||
                    device["Caption"] == null ||
                    device["DeviceID"] == null)
                {
                    continue;
                }

                string[] driverInfo = GetDriverInfo(device);
                devices.Add(new DeviceManager(device["Name"].ToString(),
                    device["ClassGuid"].ToString(),
                    device["HardwareID"] == null ? "" : String.Join("\n", (string[])device["HardwareID"]),
                    device["Manufacturer"].ToString(),
                    driverInfo[0],
                    device["Caption"].ToString(),
                    driverInfo[1],
                    device["DeviceID"].ToString(),
                    device["Status"].ToString().Equals("OK")
                    ));
            }
            return devices;
        }

        private string[] GetDriverInfo(ManagementObject device)
        {
            string[] driverInfo = new string[2];
            foreach (var driverParameter in device.GetRelated("Win32_SystemDriver"))
            {
                driverInfo[0] += driverParameter["Description"] == null ? "" : (driverParameter["Description"].ToString() + "\n");
                driverInfo[1] += driverParameter["PathName"] == null ? "" : (driverParameter["PathName"].ToString() + "\n");
            }
            return driverInfo;
        }
    }
}
