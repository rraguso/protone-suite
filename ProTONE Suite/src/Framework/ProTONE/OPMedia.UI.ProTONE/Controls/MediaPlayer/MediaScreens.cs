using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens;
using OPMedia.UI.ProTONE.Controls.BookmarkManagement;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using OPMedia.UI.Themes;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public partial class MediaScreens : ScreenSlider
    {
        public PlaylistScreen PlaylistScreen { get { return base.Screens[0] as PlaylistScreen; } }
        public TrackInfoScreen TrackInfoScreen { get { return base.Screens[1] as TrackInfoScreen; } }
        public VisualEffectsScreen VisualEffectsScreen { get { return base.Screens[2] as VisualEffectsScreen; } }
        public BookmarkScreen BookmarkScreen { get { return base.Screens[3] as BookmarkScreen; } }

        public Control _activeScreen = null;
        public Control _oldActiveScreen = null;
            
        public MediaScreens()
        {
            InitializeComponent();

            AddScreen(new PlaylistScreen());
            AddScreen(new TrackInfoScreen());
            AddScreen(new VisualEffectsScreen());
            AddScreen(new BookmarkScreen());

            this.ScreenChanged += new ScreenChangedHandler(MediaScreens_ScreenChanged);
            this.PlaylistScreen.TotalTimeChanged += new TotalTimeChangedHandler(PlaylistScreen_TotalTimeChanged);

            // TODO - maybe active screen will need to be persisted ?
            _oldActiveScreen = null;
            _activeScreen = this.PlaylistScreen;

            this.HandleCreated += new EventHandler(MediaScreens_HandleCreated);
        }

        void MediaScreens_HandleCreated(object sender, EventArgs e)
        {
            ThemeManager.SetDoubleBuffer(this);
        }

        TimeSpan _totalTime = new TimeSpan(0);

        void PlaylistScreen_TotalTimeChanged(TimeSpan tsTotalTime)
        {
            _totalTime = tsTotalTime;
            DoSetDesc(_activeScreen);
        }

        void MediaScreens_ScreenChanged(Control currentScreen)
        {
            DoScreenSelectionTasks(currentScreen);
            //DoSetDesc(currentScreen);
        }

        private void DoSetDesc(Control c)
        {
            string desc = string.Empty;

            if (c == this.PlaylistScreen)
            {
                int h = _totalTime.Days * 24 + _totalTime.Hours;
                desc = string.Format("Total: {0}:{1:d2}:{2:d2}", h, _totalTime.Minutes, _totalTime.Seconds);
            }
            else if (c == this.BookmarkScreen)
            {
            }
            else if (c == this.TrackInfoScreen)
            {
            }
            else if (c == this.VisualEffectsScreen)
            {
            }

            this.Description = desc;
        }

        private void DoScreenSelectionTasks(Control c)
        {
            string desc = string.Empty;

            _oldActiveScreen = _activeScreen;
            _activeScreen = c;

            if (_activeScreen == this.PlaylistScreen)
            {
                int h = _totalTime.Days * 24 + _totalTime.Hours;
                desc = string.Format("Total: {0}:{1:d2}:{2:d2}", h, _totalTime.Minutes, _totalTime.Seconds);
            }
            else if (_activeScreen == this.BookmarkScreen)
            {
                this.BookmarkScreen.CopyPlaylist(this.PlaylistScreen);

                PlaylistItem plItem = null;
                if (MediaRenderer.DefaultInstance.FilterState == FilterState.Running ||
                    MediaRenderer.DefaultInstance.FilterState == FilterState.Paused)
                {
                    plItem = this.PlaylistScreen.GetActivePlaylistItem();
                }

                if (plItem == null)
                {
                    plItem = this.PlaylistScreen.GetFirstSelectedPlaylistItem();
                }

                this.BookmarkScreen.PlaylistItem = plItem;

            }
            else if (_activeScreen == this.TrackInfoScreen)
            {
                this.TrackInfoScreen.CopyPlaylist(this.PlaylistScreen);

                PlaylistItem plItem = null;
                if (MediaRenderer.DefaultInstance.FilterState == FilterState.Running ||
                    MediaRenderer.DefaultInstance.FilterState == FilterState.Paused)
                {
                    plItem = this.PlaylistScreen.GetActivePlaylistItem();
                }

                if (plItem == null)
                {
                    plItem = this.PlaylistScreen.GetFirstSelectedPlaylistItem();
                }

                this.TrackInfoScreen.PlaylistItem = plItem;
            }
            else if (_activeScreen == this.VisualEffectsScreen)
            {
            }

            if (_oldActiveScreen == this.BookmarkScreen)
            {
                this.BookmarkScreen.SaveBookmarks();
            }
            else if (_oldActiveScreen == this.TrackInfoScreen)
            {
                this.TrackInfoScreen.SaveData();
            }

            this.Description = desc;
        }

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(Runtime.Shortcuts.OPMShortcutEventArgs args)
        {
            // Dispatch shortcut to active screen

            if (_activeScreen == this.PlaylistScreen)
            {
                this.PlaylistScreen.OnExecuteShortcut(args);
            }
            else if (_activeScreen == this.BookmarkScreen)
            {
                //this.BookmarkScreen.OnE
            }
            else if (_activeScreen == this.TrackInfoScreen)
            {
                //this.TrackInfoScreen.OnE
            }
            else if (_activeScreen == this.VisualEffectsScreen)
            {
                //this.VisualEffectsScreen.OnE
            }
        }
    }
}
