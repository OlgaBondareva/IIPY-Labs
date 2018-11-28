using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private readonly DeviceInformationSearcher searcher = new DeviceInformationSearcher();
        private List<DeviceManager> devices;
        public Form1()
        {
            InitializeComponent();
            UpdateDeviceList();
        }

        private void UpdateDeviceList()
        {
            devices = searcher.GetDevices();
            foreach (DeviceManager deviceManager in devices)
            {
                DeviceList.Items.Add(deviceManager.Name);
            }
        }

        private void DeviceList_MouseClick(object sender, MouseEventArgs e)
        {
            DisplayDeviceInfo(devices[DeviceList.SelectedItems[0].Index]);
        }

        private void DisplayDeviceInfo(DeviceManager deviceManager)
        {
            string info = "GUID:    " + deviceManager.ClassGUID + "\r\nHardwareID:  " + deviceManager.HardwareID + 
                        "\r\nManufacturer:  " + deviceManager.Manufacturer + "\r\nProvider:  " + deviceManager.Provider + 
                        "\r\nDriver description:    " + deviceManager.Description + "\r\n.sys path: " + deviceManager.SysPath + 
                        "\r\nDevice Path:   " + deviceManager.DevicePath;
            DeviceInfo.Text = info;
            EnableButton.Enabled = !deviceManager.Status;
            DisableButton.Enabled = deviceManager.Status;
        }

        private void EnableButton_Click(object sender, EventArgs e)
        {
            devices[DeviceList.SelectedItems[0].Index].ChangeConnection("Enable");
            devices[DeviceList.SelectedItems[0].Index].Status = !devices[DeviceList.SelectedItems[0].Index].Status;
            EnableButton.Enabled = !EnableButton.Enabled;
            DisableButton.Enabled = !DisableButton.Enabled;
        }

        private void DisableButton_Click(object sender, EventArgs e)
        {
            devices[DeviceList.SelectedItems[0].Index].ChangeConnection("Disable");
            devices[DeviceList.SelectedItems[0].Index].Status = !devices[DeviceList.SelectedItems[0].Index].Status;
            DisableButton.Enabled = !DisableButton.Enabled;
            EnableButton.Enabled = !EnableButton.Enabled;
        }
    }
}
