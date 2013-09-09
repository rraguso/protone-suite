#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	AddonPanel.cs
#endregion

#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime;
using System.IO;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.Addons.Builtin.ID3Prop;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.UI.Wizards;
using OPMedia.Addons.Builtin.FileExplorer.SearchWizard;
using OPMedia.Addons.Builtin.FileExplorer.SearchWizard.Controls;
using OPMedia.Core.Logging;
using OPMedia.Addons.Builtin.Properties;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.UI;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Runtime.Addons;
using OPMedia.Runtime.Addons.ActionManagement;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.FileTasks;
using OPMedia.UI.Generic;
using System.Diagnostics;

using OPMedia.Runtime.Addons.Configuration;
using OPMedia.UI.Configuration;
using OPMedia.Core.GlobalEvents;
using OPMedia.Addons.Builtin.FileExplorer.FileOperations.Forms;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.FileOperations.Tasks;

#endregion

namespace OPMedia.Addons.Builtin.FileExplorer
{
    /// <summary>
    /// The panel for the File Explorer addon.
    /// </summary>
    public partial class AddonPanel : NavBaseCtl
    {
        private bool disableEvents = false;
        
        //private bool drivesDisplayed = false;

        private ImageList ilDrives = null;
        private FileTaskForm _fileTask = null;

        private ImageList ilFavorites = null;


        private Timer updateUiTimer;
        private Timer previewTimer;

        public static bool IsRequired { get { return true; } }

        public override string GetHelpTopic()
        {
            return "FileExplorer";
        }

        public AddonPanel() : base()
        {
            InitializeComponent();

            opmShellList.MultiSelect = true;
            
            opmShellList.Clear();

            ilAddon.Images.Add(Resources.FileExplorer);

            this.tsbFavorites.Image = OPMedia.UI.Properties.Resources.Favorites;
            this.tsmiFavorites.Image = OPMedia.UI.Properties.Resources.Favorites16;

            this.AddonImage = Resources.FileExplorer;
            this.SmallAddonImage = Resources.FileExplorer16;

            updateUiTimer = new Timer();
            updateUiTimer.Enabled = true;
            updateUiTimer.Interval = 500;
            updateUiTimer.Start();
            updateUiTimer.Tick += new EventHandler(updateUiTimer_Tick);


            previewTimer = new Timer();
            previewTimer.Stop();
            previewTimer.Tick += new EventHandler(previewTimer_Tick);

            ilDrives = new ImageList();
            ilDrives.ImageSize = new Size(16, 16);
            ilDrives.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            ilFavorites = new ImageList();
            ilFavorites.ImageSize = new Size(16, 16);
            ilFavorites.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilFavorites.Images.Add(Resources.none);

            toolStripMain.ImageList = ilDrives;

            opmShellList.KeyDown += new KeyEventHandler(opmShellList_KeyDown);
            opmShellList.QueryLinkedFiles += new QueryLinkedFilesHandler(OnQueryLinkedFiles);
            opmShellList.ItemRenamed += new ItemRenameHandler(OnRenamed);

            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);
            this.Leave += new EventHandler(AddonPanel_Leave);
        }

        List<string> OnQueryLinkedFiles(string path)
        {
            FEFileTaskSupport support = new FEFileTaskSupport(null);

            FileInfo fi = new FileInfo(path);
            if (fi != null && fi.Exists)
            {
                return support.GetLinkedFiles(fi);
            }

            return null;
        }

