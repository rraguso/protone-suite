using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using System.IO;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.Core;
using OPMedia.Addons.Builtin.CatalogExplorer.SearchWizard.Tasks;
using OPMedia.Runtime;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.UI.Controls;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.Dialogs;

namespace OPMedia.Addons.Builtin.CatalogExplorer.SearchWizard.Controls
{
    public partial class WizMCSearchStep1Ctl : WizardBaseCtl
    {
        private Task theTask
        {
            get
            {
                return (BkgTask as Task);
            }
        }

        public WizMCSearchStep1Ctl()
        {
            InitializeComponent();

            this.ResizeParent = true;
            this.DecorationsVisible = false;

            ilImages = new ImageList();
            ilImages.ImageSize = new Size(16, 16);
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            ilImages.Images.Clear();

            ilImages.Images.Add(ImageProvider.GetIconOfFileType("ctx"));
            
            LoadShell32Image(Shell32Icon.DriveUnknown);
            LoadShell32Image(Shell32Icon.DriveNoRoot);
            LoadShell32Image(Shell32Icon.DriveRemovable);
            LoadShell32Image(Shell32Icon.DriveFixed);
            LoadShell32Image(Shell32Icon.DriveNetwork);
            LoadShell32Image(Shell32Icon.DriveCdrom);
            LoadShell32Image(Shell32Icon.DriveRamdisk);
            LoadShell32Image(Shell32Icon.GenericFolder);
            LoadShell32Image(Shell32Icon.GenericFile);

            lvResults.SmallImageList = ilImages;

            Translator.TranslateToolStrip(contextMenuStrip, DesignMode);

        }

        private void LoadShell32Image(Shell32Icon shell32Icon)
        {
            ilImages.Images.Add(ImageProvider.GetShell32Icon(shell32Icon, false));
        }

        private void OnClearSearchPatternHistory(object sender, EventArgs e)
        {
            AppSettings.SearchPatternsMC = string.Empty;
            AppSettings.Save();
            PopulateSearchPattern();
        }

        private void OnClearSearchValueHistory(object sender, EventArgs e)
        {
            AppSettings.SearchTextsMC = string.Empty;
            AppSettings.Save();
            PopulateSearchText();
        }

        

        protected override void OnWizardInitializing()
        {
            base.OnWizardInitializing();

            ssStatus.BackColor = ThemeManager.BackColor;
            pbProgress.BackColor = ThemeManager.BackColor;
            statusBar.BackColor = ThemeManager.BackColor;

            Display();
        }

        bool enableEvents = false;
        private void Display()
        {
            Wizard.CanFinish = false;
            Wizard.CanMoveBack = false;
            Wizard.CanMoveNext = false;
            Wizard.StepButtonsVisible = false;
            Wizard.ShowOKButton = false;
            Wizard.ShowRepeatWizard = false;
            Wizard.AcceptButton = btnSearch.Button;

            enableEvents = false;

            PopulateSearchPattern();
            PopulateSearchText();
            FillSearchPath(theTask.SearchPath);

            chkRecursive.Checked = theTask.IsRecursive;
            enableEvents = true;
        }

        private void PopulateSearchText()
        {
            cmbSearchText.Items.Clear();
            cmbSearchText.Items.AddRange(AppSettings.SearchTextsMC.Split(
                "?".ToCharArray()));

            if (!cmbSearchText.Items.Contains(theTask.SearchText))
                cmbSearchText.Items.Add(theTask.SearchText);

            cmbSearchText.SelectedItem = theTask.SearchText;
        }

        private void PopulateSearchPattern()
        {
            cmbSearchPattern.Items.Clear();
            cmbSearchPattern.Items.AddRange(AppSettings.SearchPatternsMC.Split(
                "?".ToCharArray()));

            if (!cmbSearchPattern.Items.Contains(theTask.SearchPattern))
                cmbSearchPattern.Items.Add(theTask.SearchPattern);

            cmbSearchPattern.SelectedItem = theTask.SearchPattern;
        }

        private void SaveSearchSettings()
        {
            AppSettings.SearchPatternsMC = SaveSetting(AppSettings.SearchPatternsMC, cmbSearchPattern.Text);
            AppSettings.SearchTextsMC = SaveSetting(AppSettings.SearchTextsMC, cmbSearchText.Text);
            AppSettings.Save();
        }

        private string SaveSetting(string initialSetting, string settingToAdd)
        {
            if (string.IsNullOrEmpty(initialSetting))
                return settingToAdd;

            string[] parts = initialSetting.Split("?".ToCharArray());
            string finalSetting = settingToAdd;

            if (parts.Length >= 20)
            {
                for (int i = 1; i < 20; i++)
                {
                    finalSetting += "?";
                    finalSetting += parts[i];
                }
            }
            else
            {
                finalSetting += "?";
                finalSetting += initialSetting;
            }

            return finalSetting;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            theTask.Attributes ^= theTask.Attributes;

            SaveSearchSettings();
            ExecuteSearch();
            DisplaySearchResults();
        }

        private void DisplaySearchResults()
        {
            lvResults.Items.Clear();
            foreach (CatalogItem item in _matchingItems)
            {
                CreateItem(item);
            }
        }

