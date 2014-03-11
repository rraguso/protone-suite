using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Properties;
using OPMedia.UI.Controls;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.UI.Configuration
{
    public partial class TroubleshootingPanel : MultiPageCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Troubleshooting;
            }
        }

        public TroubleshootingPanel()
            : base()
        {
            this.Title = "TXT_S_TROUBLESHOOTING";
            InitializeComponent();
        }

        public void AddLoggingPage()
        {
            if (SuiteConfiguration.LogFullyDisabled == false)
            {
                AddSubPage(new LoggingSettingsPanel());
            }
        }
    }
}