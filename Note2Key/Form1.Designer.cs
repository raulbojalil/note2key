namespace Note2Key
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            this.cmbRecordingDevice = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgbVolume = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoteName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRecordingDevice
            // 
            this.cmbRecordingDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecordingDevice.FormattingEnabled = true;
            this.cmbRecordingDevice.Location = new System.Drawing.Point(15, 20);
            this.cmbRecordingDevice.Name = "cmbRecordingDevice";
            this.cmbRecordingDevice.Size = new System.Drawing.Size(256, 21);
            this.cmbRecordingDevice.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbVolume);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.cmbRecordingDevice);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recording device";
            // 
            // pgbVolume
            // 
            this.pgbVolume.Location = new System.Drawing.Point(15, 78);
            this.pgbVolume.Name = "pgbVolume";
            this.pgbVolume.Size = new System.Drawing.Size(256, 19);
            this.pgbVolume.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(141, 47);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Listening";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNoteName);
            this.groupBox2.Location = new System.Drawing.Point(5, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Note info";
            // 
            // lblNoteName
            // 
            this.lblNoteName.AutoSize = true;
            this.lblNoteName.Enabled = false;
            this.lblNoteName.Location = new System.Drawing.Point(12, 25);
            this.lblNoteName.Name = "lblNoteName";
            this.lblNoteName.Size = new System.Drawing.Size(249, 13);
            this.lblNoteName.TabIndex = 0;
            this.lblNoteName.Text = "Please connect a keyboard to the recording device";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 179);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Note2Key";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRecordingDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pgbVolume;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNoteName;
    }
}

