using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using OPMedia.Core.Logging;
using OPMedia.Core;

using OPMedia.Runtime.ServiceHelpers;
using System.Windows.Forms;
using OPMedia.UI;
using OPMedia.UI.ProTONE;
using OPMedia.UI.Configuration;
using System.ComponentModel;
using OPMedia.Runtime;
using OPMedia.UI.ProTONE.Configuration;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.ServiceHelper.RCCService.Configuration;
using OPMedia.Core.Utilities;
using System.Configuration;

namespace OPMedia.ServiceHelper.RCCService.InputPins
{
    public class SerialDeviceInputPin : InputPin
    {
        protected string _comPortName = null;
        protected SerialRemoteDeviceDriver _driver = new SerialRemoteDeviceDriver();
        protected bool _isPortConfigured = false;

        public override bool IsConfigurable
        {
            get { return true; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            SerialDeviceCfgDlg dlg = new SerialDeviceCfgDlg();

            bool cfgValid = ParseConfigurationString(initialCfgData, dlg.DeviceConfigurationData);

            if (cfgValid && dlg.ShowDialog() == DialogResult.OK)
            {
                string[] cfgFields = new string[]
                { 
                    dlg.DeviceConfigurationData.ComPortName,
                    dlg.DeviceConfigurationData.InterCodeWordsGap.ToString(),
                    dlg.DeviceConfigurationData.MinCodeWordOccurences.ToString(),
                    dlg.DeviceConfigurationData.MinCodeWordLength.ToString(),
                    dlg.DeviceConfigurationData.MaxCodeWordLength.ToString()
                };

                return StringUtils.FromStringArray(cfgFields, SerialRemoteDeviceDriver.Delimiter);
            }

            return null;
        }

        protected override void ConfigureInternal()
        {
            _isPortConfigured = ParseConfigurationString(_cfgData, _driver);
        }

        public static bool ParseConfigurationString(string configString, SerialRemoteDeviceDriver cfgData)
        {
            string[] cfgFields = StringUtils.ToStringArray(configString, SerialRemoteDeviceDriver.Delimiter);
            if (cfgFields == null || cfgFields.Length < 1)
                return false;

            int i = 0;
            int param;

            string portName = string.Empty;

            if (cfgFields.Length > i)
                cfgData.ComPortName = cfgFields[i++];

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.InterCodeWordsGap = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MinCodeWordOccurences = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MinCodeWordLength = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MaxCodeWordLength = param;

            return true;
        }

        protected override void StartInternal()
        {
            Logger.LogInfo("{0}: Starting remote control device on port {1} ...", this.GetType().Name, _driver.ComPortName);

            if (_isPortConfigured)
            {
                _driver.SignalOutput -= new SignalOutputCallbackDelegate(_driver_SignalOutput);
                _driver.SignalOutput += new SignalOutputCallbackDelegate(_driver_SignalOutput);

                _driver.TrainMode = RemoteControlServiceMux.Instance.TrainMode;
                _driver.Start();
            }
            else
            {
                throw new ConfigurationErrorsException(string.Format("{0}: Settings for port {1} could not be retrieved",
                    this.GetType().Name, _driver.ComPortName));
            }
        }

        protected override void StopInternal()
        {
            if (_isPortConfigured && _driver.Running)
            {
                _driver.SignalOutput -= new SignalOutputCallbackDelegate(_driver_SignalOutput);
                _driver.Stop();
            }

            int i = 0;
            do
            {
                i++;
                Thread.Sleep(200);
            }
            while (_driver.Running && i < 10);

            if (_driver.Running)
            {
                throw new TimeoutException(string.Format("{0}: Could not stop remote control device on port {1} in a timely fashion",
                    this.GetType().Name, _driver.ComPortName));
            }
            else
            {
                Logger.LogInfo("{0}: Remote control device on port {1} was stopped succesfully ...", this.GetType().Name, 
                    _driver.ComPortName);
            }
        }

        void _driver_SignalOutput(long counter, double erfc)
        {
            if (counter != long.MaxValue)
            {
                RemoteControlServiceMux.Instance.ProcessRequest(this, counter.ToString("x"));
            }
        }
    }
}
