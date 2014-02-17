using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Tasks;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.Controls;
using System.IO;
using OPMedia.Core;
using OPMedia.Runtime.FileInformation;

namespace OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Controls
{
    public partial class WizImportStep2Ctl : WizardBaseCtl
    {
        public WizImportStep2Ctl()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                DisplaySourcePath();
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnPageEnter_MovingNext()
        {
            DisplaySourcePath();
        }

        protected override void OnPageEnter_MovingBack()
        {
            DisplaySourcePath();
        }

        private void DisplaySourcePath()
        {
            tvImportPath.InitOPMShellTreeView();

            if (!string.IsNullOrEmpty((BkgTask as Task).SourcePath))
            {
                NativeFileInfo nfi = new NativeFileInfo((BkgTask as Task).SourcePath, false);
                if (nfi.IsValid)
                {
                    tvImportPath.Select();
                    tvImportPath.Focus();
                    tvImportPath.DrillToFolder(nfi.Path);
                    Wizard.CanFinish = true;
                }
            }

            txtEntryDesc.Text = (BkgTask as Task).EntryDescription;
        }

        private void tvImportPath_AfterSelect(object sender, TreeViewEventArgs e)
        {
            (BkgTask as Task).SourcePath = tvImportPath.SelectedNodePath;

            NativeFileInfo nfi = new NativeFileInfo((BkgTask as Task).SourcePath, false);
            Wizard.CanFinish = nfi.IsValid;

            if (Directory.Exists((BkgTask as Task).SourcePath))
            {
                string label = string.Empty;
                string sernum = Kernel32.GetVolumeInformation(Path.GetPathRoot((BkgTask as Task).SourcePath), ref label);
                txtEntryDesc.Text = string.Format("{0}:{1}", label, sernum);
            }
        }

        private void txtEntryDesc_TextChanged(object sender, EventArgs e)
        {
            (BkgTask as Task).EntryDescription = txtEntryDesc.Text;
        }
    }
}
