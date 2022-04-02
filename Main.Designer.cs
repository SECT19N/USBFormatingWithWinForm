
namespace USBFormatingWithWinForm {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeviceBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DriveStatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClusterSizeBox = new System.Windows.Forms.ComboBox();
            this.FileSystemBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.USBVolumeLabelBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceBox
            // 
            this.DeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceBox.FormattingEnabled = true;
            this.DeviceBox.Location = new System.Drawing.Point(28, 73);
            this.DeviceBox.Name = "DeviceBox";
            this.DeviceBox.Size = new System.Drawing.Size(472, 28);
            this.DeviceBox.TabIndex = 0;
            this.DeviceBox.SelectedIndexChanged += new System.EventHandler(this.DeviceBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DeviceBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(25);
            this.groupBox1.Size = new System.Drawing.Size(528, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DriveStatusLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ClusterSizeBox);
            this.groupBox2.Controls.Add(this.FileSystemBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.USBVolumeLabelBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(25);
            this.groupBox2.Size = new System.Drawing.Size(528, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format Options";
            // 
            // DriveStatusLabel
            // 
            this.DriveStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DriveStatusLabel.Location = new System.Drawing.Point(28, 182);
            this.DriveStatusLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.DriveStatusLabel.Name = "DriveStatusLabel";
            this.DriveStatusLabel.Size = new System.Drawing.Size(472, 20);
            this.DriveStatusLabel.TabIndex = 6;
            this.DriveStatusLabel.Text = ".";
            this.DriveStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cluster Size";
            // 
            // ClusterSizeBox
            // 
            this.ClusterSizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClusterSizeBox.FormattingEnabled = true;
            this.ClusterSizeBox.Location = new System.Drawing.Point(300, 136);
            this.ClusterSizeBox.Name = "ClusterSizeBox";
            this.ClusterSizeBox.Size = new System.Drawing.Size(200, 28);
            this.ClusterSizeBox.TabIndex = 4;
            // 
            // FileSystemBox
            // 
            this.FileSystemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileSystemBox.FormattingEnabled = true;
            this.FileSystemBox.Items.AddRange(new object[] {
            "FAT32 (Default)",
            "NTFS",
            "exFAT"});
            this.FileSystemBox.Location = new System.Drawing.Point(28, 136);
            this.FileSystemBox.Name = "FileSystemBox";
            this.FileSystemBox.Size = new System.Drawing.Size(200, 28);
            this.FileSystemBox.TabIndex = 2;
            this.FileSystemBox.SelectedIndexChanged += new System.EventHandler(this.FileSystemBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "File System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume Label";
            // 
            // USBVolumeLabelBox
            // 
            this.USBVolumeLabelBox.Location = new System.Drawing.Point(28, 70);
            this.USBVolumeLabelBox.Name = "USBVolumeLabelBox";
            this.USBVolumeLabelBox.Size = new System.Drawing.Size(472, 27);
            this.USBVolumeLabelBox.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(418, 375);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(94, 29);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(552, 412);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nufus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DeviceBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox USBVolumeLabelBox;
        private System.Windows.Forms.ComboBox FileSystemBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ClusterSizeBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label DriveStatusLabel;
    }
}