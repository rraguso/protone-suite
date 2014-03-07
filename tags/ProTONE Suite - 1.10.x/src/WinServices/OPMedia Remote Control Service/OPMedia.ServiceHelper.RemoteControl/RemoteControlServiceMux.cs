using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using OPMedia.Core.Logging;
using OPMedia.ServiceHelper.RCCService.InputPins;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using System.Diagnostics;

using System.IO;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using System.Configuration;
using System.Linq;

namespace OPMedia.ServiceHelper.RCCService
{
    public delegate void InputPinProbeHandler(InputPin origin, string request);

    public class RemoteControlServiceMux
    {
        private Dictionary<string, InputPin> _inputPins = null;
        private Dictionary<string, OutputPin> _outputPins = null;
        private RCCServiceConfig _config = new RCCServiceConfig();

        private static RemoteControlServiceMux _instance = null;

        public event InputPinProbeHandler InputPinProbeData = null;

        private bool _trainMode = false;

        /// <summary>
        /// Put the mux in train mode (that is - learn remote control buttons)
        /// </summary>
        public bool TrainMode
        {
            get 
            { 
                return _trainMode; 
            }

            set 
            {
                if (value)
                {
                    // Do we have all preconditions to go in train mode ??

                    if (InputPinProbeData == null)
                    {
                        throw new InvalidOperationException("Error: attempt to set TrainMode to True without a valid InputPinProbeHandler attached to the RemoteControlServiceMux.");
                    }
                   
                }

                _trainMode = value; 
            }
        }

        public static RemoteControlServiceMux Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new RemoteControlServiceMux();
                }

