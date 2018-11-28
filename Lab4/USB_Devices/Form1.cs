using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_devices
{
    public partial class Form1 : Form
    {
        private const int WM_DEVICECHANGE = 0X219;
        private static readonly DeviceSearcher Searcher = new DeviceSearcher();
        private List<usbDevice> devices;
        private readonly DataTable table = new DataTable();

        protected override void WndProc(ref Message m)
        {
 	        base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE) 
            {
                UpdateGrid();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            int currentPosition = 0;
            if (OutputGrid.CurrentRow != null)
            {
                currentPosition = OutputGrid.CurrentRow.Index;
            }
            table.Clear();
            devices = Searcher.GetDevices();
            foreach(usbDevice device in devices)
            {
                table.Rows.Add(device.Name, device.TotalFreeSpace, device.BusySpace, device.TotalSize);
            }
            if (OutputGrid.RowCount - 1 > currentPosition)
            {
                OutputGrid.Rows[currentPosition].Selected = true;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (OutputGrid.CurrentRow != null)
            {
                if (!devices[OutputGrid.CurrentRow.Index].Eject())
                {
                    Message.Text = "Устройство занято";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void OutputGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            if (OutputGrid.CurrentRow != null)
            {
                if (OutputGrid.CurrentRow.Index >= 0 && OutputGrid.CurrentRow.Index < devices.Count)
                {
                    RemoveButton.Enabled = !devices[OutputGrid.CurrentRow.Index].IsMtp;
                }
                else
                {
                    RemoveButton.Enabled = false;
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            devices = new List<usbDevice>();
            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Свободно", typeof(string));
            table.Columns.Add("Занято", typeof(string));
            table.Columns.Add("Всего", typeof(string));
            UpdateGrid();
            OutputGrid.DataSource = table;
            RemoveButton.Enabled = false;
            timer1.Enabled = true;
        }
    }
}
