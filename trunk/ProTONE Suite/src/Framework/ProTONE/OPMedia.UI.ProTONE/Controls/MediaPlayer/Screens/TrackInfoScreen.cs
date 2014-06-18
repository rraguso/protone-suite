using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Core.Logging;
using TagLib.Riff;
using OPMedia.Runtime.FileInformation;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer.Screens
{
    public partial class TrackInfoScreen : OPMBaseControl
    {
        bool _canSaveData = false;

        public PlaylistItem PlaylistItem 
        {
            set
            {
                ShowPlaylistItem(value, true);
            }
        }

        public void SaveData()
        {
            if (pgProperties.SelectedObjects != null)
            {
                foreach (MediaFileInfo mfi in pgProperties.SelectedObjects)
                {
                    try
                    {
                        mfi.Save();
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(ex);
                    }
                }
            }

        }

        public TrackInfoScreen()
        {
            InitializeComponent();
            playlistScreen.SelectedItemChanged += new SelectedItemChangedHandler(playlistScreen_SelectedItemChanged);
        }

        void playlistScreen_SelectedItemChanged(PlaylistItem newSelectedItem)
        {
            if (_canSaveData)
            {
                SaveData();
            }

            ShowPlaylistItem(newSelectedItem, false);
        }

        public void ShowPlaylistItem(PlaylistItem plItem, bool callByProperty)
        {
            if (plItem == null)
            {
                List<PlaylistItem> plItems = playlistScreen.GetPlaylistItems();
                if (plItems != null && plItems.Count > 0)
                {
                    plItem = plItems[0];
                }
            }

            if (plItem != null)
            {
                List<object> lii = new List<object>();
                lii.Add(plItem.MediaFileInfo);

                List<string> categoriesToIgnore = new List<string>();
                categoriesToIgnore.Add("TXT_BOOKMARKINFO");
                categoriesToIgnore.Add("TXT_FILESYSTEMINFO");

                FileAttributesBrowser.ProcessObjectAttributes(lii, null, categoriesToIgnore);

                pgProperties.SelectedObjects = lii.ToArray();
                lblItem.Text = plItem.MediaFileInfo.Path;
            }
            else
            {
                pgProperties.SelectedObjects = null;
                lblItem.Text = string.Empty;
            }

            if (callByProperty)
            {
                try
                {
                    _canSaveData = false;
                    playlistScreen.SetFirstSelectedPlaylistItem(plItem);
                }
                finally
                {
                    _canSaveData = true;
                }
            }
        }

        public void CopyPlaylist(PlaylistScreen source)
        {
            this.playlistScreen.CopyPlaylist(source);
        }
    }
}
