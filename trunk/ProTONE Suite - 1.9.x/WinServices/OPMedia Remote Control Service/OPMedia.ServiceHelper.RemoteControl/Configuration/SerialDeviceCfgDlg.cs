using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Configuration;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.ServiceHelper.RCCService.InputPins;
using System.IO.Ports;
using OPMedia.Core;
using OPMedia.UI.Controls;
using OPMedia.UI.Configuration;


namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    public class SerialDeviceInputPinCfgDlg : SerialPortCfgDlg
    {
        private SerialDeviceCfgPanel cfgDeviceSettingsPanel;

        public SerialRemoteDeviceDriver DeviceConfigurationData
        {
            get { return cfgDeviceSettingsPanel.DeviceConfigurationData; }
            set { cfgDeviceSettingsPanel.DeviceConfigurationData = value; }
        }
        
        public SerialDeviceInputPinCfgDlg()
            : base()
        {
            SetTitle("TXT_SERIAL_DEVICE_CFG");
            InitializeComponent();

            this.pnlExtension.Visible = true;
            this.pnlExtension.Controls.Add(cfgDeviceSettingsPanel);
            this.PerformLayout();

            cfgDeviceSettingsPanel.StartDetection += new EventHandler(cfgDeviceSettingsPanel_StartDetection);

            this.FormClosed += new FormClosedEventHandler(SerialDeviceInputPinCfgDlg_FormClosed);
        }

        void SerialDeviceInputPinCfgDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing &&
                this.DialogResult == DialogResult.OK)
            {
                cfgPanel.SaveSettings();
            }
        }

        void cfgDeviceSettingsPanel_StartDetection(object sender, EventArgs e)
        {
            // Save serial port data
            cfgPanel.SaveSettings();

            // Retrieve serial port
            SerialPort port = new SerialPort(cfgPanel.PortName);
            if (SerialPortAPI.FillSerialPortSettings(ref port))
            {
                SerialRemoteDeviceDriver driver = cfgDeviceSettingsPanel.DeviceConfigurationData.Clone();

                SerialDeviceTuningDlg dlg = new SerialDeviceTuningDlg(port, driver);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    cfgDeviceSettingsPanel.DeviceConfigurationData = driver;
                    cfgDeviceSettingsPanel.Reload();
                }
            }
        }

        private void InitializeComponent()
        {
            OPMedia.ServiceHelper.RCCService.InputPins.SerialRemoteDeviceDriver serialRemoteDeviceDriver1 = new OPMedia.ServiceHelper.RCCService.InputPins.SerialRemoteDeviceDriver();
            this.cfgDeviceSettingsPanel = new OPMedia.ServiceHelper.RCCService.Configuration.SerialDeviceCfgPanel();
            this.SuspendLayout();
            // 
            // cfgDeviceSettingsPanel
            // 
            serialRemoteDeviceDriver1.TrainMode = true;
            this.cfgDeviceSettingsPanel.DeviceConfigurationData = serialRemoteDeviceDriver1;
            this.cfgDeviceSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgDeviceSettingsPanel.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cfgDeviceSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.cfgDeviceSettingsPanel.MinimumSize = new System.Drawing.Size(250, 120);
            this.cfgDeviceSettingsPanel.Name = "cfgDeviceSettingsPanel";
            this.cfgDeviceSettingsPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.cfgDeviceSettingsPanel.Size = new System.Drawing.Size(253, 120);
            this.cfgDeviceSettingsPanel.TabIndex = 0;
            // 
            // SerialDeviceInputPinCfgDlg
            // 
            this.ClientSize = new System.Drawing.Size(263, 423);
            this.Name = "SerialDeviceInputPinCfgDlg";
            this.ResumeLayout(false);

        }
    }
}