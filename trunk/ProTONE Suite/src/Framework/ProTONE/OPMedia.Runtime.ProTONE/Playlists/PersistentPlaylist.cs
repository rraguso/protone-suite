using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.Playlists;
using System.IO;
using System.Windows.Forms;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.Playlists
{
    public class PersistentPlaylist
    {
        static bool _isLoading = false;
        static string _fileName = string.Empty;

        static PersistentPlaylist()
        {
            _fileName = Path.Combine(ApplicationInfo.SettingsFolder, ApplicationInfo.ApplicationName) + ".m3u";
        }

        public static void Load(ref Playlist playlist)
        {
            if (File.Exists(_fileName))
            {
                try
                {
                    _isLoading = true;
                    playlist.LoadPlaylist(_fileName);
                }
                finally
                {
                    _isLoading = false;
                }
            }
        }

        public static void Save(Playlist playlist)
        {
            if (_isLoading)
            {
                playlist.AbortLoad();
            }
            else
            {
                playlist.SavePlaylist(_fileName);
            }
        }
    }
}
