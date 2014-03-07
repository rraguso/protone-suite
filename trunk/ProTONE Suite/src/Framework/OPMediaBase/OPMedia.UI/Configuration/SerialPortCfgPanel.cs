using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using OPMedia.Core;
using OPMedia.UI.Controls;

namespace OPMedia.UI.Configuration
{
    public partial class SerialPortCfgPanel : OPMBaseControl
    {
        string _portName = "COM1";
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public event EventHandler SettingsChanged = null;

        public SerialPortCfgPanel()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(SerialPortCfgPanel_Load);
        }

        void SerialPortCfgPanel_Load(object sender, EventArgs e)
        {
            cmbSerialPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                cmbSerialPort.Items.AddRange(ports);
                cmbSerialPort.SelectedIndex = cmbSerialPort.FindStringExact(_portName);

                DisplayComPortDetails();
            }

            cmbSerialPort.SelectedIndexChanged += new System.EventHandler(this.cmbSerialPort_SelectedIndexChanged);
        }

        void DisplayComPortDetails()
        {
            string portName = cmbSerialPort.Text;

            if (portName.StartsWith("COM"))
            {
                SerialPort port = new SerialPortCfg(portName);
                SerialPortAPI.FillSerialPortSettings(ref port);
                pgComSettings.SelectedObject = port;
            }
        }

        private void cmbSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayComPortDetails();
            RaiseSettingsChanged();
        }

        public virtual void SaveSettings()
        {
            SerialPort port = pgComSettings.SelectedObject as SerialPort;
            if (port != null)
            {
                _portName = cmbSerialPort.Text;
                SerialPortAPI.SavePortSettings(port);
            }
        }

        public void RaiseSettingsChanged()
        {
            if (SettingsChanged != null)
            {
                SettingsChanged(this, null);
            }
        }

        private void pgComSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            RaiseSettingsChanged();
        }
    }

    #region SerialPortCfg
    public class SerialPortCfg : SerialPort
    {
        public SerialPortCfg(string name)
            : base(name)
        {
            // Apply default values
            base.RtsEnable = true;
            base.ReadTimeout = 500;
            base.WriteTimeout = 500;
        }

        [Browsable(false)]
        public new string PortName
        {
            get { return base.PortName; }
        }


        [Browsable(false)]
        public new bool DiscardNull
        {
            get { return base.DiscardNull; }
        }

        [Browsable(false)]
        public new byte ParityReplace
        {
            get { return base.ParityReplace; }
        }

        [Browsable(false)]
        public new int ReadBufferSize
        {
            get { return base.ReadBufferSize; }
        }

        [Browsable(false)]
        public new int WriteBufferSize
        {
            get { return base.WriteBufferSize; }
        }

        [Browsable(true)]
        [DefaultValue(500)]
        [DisplayName("ReadTimeout (msec)")]
        public new int ReadTimeout
        {
            get { return base.ReadTimeout; }
            set { base.ReadTimeout = value; }
        }

        [Browsable(true)]
        [DefaultValue(500)]
        [DisplayName("WriteTimeout (msec)")]
        public new int WriteTimeout
        {
            get { return base.WriteTimeout; }
            set { base.WriteTimeout = value; }
        }

        [DefaultValue(true)]
        public new bool RtsEnable
        {
            get { return base.RtsEnable; }
            set { base.RtsEnable = value; }
        }
    }
    #endregion
}
