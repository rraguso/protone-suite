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

namespace OPMedia.Addons.Builtin.CatalogExplorer
{
    public partial class CatalogExplorerCfgPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Catalog16;
            }
        }

        public CatalogExplorerCfgPanel()
        {
            InitializeComponent();

            this.Title = "TXT_ADDON_MC_SETTINGS";
            this.HandleCreated += new EventHandler(FileExplorerCfgPanel_HandleCreated);

            chkReopenLastCatalog.Checked = AppSettings.Instance.MCOpenLastCatalog;
            chkRememberRecentFiles.Checked = AppSettings.Instance.MCRememberRecentFiles;
            nudRecentFilesCount.Value = AppSettings.Instance.MCRecentFilesCount;

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
            AppSettings.Instance.MCOpenLastCatalog = chkReopenLastCatalog.Checked;
            AppSettings.Instance.MCRememberRecentFiles = chkRememberRecentFiles.Checked;
            AppSettings.Instance.MCRecentFilesCount = (int)nudRecentFilesCount.Value;

            AppSettings.Instance.Save();
        }

        
    }
}
