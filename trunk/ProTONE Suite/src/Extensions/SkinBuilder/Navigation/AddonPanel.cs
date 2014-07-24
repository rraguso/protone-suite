using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.Configuration;
using OPMedia.UI.Configuration;
using SkinBuilder.Configuration;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Controls;
using OPMedia.SkinBuilder.Configuration;
using OPMedia.UI.Dialogs;
using SkinBuilder.Themes;
using System.Xml.Linq;
using OPMedia.UI.Controls.Dialogs;
using System.IO;
using OPMedia.Core.Logging;
using OPMedia.Runtime.Addons;
using SkinBuilder.Properties;
using OPMedia.UI.Themes;
using System.Threading;

namespace SkinBuilder.Navigation
{
    public partial class AddonPanel : NavBaseCtl
    {
        ColorConverter cc = new ColorConverter();

        ImageList _il;
        ThemeFile _themeFile = null;

        private System.Windows.Forms.Timer updateUiTimer;

        bool _operationInProgress = false;

        List<string> _recentFiles = new List<string>();

        public override List<string> HandledFileTypes
        {
            get
            {
                return new List<string>(new string[] { "ctx" });
            }
        }

        enum NodeIndexes
        {
            ThemeFile = 0,
            Theme,
            ColorThemeElement,
            NumericThemeElement
        }

        public AddonPanel()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);

            updateUiTimer = new System.Windows.Forms.Timer();
            updateUiTimer.Enabled = true;
            updateUiTimer.Interval = 1000;
            updateUiTimer.Start();
            updateUiTimer.Tick += new EventHandler(updateUiTimer_Tick);

            _il = new ImageList();
            _il.ImageSize = new System.Drawing.Size(16, 16);
            _il.ColorDepth = ColorDepth.Depth32Bit;
            _il.TransparentColor = Color.Magenta;
            tvThemes.ImageList = _il;

