using System;
using System.Collections.Generic;
using System.Text;

using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.Core.Logging;
using OPMedia.Core;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime;
using OPMedia.Core.GlobalEvents;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime.InterProcessCommunication;

namespace OPMedia.ServiceHelper.RCCService.InputPins
{
    public class EmulatorInputPin : InputPin
    {
        IPCRemoteControlHost _service = null;

        public override bool IsConfigurable
        {
            get { return true; }
        }

        public override bool IsEmulatorPin
        {
            get { return true; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            return null;
        }

        public EmulatorInputPin()
        {
            Logger.LogInfo("EmulatorInputPin was created ...");
        }

        void _service_OnPostRequest(string request)
        {
            try
            {
                RemoteControlServiceMux.Instance.ProcessRequest(this, request);
            }
            catch
            {
            }
        }

        protected override void ConfigureInternal()
        {
            // Nothing to configure. This pin works with standard settings.
            // See StartInternal.
        }

        protected override void StartInternal()
        {
            Logger.LogInfo("EmulatorInputPin is starting ...");

            _service = new IPCRemoteControlHost("EmulatorInputPin");
            _service.OnPostRequest += new OnPostRequestHandler(_service_OnPostRequest);
            
            Logger.LogInfo("EmulatorInputPin has started succesfully ...");
        }

        protected override void StopInternal()
        {
            Logger.LogInfo("EmulatorInputPin is stopping ...");

            _service.StopInternal();
            _service.OnPostRequest -= new OnPostRequestHandler(_service_OnPostRequest);
            _service = null;

            Logger.LogInfo("EmulatorInputPin has stopped succesfully ...");
        }
    }
}
