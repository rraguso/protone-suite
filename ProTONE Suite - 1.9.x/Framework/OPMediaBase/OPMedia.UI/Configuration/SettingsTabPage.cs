using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Configuration
{
    public partial class SettingsTabPage : BaseCfgPanel
    {
        public event EventHandler ModifiedActive = null;

        public new bool Modified
        {
            get
            {
                return base.Modified;
            }

            set
            {
                base.Modified = value;
                if (value && ModifiedActive != null)
                {
                    ModifiedActive(this, EventArgs.Empty);
                }
            }
        }

        public SettingsTabPage()
        {
            InitializeComponent();
        }
    }
}
