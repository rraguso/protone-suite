using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;

using System.IO;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using System.Diagnostics;

using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.UI.Generic;
using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.Menus;
using System.Threading;
using OPMedia.UI.ProTONE.Dialogs;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.Runtime.Processors;
using System.Net;
using OPMedia.Core.Utilities;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public delegate void LaunchFileEventHandler(string path);
    public delegate void StopRequestEventHandler();

    public partial class PlaylistPanel : OPMBaseControl
    {
        OPMToolTipManager _ttm = null;
        OPMToolTip _tip = new OPMToolTip();

        Playlist playlist = new Playlist();
        
        public event LaunchFileEventHandler LaunchFile = null;
        public event EventHandler PlaylistItemMenuClick = null;

        public bool IsPlaylistAtEnd
        { get { return playlist.IsAtEnd; } }

        public void FocusOnList()
        {
            this.Focus();
            lvPlaylist.Focus();
        }

        public PlaylistPanel() : base()
        {
            InitializeComponent();

            _ttm = new OPMToolTipManager(lvPlaylist);

            ThemeManager.SetFont(lvPlaylist, FontSizes.Normal);
            lvPlaylist.ShowItemToolTips = false;
            lvPlaylist.MultiSelect = true;
            lvPlaylist.Items.Clear();
            lvPlaylist.SmallImageList = ilImages;
            lvPlaylist.OverrideBackColor = ThemeManager.SpecialListColor;

            lvPlaylist.ItemMouseHover += new ListViewItemMouseHoverEventHandler(lvPlaylist_ItemMouseHover);
            
            playlist.PlaylistUpdated += 
                new PlaylistUpdatedEventHandler(playlist_PlaylistUpdated);

            this.HandleCreated += new EventHandler(PlaylistPanel_HandleCreated);
            this.HandleDestroyed += new EventHandler(PlaylistPanel_HandleDestroyed);

            if (MainThread.MainWindow != null)
            {
                MainThread.MainWindow.Shown += new EventHandler(MainWindow_Shown);
            }

            bookmarkManagerCtl.ShowSeparator(true);

            bookmarkManagerCtl.Visible = false;
            playlistControlPanel.Visible = false;

            playlistControlPanel.MouseUp += new MouseEventHandler(OnMouseUp);
           
            AdjustWidth();
            UpdateTotalTime(0);

            if (!DesignMode)
            {
                MediaRenderer.DefaultInstance.MediaRendererHeartbeat += new MediaRendererEventHandler(OnMediaRendererHeartbeat);
            }
        }

        void MainWindow_Shown(object sender, EventArgs e)
        {
            //ScrollBars.ScrollBarSkinner.SkinWindow(lvPlaylist);

            if (!DesignMode && initialState)
            {
                initialState = false;
                PersistentPlaylist.Load(ref playlist);
            }
        }

        protected override void OnThemeUpdatedInternal()
        {
            lvPlaylist.OverrideBackColor = ThemeManager.SpecialListColor;
        }

        public void OnMediaRendererHeartbeat()
        {
            try
            {
                ListViewItem lvi = lvPlaylist.Items[playlist.PlayIndex];
                PlaylistItem pli = lvi.Tag as PlaylistItem;
                SetItemRelation(lvi, pli);

                UpdateTotalTime(playlist.TotalPlaylistTime);
            }
            catch { }
            finally
            {
                UpdatePlaylistNames(false);
            }
        }

        [EventSink(LocalEventNames.PerformTranslation)]
        public void UpdateLanguage()
        {
            UpdatePlaylistNames(false);
        }

        [EventSink(LocalEventNames.UpdatePlaylistNames)]
        public void UpdatePlaylistNames(bool rebuildFileInfos)
        {
            foreach (ListViewItem lvi in lvPlaylist.Items)
            {
                PlaylistItem plItem = lvi.Tag as PlaylistItem;

                if (rebuildFileInfos)
                {
                    plItem.MediaFileInfo.Rebuild();
                }

                bool isActive = (plItem != null && IsActiveItem(plItem));
                if (plItem != null)
                {
                    lvi.SubItems[colFile.Index].Text = plItem.DisplayName;
                }

                UpdateMiscIcon(lvi);

                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                {
                    lvsi.Font = isActive ? ThemeManager.NormalBoldFont : ThemeManager.NormalFont;
                }
            }
        }

        private void UpdateMiscIcon(ListViewItem lvi)
        {
            PlaylistItem plItem = lvi.Tag as PlaylistItem;

            Image imgMisc = null;
            string txtMisc = string.Empty;

            if (plItem != null && plItem.IsVideo)
            {
                if (SubtitleDownloadProcessor.IsFileOnDownloadList(plItem.Path))
                {
                    // Currently downloading a subtitle
                    Bitmap bmp = OPMedia.UI.Properties.Resources.waitframe0;
                    bmp.MakeTransparent(ThemeManager.TransparentColor);
                    imgMisc = ImageProvider.ScaleImage(bmp, new Size(16, 16), true);
                    txtMisc = Translator.Translate("TXT_SUBTITLE_DOWNLOADING");

                }
                else if (SubtitleDownloadProcessor.TestForExistingSubtitle(plItem.Path))
                {
                    // Already having a subtitle
                    imgMisc = Resources.ResourceManager.GetImage("subtitles16");
                    txtMisc = Translator.Translate("TXT_SUBTITLE_AVAILABLE"); 
                }
            }

            lvi.SubItems[colMisc.Index].Tag = new ExtendedSubItemDetail(imgMisc, txtMisc);
        }

        bool _abortLoad = false;

        void PlaylistPanel_HandleDestroyed(object sender, EventArgs e)
        {
            try
            {
                _abortLoad = true;
                PersistentPlaylist.Save(playlist);

                if (!DesignMode)
                {
                    MediaRenderer.DefaultInstance.MediaRendererHeartbeat -= new MediaRendererEventHandler(OnMediaRendererHeartbeat);
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        bool initialState = true;
        void PlaylistPanel_HandleCreated(object sender, EventArgs e)
        {
            try
            {
                UpdateButtonsState();
                
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
            finally
            {
                Invalidate(true);
            }
        }

        internal List<PlaylistItem> GetPlaylistItems()
        {
            return playlist.AllItems;
        }

        internal void Clear()
        {
            ilImages.Images.Clear();
            lvPlaylist.Items.Clear();
            playlist.ClearAll();
            UpdateButtonsState();
        }

        internal void AddFiles(IEnumerable<string> files)
        {
            if (_abortLoad)
                return;

            if (files != null)
            {
                foreach (string file in files)
                {
                    if (_abortLoad)
                        break;

                    if (DvdMedia.FromPath(file) != null)
                    {
                        playlist.AddItem(file);
                        return;
                    }
                    else if (IsPlaylist(file))
                    {
                        LoadPlaylist(file, true);
                    }
                    else if (IsFolder(file))
                    {
                        AddFiles(Directory.EnumerateDirectories(file));
                        AddFiles(Directory.EnumerateFiles(file));
                    }
                    else
                    {
                        playlist.AddItem(file);
                    }
                }
            }
        }

        private bool IsPlaylist(string file)
        {
            try
            {
                Uri uri = new Uri(file);
                string ext = PathUtils.GetExtension(uri.LocalPath);
                return MediaRenderer.SupportedPlaylists.Contains(ext);
            }
            catch
            {
                return false;
            }
        }

        private bool IsFolder(string file)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(file);
                return (di.Exists);
                //{
                  //  return ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory);
                //}
            }
            catch
            {
            }

            return false;
        }

        internal string GetFirstFile()
        {
            if (playlist.Count > 0)
            {
                return playlist[playlist.FirstIndex].Path;
            }

            return string.Empty;
        }

        internal string GetNextFile()
        {
            string retVal = null;

            if (playlist.MoveNext())
            {
                retVal = GetSelectedFile();
            }

            return retVal;
        }

        internal string GetPreviousFile()
        {
            string retVal = null;

            if (playlist.MovePrevious())
            {
                retVal = GetSelectedFile();
            }

            return retVal;
        }

        internal string GetSelectedFile()
        {
            if (playlist.Count <= 0)
                return null;

            return GetActivePlaylistItem().Path;
        }

        internal string GetSelectedFileTitle()
        {
            if (playlist.Count <= 0)
                return null;

            return GetActivePlaylistItem().DisplayName;
        }

        internal PlaylistItem GetActivePlaylistItem()
        {
            if (playlist.Count <= 0)
                return null;

            return playlist.ActivePlaylistItem;
        }

        internal void Delete()
        {
            List<PlaylistItem> itemsToDelete = new List<PlaylistItem>();
            if (lvPlaylist.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvItem in lvPlaylist.SelectedItems)
                {
                    PlaylistItem itemToDelete = lvItem.Tag as PlaylistItem;
                    if (itemToDelete != null)
                    {
                        Logger.LogTrace("Requested to Delete an item from the playlist, index="
                            + lvItem.Index);
                        itemsToDelete.Add(itemToDelete);
                    }
                }
            }

            if (itemsToDelete.Count > 0)
            {
                playlist.RemoveItems(itemsToDelete);
            }

            Logger.LogTrace("Requested to Delete but no item selected -- requested igonred.");
        }

        internal void MoveDown()
        {
            List<int> selectedIndexes = new List<int>();
            List<int> selectedIndexesAfter = new List<int>();

            foreach (ListViewItem row in lvPlaylist.SelectedItems)
            {
                int i = row.Index;
                selectedIndexes.Add(i);
                selectedIndexesAfter.Add(i + 1);
            }

            if (playlist.ShiftItems(selectedIndexes, false))
            {
                foreach (ListViewItem item in lvPlaylist.Items)
                {
                    item.Selected = selectedIndexesAfter.Contains(item.Index);
                }
            }
        }

        internal void MoveUp()
        {
            List<int> selectedIndexes = new List<int>();
            List<int> selectedIndexesAfter = new List<int>();

            foreach (ListViewItem row in lvPlaylist.SelectedItems)
            {
                int i = row.Index;
                selectedIndexes.Add(i);
                selectedIndexesAfter.Add(i - 1);
            }

            if (playlist.ShiftItems(selectedIndexes, true))
            {
                foreach (ListViewItem item in lvPlaylist.Items)
                {
                    item.Selected = selectedIndexesAfter.Contains(item.Index);
                }
            }
        }

        internal void SavePlaylist()
        {
            string filter = string.Empty;

            filter += MediaRenderer.DefaultInstance.PlaylistsFilter;
            filter += Translator.Translate("TXT_ALL_FILES_FILTER");
            filter = filter.Replace("TXT_PLAYLISTS", Translator.Translate("TXT_PLAYLISTS"));

            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Title = Translator.Translate("TXT_SAVEPLAYLIST");
            dlg.Filter = filter;
            dlg.DefaultExt = "m3u";
            dlg.FilterIndex = AppSettings.PL_LastFilterIndex;
            dlg.InitialDirectory = AppSettings.PL_LastOpenedFolder;

            dlg.InheritAppIcon = false;
            dlg.Icon = Resources.btnSavePlaylist.ToIcon((uint)Color.White.ToArgb());

            dlg.FillFavoriteFoldersEvt += () => { return SuiteConfiguration.GetFavoriteFolders("FavoriteFolders"); };
            dlg.AddToFavoriteFolders += (s) => { return AddToFavoriteFolders(s); };

            dlg.ShowAddToFavorites = true;
            dlg.ShowNewFolder = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AppSettings.PL_LastFilterIndex = dlg.FilterIndex;

                playlist.SavePlaylist(dlg.FileName);

                try
                {
                    FileInfo fi = new FileInfo(dlg.FileName);
                    AppSettings.PL_LastOpenedFolder = fi.DirectoryName;
                }
                catch
                {
                    AppSettings.PL_LastOpenedFolder = dlg.InitialDirectory;
                }
            }
        }

        public void LoadPlaylist(string file, bool enqueue)
        {
            if (!enqueue)
            {
                Clear();
            }

            Uri uri = new Uri(file);
            if (uri.Scheme == "file")
            {
                playlist.LoadPlaylist(file);
            }
            else
            {
                string fileName = Path.GetFileName(uri.LocalPath);
                string tempFile = Path.Combine(Path.GetTempPath(), fileName);

                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = AppSettings.GetWebProxy();
                    wc.DownloadFile(uri, tempFile);
                    playlist.LoadPlaylist(tempFile);
                }

                //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                //request.Headers.Clear();
                //request.Proxy = AppSettings.GetWebProxy();

                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                //    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                //    using (StreamWriter sw = new StreamWriter(tempFile))
                //    {
                //        string s = sr.ReadToEnd();
                //        sw.Write(s);
                //    }

                //    playlist.LoadPlaylist(tempFile);
                //}
            }
        }

        internal void LoadPlaylist()
        {
            string filter = string.Empty;

            filter += MediaRenderer.DefaultInstance.PlaylistsFilter;
            filter += Translator.Translate("TXT_ALL_FILES_FILTER");
            filter = filter.Replace("TXT_PLAYLISTS", Translator.Translate("TXT_PLAYLISTS"));

            OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
            dlg.Multiselect = true;
            dlg.Title = Translator.Translate("TXT_LOADPLAYLIST");
            dlg.Filter = filter;
            dlg.FilterIndex = AppSettings.PL_LastFilterIndex;
            dlg.InitialDirectory = AppSettings.PL_LastOpenedFolder;

            dlg.InheritAppIcon = false;
            dlg.Icon = Resources.btnLoadPlaylist.ToIcon((uint)Color.White.ToArgb());

            dlg.FillFavoriteFoldersEvt += () => { return SuiteConfiguration.GetFavoriteFolders("FavoriteFolders"); };
            dlg.AddToFavoriteFolders += (s) => { return AddToFavoriteFolders(s); };

            dlg.ShowAddToFavorites = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AppSettings.PL_LastFilterIndex = dlg.FilterIndex;

                Clear();
                playlist.LoadPlaylist(dlg.FileName);

                try
                {
                    FileInfo fi = new FileInfo(dlg.FileName);
                    AppSettings.PL_LastOpenedFolder = fi.DirectoryName;
                }
                catch
                {
                    AppSettings.PL_LastOpenedFolder = dlg.InitialDirectory;
                }
            }
        }

        private bool AddToFavoriteFolders(string path)
        {
            List<string> favorites = new List<string>(SuiteConfiguration.GetFavoriteFolders("FavoriteFolders"));
            if (favorites.Contains(path))
                return false;

            favorites.Add(path);
            SuiteConfiguration.SetFavoriteFolders(favorites, "FavoriteFolders");
            return true;
        }

        void playlist_PlaylistUpdated(int item1, int item2, UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.Added:
                    {
                        PlaylistItem plItem = playlist[item1];

                        ListViewItem item = new ListViewItem(new string[] { "", "", "", "", "" });
                        lvPlaylist.Items.Add(item);
                        SetItemRelation(item, plItem);
                    }
                    break;

                case UpdateType.Removed:
                    if (item1 >= 0 && item1 < lvPlaylist.Items.Count)
                    {
                        lvPlaylist.Items.RemoveAt(item1);
                        if (item1 < lvPlaylist.Items.Count)
                        {
                            lvPlaylist.Items[item1].Selected = true;
                        }
                    }
                    break;

                case UpdateType.Swapped:
                    if (item1 >= 0 && item1 < lvPlaylist.Items.Count &&
                        item2 >= 0 && item2 < lvPlaylist.Items.Count)
                    {
                        ListViewItem lvItem1 = lvPlaylist.Items[item1];
                        ListViewItem lvItem2 = lvPlaylist.Items[item2];

                        PlaylistItem plItem1 = lvItem1.Tag as PlaylistItem;
                        PlaylistItem plItem2 = lvItem2.Tag as PlaylistItem;

                        SetItemRelation(lvItem1, plItem2);
                        SetItemRelation(lvItem2, plItem1);

                        lvItem1.Selected = false;
                        lvItem2.Selected = true;
                    }
                    break;
            }

            UpdateButtonsState();
            UpdateTotalTime(playlist.TotalPlaylistTime);
        }

        private void SetItemRelation(ListViewItem lvItem, PlaylistItem plItem)
        {
            if (lvItem != null && plItem != null)
            {
                lvItem.Tag = plItem;
                lvItem.SubItems[colFile.Index].Text = plItem.DisplayName;

                TimeSpan duration = plItem.Duration;
                bool isActive = IsActiveItem(plItem);

                if (duration.TotalMilliseconds == 0 && isActive)
                {
                    try
                    {
                        duration = TimeSpan.FromSeconds((int)MediaRenderer.DefaultInstance.MediaLength);
                    }
                    catch
                    {
                        duration = TimeSpan.FromMilliseconds(0);
                    }

                    plItem.Duration = duration;
                }

                if (duration.TotalMilliseconds == 0)
                {
                    lvItem.SubItems[colTime.Index].Text = "";
                }
                else
                {
                    lvItem.SubItems[colTime.Index].Text = duration.ToString();
                }

                Image img = ImageProvider.GetIcon(plItem.Path, false);
                lvItem.SubItems[colIcon.Index].Tag = new ExtendedSubItemDetail(img, null);

                UpdateMiscIcon(lvItem);
            }
        }

        private int GetIcon(string strFile)
        {
            ilImages.Images.Add(ImageProvider.GetIcon(strFile, false));
            return ilImages.Images.Count - 1;
        }

        private void lvPlaylist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                lvPlaylist.SelectedItems.Count > 0)
            {
                int sel = lvPlaylist.SelectedItems[0].Index;
                if (playlist.MoveToItem(sel) && LaunchFile != null)
                {
                    LaunchFile(GetSelectedFile());
                }
            }
        }

        internal int GetFileCount()
        {
            return playlist.Count;
        }

        private void lvPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }

        private void lvPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        private void lvPlaylist_DragLeave(object sender, EventArgs e)
        {
            OnDragLeave(e);
        }

        private void lvPlaylist_DragOver(object sender, DragEventArgs e)
        {
            OnDragOver(e);
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (args.Handled)
                return;

            bool refreshButtonState = false;

            switch (args.cmd)
            {
                case OPMShortcut.CmdClear:
                    Clear();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdDelete:
                    Delete();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdLoadPlaylist:
                    LoadPlaylist();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdSavePlaylist:
                    SavePlaylist();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdMoveDown:
                    MoveDown();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdMoveUp:
                    MoveUp();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdJumpToItem:
                    HandleJumpToItem();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdToggleShuffle:
                    AppSettings.ShufflePlaylist ^= true;
                    AppSettings.Save();
                    playlist.SetupRandomSequence(playlist.PlayIndex);
                    args.Handled = true;
                    refreshButtonState = true;
                    break;

                case OPMShortcut.CmdLoopPlay:
                    AppSettings.LoopPlay ^= true;
                    AppSettings.Save();
                    args.Handled = true;
                    refreshButtonState = true;
                    break;

                case OPMShortcut.CmdPlaylistEnd:
                    SystemScheduler.PlaylistEventEnabled ^= true;
                    refreshButtonState = true;
                    args.Handled = true;
                    break;
            }

            if (refreshButtonState)
            {
                EventDispatch.DispatchEvent(LocalEventNames.UpdateStateButtons);
            }
        }

        private void HandleJumpToItem()
        {
            JumpToItemDlg dlg = new JumpToItemDlg(playlist);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedItem != null)
                {
                    JumpToPlaylistItem(dlg.SelectedItem);
                    LaunchFile(GetSelectedFile());
                }
            }
        }

        private void UpdateButtonsState()
        {
            SuspendLayout();

            bool singleItemSelected = (lvPlaylist.SelectedItems.Count == 1);
            bool itemsSelected = (lvPlaylist.SelectedItems.Count > 0);
            bool itemsPresent = (lvPlaylist.Items.Count > 0);

            UpdateButtonsState(singleItemSelected, itemsSelected, itemsPresent);

            ResumeLayout();

            if (singleItemSelected)
            {
                PlaylistItem plItem = lvPlaylist.SelectedItems[0].Tag as PlaylistItem;
                if (plItem != null)
                {
                    bookmarkManagerCtl.PlaylistItem = plItem;
                }
            }
        }

        private void lvPlaylist_SelectionChanged(object sender, EventArgs e)
        {
            bookmarkManagerCtl.PlaylistItem = null;
            UpdateButtonsState();
        }

        internal bool JumpToPlaylistItem(PlaylistItem plItem)
        {
            return playlist.MoveToItem(plItem);
        }

        internal bool IsActiveItem(PlaylistItem plItem)
        {
            return playlist.ActivePlaylistItem == plItem;
        }

        private void lvPlaylist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            }
        }

        public PlaylistItem GetPlaylistItemForEditing()
        {
            if (lvPlaylist.SelectedItems != null && lvPlaylist.SelectedItems.Count > 0)
            {
                ListViewItem selItem = lvPlaylist.SelectedItems[0];
                if (selItem != null)
                {
                    return selItem.Tag as PlaylistItem;
                }
            }

            return null;
        }

        void lvPlaylist_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            ListViewItem item = e.Item;
            bool set = false;
            Point p = lvPlaylist.PointToClient(MousePosition);

            try
            {
                if (item != null && MouseButtons == MouseButtons.None)
                {
                    ListViewItem.ListViewSubItem lvsi = item.GetSubItemAt(p.X, p.Y);
                    if (lvsi != null)
                    {
                        ExtendedSubItemDetail esid = lvsi.Tag as ExtendedSubItemDetail;
                        if (esid != null && !string.IsNullOrEmpty(esid.Text))
                        {
                            _ttm.ShowSimpleToolTip(esid.Text, Resources.ResourceManager.GetImage("subtitles"));
                            set = true;
                        }
                        else
                        {
                            PlaylistItem pli = item.Tag as PlaylistItem;
                            if (pli != null)
                            {
                                pli.DeepLoad();

                                Image img = ImageProvider.GetIcon(pli.Path, true);

                                Image customImage = pli.MediaFileInfo.CustomImage;

                                _ttm.ShowToolTip(StringUtils.Limit(pli.DisplayName, 60), pli.MediaInfo, img, customImage);
                                set = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (!set)
                {
                    Debug.WriteLine("PL: lvPlaylist_ItemMouseHover no tip to set ...");
                    _ttm.RemoveAll();
                }
            }
        }

        bool isBMVisible = false;
        private void plDisplay_ShowHideBM(object sender, EventArgs e)
        {
            if (isBMVisible)
            {
                bookmarkManagerCtl.SaveBookmarks();
            }

            isBMVisible ^= true;
            AdjustWidth();
        }

        private void AdjustWidth()
        {
            layoutPanel.ColumnStyles[0].Width = isBMVisible ? 50f : 100f;
            layoutPanel.ColumnStyles[1].Width = isBMVisible ? 50f : 0f;
        }

        internal void OpenBM()
        {
            plDisplay_ShowHideBM(this, EventArgs.Empty);
        }

        private void cmsPlaylist_Opening(object sender, CancelEventArgs e)
        {
            cmsPlaylist.Items.Clear();

            PlaylistItem plItem = GetPlaylistItemForEditing();

            new MenuBuilder<ContextMenuStrip>(this).AttachPlaylistItemMenu(plItem,
                    new MenuWrapper<ContextMenuStrip>(cmsPlaylist),
                    (lvPlaylist.SelectedItems.Count == 1) ? MenuType.SingleItem : MenuType.MultipleItems,
                    PlaylistItemMenuClick);
        }

        private void lvPlaylist_Resize(object sender, EventArgs e)
        {
            colDummy.Width = 0;
            colIcon.Width = 18;
            colMisc.Width = 18;
            colTime.Width = 50;
            colFile.Width = lvPlaylist.Width - colIcon.Width - colMisc.Width - colTime.Width - 
                SystemInformation.VerticalScrollBarWidth;
        }

        private void UpdateTotalTime(double totalSeconds)
        {
            TimeSpan ts = TimeSpan.FromSeconds((int)totalSeconds);
            int h = ts.Days * 24 + ts.Hours;

            lblTotal.Text = string.Format("Total: {0}:{1:d2}:{2:d2}",
                h, ts.Minutes, ts.Seconds);
        }

        public void UpdateButtonsState(bool singleItemSelected, bool itemsSelected, bool itemsPresent)
        {
            SuspendLayout();

            PlaylistButtonData[] buttonsData = new PlaylistButtonData[5];

            buttonsData[0].buttonType = PlaylistButtonType.MoveUp;
            buttonsData[1].buttonType = PlaylistButtonType.MoveDown;
            buttonsData[2].buttonType = PlaylistButtonType.Delete;
            buttonsData[3].buttonType = PlaylistButtonType.Clear;
            buttonsData[4].buttonType = PlaylistButtonType.SavePlaylist;

            buttonsData[0].buttonCommand = OPMShortcut.CmdMoveUp;
            buttonsData[1].buttonCommand = OPMShortcut.CmdMoveDown;
            buttonsData[2].buttonCommand = OPMShortcut.CmdDelete;
            buttonsData[3].buttonCommand = OPMShortcut.CmdClear;
            buttonsData[4].buttonCommand = OPMShortcut.CmdSavePlaylist;

            buttonsData[0].buttonState =
                (itemsSelected) ? PlaylistButtonState.Enabled : PlaylistButtonState.Disabled;
            buttonsData[1].buttonState =
                (itemsSelected) ? PlaylistButtonState.Enabled : PlaylistButtonState.Disabled;
            buttonsData[2].buttonState =
                (itemsSelected) ? PlaylistButtonState.Enabled : PlaylistButtonState.Disabled;
            buttonsData[3].buttonState =
                (itemsPresent) ? PlaylistButtonState.Enabled : PlaylistButtonState.Disabled;
            buttonsData[4].buttonState =
                (itemsPresent) ? PlaylistButtonState.Enabled : PlaylistButtonState.Disabled;

            playlistControlPanel.SetButtonsData(buttonsData, true);

            ResumeLayout();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void OnShowHidePLControls(object sender, EventArgs e)
        {
            playlistControlPanel.Visible ^= true;

            if (playlistControlPanel.Visible)
                btnShowHidePLControls.Text = "<";
            else
                btnShowHidePLControls.Text = ">";
        }

        private void OnShowHideBM(object sender, EventArgs e)
        {
            bookmarkManagerCtl.Visible ^= true;

            if (bookmarkManagerCtl.Visible)
            {
                bookmarkManagerCtl.Width = 220;
                btnShowHideBM.Text = "<";
            }
            else
                btnShowHideBM.Text = ">";

            string text = (bookmarkManagerCtl.Visible) ?
                "TXT_CMDHIDEBOOKMARKMANAGER" : "TXT_CMDBOOKMARKMANAGER";

            _tip.SetSimpleToolTip(btnShowHideBM, Translator.Translate(text));
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            lvPlaylist.Focus();
        }
    }
}