        private void CreateItem(CatalogItem item)
        {
            CatalogItem byRootSerialNumber = theTask.Catalog.GetRootBySerialNumber(item.RootSerialNumber);
            string str = (byRootSerialNumber != null) ? byRootSerialNumber.Name : Translator.Translate("TXT_NA");

            int imgIndex = -1;
            if (item.IsFolder)
            {
                imgIndex = (int)item.ItemType + 1;
            }
            else
            {
                string ext = PathUtils.GetExtension(item.OrigItemPath);
                if (ilImages.Images.ContainsKey(ext))
                {
                    imgIndex = ilImages.Images.IndexOfKey(ext);
                }
                else
                {
                    Image img = ImageProvider.GetIconOfFileType(ext);
                    if (img != null)
                    {
                        ilImages.Images.Add(img);
                        imgIndex = ilImages.Images.Count - 1;
                    }
                }
            }

            string[] data = new string[]
            {
                "",
                str,
                item.RootItemLabel,
                item.OrigItemPath
            };

            ListViewItem lvItem = new ListViewItem(data);
            lvItem.Tag = item.VPath;
            lvItem.ImageIndex = imgIndex;

            lvResults.Items.Add(lvItem);
        }

        private int GetIcon(string path)
        {
            System.Drawing.Image icon = ImageProvider.GetIcon(path, false);
            if (icon != null)
            {
                ilImages.Images.Add(icon);
                return ilImages.Images.Count - 1;
            }

            return 0;
        }

        List<CatalogItem> _matchingItems = new List<CatalogItem>();
        private void ExecuteSearch()
        {
            _matchingItems.Clear();

            pbProgress.Maximum = 1;
            pbProgress.Value = 0;
            pbProgress.Visible = true;

            theTask.SearchPattern = cmbSearchPattern.Text;
            theTask.SearchText = cmbSearchText.Text;
            theTask.IsRecursive = chkRecursive.Checked;

            CatalogItem[] items = theTask.Catalog.FindItems(
                theTask.Catalog.GetByVPath(theTask.SearchPath),
                null,
                theTask.SearchPattern,
                theTask.SearchText,
                theTask.IsRecursive);

            if (items != null && items.Length > 0)
            {
                _matchingItems.AddRange(items);
            }

            if (_matchingItems.Count > 0)
                ssStatus.Text = Translator.Translate("TXT_TOTAL_ITEMS_FOUND", _matchingItems.Count);
            else
                ssStatus.Text = Translator.Translate("TXT_NO_ITEMS_FOUND");

            pbProgress.Visible = false;
        }

        private void OnMenuOpening(object sender, CancelEventArgs e)
        {
            bool playerInstalled = File.Exists(SuiteConfiguration.PlayerInstallationPath);
            tsmiSepProTONE.Visible = tsmiProTONEEnqueue.Visible = tsmiProTONEPlay.Visible =
                playerInstalled;

            bool enable = false;
            foreach (string vpath in GetSelectedItems())
            {
                CatalogItem ci = (BkgTask as Task).Catalog.GetByVPath(vpath);
                if (ci != null && MediaRenderer.IsSupportedMedia(ci.OrigItemPath))
                {
                    enable = true;
                    break;
                }
            }

            tsmiProTONEEnqueue.Enabled = tsmiProTONEPlay.Enabled = enable;

            //tsmiID3Wizard.Enabled = (lvResults.SelectedItems.SelectedItems.Count == 1);
        }

        private void OnToolAction(object sender, EventArgs e)
        {
            HandleAction(sender as ToolStripItem);
        }

        private void HandleAction(ToolStripItem tsi)
        {
            if (tsi == null || string.IsNullOrEmpty(tsi.Tag as string))
                return;

            theTask.Action = (ToolAction)Enum.Parse(typeof(ToolAction),
                   tsi.Tag as string);
            theTask.MatchingItems = GetSelectedItems();

            FindForm().DialogResult = DialogResult.OK;
            FindForm().Close();
        }

        private List<string> GetSelectedItems()
        {
            List<string> selPaths = new List<string>();
            foreach (ListViewItem item in lvResults.SelectedItems)
            {
                string pathToAdd = item.Tag as string;
                if (pathToAdd != null) selPaths.Add(pathToAdd);
            }

            return selPaths;
        }

        private void lvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            theTask.Action = ToolAction.ToolActionLaunch;
            theTask.MatchingItems = GetSelectedItems();

            FindForm().DialogResult = DialogResult.OK;
            FindForm().Close();
        }

        private void lvResults_Resize(object sender, EventArgs e)
        {
            colImage.Width = 20;
            colInternalLabel.Width = 135;
            colMediaLabel.Width = 135;
            colMediaPath.Width = lvResults.Width - SystemInformation.VerticalScrollBarWidth - 295;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            CatalogFolderBrowserDialog dlg = new CatalogFolderBrowserDialog();
            dlg.Catalog = theTask.Catalog;
            dlg.SelectedPath = theTask.SearchPath;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                FillSearchPath(dlg.SelectedPath);
            }
        }

        private void FillSearchPath(string vPath)
        {
            CatalogItem ci = theTask.Catalog.GetByVPath(vPath);
            if (ci != null)
            {
                theTask.SearchPath = vPath;
                txtSearchPath.Text = ci.OrigItemPath;
            }
        }
    }
}
