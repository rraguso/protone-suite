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
    public partial class ControlAppPanel : MultiPageCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.ControlPanel;
            }
        }

        int logPageIndex = -1;

        public ControlAppPanel()
            : base()
        {
            this.Title = "TXT_S_CONTROL";
            InitializeComponent();
        }

        public void AddKeyboardPage()
        {
            AddSubPage(new KeyMapCfgPanel());
        }
    }
}