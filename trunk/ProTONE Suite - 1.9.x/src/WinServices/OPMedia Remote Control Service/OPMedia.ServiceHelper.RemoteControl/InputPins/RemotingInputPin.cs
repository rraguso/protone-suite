using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Remoting;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.Core.Logging;
using OPMedia.Core;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime;
using OPMedia.Core.GlobalEvents;

namespace OPMedia.ServiceHelper.RCCService.InputPins
{
    public class RemotingInputPin : InputPin
    {
        RemoteService _service = RemoteService.Create(false);

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
            Logger.LogInfo("RemotingInputPin was created ...");
        }

        protected override void ConfigureInternal()
        {
            // Nothing to configure. This pin works with standard settings.
            // See StartInternal.
        }

        protected override void StartInternal()
        {
            _service.Start(Constants.RCCServiceShortName, Constants.RCCServiceRemotingPort);

            EventDispatch.RegisterHandler(this);

            Logger.LogInfo("RemotingInputPin was started succesfully ...");
        }

        [EventSink(RemoteObject.EventName)]
        public void OnProcessRemoteRequest(SerializableObject request)
        {
            RemoteControlServiceMux.Instance.ProcessRequest(this, request);
        }

        protected override void StopInternal()
        {
            EventDispatch.UnregisterHandler(this);

            _service.Stop();

            Logger.LogInfo("RemotingInputPin was stopped succesfully ...");
        }
    }
}
