using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.Core.Logging;
using System.IO;
using OPMedia.UI.Controls;
using OPMedia.UI;
using OPMedia.UI.Properties;

namespace OPMedia.UI.Controls.Dialogs
{
    public delegate List<string> FillFavoriteFoldersHandler();
    public delegate bool AddToFavoriteFoldersHandler(string path);

    public class OpenOption
    {
        public string OptionTitle { get; protected set; }
        public object OptionTag { get; protected set; }

        public OpenOption(string s, object o)
        {
            OptionTag = o;
            OptionTitle = s;
        }
    }

    public partial class OPMFileDialog : ToolForm
    {
        ContextMenuStrip _cmsDynamic = new ContextMenuStrip();

        OPMToolTipManager _tt = null;
        OPMToolTipManager _tt2 = null;

        public string Title { get; set; }
        public string Filter { get; set; }
        public string InitialDirectory { get; set; }
        public int FilterIndex { get; set; }
        public string[] FileNames { get; protected set; }

        public event FillFavoriteFoldersHandler FillFavoriteFoldersEvt = null;
        public event AddToFavoriteFoldersHandler AddToFavoriteFolders = null;

        public bool ShowAddToFavorites { get; set; }
        public bool ShowNewFolder { get; set; }

        List<OpenOption> _openDropDownOptions = null;
        public List<OpenOption> OpenDropDownOptions 
        {
            get
            {
                return ((this is OPMOpenFileDialog) && btnOK.ShowDropDown) ? _openDropDownOptions : null;
            }

            set
            {
                if ((this is OPMOpenFileDialog) && value != null && value.Count > 0)
                {
                    _openDropDownOptions = value;
                }

                btnOK.ShowDropDown = ((this is OPMOpenFileDialog) && _openDropDownOptions != null && _openDropDownOptions.Count > 0);
            }
        }

        object _openOption = null;
        public object OpenOption
        {
            get
            {
                return _openOption;
            }
        }

        public string FileName 
        {
            get
            {
                if (FileNames != null && FileNames.Length > 0)
                {
                    string fileName = FileNames[0];

                    OPMSaveFileDialog saveDlg = this as OPMSaveFileDialog;
                    if (saveDlg != null)
                    {
                        string ext = PathUtils.GetExtension(fileName);
                        if (string.IsNullOrEmpty(ext) && saveDlg.AddExtension)
                        {
                            if (!string.IsNullOrEmpty(saveDlg.DefaultExt))
                            {
                                fileName = string.Format("{0}.{1}", fileName, saveDlg.DefaultExt);
                            }
                        }
                    }

                    return fileName;
                }

                return null;
            }
        }

        private Timer _tmrUpdateUi = null;

        private ImageList ilDrives = null;

        private Environment.SpecialFolder[] SpecialFolders = new Environment.SpecialFolder[]
            {
                Environment.SpecialFolder.Desktop,
                Environment.SpecialFolder.Favorites,
                Environment.SpecialFolder.CDBurning,
                Environment.SpecialFolder.MyDocuments,
                Environment.SpecialFolder.Recent,
            };

        public OPMFileDialog()
        {
            InitializeComponent();
            
            this.AllowResize = true;
            this.FilterIndex = -1;

            this.ShowAddToFavorites = false;
            this.ShowNewFolder = (this is OPMSaveFileDialog);

            lvExplorer.SelectFile += new SelectFileEventHandler(lvExplorer_SelectFile);
            lvExplorer.SelectMultipleItems += new SelectMultipleItemsEventHandler(lvExplorer_SelectMultipleItems);
            lvExplorer.SelectDirectory += new SelectDirectoryEventHandler(lvExplorer_SelectDirectory);
            lvExplorer.DoubleClickFile += new DoubleClickFileEventHandler(lvExplorer_DoubleClickFile);

            lvExplorer.LaunchMultipleItems += new LaunchMultipleItemsHandler(lvExplorer_LaunchMultipleItems);

            ilDrives = new ImageList();
            ilDrives.ImageSize = new Size(16, 16);
            ilDrives.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.Load += new EventHandler(OPMFileDialog_Load);

            btnAddToFavorites.Image = Resources.Favorites16;
            btnNewFolder.Image = Resources.New_Folder_Command16;

            _tt = new OPMToolTipManager(btnAddToFavorites);
            _tt2 = new OPMToolTipManager(btnNewFolder);

            btnOK.OnDropDownClicked += new EventHandler(btnOK_OnDropDownClicked);
        }