        void OnRenamed(string newPath)
        {
            AddonHostForm masterForm = FindForm() as AddonHostForm;
            if (masterForm != null)
            {
                SelectFileEventArgs args = new SelectFileEventArgs();
                args.m_strPath = newPath;
                OnSelectFile(this, args);
            }
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (FindForm() != null && !args.Handled && ContainsFocus)
            {
                switch (args.cmd)
                {
                    case OPMShortcut.CmdGenericRename:
                        HandleAction(ToolAction.ToolActionRename);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericPaste:
                        HandleAction(ToolAction.ToolActionPaste);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericCut:
                        HandleAction(ToolAction.ToolActionCut);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericCopy:
                        HandleAction(ToolAction.ToolActionCopy);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericDelete:
                        HandleAction(ToolAction.ToolActionDelete);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdSwitchWindows:
                        CancelAutoPreview();
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdChangeDisk:
                        tsbDrives.ShowDropDown();
                        tsbDrives.Select();

                        if (tsbDrives.DropDownItems.Count > 0)
                        {
                            tsbDrives.DropDownItems[0].Select();
                        }

                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdFavManager:
                        HandleAction(ToolAction.ToolActionFavoritesManage);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdNavigateBack:
                        HandleAction(ToolAction.ToolActionBack);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdNavigateForward:
                        HandleAction(ToolAction.ToolActionFwd);
                        args.Handled = true;
                        break;

                    // Already implemented inside the list
                    //case OPMShortcut.CmdNavigateUp:
                    //    HandleAction(ToolAction.ToolActionUp);
                    //    args.Handled = true;
                    //    break;

                    case OPMShortcut.CmdGenericSearch:
                        HandleAction(ToolAction.ToolActionSearch);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdGenericRefresh:
                        HandleAction(ToolAction.ToolActionReload);
                        args.Handled = true;
                        break;

                    case OPMShortcut.CmdID3Wizard:
                        HandleAction(ToolAction.ToolActionID3Wizard);
                        args.Handled = true;
                        break;
                }
            }

            //Application.DoEvents();

        }

        void AddonPanel_Leave(object sender, EventArgs e)
        {
            if (previewTimer.Enabled)
            {
                CancelAutoPreview();
            }
        }

        void CancelAutoPreview()
        {
            previewTimer.Stop();
            RaiseNavigationAction(NavActionType.ActionCancelAutoPreview, null, new object());
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Translator.TranslateControl(this, DesignMode);
            Translator.TranslateToolStrip(toolStripMain, DesignMode);
            Translator.TranslateToolStrip(contextMenuStrip, DesignMode);
            Translator.TranslateToolStripItem(tsbFavorites, DesignMode);
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            OnPerformTranslation();
        }


