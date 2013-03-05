using OPMedia.UI.Controls;

namespace OPMedia.UI.Configuration
{
    partial class LoggingSettingsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkLogEnabled = new OPMedia.UI.Controls.OPMCheckBox();
            this.groupBox1 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.chkTrace = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkInfo = new OPMedia.UI.Controls.OPMCheckBox();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.chkWarning = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkError = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkHeavyTrace = new OPMedia.UI.Controls.OPMCheckBox();
            this.txtLogPath = new OPMedia.UI.Controls.OPMTextBox();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.lblViewLog = new OPMedia.UI.Controls.OPMLinkLabel();
            this.btnChange = new OPMedia.UI.Controls.OPMButton();
            this.nudDaysToKeepLogs = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.groupBox1.SuspendLayout();
            this.opmLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysToKeepLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLogEnabled
            // 
            this.chkLogEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLogEnabled.AutoSize = true;
            this.chkLogEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLogEnabled.Location = new System.Drawing.Point(15, 0);
            this.chkLogEnabled.Name = "chkLogEnabled";
            this.chkLogEnabled.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkLogEnabled.Size = new System.Drawing.Size(110, 17);
            this.chkLogEnabled.TabIndex = 0;
            this.chkLogEnabled.Text = "TXT_ENABLE_LOG";
            this.chkLogEnabled.CheckedChanged += new System.EventHandler(this.chkLogEnabled_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opmLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "                                   .";
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 3;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.Controls.Add(this.chkTrace, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.chkInfo, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.label2, 0, 7);
            this.opmLayoutPanel1.Controls.Add(this.chkWarning, 0, 2);
            this.opmLayoutPanel1.Controls.Add(this.chkError, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.chkHeavyTrace, 0, 4);
            this.opmLayoutPanel1.Controls.Add(this.txtLogPath, 0, 6);
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 5);
            this.opmLayoutPanel1.Controls.Add(this.lblViewLog, 0, 9);
            this.opmLayoutPanel1.Controls.Add(this.btnChange, 2, 6);
            this.opmLayoutPanel1.Controls.Add(this.nudDaysToKeepLogs, 1, 7);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 10;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(357, 306);
            this.opmLayoutPanel1.TabIndex = 0;
            // 
            // chkTrace
            // 
            this.chkTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTrace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTrace.Location = new System.Drawing.Point(3, 3);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkTrace.Size = new System.Drawing.Size(311, 19);
            this.chkTrace.TabIndex = 0;
            this.chkTrace.Text = "TXT_TRACE";
            this.chkTrace.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkInfo
            // 
            this.chkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInfo.Location = new System.Drawing.Point(3, 28);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkInfo.Size = new System.Drawing.Size(311, 19);
            this.chkInfo.TabIndex = 1;
            this.chkInfo.Text = "TXT_INFO";
            this.chkInfo.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(209, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "TXT_LOG_KEEPDAYS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkWarning
            // 
            this.chkWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkWarning.Location = new System.Drawing.Point(3, 53);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkWarning.Size = new System.Drawing.Size(311, 19);
            this.chkWarning.TabIndex = 2;
            this.chkWarning.Text = "TXT_WARNING";
            this.chkWarning.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkError
            // 
            this.chkError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkError.Location = new System.Drawing.Point(3, 78);
            this.chkError.Name = "chkError";
            this.chkError.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkError.Size = new System.Drawing.Size(311, 19);
            this.chkError.TabIndex = 3;
            this.chkError.Text = "TXT_ERRORS";
            this.chkError.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // chkHeavyTrace
            // 
            this.chkHeavyTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHeavyTrace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeavyTrace.Location = new System.Drawing.Point(3, 103);
            this.chkHeavyTrace.Name = "chkHeavyTrace";
            this.chkHeavyTrace.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkHeavyTrace.Size = new System.Drawing.Size(311, 19);
            this.chkHeavyTrace.TabIndex = 4;
            this.chkHeavyTrace.Text = "TXT_HEAVY_TRACE";
            this.chkHeavyTrace.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // txtLogPath
            // 
            this.txtLogPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.opmLayoutPanel1.SetColumnSpan(this.txtLogPath, 2);
            this.txtLogPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogPath.Location = new System.Drawing.Point(3, 150);
            this.txtLogPath.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtLogPath.MaxLength = 50;
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(334, 22);
            this.txtLogPath.TabIndex = 6;
            this.txtLogPath.TextChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(311, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "TXT_LOG_PATH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblViewLog
            // 
            this.lblViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblViewLog.Location = new System.Drawing.Point(3, 287);
            this.lblViewLog.Name = "lblViewLog";
            this.lblViewLog.Size = new System.Drawing.Size(311, 19);
            this.lblViewLog.TabIndex = 10;
            this.lblViewLog.TabStop = true;
            this.lblViewLog.Text = "TXT_SHOWLOG";
            this.lblViewLog.Click += new System.EventHandler(this.lblViewLog_LinkClicked);
            // 
            // btnChange
            // 
            this.btnChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(337, 150);
            this.btnChange.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnChange.Name = "btnChange";
            this.btnChange.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnChange.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnChange.Size = new System.Drawing.Size(17, 22);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "...";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // nudDaysToKeepLogs
            // 
            this.opmLayoutPanel1.SetColumnSpan(this.nudDaysToKeepLogs, 2);
            this.nudDaysToKeepLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudDaysToKeepLogs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nudDaysToKeepLogs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nudDaysToKeepLogs.Location = new System.Drawing.Point(320, 178);
            this.nudDaysToKeepLogs.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDaysToKeepLogs.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDaysToKeepLogs.Name = "nudDaysToKeepLogs";
            this.nudDaysToKeepLogs.ReadOnly = true;
            this.nudDaysToKeepLogs.Size = new System.Drawing.Size(34, 22);
            this.nudDaysToKeepLogs.TabIndex = 9;
            this.nudDaysToKeepLogs.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDaysToKeepLogs.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // LoggingSettingsPanel
            // 
            this.Controls.Add(this.chkLogEnabled);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoggingSettingsPanel";
            this.Size = new System.Drawing.Size(361, 329);
            this.groupBox1.ResumeLayout(false);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysToKeepLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMCheckBox chkLogEnabled;
        private OPMGroupBox groupBox1;
        private OPMCheckBox chkError;
        private OPMCheckBox chkWarning;
        private OPMCheckBox chkInfo;
        private OPMCheckBox chkTrace;
        private OPMCheckBox chkHeavyTrace;
        private OPMButton btnChange;
        private OPMLabel label1;
        private OPMTextBox txtLogPath;
        private OPMLabel label2;
        private OPMNumericUpDown nudDaysToKeepLogs;
        private OPMLinkLabel lblViewLog;
        private OPMTableLayoutPanel opmLayoutPanel1;





    }
}
