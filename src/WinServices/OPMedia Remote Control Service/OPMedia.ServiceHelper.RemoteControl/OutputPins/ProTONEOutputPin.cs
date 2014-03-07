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

namespace OPMedia.ServiceHelper.RCCService.OutputPins
{
    public class ProTONEOutputPin : OutputPin
    {
        public override string TranslateToOutputPinFormat(string data, RCCServiceConfig.RemoteButtonsRow button)
        {
            return button.OutputData;
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
            string playerLocation = SuiteConfiguration.PlayerInstallationPath;
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