        void btnOK_OnDropDownClicked(object sender, EventArgs e)
        {
            _cmsDynamic.Items.Clear();
            foreach (OpenOption opt in _openDropDownOptions)
            {
                OPMToolStripMenuItem tsmi = new OPMToolStripMenuItem(opt.OptionTitle);
                tsmi.Tag = opt.OptionTag;
                tsmi.Click += new EventHandler(tsmi_Click);
                _cmsDynamic.Items.Add(tsmi);
            }

            Point p = new Point(0, btnOK.Height);
            _cmsDynamic.Show(btnOK, p, ToolStripDropDownDirection.Default);
        }

        void tsmi_Click(object sender, EventArgs e)
        {
            OPMToolStripMenuItem tsmi = sender as OPMToolStripMenuItem;
            if (tsmi != null)
            {
                _openOption = tsmi.Tag;
                OnOK(sender, e);
                return;
            }
        }

        bool lvExplorer_LaunchMultipleItems(object sender, EventArgs e)
        {
            List<string> paths = new List<string>();

            if (lvExplorer.SelectedPaths != null)
            {
                foreach (string path in lvExplorer.SelectedPaths)
                {
                    if (File.Exists(path))
                        paths.Add(path);
                }
            }

            if (paths.Count > 0)
            {
                FileNames = paths.ToArray();
                OnOK(this, EventArgs.Empty);
                return true;
            }

            return false;
        }

        void lvExplorer_SelectDirectory(object sender, SelectDirectoryEventArgs args)
        {
            FileNames = null;
            ShowFileNames();
        }

        void lvExplorer_DoubleClickFile(object sender, DoubleClickFileEventArgs args)
        {
            bool exists = File.Exists(args.m_strPath);

            if (((this is OPMOpenFileDialog) && exists) ||
                ((this is OPMSaveFileDialog) && (CanSaveFile(args.m_strPath, false))))
            {
                FileNames = new string[] { args.m_strPath };
                ShowFileNames();

                DialogResult = DialogResult.OK;
                Close();
            }
           
        }


        void lvExplorer_SelectFile(object sender, SelectFileEventArgs args)
        {
            FileNames = new string[] { args.m_strPath };
            ShowFileNames();
        }

        void lvExplorer_SelectMultipleItems(object sender, SelectMultipleItemsEventArgs args)
        {
            List<string> files = new List<string>();
            foreach(string fileName in args.m_strPaths)
            {
                if (File.Exists(fileName))
                {
                    files.Add(fileName);
                }
            }

            FileNames = files.ToArray();
            ShowFileNames();
        }

        private void ShowFileNames()
        {
            string s = string.Empty;

            if (FileNames != null)
            {
                if (FileNames.Length == 1)
                {
                    s = Path.GetFileName(FileNames[0]);
                }
                else
                {
                    foreach (string fileName in FileNames)
                    {
                        string name = Path.GetFileName(fileName);
                        s += string.Format("\"{0}\"", name);
                    }
                }
            }
                
            try
            {
                _enableTextChange = false;
                txtFileNames.Text = s;
            }
            finally
            {
                _enableTextChange = true;
            }
        }

        protected override bool AllowCloseOnKeyDown(Keys key)
        {
            if (key == Keys.Escape)
                return true;

            if (key == Keys.Enter)
            {
                if (this.ActiveControl != lvExplorer)
                {
                    return CanCloseOnEnter();
                }
            }

            return false;
        }

        void OPMFileDialog_Load(object sender, EventArgs e)
        {
            SetTitle(this.Title);
            FillDriveList();
            FillFilterList();
            FillSpecialFolders();
            FillFavoriteFolders();

            cmbDiskDrives.SelectedIndexChanged += new EventHandler(cmbDiskDrives_SelectedIndexChanged);
            tsSpecialFolders.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsSpecialFolders_ItemClicked);

            _tmrUpdateUi = new Timer();
            _tmrUpdateUi.Enabled = true;
            _tmrUpdateUi.Interval = 400;
            _tmrUpdateUi.Start();
            _tmrUpdateUi.Tick += new EventHandler(_tmrUpdateUi_Tick);

            lblCurrentPath.Text = this.InitialDirectory;

            if (this is OPMOpenFileDialog)
            {
                lvExplorer.MultiSelect = (this as OPMOpenFileDialog).Multiselect;
            }

            lvExplorer.Path = this.InitialDirectory;

            if (ShowAddToFavorites)
            {
                btnAddToFavorites.MouseHover += new EventHandler(btnAddToFavorites_MouseHover);
            }
            else
            {
                btnAddToFavorites.Visible = false;
            }

            if (ShowNewFolder)
            {
                btnNewFolder.MouseHover += new EventHandler(btnNewFolder_MouseHover);
            }
            else
            {
                btnNewFolder.Visible = false;
            }
        }

