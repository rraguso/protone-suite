using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.ServiceHelper.RCCService;
using OPMedia.Runtime.Remoting;

namespace OPMedia.RCCManager.InputData
{
    public class InputPinProbe
    {
        string _inputPinName = null;

        public event InputPinProbeHandler InputPinData = null;

        public InputPinProbe(string inputPinName, string inputPinCfgData)
        {
            _inputPinName = inputPinName;

            // Configure the mux to send data to the InputPinProbe instead of output pins.
            RemoteControlServiceMux.Instance.InputPinProbeData += new InputPinProbeHandler(OnInputPinProbeData);
            RemoteControlServiceMux.Instance.StartSingleInputPin(inputPinName, inputPinCfgData);

            // Put the mux in train mode (that is - learn remote control buttons)
            RemoteControlServiceMux.Instance.TrainMode = true; 
        }

        public void Stop()
        {
            RemoteControlServiceMux.Instance.Stop();
        }

        void OnInputPinProbeData(InputPin origin, SerializableObject request)
        {
            if (origin.GetType().Name == _inputPinName && InputPinData != null)
            {
                InputPinData(origin, request);
            }
        }
    }
}
