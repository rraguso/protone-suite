using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.ServiceHelper.RCCService.InputPins;
using System.IO.Ports;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    public partial class SerialDeviceTuningDlg : ThemeForm
    {
        protected SerialPort _port = null;
        protected SerialRemoteDeviceDriver _cfgData = null;

        public SerialRemoteDeviceDriver DeviceConfigurationData
        {
            get { return _cfgData; }
            set { _cfgData = value; }
        }

        public SerialDeviceTuningDlg(SerialPort port, SerialRemoteDeviceDriver cfgData)
        {
            _cfgData = cfgData;
            _port = port;

            InitializeComponent();

            this.Load += new EventHandler(RemoteControlFineTuningDlg_Load);
            this.HandleDestroyed += new EventHandler(RemoteControlFineTuningDlg_HandleDestroyed);
        }

        void RemoteControlFineTuningDlg_HandleDestroyed(object sender, EventArgs e)
        {
            _cfgData.Stop();
        }

        void RemoteControlFineTuningDlg_Load(object sender, EventArgs e)
        {
            base.SetTitle(Translator.TranslateTaggedString("TXT_SERIALDEVICE - " + _port.PortName));

            _cfgData.SignalOutput -=
                new SignalOutputCallbackDelegate(cfgData_SignalOutput);
            _cfgData.SignalOutput +=
                new SignalOutputCallbackDelegate(cfgData_SignalOutput);

            _cfgData.TrainMode = true;
            _cfgData.Start(_port);

            Reload();
            cfgData_SignalOutput(long.MaxValue, 1.0f /* max erfc */);
        }

        void cfgData_SignalOutput(long counter, double erfc)
        {
            lblDetCW.Text = Translator.Translate("TXT_DETECTEDCODEWORD", counter);
            lblERFC.Text = Translator.Translate("TXT_ERRORFACTOR", 10 * Math.Log10(erfc));

            btnOk.Enabled = (erfc < 0.25f);
        }

        private void btnICWGPlus_Click(object sender, EventArgs e)
        {
            _cfgData.InterCodeWordsGap += 10; Reload();
        }

        private void btnICWGMinus_Click(object sender, EventArgs e)
        {
            _cfgData.InterCodeWordsGap -= 10; Reload();
        }

        private void btnMinCWPlus_Click(object sender, EventArgs e)
        {
            _cfgData.MinCodeWordLength += 1; Reload();
        }

        private void btnMinCWMinus_Click(object sender, EventArgs e)
        {
            _cfgData.MinCodeWordLength -= 1; Reload();
        }

        private void btnMaxCWPlus_Click(object sender, EventArgs e)
        {
            _cfgData.MaxCodeWordLength += 1; Reload();
        }

        private void btnMaxCWMinus_Click(object sender, EventArgs e)
        {
            _cfgData.MaxCodeWordLength -= 1; Reload();
        }

        private void btnMinCWOccPlus_Click(object sender, EventArgs e)
        {
            _cfgData.MinCodeWordOccurences += 1; Reload();
        }

        private void btnMinCWOccMinus_Click(object sender, EventArgs e)
        {
            _cfgData.MinCodeWordOccurences -= 1; Reload();
        }

        private void OnDataChanged(double val)
        {
            _cfgData.InterCodeWordsGap = (long)cgICWG.Value;
            _cfgData.MinCodeWordLength = (long)cgMinCW.Value;
            _cfgData.MaxCodeWordLength = (long)cgMaxCW.Value;
            _cfgData.MinCodeWordOccurences = (int)cgMinCWOcc.Value;

            Reload();
        }

        private void Reload()
        {
            lblDesc.Text = _cfgData.ToString();

            cgICWG.Value = _cfgData.InterCodeWordsGap;
            cgMinCW.Value = _cfgData.MinCodeWordLength;
            cgMaxCW.Value = _cfgData.MaxCodeWordLength;
            cgMinCWOcc.Value = _cfgData.MinCodeWordOccurences;
        }
    }
}
