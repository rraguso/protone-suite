using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using System.IO;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.Core.Configuration;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.UI.Dialogs;
using OPMedia.Addons.Builtin.Properties;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public partial class WizTagStep1Ctl : WizardBaseCtl
    {
        ImageList _ilFiles = new ImageList();

        public WizTagStep1Ctl()
        {
            InitializeComponent();
            lvFiles.MultiSelect = true;
            _ilFiles.ColorDepth = ColorDepth.Depth32Bit;
            _ilFiles.ImageSize = new Size(16, 16);
            lvFiles.SmallImageList = _ilFiles;

            
        }

        protected override void  OnPageLeave_MovingNext()
        {
            (BkgTask as Task).Files = new List<string>();
            foreach (ListViewItem item in lvFiles.Items)
            {
                (BkgTask as Task).Files.Add(item.Tag as string);
            }
        }

        protected override void OnPageEnter_MovingBack()
        {
            OnPageEnter_Initializing();
        }

        protected override void OnPageEnter_Initializing()
        {
            base.OnPageEnter_Initializing();

            lvFiles.Items.Clear();
            _ilFiles.Images.Clear();

            if (BkgTask == null)
            {
                BkgTask = new Task();
            }

            foreach (string file in (BkgTask as Task).Files)
            {
                AddFile(file);
            }

            Wizard.CanMoveNext = lvFiles.Items.Count > 0;
        }

        private void AddFile(string file)
        {
            _ilFiles.Images.Add(ImageProvider.GetIcon(file, false));

            ListViewItem item = lvFiles.Items.Add(file);
            item.ImageIndex = _ilFiles.Images.Count - 1;
            item.Tag = file;
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            CursorHelper.ShowWaitCursor(this, true);

            OPMOpenFileDialog dlg = new OPMOpenFileDialog();
            dlg.Title = Translator.Translate("TXT_SELECTTAGGEDFILES");
            dlg.Filter = Translator.Translate("TXT_TAGGEDFILESFILTER");
            dlg.InitialDirectory = ProTONEConfig.LastOpenedFolder;
            dlg.Multiselect = true;

            dlg.InheritAppIcon = false;
            dlg.Icon = Resources.Tagging16.ToIcon();

            dlg.FillFavoriteFoldersEvt += () => { return ProTONEConfig.GetFavoriteFolders("FavoriteFolders"); };
            dlg.AddToFavoriteFolders += (s) => { return ProTONEConfig.AddToFavoriteFolders(s); };
            dlg.ShowAddToFavorites = true;


            if (dlg.ShowDialog() == DialogResult.OK && dlg.FileNames.Length > 0)
            {
                foreach (string file in dlg.FileNames)
                {
                    AddFile(file);
                }

                try
                {
                    FileInfo fi = new FileInfo(dlg.FileNames[0]);
                    ProTONEConfig.LastOpenedFolder = fi.DirectoryName;
                }
                catch
                {
                    ProTONEConfig.LastOpenedFolder = dlg.InitialDirectory;
                }
            }

            CursorHelper.ShowWaitCursor(this, false);
            Wizard.CanMoveNext = lvFiles.Items.Count > 0;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            CursorHelper.ShowWaitCursor(this, true);

            OPMFolderBrowserDialog dlg = new OPMFolderBrowserDialog();
            dlg.Description = Translator.Translate("TXT_SELECTTAGGEDFILESFOLDER");
            dlg.SelectedPath = ProTONEConfig.LastOpenedFolder;
            dlg.ShowNewFolderButton = false;

            dlg.InheritAppIcon = false;
            dlg.Icon = Resources.Tagging16.ToIcon();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(dlg.SelectedPath, "*.mp?", SearchOption.AllDirectories);
                if (files != null)
                {
                    foreach (string file in files)
                    {
                        AddFile(file);
                    }
                }
                
                ProTONEConfig.LastOpenedFolder = dlg.SelectedPath;
            }

            CursorHelper.ShowWaitCursor(this, false);
            Wizard.CanMoveNext = lvFiles.Items.Count > 0;
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            CursorHelper.ShowWaitCursor(this, true);

            if (lvFiles.SelectedItems == null)
                return;

            List<ListViewItem> toBeRemoved = new List<ListViewItem>();
            foreach (ListViewItem file in lvFiles.SelectedItems)
            {
                toBeRemoved.Add(file);
            }

            foreach (ListViewItem file in toBeRemoved)
            {
                lvFiles.Items.Remove(file);
            }

            CursorHelper.ShowWaitCursor(this, false);
            Wizard.CanMoveNext = lvFiles.Items.Count > 0;
        }

        private void lvFiles_Resize(object sender, EventArgs e)
        {
            colPath.Width = lvFiles.Width - SystemInformation.VerticalScrollBarWidth;
        }
    }
}
