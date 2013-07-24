using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.Core.ApplicationSettings;
using System.Threading;
using OPMedia.Core.Logging;
using OPMedia.UI;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;
using OPMedia.UI.Controls;
using OPMedia.Core;

namespace OPMedia.Addons.Builtin.VideoProp
{
    public partial class AddonPanel : OPMedia.Runtime.Addons.AddonsBase.Prop.PropBaseCtl
    {
        List<object> lvi = null;
        List<string> strItems = null;

        public override string GetHelpTopic()
        {
            return "VideoPropertyPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);

        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            btnSearchSubtitles.Text = Translator.Translate("TXT_SEARCH_SUBTITLES");
        }

        public override bool CanHandleFolders
        {
            get
            {
                return false;
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return MediaRenderer.SupportedVideoTypes;
            }
        }

        public override int MaximumHandledItems
        {
            get
            {
                return -1;
            }
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            this.strItems = strItems;
            DoShowProperties();
        }

        private void DoShowProperties()
        {
            lvi = new List<object>();
            foreach (string item in strItems)
            {
                VideoFileInfo vi = VideoFileInfo.FromPath(item)
                    as VideoFileInfo;
                if (vi.IsValid)
                {
                    lvi.Add(vi);
                }
            }

            FileAttributesBrowser.SuppressNonBrowsableAttributes(lvi);

            pgProperties.SelectedObjects = lvi.ToArray();

            btnSearchSubtitles.Enabled = false;
            if (lvi.Count == 1)
            {
                VideoFileInfo vfi = lvi[0] as VideoFileInfo;
                if (vfi != null)
                {
                    btnSearchSubtitles.Enabled =
                        SubtitleDownloadProcessor.CanPerformSubtitleDownload(vfi.Path,
                        (int)vfi.Duration.GetValueOrDefault().TotalSeconds);
                }
            }
        }

        [EventSink(OPMedia.Core.EventNames.PerformTranslation)]
        public new void OnPerformTranslation()
        {
            btnSearchSubtitles.Text = Translator.Translate("TXT_SEARCH_SUBTITLES");
        }

        private void btnSearchSubtitles_Click(object sender, EventArgs e)
        {
            VideoFileInfo vi = pgProperties.SelectedObject as VideoFileInfo;
            if (vi != null)
            {
                TryFindSubtitle(vi.Path, (int)vi.Duration.GetValueOrDefault().TotalSeconds);
            }
        }

        private void TryFindSubtitle(string strFile, int duration)
        {
            // If strFile indicates only a disk root, the movie is actually a DVD
            // We don't want to look up on Internet for DVD subtitles. Usually DVD's 
            // come with their builtin subtitles.
            if (PathUtils.IsRootPath(strFile))
                return;

            if (SubtitleDownloadProcessor.TestForExistingSubtitle(strFile))
            {
                if (MessageDisplay.Query(Translator.Translate("TXT_OVERWRITE_SUBTITLE"),
                    Translator.Translate("TXT_QUESTION"), MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return;
                }
            }

            if (SubtitleDownloadProcessor.CanPerformSubtitleDownload(strFile, duration))
            {
                // We should display a subtitle but we don't have one.
                // Try to grab one from internet.
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(SubtitleDownloadProcessor.AttemptDownload), strFile);
            }
        }
    }
}

