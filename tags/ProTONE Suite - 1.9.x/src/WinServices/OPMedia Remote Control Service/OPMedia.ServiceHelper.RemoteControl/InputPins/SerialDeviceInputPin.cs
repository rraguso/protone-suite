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
        protected SerialPort _port = null;
        protected SerialRemoteDeviceDriver _driver = new SerialRemoteDeviceDriver();
        protected bool _isPortConfigured = false;

        public override bool IsConfigurable
        {
            get { return true; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            SerialDeviceInputPinCfgDlg dlg = new SerialDeviceInputPinCfgDlg();

            dlg.PortName = GetConfigurationFromString(initialCfgData, dlg.DeviceConfigurationData);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] cfgFields = new string[]
                { 
                    dlg.PortName,
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
            string portName = GetConfigurationFromString(_cfgData, _driver);
            _port = new SerialPort(portName);
            _isPortConfigured = SerialPortAPI.FillSerialPortSettings(ref _port);
        }

        public static string GetConfigurationFromString(string configString, SerialRemoteDeviceDriver cfgData)
        {
            string[] cfgFields = StringUtils.ToStringArray(configString, SerialRemoteDeviceDriver.Delimiter);
            if (cfgFields == null || cfgFields.Length < 1)
                return string.Empty;

            int i = 0;
            int param;

            string portName = string.Empty;

            if (cfgFields.Length > i)
                portName = cfgFields[i++];

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.InterCodeWordsGap = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MinCodeWordOccurences = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MinCodeWordLength = param;

            if (cfgFields.Length > i && int.TryParse(cfgFields[i++], out param))
                cfgData.MaxCodeWordLength = param;

            return portName;
        }

        protected override void StartInternal()
        {
            Logger.LogInfo("{0}: Starting remote control device on port {1} ...", this.GetType().Name, _port.PortName);

            if (_isPortConfigured)
            {
                _driver.SignalOutput -= new SignalOutputCallbackDelegate(_driver_SignalOutput);
                _driver.SignalOutput += new SignalOutputCallbackDelegate(_driver_SignalOutput);

                _driver.TrainMode = RemoteControlServiceMux.Instance.TrainMode;
                _driver.Start(_port);
            }
            else
            {
                throw new ConfigurationErrorsException(string.Format("{0}: Settings for port {1} could not be retrieved",
                    this.GetType().Name, _port.PortName));
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
                    this.GetType().Name, _port.PortName));
            }
            else
            {
                Logger.LogInfo("{0}: Remote control device on port {1} was stopped succesfully ...", this.GetType().Name, _port.PortName);
                _port = null;
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
