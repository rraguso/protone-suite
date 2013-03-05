using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Tasks;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Runtime.ProTONE.FileInformation;

using OPMedia.Core;
using OPMedia.Runtime.FileInformation;
using System.Threading;
using OPMedia.Core.Logging;
using OPMedia.UI.Controls;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.Addons.Builtin.Properties;
using OPMedia.Core.ApplicationSettings;

namespace OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Controls
{
    public partial class WizImportStep1Ctl : WizardBaseCtl
    {
        public WizImportStep1Ctl()
        {
            InitializeComponent();
            //Bitmap bmp = Resources.OpenFolder;
            //bmp.MakeTransparent(Color.Magenta);
            //btnBrowse.Image = bmp;
        }

        protected override void  OnWizardMovingNext()
        {
            long insertionPointID = -1;

            if (tvCatFolders.SelectedNode != null && tvCatFolders.SelectedNode.Tag != null)
                insertionPointID = (tvCatFolders.SelectedNode.Tag as CatalogItem).ItemID;

            (BkgTask as Task).InsertionPointID = insertionPointID;
            (BkgTask as Task).CatalogDescription = txtCatDesc.Text;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayCatalogContents));
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnWizardInitializing()
        {
            if (BkgTask == null)
            {
                BkgTask = new Task();
            }
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayCatalogContents));
            }
        }

        protected override void OnWizardMovingBack()
        {
            OnWizardInitializing();
        }

        private void OnBrowseCatalog(object sender, EventArgs e)
        {
            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Title = Translator.Translate("TXT_SELECTCATALOG");
            dlg.Filter = Translator.Translate("TXT_CATALOG_FILTER");
            dlg.DefaultExt = "ctx";
            dlg.InitialDirectory = AppSettings.MCLastOpenedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AppSettings.MCLastOpenedFolder = Path.GetDirectoryName(dlg.FileName);

                (BkgTask as Task).CatalogPath = dlg.FileName;
                lblCatalogPath.Text = Translator.Translate("TXT_CATALOGPATH", dlg.FileName);

                ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayCatalogContents));
            }
        }

        private void DisplayCatalogContents(object state)
        {
            try
            {
                ShowWaitDialog("TXT_WAIT_LOADING_CATALOG");

                string path = (BkgTask as Task).CatalogPath;

                Catalog cat = null;

                NativeFileInfo nfi = new NativeFileInfo(path, false);
                if (nfi.IsValid)
                {
                    cat = new Catalog(path);
                }
                else if (!string.IsNullOrEmpty(path))
                {
                    cat = new Catalog();
                    cat.Save(path);
                }

                if (cat != null && cat.IsValid)
                {
                    DisplayCatalog(cat);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                CloseWaitDialog();
            }
        }

        private delegate void DisplayCatalogDG(Catalog cat);
        private void DisplayCatalog(Catalog cat)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayCatalogDG(DisplayCatalog), cat);
                return;
            }

            try
            {
                string path = (BkgTask as Task).CatalogPath;
                lblCatalogPath.Text = path;

                tvCatFolders.Nodes.Clear();

                if (cat.IsValid && !cat.IsInDefaultLocation)
                {
                    txtCatDesc.Text = Translator.TranslateTaggedString(cat.CatalogDescription);
                    tvCatFolders.DisplayCatalog(cat);

                    // At this time Enabled = false so we really can't set CanMoveNext
                    // Must enable the control first.
                    this.Enabled = true;
                    Wizard.CanMoveNext = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
