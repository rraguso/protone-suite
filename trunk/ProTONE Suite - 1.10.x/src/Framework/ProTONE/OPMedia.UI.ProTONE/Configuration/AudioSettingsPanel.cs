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
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class AudioSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.AudioSettings;
            }
        }

        public AudioSettingsPanel()
        {
            this.Title = "TXT_S_AUDIOSETTINGS";
            InitializeComponent();

            double[] freqws = MediaRenderer.DefaultInstance.EqFrequencies;

            lblCautionRealtime.OverrideForeColor = ThemeManager.HighlightColor;

            cgBalance.Value = AppSettings.LastBalance + 2000;
            cgBalance.PositionChanged += (b) =>
                {
                    AppSettings.LastBalance = (int)cgBalance.Value - 2000;
                    MediaRenderer.DefaultInstance.AudioBalance = AppSettings.LastBalance;
                    AppSettings.Save();

                };

            cgVolume.Value = AppSettings.LastVolume;
            cgVolume.PositionChanged += (v) =>
                {
                    AppSettings.LastVolume = (int)cgVolume.Value;
                    MediaRenderer.DefaultInstance.AudioVolume = AppSettings.LastVolume;
                    AppSettings.Save();
                };
        }
    }
}
