#region Copyright © opmedia research 2006
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	OPMShellListView.cs
#endregion

#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.IO;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using OPMedia.Runtime;

using System.Threading;
using OPMedia.Core.Configuration;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;

using OPMedia.UI.Controls;
using OPMedia.Core.GlobalEvents;

using System.Linq;
using System.Globalization;
using OPMedia.Core.Utilities;
using OPMedia.UI.FileTasks;
using OPMedia.Core.NetworkAccess;

#endregion

namespace OPMedia.UI.Controls
{
    #region Delegates
    /// <summary>
    /// Delegate used for the DoubleClickDirectory event.
    /// </summary>
    public delegate void DoubleClickDirectoryEventHandler(object sender, DoubleClickDirectoryEventArgs args);
    /// <summary>
    /// Delegate used for the DoubleClickFile event.
    /// </summary>
    public delegate void DoubleClickFileEventHandler(object sender, DoubleClickFileEventArgs args);
    /// <summary>
    /// Delegate used for the SelectDirectory event.
    /// </summary>
    public delegate void SelectDirectoryEventHandler(object sender, SelectDirectoryEventArgs args);
    /// <summary>
    /// Delegate used for the SelectFile event.
    /// </summary>
    public delegate void SelectFileEventHandler(object sender, SelectFileEventArgs args);
    /// <summary>
    /// Delegate used for the SelectMultipleItems event.
    /// </summary>
    public delegate void SelectMultipleItemsEventHandler(object sender, SelectMultipleItemsEventArgs args);

    public delegate List<string> QueryLinkedFilesHandler(string path, FileTaskType taskType);
    public delegate void ItemRenameHandler(string newPath);

    public delegate bool LaunchMultipleItemsHandler(object sender, System.EventArgs e);
    #endregion

    #region Main class
    /// <summary>
	/// Component that implements a list with the contents of a
    /// given file system folder.
	/// </summary>
	public class OPMShellListView : OPMListView
    {
        #region Members

        System.Windows.Forms.Timer _delayedExplore = null;
        System.Windows.Forms.Timer _delayedSelectionTimer = null;

        private string m_strDirPath = Environment.CurrentDirectory;
		private string m_strPrevDirPath = "";
		
        private bool ignoreEvents = false;

        private object syncRoot = new object();

        FileSystemWatcher fsw = null;

        private Stack<string> bckPaths = new Stack<string>();
        private Stack<string> fwdPaths = new Stack<string>();

        ColumnHeader colName = new ColumnHeader();
        ColumnHeader colLastAccess = new ColumnHeader();
        ColumnHeader colSize = new ColumnHeader();
        ColumnHeader colAttr = new ColumnHeader();

        private ImageList m_ilDirList;

        #endregion

        #region Events

        public event LaunchMultipleItemsHandler LaunchMultipleItems = null;

        /// <summary>
        /// Occurs when a directory is double clicked.
        /// Directory path is part of the event data.
        /// </summary>
        public event DoubleClickDirectoryEventHandler DoubleClickDirectory = null;
        /// <summary>
        /// Occurs when a file is double clicked.
        /// File path is part of the event data.
        /// </summary>
        public event DoubleClickFileEventHandler DoubleClickFile = null;
        /// <summary>
        /// Occurs when a directory is selected.
        /// Directory path is part of the event data.
        /// </summary>
        public event SelectDirectoryEventHandler SelectDirectory = null;
        /// <summary>
        /// Occurs when a file is selected.
        /// File path is part of the event data.
        /// </summary>
        public event SelectFileEventHandler SelectFile = null;
        /// <summary>
        /// Occurs when multiple items are selected.
        /// Items paths are part of the event data.
        /// </summary>
        public event SelectMultipleItemsEventHandler SelectMultipleItems = null;

        public event QueryLinkedFilesHandler QueryLinkedFiles = null;
        public event ItemRenameHandler ItemRenamed = null;

        #endregion

        #region Properties

        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageList SmallImageList { get { return base.SmallImageList; } }

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private new ColumnHeaderCollection Columns
        {
            get
            {
                return base.Columns;
            }
        }

        public List<string> SelectedPaths
        {
            get
            {
                List<string> selectedItems = new List<string>();

                foreach (ListViewItem item in SelectedItems)
                {
                    FileSystemInfo fsi = item.Tag as FileSystemInfo;
                    if (fsi != null && fsi.Exists && string.Compare(fsi.FullName, ParentFolderTarget, true) != 0)
                    {
                        selectedItems.Add(fsi.FullName);
                    }
                }

                return selectedItems;
            }
        }

