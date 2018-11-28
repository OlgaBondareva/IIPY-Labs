using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Lab5
{
    class DeviceManager
    {
        public string Name { get; set; }
        public string ClassGUID { get; set; }
        public string HardwareID { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Provider { get; set; }
        public string SysPath { get; set; }
        public string DevicePath { get; set; }
        public bool Status { get; set; }

        public DeviceManager(string name, string classGuid, string harwareId, string manufacturer, string description, string provider, string sysPath, string devicePath, bool status)
        {
            Name = name;
            ClassGUID = classGuid;
            HardwareID = harwareId;
            Manufacturer = manufacturer;
            Description = description;
            Provider = provider;
            SysPath = sysPath;
            DevicePath = devicePath;
            Status = status;
        }

        public void ChangeConnection(string method)
        {
            var device = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity")
                .Get().OfType<ManagementObject>().FirstOrDefault(x => x["DeviceID"].ToString().Equals(DevicePath));
            device.InvokeMethod(method, new object[] { false });
        }
    }
}
