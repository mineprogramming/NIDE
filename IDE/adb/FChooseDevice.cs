
using Managed.Adb;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NIDE.adb
{
    public partial class FChooseDevice : Form
    {
        public static Device Device { get; private set; }
        public static bool Ask { get; set; } = true;

        public DialogResult ShowDialog(IList<Device> devices)
        {
            if (Ask || !Device.IsOnline)
            {
                foreach (Device device in devices)
                {
                    lbDevices.Items.Add(new DeviceItem(device));
                }
                return ShowDialog();
            }
            else
                return DialogResult.OK;
        }

        public FChooseDevice()
        {
            InitializeComponent();
        }

        private void BtnPush_Click(object sender, System.EventArgs e)
        {
            if (lbDevices.SelectedItem != null)
            {
                Device = ((DeviceItem)lbDevices.SelectedItem).Device;
                Ask = !CBDontAsk.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class DeviceItem
        {
            public Device Device { get; }
            public DeviceItem(Device device) => Device = device;
            public override string ToString() => Device.Model;
        }
    }
}
