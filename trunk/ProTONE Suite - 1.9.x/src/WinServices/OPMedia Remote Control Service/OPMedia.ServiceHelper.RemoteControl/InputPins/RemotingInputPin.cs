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
    public class RemotingInputPin : InputPin
    {
        RemoteControlHost _service = null;

        public override bool IsConfigurable
        {
            get { return false; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            return null;
        }

        public RemotingInputPin()
        {
            _service = new RemoteControlHost(Constants.RCCServiceShortName, CommandTargetPort.RccService);
            _service.OnSendRequest += new OnSendRequestHandler(_service_OnSendRequest);

            Logger.LogInfo("RemotingInputPin was created ...");
        }

        string _service_OnSendRequest(string request)
        {
            try
            {
                RemoteControlServiceMux.Instance.ProcessRequest(this, request);
                return "ACK";
            }
            catch
            {
                return null;
            }
        }

        protected override void ConfigureInternal()
        {
            // Nothing to configure. This pin works with standard settings.
            // See StartInternal.
        }

        protected override void StartInternal()
        {
            _service.StartInternal();

            EventDispatch.RegisterHandler(this);

            Logger.LogInfo("RemotingInputPin was started succesfully ...");
        }

        protected override void StopInternal()
        {
            EventDispatch.UnregisterHandler(this);

            _service.StopInternal();

            Logger.LogInfo("RemotingInputPin was stopped succesfully ...");
        }
    }
}