        void opmShellList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Modifiers)
            {
                case Keys.None:
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Escape:
                                previewTimer.Stop();
                                if (AppSettings.FEPreviewTimer > 0)
                                {
                                    RaiseNavigationAction(NavActionType.ActionCancelAutoPreview, null, null);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        #region Navigation events
        public override void OnActiveStateChanged(bool isActive)
        {
            updateUiTimer.Enabled = isActive;
        }

        void updateUiTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateUiTimer.Stop();

                SuspendLayout();

                OnUpdateUi(toolStripMain.Items);
                OnUpdateUi(contextMenuStrip.Items);

                OnUpdateUi(tsbFavorites.DropDownItems);
                OnUpdateUi(tsmiFavorites.DropDownItems);

                DisplayCurrentPath();

                ResumeLayout();
            }
            finally
            {
                updateUiTimer.Start();
            }
        }

        void previewTimer_Tick(object sender, EventArgs e)
        {
            previewTimer.Stop();

            List<string> paths = opmShellList.SelectedPaths;
            if (paths != null && paths.Count > 0)
            {
                RaiseNavigationAction(NavActionType.ActionDoubleClickFile, paths);
            }
        }


        private void OnLoad(object sender, EventArgs e)
        {
            ChangePath(AppSettings.LastExploredFolder);
        }


        private void OnDoubleClickDirectory(object sender, DoubleClickDirectoryEventArgs args)
        {
            Application.UseWaitCursor = (true);

            if (!disableEvents)
            {
                disableEvents = true;
                string folderPath = args.m_strPath;
                DisplayCurrentPath();
                disableEvents = false;
            }

            Application.UseWaitCursor = (false);
        }

        private void OnDoubleClickFile(object sender, DoubleClickFileEventArgs args)
        {
            CancelAutoPreview();

            if (args != null)
            {
                List<string> paths = new List<string>();
                paths.Add(args.m_strPath);
                
                RaiseNavigationAction(NavActionType.ActionDoubleClickFile, paths);
            }
        }

        private void OnSelectDirectory(object sender, SelectDirectoryEventArgs args)
        {
            CancelAutoPreview();

            if (args != null)
            {
                List<string> paths = new List<string>();
                paths.Add(args.m_strPath);
                RaiseNavigationAction(NavActionType.ActionSelectDirectory, paths);
            }
        }

        private void OnSelectFile(object sender, SelectFileEventArgs args)
        {
            CancelAutoPreview();

            if (args != null)
            {
                List<string> paths = new List<string>();
                paths.Add(args.m_strPath);
                RaiseNavigationAction(NavActionType.ActionSelectFile, paths);

                if (paths != null && 
                    paths.Count == 1 &&
                    !string.IsNullOrEmpty(paths[0]))
                {
                    ActionRequest req = new ActionRequest();
                    req.ActionType = ActionType.ActionBeginPreview;
                    req.Items = paths;

                    bool autoPreviewAvailable = false;
                    if (AddonsCore.Instance.CanDispatchAction(req, ref autoPreviewAvailable))
                    {
                        if (autoPreviewAvailable && AppSettings.FEPreviewTimer > 0)
                        {
                            previewTimer.Interval = (int)(AppSettings.FEPreviewTimer * 1000);
                            previewTimer.Start();
                            RaiseNavigationAction(NavActionType.ActionPrepareAutoPreview, null, null);
                        }
                        else
                        {
                            RaiseNavigationAction(NavActionType.ActionNotifyPreviewableItem, null, null);
                        }
                    }
                    else
                    {
                        RaiseNavigationAction(NavActionType.ActionNotifyNonPreviewableItem, null, null);
                    }
                }
            }
        }

        private void OnSelectMultipleItems(object sender, SelectMultipleItemsEventArgs args)
        {
            CancelAutoPreview();

            if (args != null)
            {
                RaiseNavigationAction(NavActionType.ActionSelectMultipleItems, args.m_strPaths);
            }
        }
        #endregion

        #region Helpers
        

        private void ChangePath(string path)
        {
            Application.UseWaitCursor = (true);
            if (!disableEvents)
            {
                disableEvents = true;
                opmShellList.Path = path;
                DisplayCurrentPath();

                disableEvents = false;
            }
            Application.UseWaitCursor = (false);
        }

        string _prevPath = string.Empty;
        private void DisplayCurrentPath()
        {
            _prevPath = opmShellList.Path;

            Image img = null;
            string text = null;

            try
            {
                img = ImageProvider.GetIcon(opmShellList.Path, false);
                text = Translator.Translate("TXT_CURRENT_PATH", opmShellList.Path);
            }
            catch
            {
                img = null;
                text = null;
            }

            EventDispatch.DispatchEvent(EventNames.SetMainStatusBar, text, img);
        }

        private void NavigateUp()
        {
            try
            {
                if (!opmShellList.IsInDriveRoot)
                {
                    opmShellList.Path = PathUtils.ParentDir;
                    DisplayCurrentPath();
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Handle tool actions (toolbar/menu)
        private void OnToolAction(object sender, EventArgs e)
        {
            HandleToolAction(sender as ToolStripItem);
        }

        private void HandleToolAction(ToolStripItem tsi)
        {
            try
            {
                if (tsi == null || string.IsNullOrEmpty(tsi.Tag as string))
                    return;

                ToolAction action = (ToolAction)Enum.Parse(typeof(ToolAction),
                       tsi.Tag as string);

                HandleAction(action);
            }
            catch
            {
            }
        }


        private void HandleAction(ToolAction action)
        {
            try
            {
                if (!IsToolActionEnabled(action))
                    return;

                updateUiTimer.Stop();

                List<string> selItems = opmShellList.SelectedPaths;
                switch (action)
                {
                    case ToolAction.ToolActionBack:
                        opmShellList.ExploreBack();
                        return;

                    case ToolAction.ToolActionFwd:
                        opmShellList.ExploreForward();
                        return;

                    case ToolAction.ToolActionUp:
                        NavigateUp();
                        return;

                    case ToolAction.ToolActionSearch:
                        SearchWizard.Tasks.Task taskSearch = new SearchWizard.Tasks.Task();
                        taskSearch.SearchPath = opmShellList.Path;
                        if (SearchWizardMain.Execute(taskSearch) == DialogResult.OK)
                        {
                            switch (taskSearch.Action)
                            {
                                case ToolAction.ToolActionProTONEEnqueue:
                                    {
                                        if (taskSearch.MatchingItems.Count > 0)
                                        {
                                            RemoteControlHelper.SendPlayerCommand(
                                                OPMedia.Runtime.ProTONE.RemoteControl.CommandType.EnqueueFiles,
                                                taskSearch.MatchingItems.ToArray());
                                        }
                                    }
                                    break;

                                case ToolAction.ToolActionProTONEPlay:
                                    {
                                        if (taskSearch.MatchingItems.Count > 0)
                                        {
                                            RemoteControlHelper.SendPlayerCommand(
                                                OPMedia.Runtime.ProTONE.RemoteControl.CommandType.PlayFiles,
                                                taskSearch.MatchingItems.ToArray());
                                        }
                                    }
                                    break;

                                case ToolAction.ToolActionJumpToItem:
                                    if (taskSearch.MatchingItems.Count > 0)
                                    {
                                        opmShellList.JumpToItem(taskSearch.MatchingItems[0], false);
                                    }
                                    break;

                                case ToolAction.ToolActionID3Wizard:
                                    {
                                        ID3Prop.ID3Wizard.Task taskID3 = new ID3Prop.ID3Wizard.Task();
                                        foreach (string item in taskSearch.MatchingItems)
                                        {
                                            if (Directory.Exists(item))
                                            {
                                                taskID3.Files.AddRange(Directory.EnumerateFiles(item, "*.mp?", SearchOption.AllDirectories));
                                            }
                                            else if (File.Exists(item))
                                            {
                                                taskID3.Files.Add(item);
                                            }
                                        }
                                        
                                        ID3WizardMain.Execute(FindForm(), taskID3);
                                        ReloadProperties();
                                    }
                                    break;

                                case ToolAction.ToolActionCopy:
                                    _fileTask = new FEFileTaskForm(FileTaskType.Copy, taskSearch.MatchingItems, opmShellList.Path);
                                    break;

                                case ToolAction.ToolActionCut:
                                    _fileTask = new FEFileTaskForm(FileTaskType.Move, taskSearch.MatchingItems, opmShellList.Path);
                                    break;

                                case ToolAction.ToolActionDelete:
                                    _fileTask = new FEFileTaskForm(FileTaskType.Delete, taskSearch.MatchingItems, opmShellList.Path);
                                    break;

                                case ToolAction.ToolActionLaunch:
                                    if (taskSearch.MatchingItems.Count > 0)
                                    {
                                        opmShellList.OpenItem(taskSearch.MatchingItems[0]);
                                    }
                                    break;
                            }
                        }
                        return;

                    case ToolAction.ToolActionReload:
                        GlobalReload();
                        return;

                    case ToolAction.ToolActionID3Wizard:
                        {
                            ID3Prop.ID3Wizard.Task taskID3 = new ID3Prop.ID3Wizard.Task();
                            foreach(string item in opmShellList.SelectedPaths)
                            {
                                if (Directory.Exists(item))
                                {
                                    taskID3.Files.AddRange(Directory.EnumerateFiles(item, "*.mp?", SearchOption.AllDirectories));
                                }
                                else if (File.Exists(item))
                                {
                                    taskID3.Files.Add(item);
                                }
                            }
                            
                            ID3WizardMain.Execute(FindForm(), taskID3);
                            ReloadProperties();
                        }
                        return;

                    case ToolAction.ToolActionCopy:
                        _fileTask = new FEFileTaskForm(FileTaskType.Copy, opmShellList.SelectedPaths, opmShellList.Path);
                        return;

                    case ToolAction.ToolActionCut:
                        _fileTask = new FEFileTaskForm(FileTaskType.Move, opmShellList.SelectedPaths, opmShellList.Path);
                        return;

                    case ToolAction.ToolActionPaste:
                        if (_fileTask != null)
                        {
                            _fileTask.DestFolder = opmShellList.Path;
                        }
                        break;

                    case ToolAction.ToolActionDelete:
                        if (!opmShellList.IsInEditMode)
                        {
                            _fileTask = new FEFileTaskForm(FileTaskType.Delete, opmShellList.SelectedPaths, opmShellList.Path);
                        }
                        break;

                    case ToolAction.ToolActionRename:
                        Rename();
                        return;

                    case ToolAction.ToolActionFavoritesAdd:
                        {
                            List<string> favorites = new List<string>(SuiteConfiguration.GetFavoriteFolders("FavoriteFolders"));
                            if (favorites.Contains(opmShellList.Path))
                                return;

                            favorites.Add(opmShellList.Path);
                            SuiteConfiguration.SetFavoriteFolders(favorites, "FavoriteFolders");
                        }
                        return;

                    case ToolAction.ToolActionFavoritesManage:
                        new FavoriteFoldersManager("FavoriteFolders").ShowDialog();
                        return;

                    case ToolAction.ToolActionProTONEEnqueue:
                        {
                            List<String> items = opmShellList.SelectedPaths;
                            if (items.Count > 0)
                            {
                                RemoteControlHelper.SendPlayerCommand(
                                    OPMedia.Runtime.ProTONE.RemoteControl.CommandType.EnqueueFiles,
                                    items.ToArray());
                            }
                        }
                        break;

                    case ToolAction.ToolActionProTONEPlay:
                        {
                            List<String> items = opmShellList.SelectedPaths;
                            if (items.Count > 0)
                            {
                                RemoteControlHelper.SendPlayerCommand(
                                    OPMedia.Runtime.ProTONE.RemoteControl.CommandType.PlayFiles,
                                    items.ToArray());
                            }
                        }
                        break;

                }

                if (_fileTask != null)
                {
                    RaiseNavigationAction(NavActionType.ActionCancelAutoPreview, null, null);

                    try
                    {
                        opmShellList.EnableAutoRefresh(false);
                        DialogResult dlg = _fileTask.ShowDialog();
                    }
                    finally
                    {
                        if (_fileTask.RequiresRefresh)
                        {
                            opmShellList.RefreshList(true);
                        }

                        opmShellList.EnableAutoRefresh(true);
                        _fileTask = null;
                    }
                }
            }
            finally
            {
                updateUiTimer.Start();
            }
        }

        private void Rename()
        {
            opmShellList.Rename();
            ReloadProperties();
        }

        public override void Reload(object target)
        {
            opmShellList.RefreshList(true);
        }

        #endregion

        #region Update UI (toolbar/menu)
        private void OnUpdateUi(ToolStripItemCollection tsic)
        {
            if (tsic == null)
                return;

            bool playerInstalled = File.Exists(SuiteConfiguration.PlayerInstallationPath);
            tsmiSepProTONE.Visible = tsmiProTONEEnqueue.Visible = tsmiProTONEPlay.Visible = 
                playerInstalled;

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

                List<string> selItems = opmShellList.SelectedPaths;
                switch (action)
                {
                    case ToolAction.ToolActionBack:
                        btn.Enabled = opmShellList.ExploreBackTarget.Length > 0;
                        BuildMenuText(btn, "TXT_BACK", opmShellList.ExploreBackTarget, OPMShortcut.CmdNavigateBack);
                        break;

                    case ToolAction.ToolActionFwd:
                        btn.Enabled = opmShellList.ExploreForwardTarget.Length > 0;
                        BuildMenuText(btn, "TXT_FORWARD", opmShellList.ExploreForwardTarget, OPMShortcut.CmdNavigateForward);
                        break;

                    case ToolAction.ToolActionUp:
                        btn.Enabled = !opmShellList.IsInDriveRoot;
                        BuildMenuText(btn, "TXT_UP", opmShellList.ParentFolderTarget, OPMShortcut.CmdNavigateUp);
                        break;

                    case ToolAction.ToolActionSearch:
                        BuildMenuText(btn, "TXT_SEARCH", string.Empty, OPMShortcut.CmdGenericSearch);
                        btn.Enabled = !string.IsNullOrEmpty(opmShellList.Path);
                        break;

                    case ToolAction.ToolActionReload:
                        BuildMenuText(btn, "TXT_REFRESH", string.Empty, OPMShortcut.CmdGenericRefresh);
                        btn.Enabled = !string.IsNullOrEmpty(opmShellList.Path);
                        break;

                    case ToolAction.ToolActionCopy:
                        BuildMenuText(btn, "TXT_COPY", string.Empty, OPMShortcut.CmdGenericCopy);
                        btn.Enabled = opmShellList.SelectedPaths.Count > 0;
                        break;
                    case ToolAction.ToolActionCut:
                        BuildMenuText(btn, "TXT_CUT", string.Empty, OPMShortcut.CmdGenericCut);
                        btn.Enabled = opmShellList.SelectedPaths.Count > 0;
                        break;
                    case ToolAction.ToolActionDelete:
                        BuildMenuText(btn, "TXT_DELETE", string.Empty, OPMShortcut.CmdGenericDelete);
                        btn.Enabled = opmShellList.SelectedPaths.Count > 0;
                        break;

                    case ToolAction.ToolActionPaste:
                        BuildMenuText(btn, "TXT_PASTE", string.Empty, OPMShortcut.CmdGenericPaste);
                        btn.Enabled = (_fileTask != null &&
                            (_fileTask.FileTaskType == FileTaskType.Copy || _fileTask.FileTaskType == FileTaskType.Move));
                        break;

                    case ToolAction.ToolActionRename:
                        BuildMenuText(btn, "TXT_RENAME", string.Empty, OPMShortcut.CmdGenericRename);
                        btn.Enabled = opmShellList.SelectedPaths.Count == 1;
                        break;

                    case ToolAction.ToolActionProTONEEnqueue:
                    case ToolAction.ToolActionProTONEPlay:
                        if (btn.Visible)
                        {
                            string text = (action == ToolAction.ToolActionProTONEEnqueue) ?
                                "TXT_PROTONE_ENQUEUE" : "TXT_PROTONE_PLAY";

                            BuildMenuText(btn, text, string.Empty, OPMShortcut.CmdOutOfRange);

                            bool enable = false;
                            foreach (string path in opmShellList.SelectedPaths)
                            {
                                if (MediaRenderer.IsSupportedMedia(path))
                                {
                                    enable = true;
                                    break;
                                }
                            }
                            btn.Enabled = enable;
                        }
                        break;

                    case ToolAction.ToolActionID3Wizard:
                        BuildMenuText(btn, "TXT_ID3WIZARD", string.Empty, OPMShortcut.CmdID3Wizard);
                        break;

                    case ToolAction.ToolActionListDrives:
                        BuildMenuText(btn, "TXT_DRIVES", string.Empty, OPMShortcut.CmdChangeDisk);
                        break;

                    case ToolAction.ToolActionFavoritesAdd:
                        btn.Visible = true;
                        BuildMenuText(btn, "TXT_FAVORITES_ADD", string.Empty, OPMShortcut.CmdOutOfRange);
                        break;

                    case ToolAction.ToolActionFavoritesManage:
                        btn.Visible = true;
                        BuildMenuText(btn, "TXT_FAVORITES_MANAGE", string.Empty, OPMShortcut.CmdFavManager);
                        break;

                    case ToolAction.ToolActionFavoriteFolders:
                        btn.Visible = true;
                        BuildMenuText(btn, "TXT_FAVORITES", string.Empty, OPMShortcut.CmdOutOfRange);
                        break;
                }
            }
        }

        private bool IsToolActionEnabled(ToolAction action)
        {
            for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            {
                ToolStripItem btn = contextMenuStrip.Items[i] as ToolStripItem;

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
        #endregion

        #region Drive bar / Favorites bar
        private void OnFavoriteChosen(object sender, EventArgs e)
        {
            if (sender as OPMToolStripMenuItem != null)
            {
                ChangePath((sender as OPMToolStripMenuItem).Text);
            }
        }

        private void OnDriveChosen(object sender, ToolStripItemClickedEventArgs e)
        {
            ChangePath(e.ClickedItem.Tag as String);
        }

        private void OnBuildDriveButtonMenu(object sender, EventArgs e)
        {
            try
            {
                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

                tsbDrives.DropDownItems.Clear();
                ilDrives.Images.Clear();

                foreach (System.IO.DriveInfo di in drives)
                {
                    string name = string.Empty;
                    string label = string.Empty;
                    string format = string.Empty;
                    string freeSpace = string.Empty;
                    string ready = string.Empty;

                    try { name = di.Name.ToUpperInvariant(); }
                    catch { }

                    try { label = di.VolumeLabel; }
                    catch { }

                    try { format = di.DriveFormat; }
                    catch { }

                    try { freeSpace = ((double)(di.AvailableFreeSpace) / (1024 * 1024)).ToString("F"); }
                    catch { }

                    try { ready = (di.IsReady) ? Translator.Translate("TXT_READY") : Translator.Translate("TXT_NOT_READY"); }
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

                    ilDrives.Images.Add(ImageProvider.GetIcon(name, false));

                    OPMToolStripDropDownMenuItem tsi = new OPMToolStripDropDownMenuItem(tsbDrives);
                    tsi.ImageScaling = ToolStripItemImageScaling.None;

                    // "{0}    [{1}][{2}][{3} MB free][{4}]"
                    tsi.Text = Translator.Translate("TXT_DRIVE_DESC_FORMAT", name, label, format, freeSpace, ready);
                    
                    tsi.Tag = name;
                    tsi.Image = ilDrives.Images[ilDrives.Images.Count - 1];

                    tsbDrives.DropDownItems.Add(tsi);
                }
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }
        #endregion

        private void BuildMenuText(ToolStripItem tsm, string tag, string param, OPMShortcut command)
        {
            tsm.ToolTipText =
                (tsm.Enabled && !string.IsNullOrEmpty(param)) ? Translator.Translate(tag) + ": " + param : 
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
            }
        }

        private void OnBuildFavoritesMenu(object sender, EventArgs e)
        {
            try
            {
                ToolStripDropDownItem tsmi = sender as ToolStripDropDownItem;
                if (tsmi == null || tsmi.DropDownItems == null || tsmi.DropDownItems.Count < 2) 
                    return;

                ilFavorites.Images.Clear();

                // Clear favorites items
                List<ToolStripItem> itemsToClear = new List<ToolStripItem>();
                foreach (ToolStripItem child in tsmi.DropDownItems)
                {
                    if ((child as ToolStripSeparator) != null || child.Tag != null)
                        continue;

                    itemsToClear.Add(child);
                }

                foreach (ToolStripItem itemToClear in itemsToClear)
                {
                    tsmi.DropDownItems.Remove(itemToClear);
                }

                List<string> favPaths = SuiteConfiguration.GetFavoriteFolders("FavoriteFolders");
                if (favPaths != null && favPaths.Count > 0)
                {
                    foreach (string path in favPaths)
                    {
                        if (Directory.Exists(path))
                        {
                            OPMToolStripDropDownMenuItem tsi = new OPMToolStripDropDownMenuItem(tsbFavorites);
                            tsi.Text = path;
                            tsi.Click += new EventHandler(OnFavoriteChosen);
                            tsi.Image = ilFavorites.Images[GetIcon(path)];
                            tsi.ImageScaling = ToolStripItemImageScaling.None;

                            tsmi.DropDownItems.Add(tsi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private int GetIcon(string path)
        {
            System.Drawing.Image icon = ImageProvider.GetIcon(path, false);
            if (icon != null)
            {
                ilFavorites.Images.Add(icon);
                return ilFavorites.Images.Count - 1;
            }

            return 0;
        }

        protected override SettingsTabPage GetSettingsTabPage()
        {
            return new FileExplorerCfgPanel();
        }
    }

    #region Tool actions
    internal enum ToolAction : int
    {
        ToolActionNothing = -1,

        ToolActionBack = 0,
        ToolActionFwd,
        ToolActionUp,

        ToolActionFavoriteFolders,
        ToolActionFavoritesAdd,
        ToolActionFavoritesManage,

        ToolActionSearch,
        ToolActionReload,

        ToolActionCopy,
        ToolActionCut,
        ToolActionPaste,

        ToolActionRename,
        ToolActionDelete,

        ToolActionID3Wizard,

        ToolActionJumpToItem,

        ToolActionProTONEPlay,
        ToolActionProTONEEnqueue,

        ToolActionLaunch,

        ToolActionListDrives,
    }
    #endregion

    #region Wizard
    public static class SearchWizardMain
    {
        public static DialogResult Execute(BackgroundTask initTask)
        {
            Type[] pages = new Type[]
                {
                    typeof(WizFESearchStep1Ctl),
                };

            return WizardHostForm.CreateWizard("TXT_SEARCHWIZARD_FE", pages, true, initTask, Resources.Search16.ToIcon());
        }

        public static DialogResult Execute()
        {
            return Execute(null);
        }
    }
    #endregion
}


