using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace USBFormatingWithWinForm {
    public partial class Main : Form {
        string DriveLabel, DriveFileSystem, DriveCluster, DriveName;
        public Main() {
            InitializeComponent();
            USBNotification.RegisterUsbDeviceNotification(this.Handle);
        }

        #region Functions

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == USBNotification.WmDevicechange) {
                switch ((int)m.WParam) {
                    case USBNotification.DbtDeviceremovecomplete: Main_Load(this, null); break; //updates when device are removed
                    case USBNotification.DbtDevicearrival: Main_Load(this, null); break; //updates when device are added
                }
            }
        }
        public static string GetSize(long size) {
            string postfix = "Bytes";
            long result = size;
            if (size >= 1000000000) { // Larger than 1 GB
                result = size / 1000000000;
                postfix = "GB";
            } else if (size >= 1000000) { // Larger than 1 MB
                result = size / 1000000;
                postfix = "MB";
            } else if (size >= 1000) { // Larger than 1 KB
                result = size / 1000;
                postfix = "KB";
            }
            return result.ToString("F1") + " " + postfix;
        }
        public void FormatDrive(string filesystem, string label, string name) {
            try {
                StartButton.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                DriveStatusLabel.Text = "Creating Process.";
                Process process = new Process { StartInfo = {
                        FileName = "cmd.exe",
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = $"/C format {name} /FS:{filesystem} /V:{label} /Q /A:{DriveCluster} /X"
                    }
                };
                DriveStatusLabel.Text = "Starting Process...";
                process.Start();
                DriveStatusLabel.Text = "Starting Format...";
                StreamWriter standardInput = process.StandardInput;
                standardInput.WriteLine();
                DriveStatusLabel.Text = "Formatting...";
                process.WaitForExit();
                DriveStatusLabel.Text = "Formatting finished";
                DeviceBox_SelectedIndexChanged(this, null);
                StartButton.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception err) {
                MessageBox.Show("" + err);
            }
            Main_Load(this, null);
        }

        #endregion

        #region Events

        private void Main_Load(object sender, EventArgs e) {
            DeviceBox.Items.Clear();
            try {
                DriveInfo[] Removeable = DriveInfo.GetDrives();
                foreach (DriveInfo r in Removeable) {
                    if (r.DriveType == DriveType.Removable) {
                        string DriverSize = GetSize(r.TotalSize);
                        DriveLabel = r.VolumeLabel;
                        DriveName = r.Name.Remove(2);
                        DeviceBox.Items.Add($"{DriveLabel} {DriveName} [{DriverSize}]");
                    }
                }
            } catch { MessageBox.Show("Error Fetching Removeable Drives", "Error"); }
            DriveStatusLabel.Text = string.Empty;
            if (DeviceBox.Items.Count > 0) {
                DeviceBox.SelectedIndex = 0;
            }
            FileSystemBox.SelectedIndex = 0;
            USBVolumeLabelBox.Text = DriveLabel;
            FileSystemBox_SelectedIndexChanged(this, null);
            DeviceBox_SelectedIndexChanged(this, null);
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
        private void DeviceBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (DeviceBox.Items.Count <= 0) {
                DriveStatusLabel.Text = "No Devices Found";
                return;
            }
            USBVolumeLabelBox.Text = DeviceBox.Text.Substring(0, DeviceBox.Text.IndexOf(" "));
            DriveName = DeviceBox.Text.Substring(DeviceBox.Text.IndexOf(" "), 3).Trim();
            DriveInfo currentDrive = new DriveInfo(DriveName);
            if (currentDrive.IsReady) {
                DriveStatusLabel.Text = "Ready";
            } else {
                DriveStatusLabel.Text = "Not Ready";
            }
        }
        private void FileSystemBox_SelectedIndexChanged(object sender, EventArgs e) {
            ClusterSizeBox.Items.Clear();
            string[] Zero = { "4096 Bytes", "8192 Bytes (Default)", "16 Kilobytes", "32 Kilobytes", "64 Kilobytes" };
            string[] One = {
                "512 Bytes", "1024 Bytes", "2048 Bytes",
                "4096 Bytes (Default)", "8192 Bytes", "16 Kilobytes",
                "32 Kilobytes", "64 Kilobytes"
            };
            string[] Two = {
                "512 Bytes", "1024 Bytes", "2048 Bytes",
                "4096 Bytes", "8192 Bytes", "16 Kilobytes",
                "32 Kilobytes (Default)", "64 Kilobytes", "128 Kilobytes",
                "256 Kilobytes", "512 Kilobytes", "1024 Kilobytes",
                "2048 Kilobytes", "4096 Kilobytes", "8192 Kilobytes",
                "16 Megabytes", "32 Megabytes"
            };
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
                    ClusterSizeBox.SelectedIndex = 6;
                    break;
            }
        }
        private void StartButton_Click(object sender, EventArgs e) {
            if (DeviceBox.Text == string.Empty) {
                MessageBox.Show("No items selected!", "Warning");
            } else {
                DriveFileSystem = FileSystemBox.Text;
                DriveLabel = USBVolumeLabelBox.Text;
                DriveCluster = ClusterSizeBox.Text;
                if (DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Bytes" ||
                    DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Bytes (Default)") {
                    DriveCluster = DriveCluster.Substring(0, DriveCluster.IndexOf(" "));
                } else if (DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Kilobytes" ||
                DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Kilobytes (Default)") {
                    DriveCluster = DriveCluster.Substring(0, DriveCluster.IndexOf(" ")) + "K";
                } else if (DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Megabytes" ||
                DriveCluster.Remove(0, DriveCluster.IndexOf(" ")) == " Megabtes (Default)") {
                    DriveCluster = DriveCluster.Substring(0, DriveCluster.IndexOf(" ")) + "M";
                }
                if (DriveFileSystem == "FAT32 (Default)") {
                    DriveFileSystem = DriveFileSystem.Substring(0, DriveFileSystem.IndexOf(" "));
                }
                FormatDrive(DriveFileSystem, DriveLabel, DriveName);
            }
        }

        #endregion

    }
}