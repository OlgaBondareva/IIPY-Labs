using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbEject;

namespace USB_devices
{
    class usbDevice
    {
        public string Name { get; set; }
        public string TotalFreeSpace { get; set; }
        public string BusySpace { get; set; }
        public string TotalSize { get; set; }
        public bool IsMtp { get; set; }

        public usbDevice(string name, string totalFreeSpace, string busySpace, string totalSize, bool isMtp)
        {
            Name = name;
            TotalFreeSpace = totalFreeSpace;
            BusySpace = busySpace;
            TotalSize = totalSize;
            IsMtp = isMtp;
        }

        public bool Eject()
        {
            var ejectDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == this.Name.Remove(2));
            ejectDevice.Eject(false);
            ejectDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == this.Name.Remove(2));
            return ejectDevice == null;
        }
    }
}
