using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime.ProTONE.Playlists
{
    public class UrlPlaylistItem : PlaylistItem
    {
        public UrlPlaylistItem(string uri) : 
            base(uri, false, false)
        {
            
        }
    }
}
