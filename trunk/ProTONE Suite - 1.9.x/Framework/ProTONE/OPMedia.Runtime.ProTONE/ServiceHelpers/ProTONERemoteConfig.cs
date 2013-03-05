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
                bool retVal = false;
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OPMedia Research\ProTONE Suite");
                    if (key != null)
                    {
                        retVal = ((int)key.GetValue("EnableRemoteControl", 0) != 0);
                    }
                }
                catch
                {
                }

                return retVal;
            }

            set
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\OPMedia Research\ProTONE Suite"))
                {
                    if (key != null)
                    {
                        key.SetValue("EnableRemoteControl", value ? 1 : 0);
                    }
                }
            }
        }

        public static bool ReconfigureRCCService()
        {
            try
            {
                ServiceController sc = new ServiceController(
                    Constants.RCCServiceShortName, 
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
