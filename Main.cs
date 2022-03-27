using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace USBFormatingWithWinForm {
    public partial class Main : Form {
        string DriveLabel;
        public Main() {
            InitializeComponent();
        }

        public static string GetSize(long size) {
            string postfix = "Bytes";
            long result = size;
            if (size >= 1073741824) { // Larger than 1 GB
                result = size / 1073741824;
                postfix = "GB";
            } else if (size >= 1048576) { // Larger than 1 MB
                result = size / 1048576;
                postfix = "MB";
            } else if (size >= 1024) { // Larger than 1 KB
                result = size / 1024;
                postfix = "KB";
            }
            return result.ToString("F1") + " " + postfix;
        }

        private void Main_Load(object sender, EventArgs e) {
            try {
                DriveInfo[] Removeable = DriveInfo.GetDrives();
                foreach (DriveInfo r in Removeable) {
                    if (r.DriveType == DriveType.Removable) {
                        string DriverSize = GetSize(r.TotalSize);
                        DriveLabel = r.VolumeLabel;
                        comboBox1.Items.Add($"{DriveLabel} {r.Name.Remove(2)} {DriverSize}");
                    }
                }
            } catch { MessageBox.Show("Error Fetching Removeable Drives", "Error"); }
            comboBox1.SelectedIndex = 0;
            USBVolumeLabelBox.Text = DriveLabel;
        }
    }
}