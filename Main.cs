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
                result = size / 1000000000;//1073741824;
                postfix = "GB";
            } else if (size >= 1048576) { // Larger than 1 MB
                result = size / 1000000;
                postfix = "MB";
            } else if (size >= 1024) { // Larger than 1 KB
                result = size / 1000;
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
                        DeviceBox.Items.Add($"{DriveLabel} {r.Name.Remove(2)} {DriverSize}");
                    }
                }
            } catch { MessageBox.Show("Error Fetching Removeable Drives", "Error"); }
            DeviceBox.SelectedIndex = 0;
            FileSystemBox.SelectedIndex = 0;
            FileSystemBox_SelectedIndexChanged(this, null);
            USBVolumeLabelBox.Text = DriveLabel;
        }
        private void DeviceBox_SelectedIndexChanged(object sender, EventArgs e) {
            USBVolumeLabelBox.Text = DeviceBox.Text.Substring(0, DeviceBox.Text.IndexOf(" "));
        }
        private void FileSystemBox_SelectedIndexChanged(object sender, EventArgs e) {
            ClusterSizeBox.Items.Clear();
            string[] Zero = { "4096 Bytes", "8192 Bytes (Default)", "16 Kilobytes", "32 Kilobytes", "64 Kilobytes" };
            string[] One = {
                "512 Bytes", "1024 Bytes", "2048 Bytes",
                "4096 Bytes (Default)", "8192 Bytes", "16 Kilobytes",
                "32 Kilobytes", "64 Kilobytes"
            };
            string[] Two = { "Default" };
            string[] Three = {
                "512 Bytes", "1024 Bytes", "2048 Bytes",
                "4096 Bytes", "8192 Bytes", "16 Kilobytes",
                "32 Kilobytes (Default)", "64 Kilobytes", "128 Kilobytes",
                "256 Kilobytes", "512 Kilobytes", "1024 Kilobytes",
                "2048 Kilobytes", "4096 Kilobytes", "8192 Kilobytes",
                "16 Megabytes", "32 Megabytes"
            };
            string[] FourAndFive = { "Default" };
            switch (FileSystemBox.SelectedIndex) {
                case 0:
                    ClusterSizeBox.Items.AddRange(Zero);
                    ClusterSizeBox.SelectedIndex = 1;
                    break;
                case 1:
                    ClusterSizeBox.Items.AddRange(One);
                    ClusterSizeBox.SelectedIndex = 3;
                    break;
                case 2:
                    ClusterSizeBox.Items.AddRange(Two);
                    ClusterSizeBox.SelectedIndex = 0;
                    break;
                case 3:
                    ClusterSizeBox.Items.AddRange(Three);
                    ClusterSizeBox.SelectedIndex = 6;
                    break;
                case 4:
                    ClusterSizeBox.Items.AddRange(FourAndFive);
                    ClusterSizeBox.SelectedIndex = 0;
                    break;
                case 5:
                    ClusterSizeBox.Items.AddRange(FourAndFive);
                    ClusterSizeBox.SelectedIndex = 0;
                    break;
            }
        }
    }
}