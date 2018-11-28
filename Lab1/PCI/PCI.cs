using System;
using System.Management;
using System.IO;
using System.Text.RegularExpressions;

namespace PCI_devices
{
    class Program
    {
        static void Main(string[] args)
        {
            String vendorId, deviceId;
            String[] info = File.ReadAllLines("pci.ids.txt");
            string vendorIdPrefix = @"^\t";
            string deviceIdPrefix = @"^\t\=";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                if (queryObj["DeviceID"].ToString().Substring(0, 3) == "PCI")
                {
                    vendorId = queryObj["DeviceID"].ToString().Substring(8, 4);
                    deviceId = queryObj["DeviceID"].ToString().Substring(17, 4);
                    int i = 0;
                    
                    Regex vendorIdRegex = new Regex(vendorIdPrefix + vendorId);
                    for (; i < info.Length; ++i)
                    {
                        if (vendorIdRegex.IsMatch(info[i]))
                        {
                            Console.WriteLine("Vendor: {0}", vendorIdRegex.Replace(info[i], string.Empty));
                            break;
                        }
                    }

                    Console.WriteLine("VendorID: 0x{0}", vendorId);

                    Regex deviceIdRegex = new Regex(deviceIdPrefix + deviceId);
                    for (; i < info.Length; ++i)
                    {
                            Console.WriteLine("Device: {0}", queryObj["Name"]);
                            break;
                    }
                    
                    Console.WriteLine("DeviceID: 0x{0}", deviceId);
                    Console.WriteLine("==========================================================");
                }
            }
            Console.ReadKey();
        }
    }
}