        /// <summary>
        /// Gets/sets the current folder path.
        /// Note: setting the property toggles exploring for 
        /// files and folder on the new path. Wrong path specified
        /// results in an Exception being thrown.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        public string Path
        {
            get
            {
                return m_strDirPath;
            }

            set
            {
                try
                {
                    ignoreEvents = true;

                    m_strPrevDirPath = m_strDirPath;

                    if (value == PathUtils.DirectorySeparator)
                    {
                        if (PathUtils.IsRootPath(m_strDirPath))
                        {
                            return;
                        }
                        else
                        {
                            DirectoryInfo di = new DirectoryInfo(m_strDirPath);
                            m_strDirPath = di.Root.FullName;
                        }
                    }
                    else if (value == PathUtils.ParentDir)
                    {
                        DirectoryInfo di = new DirectoryInfo(m_strDirPath);
                        m_strDirPath = di.Parent.FullName;
                    }
                    else if (value == PathUtils.CurrentDir)
                    {
                        m_strDirPath = Environment.CurrentDirectory;
                    }
                    else
                    {
                        m_strDirPath = value;
                    }

                    if (fsw != null)
                    {
                        fsw.Created -= new FileSystemEventHandler(OnFolderContentsUpdated);
                        fsw.Deleted -= new FileSystemEventHandler(OnFolderContentsUpdated);
                        fsw.Renamed -= new RenamedEventHandler(fsw_Renamed);

                        fsw.Dispose();
                        fsw = null;
                    }

                    if (Directory.Exists(m_strDirPath))
                    {
                        fsw = new FileSystemWatcher(m_strDirPath);
                        fsw.EnableRaisingEvents = true;
                        fsw.Created += new FileSystemEventHandler(OnFolderContentsUpdated);
                        fsw.Deleted += new FileSystemEventHandler(OnFolderContentsUpdated);
                        fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
                        //fsw.Changed += new FileSystemEventHandler(OnFolderContentsUpdated);
                    }

                    bckPaths.Push(m_strPrevDirPath);

                    Explore(false);
                }
                catch (Exception ex)
                {
                    Logger.LogWarning(ex.Message);

                    this.Items.Clear();
                    CreateMessageRow(Translator.Translate("TXT_FOLDERNOTACCESSIBLE"));
                }
                finally
                {
                    ignoreEvents = false;
                }
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ReadOnly(true)]
        public string SearchPattern { get; set; }

        public void EnableAutoRefresh(bool enable)
        {
            if (fsw != null)
            {
                fsw.EnableRaisingEvents = enable;
            }
        }

        void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            OnFolderContentsUpdated(sender, e);
        }

        void OnFolderContentsUpdated(object sender, FileSystemEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new FileSystemEventHandler(OnFolderContentsUpdated), sender, e);
                return;
            }

            Logger.LogHeavyTrace("OnFolderContentsUpdated: " + e.ToString());
            _delayedExplore.Stop();

