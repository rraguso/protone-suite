using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.ServiceHelper.RCCService.InputPins;

using System.Configuration;

namespace OPMedia.ServiceHelper.RCCService
{
    public abstract class Pin
    {
        static readonly Dictionary<string, Type> _inputPinsTable = null;
        static readonly Dictionary<string, Type> _outputPinsTable = null;

        protected string _cfgData = string.Empty;

        public abstract bool IsConfigurable { get; }

        public string CfgData
        { get  { return _cfgData; } }

        public static Dictionary<string, Type>  AvailableInputPins
        { get { return _inputPinsTable; } }

        public static Dictionary<string, Type>  AvailableOutputPins
        { get { return _outputPinsTable; } }

        static Pin()
        {
            _inputPinsTable = new Dictionary<string, Type>();
            _inputPinsTable.Add(typeof(SerialDeviceInputPin).Name, typeof(SerialDeviceInputPin));
            _inputPinsTable.Add(typeof(RemotingInputPin).Name, typeof(RemotingInputPin));

            _outputPinsTable = new Dictionary<string, Type>();
            _outputPinsTable.Add(typeof(ProTONEOutputPin).Name, typeof(ProTONEOutputPin));
            _outputPinsTable.Add(typeof(LircOutputPin).Name, typeof(LircOutputPin));
            _outputPinsTable.Add(typeof(HotkeyOutputPin).Name, typeof(HotkeyOutputPin));
        }

        public static bool IsPinConfigurable(string name)
        {
            bool retVal = false;
            
            Pin pin = FindPinByName(name);
            if (pin != null)
            {
                retVal = pin.IsConfigurable;
                
                pin = null;
                GC.Collect();
            }

            return retVal;
        }

        public static Pin FindPinByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (_inputPinsTable.ContainsKey(name))
                {
                    return Activator.CreateInstance(_inputPinsTable[name]) as Pin;
                }
                else if (_outputPinsTable.ContainsKey(name))
                {
                    return Activator.CreateInstance(_outputPinsTable[name]) as Pin;
                }
            }

            return null;
        }

        public static Pin CreatePin(RemoteControlServiceMux mux, string name, string cfgData)
        {
            Pin pin = FindPinByName(name);
            if (pin != null)
            {
                pin.ConfigureAndStart(cfgData);
                return pin;
            }

            throw new ConfigurationErrorsException(string.Format("The pin: {0} does not exist.", name));
        }

        public void Stop()
        {
            StopInternal();
            GC.Collect();
        }

        public string GetConfigData(string initialCfgData)
        {
            return GetConfigDataInternal(initialCfgData);
        }

        private void ConfigureAndStart(string cfgData)
        {
            _cfgData = cfgData;
            ConfigureInternal();
            Start();
        }

        private void Start()
        {
            try
            {
                StartInternal();
            }
            catch (Exception ex)
            {
                Stop();
                throw ex;
            }
        }

        protected abstract string GetConfigDataInternal(string initialCfgData);
        protected abstract void StartInternal();
        protected abstract void StopInternal();
        protected abstract void ConfigureInternal();
    }

    public abstract class InputPin : Pin
    {
    }

    public abstract class OutputPin : Pin
    {
        public virtual string TranslateToOutputPinFormat(string data, RCCServiceConfig.RemoteButtonsRow button)
        {
            return data;
        }

        public void SendRequest(string request)
        {
            SendRequestInternal(request);
        }

        protected abstract void SendRequestInternal(string request);
    }
}