        void btnNewFolder_MouseHover(object sender, EventArgs e)
        {
            _tt2.ShowSimpleToolTip(Translator.Translate("TXT_NEWFOLDER"), Resources.New_Folder_Command);
        }

        void btnAddToFavorites_MouseHover(object sender, EventArgs e)
        {
            _tt.ShowSimpleToolTip(Translator.Translate("TXT_FAVORITES_ADD"), Resources.Favorites);
        }

        void _tmrUpdateUi_Tick(object sender, EventArgs e)
        {
            lblCurrentPath.Text = Translator.Translate("TXT_CURRENT_PATH", lvExplorer.Path);

            foreach (ToolStripItem tsi in tsSpecialFolders.Items)
            {
                SpecialFolderButton button = tsi as SpecialFolderButton;
                if (button != null)
                {
                    button.Checked = (button.Path == lvExplorer.Path);
                }
            }
        }

        #region Filter combo box

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _enableTextChange = false;
                txtFileNames.Text = "";
            }
            finally
            {
                _enableTextChange = true;
            }

            FilterItem fi = cmbFilter.SelectedItem as FilterItem;
            if (fi != null)
            {
                lvExplorer.SearchPattern = fi.SearchPattern.Replace("; ", ";");
                lvExplorer.RefreshList(false);

                FilterIndex = cmbFilter.SelectedIndex;
            }
        }

        private void FillFilterList()
        {
            cmbFilter.Items.Clear();

            if (!string.IsNullOrEmpty(this.Filter))
            {
                string[] filterParts = this.Filter.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (filterParts != null)
                {
                    int max = 2 * (filterParts.Length / 2); // This is to ensure that we iterate up to an even number
                    for (int i = 0; i < max; i += 2)
                    {
                        cmbFilter.Items.Add(new FilterItem(filterParts[i], filterParts[i + 1]));
                    }
                }

                if (FilterIndex >= 0 && FilterIndex < cmbFilter.Items.Count)
                {
                    cmbFilter.SelectedIndex = FilterIndex;
                }
                else
                {
                    cmbFilter.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region Drives combo box

        void cmbDiskDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            FolderItem fi = cmbDiskDrives.SelectedItem as FolderItem;
            if (fi != null)
            {
                lvExplorer.Path = fi.Path;
            }

            cmbDiskDrives.Focus();
            cmbDiskDrives.Select();
        }

        private void FillFavoriteFolders()
        {
            if (FillFavoriteFoldersEvt != null)
            {
                List<string> favorites = FillFavoriteFoldersEvt();
                if (favorites != null)
                {
                    foreach (string fav in favorites)
                    {
                        try
                        {
                            string title = Path.GetFileName(fav);
                            OPMToolStripButton btn = new OPMToolStripButton(title);
                            btn.Name = title;
                            btn.Image = ImageProvider.GetIcon(fav, true);
                            btn.ToolTipText = fav;

                            btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                            btn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
                            btn.ImageTransparentColor = System.Drawing.Color.Magenta;
                            btn.AutoSize = true;
                            btn.Tag = fav;
                            btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;

                            tsSpecialFolders.Items.Add(btn);
                        }
                        catch { }
                    }
                }
            }
        }

        private void FillSpecialFolders()
        {
            foreach (Environment.SpecialFolder sf in SpecialFolders)
            {
                try
                {
                    SpecialFolderButton btn = new SpecialFolderButton(sf);
                    tsSpecialFolders.Items.Add(btn);
                }
                catch { }
            }
        }

        private void FillDriveList()
        {
            try
            {
                if (!Directory.Exists(this.InitialDirectory))
                {
                    this.InitialDirectory =
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.Create);
                }

                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

                cmbDiskDrives.Items.Clear();
                ilDrives.Images.Clear();

                foreach (System.IO.DriveInfo di in drives)
                {
                    cmbDiskDrives.Items.Add(new DriveInfoItem(di));
                }

                SelectDrive(this.InitialDirectory);
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void SelectDrive(string dir)
        {
            foreach (object item in cmbDiskDrives.Items)
            {
                FolderItem fi = item as FolderItem;
                if (fi != null)
                {
                    string itemPath = fi.Path.Trim("\\/".ToCharArray());
                    string compareDir = dir.Trim("\\/".ToCharArray());
                    if (compareDir.StartsWith(itemPath))
                    {
                        cmbDiskDrives.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        #endregion

        private void OnOK(object sender, EventArgs e)
        {
            if (CanCloseOnEnter())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool CanCloseOnEnter()
        {
            try
            {
                if (FileNames != null && FileNames.Length > 0)
                {
                    if (this is OPMSaveFileDialog)
                    {
                        if (!CanSaveFile(FileName, false))
                            return false;
                    }

                    return true;
                }

                string x = txtFileNames.Text;

                if (string.IsNullOrEmpty(x))
                {
                    // Force re-applying selected filter
                    cmbFilter_SelectedIndexChanged(null, null);
                }
                else if (x.Contains("*") || x.Contains("?"))
                {
                    lvExplorer.SearchPattern = x.Replace("; ", ";");
                    lvExplorer.RefreshList(false);
                }
                else if (TestForFile(x))
                {
                    return true;
                }
                else
                {
                    TestForFolder(x);
                }
            }
            catch (IOException ex)
            {
                MessageDisplay.Show(ex.Message, Translator.Translate("TXT_APP_NAME"), MessageBoxIcon.Warning);
            }
            catch { }

            return false;
        }

        private void TestForFolder(string x)
        {
            string path = string.Empty;
            if (Directory.Exists(x))
            {
                path = x;
            }
            else if (Directory.Exists(Path.Combine(lvExplorer.Path, x)))
            {
                path = Path.Combine(lvExplorer.Path, x);
            }

            if (Directory.Exists(path))
            {
                SelectDrive(path);
                lvExplorer.Path = path;
            }
            else
            {
                // This will cause throwing FileNotFoundException
                File.Open(x, FileMode.Open);

                //throw new FileNotFoundException(Translator.Translate("TXT_FILE_NOT_FOUND", x));
            }
        }

        private bool TestForFile(string x)
        {
            string file = string.Empty;

            if (Directory.Exists(Path.GetDirectoryName(x)))
            {
                if ((this is OPMSaveFileDialog) || File.Exists(x))
                {
                    file = x;
                }
            }
            else if ((this is OPMSaveFileDialog) || File.Exists(Path.Combine(lvExplorer.Path, x)))
            {
                file = Path.Combine(lvExplorer.Path, x);
            }

            if (this is OPMSaveFileDialog)
            {
                if (CanSaveFile(file, true))
                {
                    FileNames = new string[] { file };
                    return true;
                }
            }

            return false;
        }

        private bool CanSaveFile(string file, bool addExtensionIfRequired)
        {
            bool canSave = false;

            OPMSaveFileDialog dlg = this as OPMSaveFileDialog;
            if (dlg != null)
            {
                string ext = PathUtils.GetExtension(file);
                if (string.IsNullOrEmpty(ext) && dlg.AddExtension)
                {
                    file = string.Format("{0}.{1}", file, dlg.DefaultExt);
                }

                bool exists = File.Exists(file);
                if (exists)
                {
                    canSave = (!dlg.OverwritePrompt || ConfirmOverwrite(file));
                }
                else
                {
                    canSave = (!dlg.CreatePrompt || ConfirmCreate(file));
                }
            }

            return canSave;
        }

        private bool ConfirmOverwrite(string p)
        {
            return (MessageDisplay.Query(Translator.Translate("TXT_CONFIRM_OVERWRITE", p), Translator.Translate("TXT_APP_NAME")) == DialogResult.Yes);
        }

        private bool ConfirmCreate(string p)
        {
            return (MessageDisplay.Query(Translator.Translate("TXT_CONFIRM_CREATE", p), Translator.Translate("TXT_APP_NAME")) == DialogResult.Yes);
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tsSpecialFolders_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OPMToolStripButton tsb = e.ClickedItem as OPMToolStripButton;
            if (tsb != null)
            {
                foreach (ToolStripItem tsi in tsSpecialFolders.Items)
                {
                    OPMToolStripButton button = tsi as OPMToolStripButton;
                    if (button != null)
                    {
                        button.Checked = (button == tsb);
                    }
                }

                SpecialFolderButton sfb = tsb as SpecialFolderButton;
                if (sfb != null)
                {
                    SelectDrive(sfb.Path);
                    lvExplorer.Path = sfb.Path;
                }
                else
                {
                    string path = tsb.Tag as string;
                    if (Directory.Exists(path))
                    {
                        SelectDrive(path);
                        lvExplorer.Path = path;
                    }
                }
            }
        }

        bool _enableTextChange = false;
        private void txtFileNames_TextChanged(object sender, EventArgs e)
        {
            if (_enableTextChange)
            {
                FileNames = null;
            }
        }

        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            if (AddToFavoriteFolders != null)
            {
                if (AddToFavoriteFolders(lvExplorer.Path))
                {
                    try
                    {
                        string title = Path.GetFileName(lvExplorer.Path);
                        OPMToolStripButton btn = new OPMToolStripButton(title);
                        btn.Name = title;
                        btn.Image = ImageProvider.GetIcon(lvExplorer.Path, true);
                        btn.ToolTipText = lvExplorer.Path;

                        btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                        btn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
                        btn.ImageTransparentColor = System.Drawing.Color.Magenta;
                        btn.AutoSize = true;
                        btn.Tag = lvExplorer.Path;
                        btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;

                        tsSpecialFolders.Items.Add(btn);
                    }
                    catch { }
                    
                }
            }
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            lvExplorer.CreateNewFolder();
        }
    }

    public class SpecialFolderButton : OPMToolStripButton
    {
        Environment.SpecialFolder _sf = Environment.SpecialFolder.MyComputer;

        public string Path
        {
            get
            {
                return Environment.GetFolderPath(_sf, Environment.SpecialFolderOption.Create);
            }
        }

        public override string ToString()
        {
            return _sf.ToString();
        }

        private static string GetDisplayName(Environment.SpecialFolder sf)
        {
            string path = Environment.GetFolderPath(sf, Environment.SpecialFolderOption.Create);
            if (Directory.Exists(path))
            {
                return System.IO.Path.GetFileName(path);
            }

            return sf.ToString();
        }

        public SpecialFolderButton(Environment.SpecialFolder sf)
            : base(GetDisplayName(sf))
        {
            _sf = sf;
            
            if (string.IsNullOrEmpty(Path))
                throw new ArgumentException();

            base.Name = GetDisplayName(sf);

            base.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            base.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
            base.ImageTransparentColor = System.Drawing.Color.Magenta;
            base.AutoSize = true;
            base.Tag = _sf;
            base.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;

            base.Image = ImageProvider.GetIcon(Path, true);
        }
    }

    public class DriveInfoItem : FolderItem
    {
        DriveInfo _di = null;

        protected override string DoGetPath()
        {
            return _di.RootDirectory.FullName;
        }

        public override string ToString()
        {
            string name = string.Empty;
            string label = string.Empty;
            string format = string.Empty;
            string freeSpace = string.Empty;
            string ready = string.Empty;

            try { name = _di.Name.ToUpperInvariant(); }
            catch { }

            try { label = _di.VolumeLabel; }
            catch { }

            try { format = _di.DriveFormat; }
            catch { }

            try { freeSpace = ((double)(_di.AvailableFreeSpace) / (1024 * 1024)).ToString("F"); }
            catch { }

            try { ready = (_di.IsReady) ? Translator.Translate("TXT_READY") : Translator.Translate("TXT_NOT_READY"); }
            catch { }

            if (string.IsNullOrEmpty(name))
                name = Translator.Translate("TXT_NO_NAME");
            if (string.IsNullOrEmpty(label))
                label = Translator.Translate("TXT_NO_LABEL");
            if (string.IsNullOrEmpty(format))
                format = Translator.Translate("TXT_FORMAT_UNKNOWN");
            if (string.IsNullOrEmpty(freeSpace))
                freeSpace = "0";
            if (string.IsNullOrEmpty(ready))
                ready = Translator.Translate("TXT_NOT_READY");

            return Translator.Translate("TXT_DRIVE_DESC_FORMAT", name, label, format, freeSpace, ready);
        }

        public DriveInfoItem(DriveInfo di)
        {
            _di = di;
            base.Image = ImageProvider.GetIcon(di.Name.ToUpperInvariant(), false);
        }
    }

    public abstract class FolderItem : ComboBoxItem
    {
        public string Path 
        {
            get
            {
                return DoGetPath();
            }
        }

        protected abstract string DoGetPath();

        public FolderItem()
            : base(null)
        {
        }
    }

    public sealed class FilterItem : ComboBoxItem
    {
        public string DisplayName { get; private set; } 
        public string SearchPattern { get; private set; }

        public override string ToString()
        {
            return DisplayName;
        }

        public FilterItem(string name, string val) : base(null)
        {
            this.DisplayName = name;
            this.SearchPattern = val;
        }
    }

    public sealed class OPMSaveFileDialog : OPMFileDialog
    {
        public bool CreatePrompt { get; set; }
        public bool OverwritePrompt { get; set; }
        public bool AddExtension { get; set; }
        public string DefaultExt { get; set; }

        public OPMSaveFileDialog()
            : base()
        {
            this.Title = "Save file as:";
        }
    }

    public sealed class OPMOpenFileDialog : OPMFileDialog
    {
        public bool Multiselect { get; set; }

        public OPMOpenFileDialog() : base()
        {
            this.Title = "Open file:";
        }
    }
}