            try
            {
                if (sender is FileSystemWatcher)
                {
                    _delayedExplore.Start();
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        void _delayedExplore_Tick(object sender, EventArgs e)
        {
            _delayedExplore.Stop();

            try
            {
                Explore(_diNew == null);
            }
            finally
            {
                ignoreEvents = false;
            }
        }
        #endregion

        #region Methods
        public new void Clear()
        {
            this.Items.Clear();
        }
        #endregion

        #region Construction
        /// <summary>
        /// Default contructor.
        /// </summary>
        public OPMShellListView() : base()
		{
            this.SearchPattern = null;

            m_ilDirList = new ImageList();
            m_ilDirList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            m_ilDirList.ImageSize = new System.Drawing.Size(16, 16);
            m_ilDirList.TransparentColor = Color.Transparent;
            
            base.SmallImageList = m_ilDirList;

            colName.Text = "TXT_FILENAME";
            this.Columns.Add(colName);

            colLastAccess.Text = "TXT_LASTCHANGEDATE";
            this.Columns.Add(colLastAccess);

            colSize.Text = "TXT_FILESIZE";
            this.Columns.Add(colSize);

            colAttr.Text = "TXT_ATTRIBUTES";
            this.Columns.Add(colAttr);

            int i = 0;
            colName.DisplayIndex = i++;
            colLastAccess.DisplayIndex = i++;
            colSize.DisplayIndex = i++;
            colAttr.DisplayIndex = i++;

            this.ListViewItemSorter = new Sorter(colName.Index);
            
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.DoubleClick += new EventHandler(this.OnDoubleClick);
            
            //this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(OnPreviewKeyDown);

            this.SelectedIndexChanged += new EventHandler(this.OnSelectedItemChanged);

            this.HandleCreated += new EventHandler(OPMShellListView_HandleCreated);
            this.HandleDestroyed += new EventHandler(OPMShellListView_HandleDestroyed);

            this.LabelEdit = true;
            this.BeforeLabelEdit += new LabelEditEventHandler(OnCellBeginEdit);
            this.AfterLabelEdit += new LabelEditEventHandler(OnCellEndEdit);

            this.Resize += new EventHandler(OPMShellListView_Resize);

            _delayedSelectionTimer = new System.Windows.Forms.Timer();
            _delayedSelectionTimer.Interval = 100;
            _delayedSelectionTimer.Tick += new EventHandler(_delayedSelectionTimer_Tick);
            _delayedSelectionTimer.Enabled = false;

            _delayedExplore = new System.Windows.Forms.Timer();
            _delayedExplore.Interval = 200;
            _delayedExplore.Tick += new EventHandler(_delayedExplore_Tick);
            _delayedExplore.Enabled = false;

            ThemeManager.SetFont(this, FontSizes.Normal);
        }

        void OPMShellListView_Resize(object sender, EventArgs e)
        {
            colSize.Width = 83;
            colAttr.Width = 85;
            colLastAccess.Width = 130;
            colName.Width = this.Width - colSize.Width - colAttr.Width - colLastAccess.Width - SystemInformation.VerticalScrollBarWidth - 5;
        }

        #endregion

        #region Items rename

        public void Rename()
        {
            if (this.SelectedItems != null && this.SelectedItems.Count == 1)
            {
                ListViewItem lvi = this.SelectedItems[0];
                lvi.BeginEdit();
            }
        }

        public bool IsInEditMode { get; private set; }

        void OnCellBeginEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;

            if (this.SelectedItems != null && this.SelectedItems.Count == 1)
            {
                string initialName = this.SelectedItems[0].Text;
                e.CancelEdit = (initialName == PathUtils.ParentDir);
            }

            this.IsInEditMode = !e.CancelEdit;
        }

        void OnCellEndEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string newName = e.Label;
                if (e.CancelEdit || string.IsNullOrEmpty(newName))
                    return;

                FileSystemInfo fsi = this.Items[e.Item].Tag as FileSystemInfo;
                if (fsi == null)
                    return;

                e.CancelEdit = true;
                string initialName = string.Empty;
                ListViewItem item = null;

                if (this.SelectedItems != null && this.SelectedItems.Count == 1)
                {
                    item = this.SelectedItems[0];
                    initialName = this.SelectedItems[0].Text;
                    e.CancelEdit = (initialName == PathUtils.ParentDir);
                }

                string oldPath = fsi.FullName;
                string finalPath = System.IO.Path.Combine(m_strDirPath, newName);

                if (String.Equals(finalPath, fsi.FullName, StringComparison.InvariantCultureIgnoreCase))
                    return;

                if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    // Renaming a folder
                    DirectoryInfo di = fsi as DirectoryInfo;
                    if (di != null && di.Exists)
                    {
                        di.MoveTo(finalPath);
                    }
                }
                else
                {
                    // Renaming a file
                    FileInfo fi = fsi as FileInfo;
                    if (fi != null && fi.Exists)
                    {
                        List<String> linkedFiles = null;

                        if (QueryLinkedFiles != null)
                        {
                            linkedFiles = QueryLinkedFiles(oldPath, FileTaskType.Move);
                        }

                        if (linkedFiles != null)
                        {
                            string oldFileName = System.IO.Path.GetFileNameWithoutExtension(oldPath);
                            string newFileName = System.IO.Path.GetFileNameWithoutExtension(finalPath);

                            // TODO correctly handle letter casing

                            foreach (string linkedFile in linkedFiles)
                            {
                                string linkedFileName = System.IO.Path.GetFileName(linkedFile).Replace(oldFileName, newFileName);
                                string linkedFileFinalPath = System.IO.Path.Combine(m_strDirPath, linkedFileName);

                                FileInfo lfi = new FileInfo(linkedFile);
                                if (lfi.Exists)
                                {
                                    lfi.MoveTo(linkedFileFinalPath);
                                }
                            }
                        }

                        fi.MoveTo(finalPath);
                    }
                }