            tvThemes.AfterSelect += new TreeViewEventHandler(tvThemes_AfterSelect);
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            OnPerformTranslation();
        }

        protected override BaseCfgPanel GetBaseCfgPanel()
        {
            return new SkinBuilderCfgPanel();
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Translator.TranslateControl(this, DesignMode);
            Translator.TranslateToolStrip(toolStripMain, DesignMode);
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (FindForm() != null && !args.Handled && ContainsFocus)
            {
                switch (args.cmd)
                {
                    case OPMShortcut.CmdGenericNew:
                        CreateNewTheme();
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericOpen:
                        OpenTheme();
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericSave:
                        HandleAction(ToolAction.ToolActionSave);
                        args.Handled = true;
                        break;

                     case OPMShortcut.CmdGenericDelete:
                        HandleAction(ToolAction.ToolActionDeleteTheme);
                        args.Handled = true;
                        break;
                }
            }
        }

        void updateUiTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateUiTimer.Stop();

                if (SkinBuilderConfiguration.RememberRecentFiles)
                {
                    tsbOpen.DropDownButtonWidth = 15;
                }
                else
                {
                    tsbOpen.DropDownButtonWidth = 1;
                    tsbOpen.DropDownItems.Clear();
                }

                SuspendLayout();
                OnUpdateUi(toolStripMain.Items);
                ResumeLayout();
            }
            finally
            {
                updateUiTimer.Start();
            }
        }

        private void OnToolAction(object sender, EventArgs e)
        {
            HandleToolAction(sender as ToolStripItem);
        }

        private void HandleToolAction(ToolStripItem tsi)
        {
            if (tsi == null || string.IsNullOrEmpty(tsi.Tag as string))
                return;

            ToolAction action = (ToolAction)Enum.Parse(typeof(ToolAction),
                   tsi.Tag as string);

            HandleAction(action);
        }

        private void HandleAction(ToolAction action)
        {
            if (!IsToolActionEnabled(action))
                return;

            switch (action)
            {
                case ToolAction.ToolActionNew:
                    CreateNewTheme();
                    break;
                case ToolAction.ToolActionOpen:
                    OpenTheme();
                    break;

                case ToolAction.ToolActionSave:
                    if (_themeFile != null)
                    {
                        if (_themeFile.IsSaved)
                            SaveThemeNoDialog();
                        else
                            // New theme, never saved before.
                            SaveThemeWithDialog();
                    }
                    break;

                case ToolAction.ToolActionSaveAs:
                    SaveThemeWithDialog();
                    break;

                case ToolAction.ToolActionNewTheme:
                    break;

                case ToolAction.ToolActionDeleteTheme:
                    break;
            }
        }

        private bool IsToolActionEnabled(ToolAction action)
        {
            if (_operationInProgress)
                return false;

            for (int i = 0; i < toolStripMain.Items.Count; i++)
            {
                ToolStripItem btn = toolStripMain.Items[i] as ToolStripItem;

                if (btn == null ||
                    string.IsNullOrEmpty(btn.Tag as string))
                {
                    // Not an action button, continue.
                    continue;
                }

                if ((btn.Tag as string).ToLowerInvariant() == action.ToString().ToLowerInvariant())
                {
                    return btn.Enabled;
                }
            }

            return true;
        }

        private void OnUpdateUi(ToolStripItemCollection tsic)
        {
            if (tsic == null)
                return;

            for (int i = 0; i < tsic.Count; i++)
            {
                ToolStripItem btn = tsic[i] as ToolStripItem;

                if (btn == null)
                    continue;

                btn.Enabled = true;

                string tag = btn.Tag as string;
                if (string.IsNullOrEmpty(tag))
                {
                    continue;
                }

                ToolAction action = ToolAction.ToolActionNothing;
                try
                {
                    action = (ToolAction)Enum.Parse(typeof(ToolAction), tag);
                }
                catch
                {
                    action = ToolAction.ToolActionNothing;
                }

                if (action == ToolAction.ToolActionNothing)
                {
                    continue;
                }

                switch (action)
                {
                    case ToolAction.ToolActionNew:
                        BuildMenuText(btn, "TXT_NEW", string.Empty, OPMShortcut.CmdGenericNew);
                        break;

                    case ToolAction.ToolActionOpen:
                        BuildMenuText(btn, "TXT_OPEN", string.Empty, OPMShortcut.CmdGenericOpen);
                        break;

                    case ToolAction.ToolActionSave:
                        BuildMenuText(btn, "TXT_SAVE", string.Empty, OPMShortcut.CmdGenericSave);
                        btn.Enabled = (_themeFile != null);
                        break;

                    case ToolAction.ToolActionSaveAs:
                        BuildMenuText(btn, "TXT_SAVE_AS", string.Empty, OPMShortcut.CmdOutOfRange);
                        btn.Enabled = (_themeFile != null);
                        break;

                    case ToolAction.ToolActionNewTheme:
                        BuildMenuText(btn, "TXT_NEW_THEME", string.Empty, OPMShortcut.CmdOutOfRange);
                        btn.Enabled = (_themeFile != null);
                        break;

                    case ToolAction.ToolActionDeleteTheme:
                        BuildMenuText(btn, "TXT_DELETE_THEME", string.Empty, OPMShortcut.CmdOutOfRange);
                        //TODO fix btn.Enabled = (_themeFile != null && tvThemes.SelectedItems.Count == 1);
                        break;
                }
            }

        }

        private void BuildMenuText(ToolStripItem tsm, string tag, string param, OPMShortcut command)
        {
            tsm.ToolTipText =
                (tsm.Enabled && !string.IsNullOrEmpty(param)) ?
                Translator.Translate(tag) + ": " + param :
                Translator.Translate(tag);
            tsm.Text = Translator.Translate(tag);

            if (tsm is OPMToolStripMenuItem)
            {
                string text = tsm.ToolTipText;
                if (text.Length > 45)
                {
                    tsm.Text = text.Substring(0, 45) + "...";
                }
                else
                {
                    tsm.ToolTipText = string.Empty;
                    tsm.Text = text;
                }

                if (command != OPMShortcut.CmdOutOfRange)
                {
                    (tsm as OPMToolStripMenuItem).ShortcutKeyDisplayString =
                        ShortcutMapper.GetShortcutString(command);
                }
            }
            else
            {
                if (command != OPMShortcut.CmdOutOfRange)
                {
                    tsm.ToolTipText +=
                        string.Format(" ({0})", ShortcutMapper.GetShortcutString(command));
                }

                if (command == OPMShortcut.CmdGenericOpen && _recentFiles.Count > 0 && SkinBuilderConfiguration.RememberRecentFiles)
                {
                    tsm.ToolTipText += "\r\n" + Translator.Translate("TXT_OPENRECENTFILEDROPDOWN");
                }
            }
        }

        private void OpenTheme()
        {
            tsbOpen.HideDropDown();

            OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
            dlg.Title = Translator.Translate("TXT_OPENTHEMEFILE");
            dlg.Filter = Translator.Translate("TXT_THEMEFILE_FILTER");
            dlg.InitialDirectory = SkinBuilderConfiguration.LastOpenedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SkinBuilderConfiguration.LastOpenedFolder = Path.GetDirectoryName(dlg.FileName);
                OpenFileWithCheck(dlg.FileName, false);
            }
        }

        private void OpenFileWithCheck(string fileName, bool openRecent)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            fileName = fileName.ToLowerInvariant();

            if (File.Exists(fileName))
            {
                LoadTheme(fileName);
            }
            else
            {
                if (_recentFiles.Contains(fileName))
                {
                    _recentFiles.Remove(fileName);
                }

                string mainMessage = Translator.Translate("TXT_FILE_NOT_FOUND", fileName);
                if (openRecent)
                {
                    mainMessage += "\r\n";
                    mainMessage += Translator.Translate("TXT_RECENT_FILE_REMOVED");
                }

                ErrorDispatcher.DispatchError(mainMessage, Translator.Translate("TXT_CAUTION"));
            }
        }

        private void LoadTheme(string themeFile)
        {
            try
            {
                _themeFile = new ThemeFile(themeFile);
                DisplayThemeFile();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                _themeFile = null;
            }
        }

        private void CreateNewTheme()
        {
            try
            {
                _themeFile = new ThemeFile();
                DisplayThemeFile();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                _themeFile = null;
            }
        }

        private void SaveThemeWithDialog()
        {
            if (_themeFile != null)
            {
                OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
                dlg.Title = Translator.Translate("TXT_SAVETHEMEFILE");
                dlg.Filter = Translator.Translate("TXT_THEMEFILE_FILTER");
                dlg.DefaultExt = "thm";
                dlg.InitialDirectory = SkinBuilderConfiguration.LastOpenedFolder;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SkinBuilderConfiguration.LastOpenedFolder = Path.GetDirectoryName(dlg.FileName);

                    string ext = PathUtils.GetExtension(dlg.FileName);

                    Save(dlg.FileName);

                    DisplayThemeFile();
                }
            }
        }

        private void SaveThemeNoDialog()
        {
            if (_themeFile != null)
                Save(_themeFile.FileName);
        }

        private void Save(string themeFile)
        {
            if (_themeFile != null)
            {
                try
                {
                    _operationInProgress = true;
                    RaiseNavigationAction(NavActionType.ActionSaveProperties, new List<string>());
                    _themeFile.SaveToFile(themeFile);
                }
                finally
                {
                    _operationInProgress = false;
                }
            }
        }

        private void DisplayThemeFile()
        {
            tvThemes.Nodes.Clear();
            _il.Images.Clear();

            if (_themeFile != null)
            {
                _il.Images.Add(ImageProvider.GetShell32Icon(Shell32Icon.GenericFileSystem, false));
                _il.Images.Add(Resources.ThemeNode);
                _il.Images.Add(Resources.ColorNode);
                _il.Images.Add(Resources.NumericNode);

                TreeNode themeFileNode = new TreeNode();
                themeFileNode.Text = _themeFile.FileName;
                themeFileNode.ImageIndex = themeFileNode.SelectedImageIndex = (int)NodeIndexes.ThemeFile;
                themeFileNode.Tag = _themeFile;
                themeFileNode.NodeFont = ThemeManager.NormalBoldFont;

                if (_themeFile.Themes != null)
                {
                    foreach (var theme in _themeFile.Themes)
                    {
                        TreeNode themeNode = new TreeNode(theme.Key);
                        themeNode.ImageIndex = themeNode.SelectedImageIndex = (int)NodeIndexes.Theme;
                        themeNode.Tag = theme;
                        themeNode.NodeFont = ThemeManager.NormalBoldFont;

                        if (theme.Value.ThemeElements != null)
                        {
                            foreach (var themeElement in theme.Value.ThemeElements)
                            {
                                bool isColorNode = themeElement.Key.ToLowerInvariant().Contains("color");

                                TreeNode themeElementNode = new TreeNode(themeElement.Key);
                                themeElementNode.Tag = themeElement;
                                themeElementNode.NodeFont = ThemeManager.NormalFont;

                                if (isColorNode)
                                {
                                    themeElementNode.ForeColor = ThemeManager.ForeColor;

                                    Color c = (Color)cc.ConvertFromInvariantString(themeElement.Value);
                                    Bitmap bmp = CreateColorBitmap(c);
                                    if (bmp != null)
                                    {
                                        themeElementNode.ImageIndex = themeElementNode.SelectedImageIndex =
                                            _il.Images.Add(bmp, Color.Magenta);
                                    }

                                    themeElementNode.Text = string.Format("{0} [{1}]", themeElement.Key, themeElement.Value);
                                }
                                else
                                {
                                    themeElementNode.ForeColor = ThemeManager.HighlightColor;
                                    themeElementNode.ImageIndex = themeElementNode.SelectedImageIndex = (int)NodeIndexes.NumericThemeElement;
                                }

                                themeNode.Nodes.Add(themeElementNode);
                            }
                        }

                        themeFileNode.Nodes.Add(themeNode);
                    }
                }

                tvThemes.Nodes.Add(themeFileNode);
            }
        }

        public override void Reload(object target)
        {
            try
            {
                NavigationReloadArguments args = target as NavigationReloadArguments;
                if (args != null && args.OldThemeName.Length > 0)
                {
                    if (args.OldThemeElementName.Length > 0)
                    {
                        TreeNode tn = FindThemeElementNode(args.OldThemeName, args.OldThemeElementName);
                        if (tn != null)
                        {
                            // Some action was done on a theme element.
                            if (args.OldThemeElementName != args.NewThemeElementName)
                            {
                                // The theme element was renamed.
                                tn.Text = args.NewThemeElementName;
                            }
                            else
                            {
                                // The value of the theme element was changed.
                                bool isColorNode = args.NewThemeElementName.ToLowerInvariant().Contains("color");
                                if (isColorNode)
                                {
                                    tn.ForeColor = ThemeManager.ForeColor;
                                    string value = _themeFile.Themes[args.OldThemeName].ThemeElements[args.NewThemeElementName];

                                    Color c = (Color)cc.ConvertFromInvariantString(value);
                                    Bitmap bmp = CreateColorBitmap(c);
                                    if (bmp != null)
                                    {
                                        tn.ImageIndex = tn.SelectedImageIndex =
                                            _il.Images.Add(bmp, Color.Magenta);
                                    }

                                    tn.Text = string.Format("{0} [{1}]", args.NewThemeElementName, value);
                                }
                                else
                                {
                                    tn.ForeColor = ThemeManager.HighlightColor;
                                    tn.ImageIndex = tn.SelectedImageIndex = (int)NodeIndexes.NumericThemeElement;
                                    tn.Text = args.NewThemeElementName;
                                }
                            }

                            tn.Tag = new KeyValuePair<string, string>(args.NewThemeElementName,
                                _themeFile.Themes[args.OldThemeName].ThemeElements[args.NewThemeElementName]);
                        }
                    }
                    else if (args.OldThemeName != args.NewThemeName)
                    {
                        // The theme was renamed.
                        TreeNode tn = FindThemeNode(args.OldThemeName);
                        if (tn != null)
                        {
                            tn.Text = args.NewThemeName;
                            tn.Tag = new KeyValuePair<string, Theme>(args.NewThemeName, _themeFile.Themes[args.NewThemeName]);
                        }
                    }
                }

                tvThemes.Invalidate();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchException(ex);
                DisplayThemeFile();
            }
        }

        private TreeNode FindThemeElementNode(string themeName, string themeElementName)
        {
            TreeNode themeNode = FindThemeNode(themeName);
            if (themeNode != null && themeNode.Nodes != null)
            {
                foreach (TreeNode tn in themeNode.Nodes)
                {
                    if (tn.Text.StartsWith(themeElementName))
                        return tn;
                }
            }

            return null;
        }

        private TreeNode FindThemeNode(string themeName)
        {
            return tvThemes.FindNode(themeName, false);
        }

        private Bitmap CreateColorBitmap(Color c)
        {
            Bitmap bmp = new Bitmap(16, 16);

            int w = 1;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (i < w || j < w || i > 16 - w || j > 16 - w)
                        bmp.SetPixel(i, j, Color.Magenta);
                    else if (i == w || j == w || i == 16 - w || j == 16 - w)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                        bmp.SetPixel(i, j, c);
                }
            }

            return bmp;
        }

        void tvThemes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> paths = new List<string>();
            paths.Add(".node");

            List<object> args = new List<object>();
            args.Add(_themeFile);

            if (tvThemes.SelectedNode != null)
            {
                if (tvThemes.SelectedNode.Parent != null &&
                    tvThemes.SelectedNode.Tag is KeyValuePair<string, string>)
                {
                    args.Add(tvThemes.SelectedNode.Parent.Tag);
                }

                args.Add(tvThemes.SelectedNode.Tag);
            }

            RaiseNavigationAction(NavActionType.ActionSelectFile, paths, args);
        }

        
    }

    internal class NavigationReloadArguments
    {
        public string OldThemeName { get; set; }
        public string OldThemeElementName { get; set; }
        public string NewThemeName { get; set; }
        public string NewThemeElementName { get; set; }

        public NavigationReloadArguments()
        {
            OldThemeName = NewThemeName = OldThemeElementName = NewThemeElementName = string.Empty;
        }
    }

    internal enum ToolAction : int
    {
        ToolActionNothing = -1,

        ToolActionNew = 0,
        ToolActionOpen,
        ToolActionSave,
        ToolActionSaveAs,

        ToolActionNewTheme,
        ToolActionDeleteTheme,
    }
}
