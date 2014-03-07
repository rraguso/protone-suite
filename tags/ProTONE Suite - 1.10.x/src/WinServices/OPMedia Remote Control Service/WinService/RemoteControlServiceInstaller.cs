using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using OPMedia.Core;
using System.Diagnostics;
using OPMedia.Runtime;

namespace OPMedia.Services.RCCService
{
    [RunInstaller(true)]
    public partial class RemoteControlServiceInstaller : Installer
    {
        public RemoteControlServiceInstaller()
        {
            InitializeComponent();

            ServiceInstaller serviceInstaller = new ServiceInstaller();
            serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = Constants.RCCServiceShortName;
            serviceInstaller.DisplayName = Constants.RCCServiceLongName;
            serviceInstaller.Description = Constants.RCCServiceDescription;

            Installers.Add(serviceInstaller);

            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

            Installers.Add(serviceProcessInstaller);
        }
    }
}