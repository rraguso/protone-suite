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
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public class MediaScreens : OPMTabControl
    {
        public PlaylistScreen PlaylistScreen { get { return base.TabPages[0].Controls[0] as PlaylistScreen; } }
        public TrackInfoScreen TrackInfoScreen { get { return base.TabPages[1].Controls[0] as TrackInfoScreen; } }
        public VisualEffectsScreen VisualEffectsScreen { get { return base.TabPages[2].Controls[0] as VisualEffectsScreen; } }
        public BookmarkScreen BookmarkScreen { get { return base.TabPages[3].Controls[0] as BookmarkScreen; } }

        public Control _activeScreen = null;
        public Control _oldActiveScreen = null;
            
        public MediaScreens() : base()
        {
            Control c = new PlaylistScreen();
            c.Dock = DockStyle.Fill;
            base.TabPages.Add(new OPMTabPage("TXT_PLAYLIST", c));
            
            c = new TrackInfoScreen();
            c.Dock = DockStyle.Fill;
            base.TabPages.Add(new OPMTabPage("TXT_TRACKINFO", c));
            
            c = new VisualEffectsScreen();
            c.Dock = DockStyle.Fill;
            base.TabPages.Add(new OPMTabPage("TXT_VISUALEFFECTS", c));
            
            c = new BookmarkScreen();
            c.Dock = DockStyle.Fill;
            base.TabPages.Add(new OPMTabPage("TXT_BOOKMARKS", c));

            base.SelectedIndexChanged += new EventHandler(MediaScreens_SelectedIndexChanged);

            // TODO - maybe active screen will need to be persisted ?
            _oldActiveScreen = null;
            _activeScreen = this.PlaylistScreen;

            this.HandleCreated += new EventHandler(MediaScreens_HandleCreated);
            this.HandleDestroyed += new EventHandler(MediaScreens_HandleDestroyed);
        }

        void MediaScreens_HandleDestroyed(object sender, EventArgs e)
        {
            EventDispatch.UnregisterHandler(this);
        }
        void MediaScreens_HandleCreated(object sender, EventArgs e)
        {
            EventDispatch.RegisterHandler(this);
            ThemeManager.SetDoubleBuffer(this);
        }

        void MediaScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control currentScreen = null;
            if (base.SelectedTab != null)
            {
                currentScreen = base.SelectedTab.Controls[0];
                DoScreenSelectionTasks(currentScreen);
            }
        }

        private void DoScreenSelectionTasks(Control c)
        {
            string desc = string.Empty;

            _oldActiveScreen = _activeScreen;
            _activeScreen = c;

            if (_activeScreen == this.PlaylistScreen)
            {
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

        }

        [EventSink(OPMedia.UI.ProTONE.GlobalEvents.EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            Translator.TranslateControl(this, DesignMode);

            TabPages[0].Text = Translator.Translate("TXT_PLAYLIST");
            TabPages[1].Text = Translator.Translate("TXT_TRACKINFO");
            TabPages[2].Text = Translator.Translate("TXT_VISUALEFFECTS");
            TabPages[3].Text = Translator.Translate("TXT_BOOKMARKS");
        }

        [EventSink(OPMedia.UI.ProTONE.GlobalEvents.EventNames.ExecuteShortcut)]
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
