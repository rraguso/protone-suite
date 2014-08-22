using System;
using System.Collections.Generic;
using System.Text;

using OPMedia.Core;
using System.Security.Principal;
using OPMedia.Core.Logging;
using System.IO;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Runtime;
using OPMedia.Runtime.ProTONE;
using System.Configuration;
using OPMedia.Core.Configuration;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.ServiceHelper.RCCService.OutputPins
{
    public class ProTONEOutputPin : OutputPin
    {
        protected override string TranslateToOutputPinFormat(string data, RCCServiceConfig.RemoteButtonsRow button)
        {
            if (button != null)
                return button.OutputData;

            return data;
        }

        public override bool IsConfigurable
        {
            get { return false; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            return null;
        }

        protected override void ConfigureInternal()
        {
            // Nothing to configure. This pin works with standard settings.
            // See StartInternal.
        }

        protected override void StartInternal()
        {
            string playerLocation = ProTONEConfig.PlayerInstallationPath;
            if (string.IsNullOrEmpty(playerLocation) || !File.Exists(playerLocation))
                throw new ConfigurationErrorsException("ProTONEOutputPin: ProTONE Player not installed.");
        }

        protected override void StopInternal()
        {
        }

        protected override void SendRequestInternal(string request)
        {
            try
            {
                BasicCommand cmd = BasicCommand.Create(request);
                if (cmd != null)
                {
                    RemoteControlHelper.SendPlayerCommand(cmd, true);
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }
    }
}
