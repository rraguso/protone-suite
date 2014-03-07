using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;

namespace TestExtension.Navigation
{
    public partial class CfgPanel : SettingsTabPage
    {
        public override Image Image
        {
            get
            {
                return SystemIcons.Shield.ToBitmap();
            }
        }

        public CfgPanel()
        {
            InitializeComponent();

            this.Title = "TXT_CFG_PANEL";
        }
    }
}
