using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaDevices;

namespace USB_devices
{
    class DeviceSearcher
    {
        public List<usbDevice> GetDevices()
        {
            List<usbDevice> devices = new List<usbDevice>();
            List<DriveInfo> drives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).ToList();
            List<MediaDevice> mtpDevice = MediaDevice.GetDevices().ToList();
            foreach (MediaDevice device in mtpDevice)
            {
                device.Connect();
                if (device.DeviceType != DeviceType.Generic)
                {
                    devices.Add(new usbDevice(device.Manufacturer + " " + device.Model, null, null, null, true));
                }
            }
            foreach (DriveInfo drive in drives)
            {
                devices.Add(new usbDevice(drive.Name + drive.VolumeLabel, BytesToMegabytesString(drive.TotalFreeSpace),
                BytesToMegabytesString(drive.TotalSize - drive.TotalFreeSpace),
                BytesToMegabytesString(drive.TotalSize), false));
            }
            return devices;
        }

        private string BytesToMegabytesString(long value)
        {
            return (value / 1000 / 1000 / 1000 ).ToString() + " GB";
        }
    }
}
