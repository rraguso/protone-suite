using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.UI.Configuration;

namespace TestExtension.Navigation
{
    public partial class AddonPanel : NavBaseCtl
    {
        public AddonPanel()
        {
            InitializeComponent();
        }

        protected override SettingsTabPage GetSettingsTabPage()
        {
            return new CfgPanel();
        }
    }
}
