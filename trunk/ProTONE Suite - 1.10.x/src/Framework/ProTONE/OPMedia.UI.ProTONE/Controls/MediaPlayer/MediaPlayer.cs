using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using OPMedia.UI.Controls;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.Runtime.ProTONE;
using System.Diagnostics;
using OPMedia.Core.Logging;

using System.IO;
using OPMedia.Core.TranslationSupport;
using System.Threading;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Core;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;

using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.ProTONE.Dialogs;
using OPMedia.UI.ProTONE.Configuration;

using OPMedia.UI.Configuration;
using OPMedia.Runtime.ProTONE.ExtendedInfo;

using OPMedia.UI.ProTONE.Controls.BookmarkManagement;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.Runtime;
using System.Net.NetworkInformation;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.Menus;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.UI.Controls.Dialogs;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using System.Net;
using OPMedia.Core.Utilities;
using OPMedia.Runtime.ProTONE.RemoteControl;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public delegate void NotifyMediaStateChangedHandler(bool isVideoFile);

    public partial class MediaPlayer : OPMBaseControl
    {
        public event NotifyMediaStateChangedHandler NotifyMediaStateChanged = null;

        private ContextMenuStrip _menuRendering = null;

        #region Members
        const int PanelOffset = 20;

        public bool compactView = false;
        public bool Autoplay = true;
        string playedFileTitle = string.Empty;
        int playlistWidth = 0;
        #endregion

        public bool CompactView
        {
            set 
            { 
                compactView = value; 
                DoLayout();  
            }
            get { return compactView; }
        }

        public new Size MinimumSize
        {
            get { return CompactView ? 
                pnlRendering.MinimumSize : 
                new Size(pnlRendering.MinimumSize.Width + pnlPlaylist.MinimumSize.Width, 
                pnlRendering.MinimumSize.Height); }
                
            set { base.MinimumSize = value; }
        }

        public string PlayedFileTitle
        {
            get { return playedFileTitle; }
        }

        #region Public methods
        

        public void StopPlayback()
        {
            Stop(true);
        }

        public void PlayFiles(string[] fileNames)
        {
            LoadFiles(fileNames);
        }

        public void EnqueueFiles(string[] fileNames)
        {
            int initialCount = pnlPlaylist.GetFileCount();
            pnlPlaylist.AddFiles(fileNames);
            if (initialCount < 1 && Autoplay)
            {
                PlayFile(pnlPlaylist.GetSelectedFile(), null);
            }
        }

        public new void Dispose()
        {
        }

        public void DoLayout()
        {
            pnlPlaylist.Visible = !compactView;

            layoutPanel.Controls.Clear();
            if (!compactView)
            {
                layoutPanel.Controls.Add(pnlPlaylist, 0, 0);
            }
            layoutPanel.Controls.Add(pnlRendering, 0, layoutPanel.Controls.Count);

            pnlRendering.CompactView = compactView;
            //canResize = true;

        }
        #endregion

        #region Constructor
        public MediaPlayer() : base()
        {
            InitializeComponent();

            pnlRendering.TimeScaleEnabled = false;

            pnlRendering.PositionChanged += 
                new ValueChangedEventHandler(pnlRendering_PositionChanged);
            pnlRendering.VolumeChanged += 
                new ValueChangedEventHandler(pnlRendering_VolumeChanged);

            this.MouseWheel += new MouseEventHandler(MediaPlayer_MouseWheel);
            this.HandleCreated += new EventHandler(MediaPlayer_HandleCreated);
            this.HandleDestroyed += new EventHandler(MediaPlayer_HandleDestroyed);

            pnlPlaylist.LaunchFile += new LaunchFileEventHandler(pnlPlaylist_LaunchFile);
            pnlPlaylist.PlaylistItemMenuClick += new EventHandler(HandlePlaylistItemMenuClick);

            if (!DesignMode)
            {
                MediaRenderer.DefaultInstance.FilterStateChanged += new FilterStateChangedHandler(OnMediaStateChanged);
                MediaRenderer.DefaultInstance.MediaRendererHeartbeat += new MediaRendererEventHandler(OnMediaRendererHeartbeat);
            }
        }

        [EventSink(LocalEventNames.JumpToBookmark)]
        public void OnJumpToBookmark(BookmarkSubItem subItem)
        {
            JumpToPlaylistSubItem(subItem);
        }
        #endregion

        #region Event handlers

        #region Drag-and-drop events and related

        #region DragEnter
        private void pnlPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            pnlRendering_DragEnter(sender, e);
        }

        private void pnlRendering_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!CompactView)
            {
                string[] droppedFiles = GetRelevantDragDropData(e);
                if (droppedFiles != null)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        #endregion

        #region DragLeave
        private void pnlPlaylist_DragLeave(object sender, EventArgs e)
        {
            pnlRendering_DragLeave(sender, e);
        }

        private void pnlRendering_DragLeave(object sender, EventArgs e)
        {
            // Do nothing
        }
        #endregion

        #region DragOver
        private void pnlPlaylist_DragOver(object sender, DragEventArgs e)
        {
            pnlRendering_DragOver(sender, e);
        }

        private void pnlRendering_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!CompactView)
            {
                string[] droppedFiles = GetRelevantDragDropData(e);
                if (droppedFiles != null)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        #endregion

        #region DragDrop
        private void pnlPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!CompactView)
            {
                string[] droppedFiles = GetRelevantDragDropData(e);
                if (droppedFiles != null)
                {
                    int initialCount = pnlPlaylist.GetFileCount();

                    e.Effect = DragDropEffects.Move;

                    pnlPlaylist.AddFiles(droppedFiles);

                    if (initialCount < 1 && Autoplay)
                    {
                        PlayFile(pnlPlaylist.GetFirstFile(), null);
                    }
                }
            }
        }

        private void pnlRendering_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!CompactView)
            {
                string[] droppedFiles = GetRelevantDragDropData(e);
                if (droppedFiles != null)
                {
                    e.Effect = DragDropEffects.Move;
                    LoadFiles(droppedFiles);
                }
            }
        }
        #endregion

        #endregion

        void MediaPlayer_HandleDestroyed(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!CompactView)
                {
                    AppSettings.RenderPanelWidth = playlistWidth;
                }

                MediaRenderer.DefaultInstance.FilterStateChanged -= new FilterStateChangedHandler(OnMediaStateChanged);
                MediaRenderer.DefaultInstance.MediaRendererHeartbeat -= new MediaRendererEventHandler(OnMediaRendererHeartbeat);

                MediaRenderer.DefaultInstance.Dispose();
            }
        }

        void MediaPlayer_HandleCreated(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                pnlRendering.ProjectedVolume = AppSettings.LastVolume;
                SetVolume(pnlRendering.ProjectedVolume);
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            playlistWidth = pnlPlaylist.Width;
        }

        void pnlPlaylist_LaunchFile(string path)
        {
            PlayFile(path, null);
        }

        void MediaPlayer_MouseWheel(object sender, MouseEventArgs e)
        {
            pnlRendering.ProjectedVolume += e.Delta;
            SetVolume(pnlRendering.ProjectedVolume);
        }

        void pnlRendering_PositionChanged(double newVal)
        {
            if (MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped)
            {
                if (MediaRenderer.DefaultInstance.FilterState != FilterState.Paused)
                {
                    MediaRenderer.DefaultInstance.PauseRenderer();
                }
                
                MediaRenderer.DefaultInstance.ResumeRenderer(newVal);

                NotifyGUI("TXT_OSD_SEEKTO", TimeSpan.FromSeconds((int)newVal));
            }
        }

        public void NotifyGUI(string format, params object[] args)
        {
            string text = Translator.Translate(format, args);

            MediaRenderer.DefaultInstance.DisplayOsdMessage(text);

            if (AppSettings.MediaStateNotificationsEnabled)
            {
                TrayNotificationBox f = new TrayNotificationBox();
                f.HideDelay = 6000;
                f.AnimationType = AnimationType.Dissolve;
                f.ShowSimple(text);

                this.Focus();
            }
        }

        void pnlRendering_VolumeChanged(double newVal)
        {
            SetVolume(newVal);
        }

        private void OnMediaStateChanged(FilterState oldState, string oldMedia, 
            FilterState newState, string newMedia)
        {
            OnMediaRendererHeartbeat();

            pnlRendering.FilterStateChanged(newState, newMedia, MediaRenderer.DefaultInstance.RenderedMediaType);

            if (newState == FilterState.NotOpened && Autoplay && pnlPlaylist.GetFileCount() >= 1)
            {
                MediaRenderer.DefaultInstance.PlaylistAtEnd = pnlPlaylist.IsPlaylistAtEnd;
                MoveNext();
            }
            else
            {
                MediaRenderer.DefaultInstance.PlaylistAtEnd = false;
            }
        }

        private void OnMediaRendererHeartbeat()
        {
            if (pnlRendering.ProjectedVolume != AppSettings.LastVolume)
            {
                pnlRendering.ProjectedVolume = AppSettings.LastVolume;
            }

            pnlRendering.ElapsedSeconds = (int)(MediaRenderer.DefaultInstance.MediaPosition);
            pnlRendering.TotalSeconds = (int)(MediaRenderer.DefaultInstance.MediaLength);

            pnlRendering.TimeScaleEnabled = MediaRenderer.DefaultInstance.CanSeekMedia &&
                (MediaRenderer.DefaultInstance.FilterState == FilterState.Running || 
                MediaRenderer.DefaultInstance.FilterState == FilterState.Paused);

            pnlRendering.VolumeScaleEnabled = (MediaRenderer.DefaultInstance.RenderedMediaType != MediaTypes.Video);
            
            if (_renderingFrame != null)
            {
                _renderingFrame.SetTitle(BuildTitle());
            }

            try
            {
                if (MediaRenderer.DefaultInstance.FilterState == FilterState.Running)
                {
                    Bookmark bmk = MediaRenderer.DefaultInstance.RenderedMediaInfo.GetNearestBookmarkInRange(
                        (int)MediaRenderer.DefaultInstance.MediaPosition, 1);

                    if (bmk != null)
                    {
                        Logger.LogHeavyTrace("Display Bookmark: " + bmk.ToString());
                        MediaRenderer.DefaultInstance.DisplayOsdMessage(bmk.Title.Replace(";", "\r\n"));
                    }
                }
            }
            catch
            {
            }
        }

        public string BuildTitle()
        {
            string title = Translator.Translate("TXT_APP_NAME");
            try
            {
                if (playedFileTitle.Length > 0)
                {
                    title = string.Format("{1} - [{2}] - {0}",
                        Translator.Translate("TXT_APP_NAME"),
                        playedFileTitle, MediaRenderer.DefaultInstance.TranslatedFilterState);
                }
                else
                {
                    title = Translator.Translate("TXT_APP_NAME");
                }
            }
            catch
            {
            }

            return title;
        }
        #endregion

        #region Implementation
        private void Stop(bool isStopFromGui)
        {
            if (MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped)
            {
                MediaRenderer.DefaultInstance.StopRenderer();

                if (isStopFromGui)
                {
                    HideRenderingRegion();
                }
            }
        }

        private void Play()
        {
            string fileToPlay = pnlPlaylist.GetSelectedFile();
            PlayFile(fileToPlay, null);
        }

        private void Pause()
        {
            switch (MediaRenderer.DefaultInstance.FilterState)
            {
                case FilterState.Running:
                    {
                        NotifyGUI("TXT_OSD_PAUSED");

                        // OSD text can be updated via FFDShow only while playing, never while paused.
                        // So we need a small time before pausing, to allow OSD to show "paused"
                        // Then we can effectively pause
                        Thread.Sleep(200);

                        MediaRenderer.DefaultInstance.PauseRenderer();
                    }
                    break;

                case FilterState.Paused:
                    {
                        MediaRenderer.DefaultInstance.ResumeRenderer(MediaRenderer.DefaultInstance.MediaPosition);

                        // Keep this action to execute AFTER resuming playback
                        // OSD text can be updated via FFDShow only while playing, never while paused.
                        NotifyGUI("TXT_OSD_SEEKTO",
                            TimeSpan.FromSeconds((int)MediaRenderer.DefaultInstance.MediaPosition));
                    }
                    break;
            }
        }

        private void MoveNext()
        {
            string strFile = pnlPlaylist.GetNextFile();
            PlayFile(strFile, null);
        }

        private void MovePrevious()
        {
            string strFile = pnlPlaylist.GetPreviousFile();
            PlayFile(strFile, null);
        }

        private void LoadDisc()
        {
            SelectDvdMediaDlg dlg = new SelectDvdMediaDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedMedia != null)
                {
                    string[] dvdDrive = new string[] { dlg.SelectedMedia.DvdPath };

                    pnlPlaylist.Clear();
                    pnlPlaylist.AddFiles(dvdDrive);

                    if (Autoplay)
                    {
                        PlayFile(pnlPlaylist.GetFirstFile(), null);
                    }

                }
            }
        }

        private void LoadFiles()
        {
            OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
            dlg.Title = Translator.Translate("TXT_LOADMEDIAFILES");
            dlg.Multiselect = true;

            dlg.InheritAppIcon = false;
            dlg.Icon = Resources.btnLoad.ToIcon((uint)Color.White.ToArgb());

            string filter = string.Empty;

            filter += MediaRenderer.DefaultInstance.AvailableFileTypesFilter;
            filter += Translator.Translate("TXT_ALL_FILES_FILTER");

            filter = filter.Replace("TXT_AUDIO_FILES", Translator.Translate("TXT_AUDIO_FILES"));
            filter = filter.Replace("TXT_VIDEO_FILES", Translator.Translate("TXT_VIDEO_FILES"));
            filter = filter.Replace("TXT_VIDEO_HD_FILES", Translator.Translate("TXT_VIDEO_HD_FILES"));
            filter = filter.Replace("TXT_PLAYLISTS", Translator.Translate("TXT_PLAYLISTS"));
            
            dlg.Filter = filter;

            dlg.FilterIndex = AppSettings.LastFilterIndex;
            dlg.InitialDirectory = AppSettings.LastOpenedFolder;

            dlg.FillFavoriteFoldersEvt += () => { return SuiteConfiguration.GetFavoriteFolders("FavoriteFolders"); };
            dlg.AddToFavoriteFolders += (s) => { return AddToFavoriteFolders(s); };
            dlg.ShowAddToFavorites = true;

            dlg.OpenDropDownOptions = new List<OpenOption>(new OpenOption[]
            {
                new MediaPlayerOpenOption(CommandType.PlayFiles),
                new MediaPlayerOpenOption(CommandType.EnqueueFiles)
            });

            if (dlg.ShowDialog() == DialogResult.OK && dlg.FileNames.Length > 0)
            {
                CommandType openOption = CommandType.PlayFiles;
                try
                {
                    openOption = (CommandType)dlg.OpenOption;
                }
                catch
                {
                    openOption = CommandType.PlayFiles;
                }

                if (openOption == CommandType.EnqueueFiles)
                    EnqueueFiles(dlg.FileNames);
                else
                    LoadFiles(dlg.FileNames);

                AppSettings.LastFilterIndex = dlg.FilterIndex;

                try
                {
                    FileInfo fi = new FileInfo(dlg.FileNames[0]);
                    AppSettings.LastOpenedFolder = fi.DirectoryName;
                }
                catch
                {
                    AppSettings.LastOpenedFolder = dlg.InitialDirectory;
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

        private void LoadFiles(string[] fileNames)
        {
            pnlPlaylist.Clear();
            pnlPlaylist.AddFiles(fileNames);

            if (Autoplay)
            {
                PlayFile(pnlPlaylist.GetFirstFile(), null);
            }
        }

        internal void PlayFile(string strFile, PlaylistSubItem subItem)
        {
            if (!string.IsNullOrEmpty(strFile))
            {
                if (subItem == null && MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped)
                {
                    Stop(false);
                }

                bool isVideoFile = false;
                bool isDVDVolume = false;

                string name = string.Empty;

                DvdMedia dvdDrive = DvdMedia.FromPath(strFile);
                if (dvdDrive != null)
                {
                    isDVDVolume = true;
                    name = dvdDrive.ToString();

                    if (subItem != null && subItem.StartHint != null)
                    {
                        name += Translator.Translate("TXT_PLAY_FROM", subItem.StartHint);
                    }
                }
                else
                {
                    MediaFileInfo mfi = MediaFileInfo.FromPath(strFile);
                    isVideoFile = MediaRenderer.SupportedVideoTypes.Contains(mfi.MediaType);
                    name = mfi.Name;
                }

                if (isVideoFile || isDVDVolume)
                {
                    ShowRenderingRegion();
                }
                else
                {
                    HideRenderingRegion();
                }

                if (NotifyMediaStateChanged != null)
                {
                    NotifyMediaStateChanged(isVideoFile || isDVDVolume);
                }

                MediaRenderer.DefaultInstance.SetRenderFile(strFile);

                bool rendererStarted = false;
                if (subItem != null && subItem.StartHint != null)
                {
                    MediaRenderer.DefaultInstance.StartRendererWithHint(subItem.StartHint);
                    rendererStarted = true;
                }

                if (!rendererStarted)
                {
                    MediaRenderer.DefaultInstance.StartRenderer();
                }

                if (_renderingFrame != null && (isVideoFile || isDVDVolume))
                {
                    if (!_renderingFrame.Visible)
                    {
                        _renderingFrame.Show();
                    }
                }

                SetVolume(pnlRendering.ProjectedVolume);

                try
                {
                    playedFileTitle = pnlPlaylist.GetSelectedFileTitle();
                }
                catch
                {
                }

                if (subItem != null && subItem.StartHint != null)
                {
                    NotifyGUI("TXT_OSD_PLAY", subItem);
                }
                else
                {
                    NotifyGUI("TXT_OSD_PLAY", name);
                }

                if (isVideoFile)
                {
                    if (_delayedSubtitleLookupTimer == null)
                    {
                        _delayedSubtitleLookupTimer = new System.Windows.Forms.Timer();
                        _delayedSubtitleLookupTimer.Interval = 1000;
                        _delayedSubtitleLookupTimer.Tick += new EventHandler(_delayedSubtitleLookupTimer_Tick);
                    }

                    _delayedSubtitleLookupTimer.Start();
                }
            }
        }

        void _delayedSubtitleLookupTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                SubtitleDownloadProcessor.TryFindSubtitle(MediaRenderer.DefaultInstance.GetRenderFile(),
                            (int)MediaRenderer.DefaultInstance.MediaLength, false);
            }
            catch { }
            finally
            {
                _delayedSubtitleLookupTimer.Stop();
            }
        }

        public System.Windows.Forms.Timer _delayedSubtitleLookupTimer = null;

        public void SetVolume(double volume)
        {
            AppSettings.LastVolume = (int)volume;
            if (MediaRenderer.DefaultInstance.RenderedMediaType != MediaTypes.Video &&
                MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped)
            {
                MediaRenderer.DefaultInstance.AudioVolume = (int)volume;
                MediaRenderer.DefaultInstance.DisplayOsdMessage(Translator.Translate("TXT_OSD_VOL", (int)volume / 100));

                MediaRenderer.DefaultInstance.AudioBalance = AppSettings.LastBalance;
            }

            if (pnlRendering.ProjectedVolume != AppSettings.LastVolume)
            {
                pnlRendering.ProjectedVolume = AppSettings.LastVolume;
            }
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (args.Handled)
                return;

            Logger.LogInfo("OnExecuteShortcut enter: " + args);

            if (_renderingFrame == null || !_renderingFrame.Visible)
            {
                pnlPlaylist.Focus();
            }

            switch (args.cmd)
            {
                case OPMShortcut.CmdPlay:
                    Play();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdPause:
                    Pause();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdStop:
                    Stop(true);
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdPrev:
                    MovePrevious();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdNext:
                    MoveNext();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdLoad:
                    LoadFiles();
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdFwd:
                    MoveToPosition(pnlRendering.ElapsedSeconds + 5);
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdRew:
                    MoveToPosition(pnlRendering.ElapsedSeconds - 5);
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdVolUp:
                    pnlRendering.ProjectedVolume += 500;
                    SetVolume(pnlRendering.ProjectedVolume);
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdVolDn:
                    pnlRendering.ProjectedVolume -= 500;
                    SetVolume(pnlRendering.ProjectedVolume);
                    args.Handled = true;
                    break;
                case OPMShortcut.CmdFullScreen:
                    ToggleFullScreen();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdOpenDisk:
                    LoadDisc();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgAudio:
                    FfdShowConfig.DoConfigureAudio(this.Handle);
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgVideo:
                    FfdShowConfig.DoConfigureVideo(this.Handle);
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgSubtitles:
                    ProTONESettingsForm.Show("TXT_S_SUBTITLESETTINGS");
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgTimer:
                    ProTONESettingsForm.Show("TXT_S_SCHEDULERSETTINGS");
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgRemote:
                    ProTONESettingsForm.Show("TXT_REMOTECONTROLCFG");
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdOpenSettings:
                    DialogResult dlgResult = ProTONESettingsForm.Show();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdCfgKeyboard:
                    ProTONESettingsForm.Show("TXT_S_KEYMAP");
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdOpenURL:
                    {
                        args.Handled = true;

                        UrlCfgDlg dlg = new UrlCfgDlg(true);
                        dlg.ShowChooserButton = true;
                        dlg.RequiredUriParts = UriComponents.SchemeAndServer;
                        dlg.OpenChooser += new EventHandler((s, e) =>
                        {
                            StreamingServerChooserDlg dlg2 = new StreamingServerChooserDlg();
                            if (dlg2.ShowDialog() == DialogResult.OK)
                            {
                                dlg.Uri = dlg2.Uri;
                                dlg.DialogResult = DialogResult.OK;
                                dlg.Close();
                            }
                        });

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            string[] urls = new string[] { dlg.Uri };
                            LoadFiles(urls);
                        }
                    }
                    break;

                case OPMShortcut.CmdBookmarkManager:
                    {
                        args.Handled = true;
                        pnlPlaylist.OpenBM();
                    }
                    break;

                case OPMShortcut.CmdSearchSubtitles:
                    {
                        args.Handled = true;

                        PlaylistItem plItem = pnlPlaylist.GetPlaylistItemForEditing();
                        if (plItem != null &&
                            plItem.MediaFileInfo is VideoFileInfo)
                        {
                            SubtitleDownloadProcessor.TryFindSubtitle(plItem.Path, (int)plItem.Duration.TotalSeconds, true);
                        }
                    }
                    break;
                    
                default:
                    pnlPlaylist.OnExecuteShortcut(args);
                    break;
            }

            Logger.LogInfo("OnExecuteShortcut leave");
        }

        private void ToggleFullScreen()
        {
            if (MediaRenderer.DefaultInstance.RenderedMediaType == MediaTypes.Video ||
                MediaRenderer.DefaultInstance.RenderedMediaType == MediaTypes.Both &&
                _renderingFrame != null)
            {
                _renderingFrame.ToggleFullScreen();
            }
        }


        public void MoveToPosition(double pos)
        {
            if (MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped && 
                MediaRenderer.DefaultInstance.CanSeekMedia)
            {
                MediaRenderer.DefaultInstance.PauseRenderer();
                MediaRenderer.DefaultInstance.ResumeRenderer(pos);

                NotifyGUI("TXT_OSD_SEEKTO", TimeSpan.FromSeconds((int)pos));
            }
        }

        private string[] GetRelevantDragDropData(DragEventArgs e)
        {
            string[] retVal = null;
            if (e != null)
            {
                e.Effect = DragDropEffects.None;
                if (e.Data != null &&
                    e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] data = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                    List<string> droppedFiles = new List<string>(data);

                    if (droppedFiles.Count > 0)
                    {
                        retVal = droppedFiles.ToArray();
                    }
                }
            }

            return retVal;
        }

        private void ShowRenderingRegion()
        {
            if (_renderingFrame == null)
            {
                CreateRenderingFrame();
            }

            _renderingFrame.SetContextMenuStrip(_menuRendering);

            MediaRenderer.DefaultInstance.RenderPanel = _renderingFrame.RenderingZone;
        }

        private void HideRenderingRegion()
        {
            if (_renderingFrame != null)
            {
                _renderingFrame.Hide();
            }
        }

        private RenderingFrame _renderingFrame = null;
        private void CreateRenderingFrame()
        {
            GC.Collect();

            _renderingFrame = new RenderingFrame();
            _renderingFrame.HandleDestroyed += new EventHandler(renderFrame_HandleDestroyed);
        }

        void renderFrame_HandleDestroyed(object sender, EventArgs e)
        {
            MediaRenderer.DefaultInstance.StopRenderer();
            MediaRenderer.DefaultInstance.RenderPanel = null;
            MediaRenderer.DefaultInstance.MessageDrain = null;
        
            _renderingFrame = null;
            GC.Collect();
        }
        #endregion

        public void SetRenderingMenu(ContextMenuStrip renderingMenu)
        {
            _menuRendering = renderingMenu;
            pnlPlaylist.ContextMenuStrip = renderingMenu;
            pnlRendering.ContextMenuStrip = renderingMenu;
        }

        public void JumpToPlaylistItem(PlaylistItem plItem)
        {
            if (plItem != null)
            {
                if (pnlPlaylist.JumpToPlaylistItem(plItem))
                {
                    string strFile = pnlPlaylist.GetSelectedFile();
                    PlayFile(strFile, null);
                }
            }
        }

        public void JumpToPlaylistSubItem(PlaylistSubItem subItem)
        {
            bool doJump = false;

            if (subItem != null && subItem.Parent != null)
            {
                if (subItem.Parent != pnlPlaylist.GetActivePlaylistItem())
                {
                    if (pnlPlaylist.JumpToPlaylistItem(subItem.Parent))
                    {
                        Stop(true);
                        doJump = true;
                    }
                } 
                else
                {
                    doJump = true;
                }
                
                if (doJump)
                {
                    string strFile = pnlPlaylist.GetSelectedFile();
                    if (!string.IsNullOrEmpty(strFile))
                    {
                        PlayFile(strFile, subItem);
                    }
                    else
                    {
                        PlayFile(subItem.ParentMediaPath, subItem);
                    }
                }
            }
        }

        public void HandlePlaylistItemMenuClick(object sender, EventArgs e)
        {
            OPMToolStripMenuItem senderMenu = (sender as OPMToolStripMenuItem);
            if (senderMenu != null)
            {
                try
                {
                    senderMenu.Enabled = false;

                    if (senderMenu.Tag != null)
                    {
                        if (senderMenu.Tag is PlaylistSubItem)
                        {
                            if (senderMenu.Tag is DvdSubItem)
                            {
                                DvdSubItem si = senderMenu.Tag as DvdSubItem;
                                DvdRenderingStartHint hint =
                                    (si != null) ?
                                    si.StartHint as DvdRenderingStartHint : null;

                                if (hint != null && hint.IsSubtitleHint)
                                {
                                    MediaRenderer.DefaultInstance.SubtitleStream = hint.SID;
                                    return;
                                }
                            }

                            if (senderMenu.Tag is AudioCdSubItem)
                            {
                                CDAFileInfo cdfi = (senderMenu.Tag as AudioCdSubItem).Parent.MediaFileInfo as CDAFileInfo;
                                if (cdfi != null)
                                {
                                    cdfi.RefreshDisk();
                                    EventDispatch.DispatchEvent(LocalEventNames.UpdatePlaylistNames, true);
                                }
                            }
                            else
                            {
                                JumpToPlaylistSubItem(senderMenu.Tag as PlaylistSubItem);
                            }
                        }
                        else if (senderMenu.Tag is PlaylistItem)
                        {
                            JumpToPlaylistItem(senderMenu.Tag as PlaylistItem);
                        }
                        else
                        {
                            ShortcutMapper.DispatchCommand((OPMShortcut)senderMenu.Tag);
                        }
                    }
                }
                finally
                {
                    senderMenu.Enabled = true;
                }
            }
        }

        public void BuildPlaylistMenu(OPMToolStripMenuItem tsmiPlaceholder, EventHandler eventHandler)
        {
            foreach (PlaylistItem plItem in pnlPlaylist.GetPlaylistItems())
            {
                new MenuBuilder<OPMToolStripMenuItem>(pnlPlaylist).AttachPlaylistItemMenu(plItem,
                       new MenuWrapper<OPMToolStripMenuItem>(tsmiPlaceholder),
                       MenuType.Playlist, eventHandler);
            }
            

        }
    }

    public class MediaPlayerOpenOption : OpenOption
    {
        public MediaPlayerOpenOption(CommandType cmd)
            : base(string.Empty, null)
        {
            OPMedia.UI.ProTONE.Configuration.FileTypesPanel.ExplorerLaunchType elt = new FileTypesPanel.ExplorerLaunchType(cmd);
            base.OptionTag = cmd;
            base.OptionTitle = elt.ToString();
        }
    }
}
