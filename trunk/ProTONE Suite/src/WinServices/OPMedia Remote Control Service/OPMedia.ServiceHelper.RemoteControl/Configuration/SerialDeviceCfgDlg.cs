using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.ServiceHelper.RCCService.InputPins;
using System.IO.Ports;
using OPMedia.Core;
using OPMedia.UI.Controls;
using OPMedia.UI.Configuration;


namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    public class SerialDeviceCfgDlg : ToolForm
    {
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMLabel opmLabel1;
        private OPMPropertyGrid pgDeviceSettings;
        private OPMButton btnDetect;
        protected OPMLabel label1;
        private OPMButton btnOK;
        private OPMButton btnCancel;
        protected OPMComboBox cmbSerialPort;

        public SerialRemoteDeviceDriver DeviceConfigurationData { get; private set; }
        
        public SerialDeviceCfgDlg()
            : base()
        {
            SetTitle("TXT_SERIAL_DEVICE_CFG");
            InitializeComponent();

            this.DeviceConfigurationData = new SerialRemoteDeviceDriver();

            this.Load += new EventHandler(SerialDeviceInputPinCfgDlg_Load);
        }

        void SerialDeviceInputPinCfgDlg_Load(object sender, EventArgs e)
        {
            cmbSerialPort.SelectedIndexChanged += (ss, ee) =>
            {
                this.DeviceConfigurationData.ComPortName = cmbSerialPort.Text;
            };

            Reload();
        }

        private void Reload()
        {
            cmbSerialPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                cmbSerialPort.Items.AddRange(ports);
                cmbSerialPort.SelectedIndex = cmbSerialPort.FindStringExact(this.DeviceConfigurationData.ComPortName);
            }

            pgDeviceSettings.SelectedObject = this.DeviceConfigurationData;
        }

        private void InitializeComponent()
        {
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pgDeviceSettings = new OPMedia.UI.Controls.OPMPropertyGrid();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.cmbSerialPort = new OPMedia.UI.Controls.OPMComboBox();
            this.btnDetect = new OPMedia.UI.Controls.OPMButton();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmLabel1, 2);
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 34);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(209, 26);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "TXT_REMOTE_DEVICE_SETTINGS";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.pgDeviceSettings, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 1, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 2, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbSerialPort, 2, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.btnDetect, 2, 2);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 6;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(301, 205);
            this.opmTableLayoutPanel1.TabIndex = 9;
            // 
            // pgDeviceSettings
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.pgDeviceSettings, 3);
            this.pgDeviceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgDeviceSettings.HelpVisible = false;
            this.pgDeviceSettings.Location = new System.Drawing.Point(3, 63);
            this.pgDeviceSettings.Name = "pgDeviceSettings";
            this.pgDeviceSettings.Size = new System.Drawing.Size(295, 103);
            this.pgDeviceSettings.TabIndex = 1;
            this.pgDeviceSettings.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(209, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "TXT_SERIAL_PORT_NAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(157, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.ShowDropDown = false;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(218, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSerialPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(218, 3);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbSerialPort.Size = new System.Drawing.Size(80, 23);
            this.cmbSerialPort.TabIndex = 4;
            // 
            // btnDetect
            // 
            this.btnDetect.AutoSize = true;
            this.btnDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetect.Location = new System.Drawing.Point(218, 37);
            this.btnDetect.MaximumSize = new System.Drawing.Size(80, 20);
            this.btnDetect.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDetect.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDetect.ShowDropDown = false;
            this.btnDetect.Size = new System.Drawing.Size(80, 20);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "TXT_DETECT";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // SerialDeviceInputPinCfgDlg
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(303, 228);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "SerialDeviceInputPinCfgDlg";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            SerialRemoteDeviceDriver driver = this.DeviceConfigurationData.Clone();
            SerialDeviceTuningDlg dlg = new SerialDeviceTuningDlg(driver);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.DeviceConfigurationData = driver;
                Reload();
            }
        }
    }
}