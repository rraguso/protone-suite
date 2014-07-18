using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core.ApplicationSettings;
using System.ServiceProcess;
using OPMedia.Core;
using System.IO;

namespace OPMedia.Runtime.ProTONE.ApplicationSettings
{
    public class ProTONEAppSettings : AppSettings
    {
        public ProTONEAppSettings()
            : base()
        {
        }

        #region RCC Service API (Calculated Level 2 settings)
        public static bool IsRCCServiceInstalled
        {
            get
            {
                try
                {
                    ServiceController sc = new ServiceController(Constants.RCCServiceShortName);
                    ServiceControllerStatus scs = sc.Status;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string RCCManagerInstallationPath
        {
            get
            {
                return Path.Combine(SuiteConfiguration.InstallationPath, Constants.RCCManagerBinary);
            }
        }

        public static string RCCServiceInstallationPath
        {
            get
            {
                return Path.Combine(SuiteConfiguration.InstallationPath, Constants.RCCServiceBinary);
            }
        }
        #endregion
    }
}
