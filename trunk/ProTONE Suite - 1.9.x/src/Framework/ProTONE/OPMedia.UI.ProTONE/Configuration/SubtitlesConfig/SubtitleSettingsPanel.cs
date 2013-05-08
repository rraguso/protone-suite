using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;

using OPMedia.Runtime;
using OPMedia.UI.Configuration;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class SubtitleSettingsPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.ResourceManager.GetImage("subtitles");
            }
        }

        public override string GetHelpTopic()
        {
            if (tabSubtitlesOsd.SelectedTab != null)
                return string.Format("{0}/{1}", this.Name, tabSubtitlesOsd.SelectedTab.Name);

            return base.GetHelpTopic();
        }

        public SubtitleSettingsPanel()
            : base()
        {
            this.Title = "TXT_SUBTITLESETTINGS";
            InitializeComponent();

            pageSubtitles.ModifiedActive += new EventHandler(OnModifiedActive);
            pageOsd.ModifiedActive += new EventHandler(OnModifiedActive);

            this.HandleCreated += new EventHandler(SubtitleSettingsPanel_HandleCreated);
        }

        void SubtitleSettingsPanel_HandleCreated(object sender, EventArgs e)
        {
            tabSubtitlesOsd.SelectedIndex = 0;
        }

        void OnModifiedActive(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void SaveInternal()
        {
            pageSubtitles.Save();
            pageOsd.Save();
            AppSettings.Save();

            Modified = false;
        }
    }
}
