using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Runtime;
using OPMedia.UI.ProTONE.GlobalEvents;

namespace OPMedia.UI.ProTONE.Dialogs
{
    public partial class BookmarkManager : ThemeForm
    {
        public PlaylistItem PlaylistItem
        {
            get
            {
                return bookmarkManagerCtl.PlaylistItem;
            }
        }

        public BookmarkManager(PlaylistItem plItem, bool canAddToCurrent)
            : base("TXT_BOOKMARK_MANAGER")
        {
            InitializeComponent();
            bookmarkManagerCtl.CanAddToCurrent = canAddToCurrent;
            bookmarkManagerCtl.PlaylistItem = plItem;

            this.FormClosed += new FormClosedEventHandler(BookmarkManager_FormClosed);

            this.ShowInTaskbar = true;
            this.InheritAppIcon = false;
            this.Icon = OPMedia.Core.Properties.Resources.bookmark;
        }

        void BookmarkManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                bookmarkManagerCtl.SaveBookmarksToFile();
            }
        }
    }
}