                return _instance; 
            }
        }
        
        private RemoteControlServiceMux()
        {
            string asmPath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(asmPath);
            string cfgPath = Path.Combine(folder, "RCCService.Config");

            Logger.LogInfo("Attempt to read config file from {0} ...", cfgPath);
            _config.ReadXml(cfgPath);
            Logger.LogInfo("Config file read, creating service pins ...");
        }

        public void Start()
        {
            _inputPins = new Dictionary<string, InputPin>();
            _outputPins = new Dictionary<string, OutputPin>();

            // Start input pins
            foreach (RCCServiceConfig.RemoteControlRow row in _config.RemoteControl.Rows)
            {
                try
                {
                    if (!_inputPins.ContainsKey(row.InputPinName + row.InputPinCfgData))
                    {
                        InputPin pin = Pin.CreatePin(this, row.InputPinName, row.InputPinCfgData)
                            as InputPin;
                        _inputPins.Add(row.InputPinName + row.InputPinCfgData, pin);
                    }
                    else
                    {
                        Logger.LogInfo("Input pin: {0} is already configured with same settings: {1}. Skipping ...",
                            row.InputPinName, row.InputPinCfgData);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogInfo("Input pin: {0} could not start up: {1}",
                        row.InputPinName, ex.Message);
                }
            }

            // Start output pins
            foreach (RCCServiceConfig.RemoteControlRow row in _config.RemoteControl.Rows)
            {
                try
                {
                    if (!_outputPins.ContainsKey(row.OutputPinName + row.OutputPinCfgData))
                    {
                        OutputPin pin = Pin.CreatePin(this, row.OutputPinName, row.OutputPinCfgData)
                            as OutputPin;
                        _outputPins.Add(row.OutputPinName + row.OutputPinCfgData, pin);
                    }
                    else
                    {
                        Logger.LogInfo("Output pin: {0} is already configured with same settings: {1}. Skipping ...",
                            row.OutputPinName, row.OutputPinCfgData);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogInfo("Output pin: {0} could not start up: {1}",
                        row.OutputPinName, ex.Message);
                }
            }

            if (_inputPins.Count == 0)
            {
                throw new ConfigurationErrorsException("There are no Input Pins configured.");
            }
            else if (_outputPins.Count == 0)
            {
                throw new ConfigurationErrorsException("There are no Output Pins configured.");
            }
        }

        public void StartSingleInputPin(string inputPinName, string inputPinCfgData)
        {
            _inputPins = new Dictionary<string, InputPin>();
            _outputPins = new Dictionary<string, OutputPin>();

            try
            {
                if (!_inputPins.ContainsKey(inputPinName))
                {
                    InputPin pin = Pin.CreatePin(this, inputPinName, inputPinCfgData)
                        as InputPin;
                    _inputPins.Add(inputPinName + inputPinCfgData, pin);
                }
                else
                {
                    Logger.LogInfo("Input pin: {0} is already configured with same settings: {1}. Skipping ...",
                        inputPinName, inputPinCfgData);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Input pin: {0} could not start up: {1}",
                    inputPinName, ex.Message));
            }
        }

        public void Stop()
        {
            foreach (KeyValuePair<string, InputPin> kvp in _inputPins)
            {
                try
                {
                    kvp.Value.Stop();
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
            }

            foreach (KeyValuePair<string, OutputPin> kvp in _outputPins)
            {
                try
                {
                    kvp.Value.Stop();
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
            }

            _inputPins.Clear();
            _outputPins.Clear();
        }

        public void ProcessRequest(InputPin origin, string request)
        {
            string originName = origin.GetType().Name;
            Logger.LogInfo("Received a remote control command from {0} ... message = {1}", originName, request);

            if (_trainMode)
            {
                Logger.LogInfo("RCC Manager is started. All received commands will be sent to the RCC Manager instead of output pins.");

                // Send command to the RCC Manager
                RaiseInputPinDataEvent(origin, request);
                return;
            }

            foreach (RCCServiceConfig.RemoteControlRow row in _config.RemoteControl.Rows)
            {
                if (row.InputPinName == originName &&
                    row.InputPinCfgData == origin.CfgData)
                {
                    // Have found the origin input pin. 
                    // But is it enabled ?

                    if (row.Enabled)
                    {
                        // See if we have an output to send the command to ...
                        if (_outputPins.ContainsKey(row.OutputPinName + row.OutputPinCfgData))
                        {
                            // There is a valid output pin.

                            // If the destination is ProTONE Player ... is this configured to be controlled remotely ?
                            if (row.OutputPinName == typeof(ProTONEOutputPin).Name && !ProTONERemoteConfig.EnableRemoteControl)
                            {
                                // ProTONE player can't accept remoting comands.
                                // so discard the command
                                Logger.LogInfo("ProTONE has EnableRemoteControl set to False. Discarding command.");
                                return;
                            }

                            // No restrictions.
                            OutputPin destination = _outputPins[row.OutputPinName + row.OutputPinCfgData];
                            if (destination != null)
                            {
                                string destName = destination.GetType().Name;
                                string translatedRequest = TranslateToOutputPinFormat(row.RemoteName, request);

                                if (!string.IsNullOrEmpty(translatedRequest))
                                {
                                    Logger.LogInfo("Sending message {0} to {1} as result of message {2} from {3}",
                                        translatedRequest.ToString(), row.OutputPinName,
                                        request.ToString(), originName);

                                    destination.SendRequest(translatedRequest);
                                }

                                return;
                            }
                        }
                    }
                    else
                    {
                        Logger.LogInfo("Although an input pin was found, can't dispatch command. The origin remote control: {0} seems to be disabled.",
                            row.RemoteName);
                        return;
                    }

                    // No chance for a valid output pin ...
                    break;
                }
            }

            Logger.LogInfo("There is no valid output pin connected to input pin {0}. Check the service configuration ...", originName);
        }

        private string TranslateFromOutputPinFormat(string remoteName, string response)
        {
            return response;
        }

        private string TranslateToOutputPinFormat(string remoteName, string request)
        {
            string trans = string.Empty;

            RCCServiceConfig.RemoteControlRow remote = _config.RemoteControl.FindByRemoteName(remoteName);

            if (remote != null && remote.Enabled)
            {
                if (remote.InputPinName == typeof(RemotingInputPin).Name &&
                    remote.OutputPinName == typeof(ProTONEOutputPin).Name)
                {
                    return request;
                }

                var rows = from btn in _config.RemoteButtons
                           where (btn.Enabled && btn.RemoteName == remoteName && btn.InputData == request.ToString())
                           select btn;

                if (rows != null && rows.Count() > 0)
                {
                    RCCServiceConfig.RemoteButtonsRow btn = rows.First();

                    if (TimedButtonProcessing.CanProcessData(remoteName, btn.TimedRepeatRate, request.ToString()))
                    {
                        Pin p = Pin.FindPinByName(remote.OutputPinName);
                        if (p != null && p is OutputPin)
                        {
                            trans = (p as OutputPin).TranslateToOutputPinFormat(request.ToString(), btn);
                        }
                    }
                    else
                    {
                        if (btn.TimedRepeatRate > 0)
                        {
                            Logger.LogInfo("Can't dispatch command. Must wait {0} seconds before processing this data again: {1}",
                                rows.First().TimedRepeatRate, request);
                        }
                        else
                        {
                            Logger.LogInfo("Can't dispatch command. This data is to be only processed once: {0}",
                                request);
                        }
                    }
                }
                else
                {
                    Logger.LogInfo("Can't dispatch command. Either there are no buttons defined for this data: {0} or they are disabled.",
                        request);
                }
            }
            else
            {
                Logger.LogInfo("Can't dispatch command. The origin remote control: {0} seems to be disabled.",
                    remoteName);
            }

            return trans;
        }

        private void RaiseInputPinDataEvent(InputPin origin, string request)
        {
            if (InputPinProbeData != null)
            {
                InputPinProbeData(origin, request);
            }
        }
    }

    internal class TimedButtonProcessing
    {
        static Dictionary<string, TimedButtonProcessing> _processedButtons =
            new Dictionary<string, TimedButtonProcessing>();

        public readonly string InputData;
        public readonly DateTime creationTime;

        const int MaxWaitTime = 15;

        private TimedButtonProcessing(string inputData)
        {
            InputData = inputData;
            creationTime = DateTime.Now;
        }

        private bool IsExpired(int secondsToWait)
        {
            TimeSpan diff = DateTime.Now.Subtract(creationTime);

            if (secondsToWait == 0)
            {
                return (diff.TotalSeconds >= MaxWaitTime);
            }
            else
            {
                return (diff.TotalSeconds >= secondsToWait);
            }
        }

        public static bool CanProcessData(string remoteName, int secondsToWait, string inputData)
        {
            bool retVal = true;

            if (_processedButtons.ContainsKey(remoteName))
            {
                TimedButtonProcessing lastButton = _processedButtons[remoteName];
                if (inputData == lastButton.InputData)
                {
                    retVal = lastButton.IsExpired(secondsToWait);
                }
            }

            if (retVal)
            {
                RegisterProcessedData(remoteName, inputData);
            }

            return retVal;
        }

        private static void RegisterProcessedData(string remoteName, string inputData)
        {
            if (_processedButtons.ContainsKey(remoteName))
            {
                _processedButtons[remoteName] = new TimedButtonProcessing(inputData);
            }
            else
            {
                _processedButtons.Add(remoteName, new TimedButtonProcessing(inputData));
            }
        }
    }
}
