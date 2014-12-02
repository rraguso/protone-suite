using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using Microsoft.Win32;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ServiceHelpers;
using System.ComponentModel;
using System.ServiceProcess;

namespace OPMedia.Runtime.ProTONE.ServiceHelpers
{
    public class ProTONERemoteConfig
    {
        public static bool EnableRemoteControl
        {
            get
            {
                return PersistenceProxy.ReadObject("EnableRemoteControl", false, false);
            }

            set
            {
                PersistenceProxy.SaveObject("EnableRemoteControl", value, false);
            }
        }

        public static bool ReconfigureRCCService()
        {
            try
            {
                ServiceController sc = new ServiceController(
                    ProTONEConstants.RCCServiceShortName, 
                    Environment.MachineName);

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.ExecuteCommand((int)ServiceCommand.Reconfigure);
                }
                else
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                }

                if (sc.Status != ServiceControllerStatus.Running)
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            return false;
        }

    }
}
