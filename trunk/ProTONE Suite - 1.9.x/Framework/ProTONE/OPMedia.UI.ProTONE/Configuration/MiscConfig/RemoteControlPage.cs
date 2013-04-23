using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Runtime.ProTONE.ServiceHelpers;
using OPMedia.Core;
using System.Diagnostics;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    public partial class RemoteControlPage : SettingsTabPage
    {
        public RemoteControlPage()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(OnLoad);
        }

        void OnLoad(object sender, EventArgs e)
        {
            chkEnableRemoting.Checked = ProTONERemoteConfig.EnableRemoteControl;
            this.Enabled = SuiteConfiguration.CurrentUserIsAdministrator;
        }

        protected override void SaveInternal()
        {
            ProTONERemoteConfig.EnableRemoteControl = chkEnableRemoting.Checked;
            ProTONERemoteConfig.ReconfigureRCCService();
            Modified = false;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            Process.Start(SuiteConfiguration.RCCManagerInstallationPath);
        }
    }
}
