using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using OPMedia.Core.Configuration;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.Core.Properties;
using OPMedia.SkinBuilder.Configuration;


namespace SkinBuilder.Configuration
{
    public partial class SkinBuilderCfgPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.AudioFile.ToBitmap();
            }
        }

        public SkinBuilderCfgPanel()
        {
            InitializeComponent();

            this.Title = "TXT_CONFIGUREAPP";
            this.HandleCreated += new EventHandler(FileExplorerCfgPanel_HandleCreated);

            chkReopenLastCatalog.Checked = SkinBuilderConfiguration.OpenLastFile;
            chkRememberRecentFiles.Checked = SkinBuilderConfiguration.RememberRecentFiles;
            nudRecentFilesCount.Value = SkinBuilderConfiguration.RecentFilesCount;

            nudRecentFilesCount.Enabled = chkRememberRecentFiles.Checked;
        }

        void FileExplorerCfgPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            Modified = true;

            nudRecentFilesCount.Enabled = chkRememberRecentFiles.Checked;
        }

        protected override void SaveInternal()
        {
            SkinBuilderConfiguration.OpenLastFile = chkReopenLastCatalog.Checked;
            SkinBuilderConfiguration.RememberRecentFiles = chkRememberRecentFiles.Checked;
            SkinBuilderConfiguration.RecentFilesCount = (int)nudRecentFilesCount.Value;
            AppConfig.Save();
        }

        
    }
}