                item.Selected = item.Focused = true;

                if (ItemRenamed != null)
                {
                    ItemRenamed(finalPath);
                }

            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex.Message, "Rename error");
            }
            finally
            {
                this.IsInEditMode = false;
            }
        }
        #endregion

        #region Event handlers
        void OPMShellListView_HandleCreated(object sender, EventArgs e)
        {
            bckPaths.Clear();
            fwdPaths.Clear();

            EventDispatch.RegisterHandler(this);
        }

        void OPMShellListView_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }

        /// <summary>
        /// Occurs when a key was pressed.
        /// </summary>
		//private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
            if (!this.IsInEditMode)
            {
	            if (e.Modifiers == Keys.None)
	            {
				    if (e.KeyCode == Keys.Back && !IsInDriveRoot)
				    {
					    this.Path = PathUtils.ParentDir;
					    //e.Handled = true;
				    }
	                else if (e.KeyCode == Keys.Enter)
	                {
	                    OnDoubleClick(sender, e);
	                }
	                else if (e.KeyCode == Keys.F2)
	                {
	                    Rename();
	                }
	                //else if (e.KeyCode == Keys.Escape)
	                //{
	                //    CancelRename();
	                //}
                }
            }
		}

        void _delayedSelectionTimer_Tick(object sender, EventArgs e)
        {
            _delayedSelectionTimer.Stop();

            if (this.SelectedItems == null || this.SelectedItems.Count <= 0)
            {
                OnSelectFile(string.Empty);
                return;
            }

            if (this.SelectedItems.Count > 1)
            {
                OnSelectMultipleItems();
            }
            else
            {
                ListViewItem item = this.SelectedItems[0];

                FileSystemInfo fsi = item.Tag as FileSystemInfo;
                if (fsi != null)
                {
                    if (fsi is FileInfo)
                    {
                        OnSelectFile(fsi.FullName);
                    }
                    else if (fsi is DirectoryInfo)
                    {
                        OnSelectDirectory(fsi.FullName);
                    }
                }
            }
        }

        void OnSelectedItemChanged(object sender, EventArgs e)
        {
            if (ignoreEvents)
                return;

            _delayedSelectionTimer.Stop();
            _delayedSelectionTimer.Start();
        }

        /// <summary>
        /// Occurs when a file item was double clicked.
        /// </summary>
        private void OnDoubleClickFile(string strPath)
        {
            if (DoubleClickFile != null)
            {
                DoubleClickFileEventArgs eventArgs = new DoubleClickFileEventArgs();
                if (File.Exists(strPath) || Directory.Exists(strPath))
                {
                    eventArgs.m_strPath = strPath;
                }
                DoubleClickFile(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a folder item was double clicked.
        /// </summary>
        private void OnDoubleClickDirectory(string strPath)
        {
            if (DoubleClickDirectory != null)
            {
                DoubleClickDirectoryEventArgs eventArgs = new DoubleClickDirectoryEventArgs();
                if (File.Exists(strPath) || Directory.Exists(strPath))
                {
                    eventArgs.m_strPath = strPath;
                }
                DoubleClickDirectory(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a file item was selected.
        /// </summary>
        private void OnSelectFile(string strPath)
        {
            if (SelectFile != null)
            {
                SelectFileEventArgs eventArgs = new SelectFileEventArgs();
                if (File.Exists(strPath) || Directory.Exists(strPath))
                {
                    eventArgs.m_strPath = strPath;
                }
                SelectFile(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a folder item was selected.
        /// </summary>
        private void OnSelectDirectory(string strPath)
        {
            if (SelectDirectory != null)
            {
                SelectDirectoryEventArgs eventArgs = new SelectDirectoryEventArgs();
                if (File.Exists(strPath) || Directory.Exists(strPath))
                {
                    eventArgs.m_strPath = strPath;                    
                }

                SelectDirectory(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when multiple items were selected.
        /// </summary>
		private void OnSelectMultipleItems()
		{
            if (SelectMultipleItems != null)
            {
                SelectMultipleItemsEventArgs eventArgs = new SelectMultipleItemsEventArgs();
                eventArgs.m_strPaths = new List<string>(SelectedPaths);

                SelectMultipleItems(this, eventArgs);
            }
		}
        #endregion

        #region Implementation
        [EventSink(EventNames.PerformTranslation)]
        public void PerformTranslation()
        {
            colName.Text = Translator.Translate("TXT_FILENAME");
            colLastAccess.Text = Translator.Translate("TXT_LASTCHANGEDATE");
            colSize.Text = Translator.Translate("TXT_FILESIZE");
            colAttr.Text = Translator.Translate("TXT_ATTRIBUTES");
        }

        [EventSink(EventNames.RefreshItems)]
        public void RefreshItems(string[] items)
        {
            if (items != null)
            {
                foreach (string item in items)
                {
                    RefreshItem(item);
                }
            }
        }

        protected override void OnThemeUpdatedInternal()
        {
            base.OnThemeUpdatedInternal();
            foreach (ListViewItem item in Items)
            {
                bool isFile = (item.Tag is FileInfo);
                item.BackColor = ThemeManager.BackColor;
                item.ForeColor = isFile ? ThemeManager.ForeColor : ThemeManager.HighlightColor;
                item.Font = isFile ? ThemeManager.NormalFont : ThemeManager.NormalBoldFont;
            }
        }

        public void RefreshItem(string item)
        {
            foreach (ListViewItem row in this.Items)
            {
                FileSystemInfo fsi = (row.Tag as FileSystemInfo);
                if (fsi != null && string.Compare(fsi.FullName, item, true) == 0)
                {
                    if (fsi is DirectoryInfo)
                    {
                        fsi = new DirectoryInfo(item);
                    }
                    else if (fsi is FileInfo)
                    {
                        fsi = new FileInfo(item);
                    }

                    row.Tag = fsi;
                    row.SubItems[colAttr.Index].Text = BuildAttributes(fsi);

                    break;
                }
            }
        }

        public void RefreshList(bool keepSelection)
        {
            try
            {
                Explore(keepSelection);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.Message);

                this.Items.Clear();
                CreateMessageRow(Translator.Translate("TXT_FOLDERNOTACCESSIBLE"));
            }
            finally
            {
                ignoreEvents = false;
            }
        }

        /// <summary>
        /// Explore the current folder.
        /// </summary>
        private delegate void ExploreHandler(bool keepSelection);
        private void Explore(bool keepSelection)
		{
            if (InvokeRequired)
            {
                Invoke(new ExploreHandler(Explore), keepSelection);
                return;
            }

            List<string> selection = new List<string>();
            if (keepSelection)
            {
                selection.AddRange(SelectedPaths);
            }

            Clear();
            m_ilDirList.Images.Clear();

            lock (syncRoot)
            {
                try
                {
                    ignoreEvents = true;

                    bool isUncPathRoot = false;

                    CursorHelper.ShowWaitCursor(this, true);

                    // Check if current path is valid.
                    if (!Directory.Exists(m_strDirPath))
                    {
                        m_strDirPath = FindFirstUsablePath(m_strDirPath, ref isUncPathRoot);
                    }

                    AppConfig.LastExploredFolder = m_strDirPath;

                    if (!isUncPathRoot && PathUtils.IsRootPath(m_strDirPath))
                    {
                        m_strDirPath = m_strDirPath.TrimEnd(string.Copy(PathUtils.DirectorySeparator).ToCharArray()) + PathUtils.DirectorySeparator;
                    }

                    CreateParentFolderRow();

                    if (isUncPathRoot)
                    {
                        ShareCollection shares = ShareCollection.GetShares(m_strDirPath);
                        foreach(Share share in shares)
                        {
                            if (!share.IsFileSystem)
                                continue;

                            DirectoryInfo di = share.Root;
                            if (!di.Exists)
                                continue;

                            CreateNewRow(di);
                        }
                    }
                    else
                    {
                        IEnumerable<string> strDirs = Directory.EnumerateDirectories(m_strDirPath);
                        if (strDirs != null)
                        {
                            foreach (string dir in strDirs)
                            {
                                DirectoryInfo di = new DirectoryInfo(dir);
                                if (!di.Exists)
                                    continue;

                                CreateNewRow(di);
                            }
                        }

                        IEnumerable<string> strFiles = null;
                        if (string.IsNullOrEmpty(this.SearchPattern))
                        {
                            strFiles = Directory.EnumerateFiles(m_strDirPath);
                        }
                        else
                        {
                            strFiles = EnumerateFiles(m_strDirPath, this.SearchPattern, SearchOption.TopDirectoryOnly);
                        }

                        if (strFiles != null)
                        {
                            foreach (string file in strFiles)
                            {
                                FileInfo fi = new FileInfo(file);
                                if (!fi.Exists)
                                    continue;

                                CreateNewRow(fi);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
                finally
                {
                    CursorHelper.ShowWaitCursor(this, false);
                    ignoreEvents = true;
                }

                if (this.Items.Count <= 0)
                {
                    CreateMessageRow(string.Empty);
                    CreateMessageRow(Translator.Translate("TXT_FOLDERNOTACCESSIBLE"));
                }
            }

            this.Sort();

            //ClearSelection();
            this.SelectedItems.Clear();

            if (keepSelection || _diNew != null)
            {
                if ((selection != null && selection.Count > 0) || _diNew != null)
                {
                    bool focusSet = false;

                    foreach (ListViewItem item in Items)
                    {
                        string path = string.Empty;
                        if (item.Tag is FileSystemInfo)
                        {
                            path = (item.Tag as FileSystemInfo).FullName;
                        }

                        if (selection.Contains(path) || (_diNew != null && string.Compare(_diNew.FullName, path, true) == 0))
                        {
                            if (!focusSet)
                            {
                                item.Focused = true;
                                focusSet = true;
                            }

                            item.Selected = true;
                            EnsureVisible(item.Index);
                        }
                    }
                }
            }
            else if (m_strPrevDirPath != null && m_strPrevDirPath.Length > 0)
            {
                int lastVisibleIndex = 0;
                foreach (ListViewItem item in this.Items)
                {
                    DirectoryInfo info = item.Tag as DirectoryInfo;
                    if (info != null)
                    {
                        item.Selected = false;

                        if (string.Compare(info.FullName, m_strPrevDirPath, false) == 0)
                        {
                            item.Selected = true;
                            item.Focused = true;

                            lastVisibleIndex = item.Index;
                           
                            break;
                        }
                    }
                }

                EnsureVisible(lastVisibleIndex);
            }

            this.Select();
            this.Focus();

            if (_diNew != null)
            {
                _diNew = null;
                Rename();
            }
		}

        private static string[] EnumerateFiles(string sourceFolder, string filters, System.IO.SearchOption searchOption)
        {
            return filters.Split(';').SelectMany(filter => System.IO.Directory.EnumerateFiles(sourceFolder, filter, searchOption)).ToArray();
        }

        public void ExploreBack()
        {
            string s = null;

            try
            {
                s = bckPaths.Pop();
            }
            catch
            {
                s = null;
            }

            if (!string.IsNullOrEmpty(s))
            {
                fwdPaths.Push(m_strDirPath);
                m_strDirPath = s;

                try
                {
                    Explore(false);
                }
                finally
                {
                    ignoreEvents = false;
                }

            }
        }

        public void ExploreForward()
        {
            string s = null;

            try
            {
                s = fwdPaths.Pop();
            }
            catch
            {
                s = null;
            }

            if (!string.IsNullOrEmpty(s))
            {
                bckPaths.Push(m_strDirPath);
                m_strDirPath = s;

                try
                {
                    Explore(false);
                }
                finally
                { 
                    ignoreEvents = false;
                }
            }

        }



        public string ExploreBackTarget
        {
            get
            {
                return (bckPaths.Count > 0) ? bckPaths.Peek() : string.Empty;
            }
        }

        public string ExploreForwardTarget
        {
            get
            {
                return (fwdPaths.Count > 0) ? fwdPaths.Peek() : string.Empty;
            }
        }

        public string ParentFolderTarget
        {
            get
            {
                if (!IsInDriveRoot)
                {
                    DirectoryInfo di = new DirectoryInfo(m_strDirPath);
                    return di.Parent.FullName;
                }

                return string.Empty;
            }
        }

        public bool IsInDriveRoot
        {
            get
            {
                return PathUtils.IsRootPath(m_strDirPath);
            }
        }

        /// <summary>
        /// Occurs when the item was double-clicked.
        /// </summary>
		private void OnDoubleClick(object sender, System.EventArgs e)
		{
            if (ignoreEvents ||
                this.SelectedItems == null ||
                this.SelectedItems.Count < 1) 
                return;

            if (LaunchMultipleItems == null || !LaunchMultipleItems(sender, e))
            {
                FileSystemInfo fsi = this.SelectedItems[0].Tag as FileSystemInfo;
                if (fsi != null)
                {
                    if (fsi is DirectoryInfo)
                    {
                        this.Path = fsi.FullName;
                        OnDoubleClickDirectory(fsi.FullName);
                    }
                    else if (fsi is FileInfo)
                    {
                        OnDoubleClickFile(fsi.FullName);
                    }
                }
            }
		}

        /// <summary>
        /// Converts the given path (that can contain invalid parts)
        /// to a physically existing, valid path.
        /// </summary>
        /// <param name="path">the given path</param>
        /// <returns>a physically existing, valid path</returns>
        private string FindFirstUsablePath(string path, ref bool isUNCPathRoot)
        {
            string usablePath = path;

            if (!Directory.Exists(path) && path.StartsWith("\\\\"))
            {
                isUNCPathRoot = true;
            }
            else
            {
                isUNCPathRoot = false;

                DirectoryInfo di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    if (di.Parent != null)
                    {
                        usablePath = FindFirstUsablePath(di.Parent.FullName, ref isUNCPathRoot);
                    }
                    else
                    {
                        di = new DirectoryInfo(Environment.SystemDirectory);
                        usablePath = di.Root.FullName;
                    }
                }
            }

            return usablePath;
        }
        #endregion

        public void JumpToItem(string itemPath, bool launchItem)
        {
            try
            {
                string pathToOpen = System.IO.Path.GetDirectoryName(itemPath);
                //string itemName = System.IO.Path.GetFileName(itemPath);

                if (Directory.Exists(pathToOpen))
                {
                    Path = pathToOpen;
                }

                ignoreEvents = true;

                foreach (ListViewItem item in this.Items)
                {
                    FileSystemInfo fsi = item.Tag as FileSystemInfo;
                    if (fsi != null && string.Compare(fsi.FullName, itemPath, true) == 0)
                    {
                        this.Select();
                        this.Focus();
                        this.SelectedItems.Clear();

                        item.Selected = true;

                        OnSelectFile(itemPath);

                        if (launchItem)
                        {
                            OnDoubleClickFile(itemPath);
                        }

                        break;
                    }
                }
            }
            finally
            {
                ignoreEvents = false;
            }
        }

        public void OpenItem(string itemPath)
        {
            if (Directory.Exists(itemPath))
            {
                Path = itemPath;
            }
            else if (File.Exists(itemPath))
            {
                JumpToItem(itemPath, true);
            }
        }

        public void CreateMessageRow(string msg)
        {
            ListViewItem item = new ListViewItem(msg);
            item.Tag = null;
            this.Items.Add(item);
        }

        public void CreateParentFolderRow()
        {
            if (!PathUtils.IsRootPath(Path))
            {
                DirectoryInfo parent = Directory.GetParent(Path);
                if (parent != null)
                {
                    int imgIndex = GetIcon(parent.FullName);

                    string[] data = new string[] { PathUtils.ParentDir, BuildLastAccessTime(parent), "[ DIR ]", BuildAttributes(parent) };

                    ListViewItem item = new ListViewItem(data);
                    item.ImageIndex = imgIndex;
                    item.Tag = parent;
                    item.BackColor = ThemeManager.BackColor;
                    item.ForeColor = ThemeManager.ForeColor;
                    item.Font = ThemeManager.NormalBoldFont;

                    this.Items.Add(item);
                }
            }
        }

        public void CreateNewRow(FileSystemInfo fsi)
        {
            string strLen = "[ DIR ]";
            Color c = ThemeManager.SelectedColor;

            bool isFile = false;
            if (fsi is FileInfo)
            {
                long len = (fsi as FileInfo).Length;
                float lenKB = (float)len / (float)(1024);
                float lenMB = (float)len / (float)(1024 * 1024);
                float lenGB = (float)len / (float)(1024 * 1024 * 1024);

                if (lenGB > 2)
                {
                    strLen = string.Format("{0} GB", lenGB.ToString("F"));
                }
                else if (lenMB > 2)
                {
                    strLen = string.Format("{0} MB", lenMB.ToString("F"));
                }
                else if (lenKB > 2)
                {
                    strLen = string.Format("{0} KB", lenKB.ToString("F"));
                }
                else
                {
                    strLen = string.Format("{0} B", len.ToString("F"));
                }

                isFile = true;
            }

            int imgIndex = GetIcon(fsi.FullName);

            string[] data = new string[] { fsi.Name, BuildLastAccessTime(fsi), strLen, BuildAttributes(fsi) };

            ListViewItem item = new ListViewItem(data);
            item.BackColor = ThemeManager.BackColor;
            item.ForeColor = isFile ? ThemeManager.ForeColor : ThemeManager.HighlightColor;
            item.ImageIndex = imgIndex;
            item.Tag = fsi;
            item.Font = isFile ? ThemeManager.NormalFont : ThemeManager.NormalBoldFont;

            this.Items.Add(item);
            
        }

        private string BuildLastAccessTime(FileSystemInfo fsi)
        {
            try
            {
                return StringUtils.BuildTimeString(fsi.LastWriteTime);
            }
            catch
            {
                return string.Empty;
            }
        }

        private string BuildAttributes(FileSystemInfo fsi)
        {
            string strAttr = "";

            if (PathUtils.ObjectHasAttribute(fsi, FileAttributes.ReadOnly))
                strAttr += "R";
            else
                strAttr += "-";
            if (PathUtils.ObjectHasAttribute(fsi, FileAttributes.Archive))
                strAttr += "A";
            else
                strAttr += "-";
            if (PathUtils.ObjectHasAttribute(fsi, FileAttributes.Hidden))
                strAttr += "H";
            else
                strAttr += "-";
            if (PathUtils.ObjectHasAttribute(fsi, FileAttributes.System))
                strAttr += "S";
            else
                strAttr += "-";

            return strAttr;
        }

        /// <summary>
        /// Gets the system image index for the specified file.
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        private int GetIcon(string strFile)
        {
            try
            {
                m_ilDirList.Images.Add(ImageProvider.GetIcon(strFile, false));
                return m_ilDirList.Images.Count - 1;
            }
            catch
            {
                return -1;
            }
        }

        DirectoryInfo _diNew = null;

        public void CreateNewFolder()
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            if (di.Exists)
            {
                string newName = string.Format("NewFolder_{0}", StringUtils.GenerateRandomToken(4));
                _diNew = di.CreateSubdirectory(newName);
            }
        }
    }

    #endregion

    #region Helper classes
    public class CursorHelper
    {
        public static void ShowWaitCursor(Control ctl, bool show)
        {
            ctl.Cursor = (show) ? Cursors.WaitCursor : Cursors.Default;
            //Application.DoEvents();
        }
    }
    
    /// <summary>
    /// Class used to compare list entries
    /// </summary>
	public class Sorter : IComparer
	{
        int _col = 0;

        public Sorter(int column)
		{
            _col = column;
		}

		public int Compare(object x, object y)
		{
            try
            {
                ListViewItem row1 = x as ListViewItem;
                ListViewItem row2 = y as ListViewItem;

                if (row1 == null && row2 == null)
                    return 0;
                else if (row1 == null)
                    return 1;
                else if (row2 == null)
                    return -1;

                FileSystemInfo fsi1 = row1.Tag as FileSystemInfo;
                FileSystemInfo fsi2 = row2.Tag as FileSystemInfo;

                if (fsi1 == null && fsi2 == null)
                    return 0;
                else if (fsi1 == null)
                    return 1;
                else if (fsi2 == null)
                    return -1;

                bool isDir1 = (fsi1.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
                bool isDir2 = (fsi2.Attributes & FileAttributes.Directory) == FileAttributes.Directory;

                if (isDir1 != isDir2)
                {
                    if (isDir1)
                        return -1;
                    else if (isDir2)
                        return 1;
                }

                string str1 = row1.SubItems[_col].Text;
                string str2 = row2.SubItems[_col].Text;

                if (str1 == PathUtils.ParentDir)
                    return -1;
                if (str2 == PathUtils.ParentDir)
                    return 1;

                return String.Compare(str1, str2, true);
            }
            catch
            {
                return 0;
            }

		}
	}

    #region Event args classes
	public class DoubleClickServerEventArgs : EventArgs
	{
		public string m_strPath = "";
	}
	
    public class DoubleClickDirectoryEventArgs : EventArgs
	{
		public string m_strPath = "";
	}
	
    public class DoubleClickFileEventArgs : EventArgs
	{
		public string m_strPath = "";
	}
	
    public class SelectServerEventArgs : EventArgs
	{
		public string m_strPath = "";
	}
	
    public class SelectDirectoryEventArgs : EventArgs
	{
		public string m_strPath = "";
	}
	
    public class SelectFileEventArgs : EventArgs
	{
		public string m_strPath = "";
	}

    public class SelectMultipleItemsEventArgs : EventArgs
    {
        public List<string> m_strPaths;
    }
    #endregion

    #endregion
}
