using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.TranslationSupport;
using OPMedia.Addons.Builtin.Properties;

using OPMedia.UI.Controls;
using OPMedia.Runtime.Addons.Configuration;

namespace OPMedia.Addons.Builtin.FileExplorer
{
    public partial class FileExplorerCfgPanel : SettingsTabPage
    {
        OPMToolTip _tip = new OPMToolTip();

        public override Image Image
        {
            get
            {
                return Resources.FileExplorer16;
            }
        }

        public FileExplorerCfgPanel()
        {
            InitializeComponent();

            this.Title = "TXT_ADDON_FE_SETTINGS";
            this.HandleCreated += new EventHandler(FileExplorerCfgPanel_HandleCreated);

            _tip.SetSimpleToolTip(chkGroupBookmarkWithMedia,
                Translator.Translate("TXT_GROUP_BMKWITHMEDIA_DESC"));
        }

        void FileExplorerCfgPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);

            nudMaxProcessedFiles.Value = AppSettings.FEMaxProcessedFiles;
            nudPreviewTimer.Value = AppSettings.FEPreviewTimer;
            chkGroupBookmarkWithMedia.Checked = AppSettings.GroupBookmarkWithMedia;
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        protected override void SaveInternal()
        {
            AppSettings.FEMaxProcessedFiles = (int)nudMaxProcessedFiles.Value;
            AppSettings.FEPreviewTimer = nudPreviewTimer.Value;
            AppSettings.GroupBookmarkWithMedia = chkGroupBookmarkWithMedia.Checked;

            AppSettings.Save();
        }
    }
}
