using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.Core.TranslationSupport;
using OPMedia.ServiceHelper.RCCService.InputPins;

using OPMedia.UI.Controls;
using System.IO.Ports;

namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    public partial class SerialDeviceCfgPanel : OPMBaseControl
    {
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMLabel opmLabel1;
        private OPMPropertyGrid pgDeviceSettings;
        private OPMButton btnDetect;
        protected SerialRemoteDeviceDriver cfgData = new SerialRemoteDeviceDriver();

        public event EventHandler StartDetection = null;

        public SerialRemoteDeviceDriver DeviceConfigurationData
        {
            get { return cfgData; }
            set { cfgData = value; }
        }

        public SerialDeviceCfgPanel()
            : base()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(SerialDeviceCfgPanel_Load);
        }

        void SerialDeviceCfgPanel_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            pgDeviceSettings.SelectedObject = cfgData;
        }

        private void InitializeComponent()
        {
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.pgDeviceSettings = new OPMedia.UI.Controls.OPMPropertyGrid();
            this.btnDetect = new OPMedia.UI.Controls.OPMButton();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.pgDeviceSettings, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.btnDetect, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(250, 120);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(154, 26);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "TXT_REMOTE_DEVICE_SETTINGS";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgDeviceSettings
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.pgDeviceSettings, 2);
            this.pgDeviceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgDeviceSettings.HelpVisible = false;
            this.pgDeviceSettings.Location = new System.Drawing.Point(3, 29);
            this.pgDeviceSettings.Name = "pgDeviceSettings";
            this.pgDeviceSettings.Size = new System.Drawing.Size(244, 88);
            this.pgDeviceSettings.TabIndex = 1;
            this.pgDeviceSettings.ToolbarVisible = false;
            // 
            // btnDetect
            // 
            this.btnDetect.AutoSize = true;
            this.btnDetect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetect.Location = new System.Drawing.Point(173, 0);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDetect.MaximumSize = new System.Drawing.Size(80, 20);
            this.btnDetect.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDetect.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDetect.Size = new System.Drawing.Size(77, 20);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "TXT_DETECT";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // SerialDeviceCfgPanel
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(250, 120);
            this.Name = "SerialDeviceCfgPanel";
            this.Size = new System.Drawing.Size(250, 120);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (StartDetection != null)
            {
                StartDetection(sender, e);
            }
        }
    }
}

