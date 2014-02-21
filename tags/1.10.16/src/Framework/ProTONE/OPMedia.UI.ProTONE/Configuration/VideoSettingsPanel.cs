using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.UI.ProTONE.Properties;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class VideoSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.VideoSettings;
            }
        }

        public VideoSettingsPanel()
        {
            this.Title = "TXT_S_VIDEOSETTINGS";
            InitializeComponent();
        }
    }
}
