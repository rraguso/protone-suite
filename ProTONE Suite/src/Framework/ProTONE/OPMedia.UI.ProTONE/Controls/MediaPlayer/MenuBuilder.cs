using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.Controls;
using System.ComponentModel;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.Core.Configuration;
using OPMedia.UI.Menus;
using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Properties;
using System.Drawing;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public enum MenuType
    {
        Playlist = 0,
        SingleItem,
        MultipleItems
    }

    public class MenuBuilder<T>
    {
        PlaylistScreen _pnlPlaylist = null;

        public MenuBuilder(PlaylistScreen pnlPlaylist)
        {
            _pnlPlaylist = pnlPlaylist;
        }

        public int BuildCommandsMenu(int index, MenuWrapper<T> menu, EventHandler clickHandler)
        {
            for (OPMShortcut cmd = OPMShortcut.CmdPlay; cmd <= OPMShortcut.CmdFullScreen; cmd++)
            {
                BuildMenuEntry(cmd, menu, clickHandler, index);
                index++;
            }

            menu.InsertSingleEntry(index, new OPMMenuStripSeparator());
            index++;

            for (OPMShortcut cmd = OPMShortcut.CmdFwd; cmd <= OPMShortcut.CmdVolDn; cmd++)
            {
                BuildMenuEntry(cmd, menu, clickHandler, index);
                index++;
            }

            menu.InsertSingleEntry(index, new OPMMenuStripSeparator());
            index++;

            for (OPMShortcut cmd = OPMShortcut.CmdLoopPlay; cmd <= OPMShortcut.CmdToggleShuffle; cmd++)
            {
                BuildMenuEntry(cmd, menu, clickHandler, index);
                index++;
            }

            return index;
        }

        public void AttachToolsMenu(MenuWrapper<T> menu, EventHandler clickHandler)
        {
            BuildMenuEntry(OPMShortcut.CmdCfgVideo, menu, clickHandler);
            BuildMenuEntry(OPMShortcut.CmdCfgAudio, menu, clickHandler);
            menu.AddSingleEntry(new OPMMenuStripSeparator());
            BuildMenuEntry(OPMShortcut.CmdCfgSubtitles, menu, clickHandler);
            BuildMenuEntry(OPMShortcut.CmdCfgTimer, menu, clickHandler);
            menu.AddSingleEntry(new OPMMenuStripSeparator());
            BuildMenuEntry(OPMShortcut.CmdOpenSettings, menu, clickHandler);
            BuildMenuEntry(OPMShortcut.CmdShowLogConsole, menu, clickHandler);
        }

        public void AttachPlaylistItemMenu(PlaylistItem plItem, MenuWrapper<T> menu, MenuType menuType, EventHandler clickHandler)
        {
            if (menuType != MenuType.Playlist)
            {
                AttachCommonPlaylistToolsMenu(menu, menuType, clickHandler, plItem);
            }

            MenuWrapper<T> menuToAlter = menu;

            if (menuType == MenuType.Playlist)
            {
                OPMToolStripMenuItem item = new OPMToolStripMenuItem(plItem.DisplayName);
                item.Tag = plItem;
                item.Click += clickHandler;
                item.Checked = _pnlPlaylist.IsActiveItem(plItem);
                menu.AddSingleEntry(item);

                menuToAlter = new MenuWrapper<OPMToolStripMenuItem>(item) as MenuWrapper<T>;
            }

            if (plItem != null && menuType != MenuType.MultipleItems)
            {
                // It may have subitems:
                // * a DVD item will have titles, chapters, etc ...
                // * other media files may have bookmarks ...
                Dictionary<PlaylistSubItem, List<PlaylistSubItem>> submenu = plItem.GetSubmenu();

                if (submenu != null && submenu.Count >= 1)
                {
                    if (menuType == MenuType.SingleItem)
                    {
                        menuToAlter.AddSingleEntry(new OPMMenuStripSeparator());
                    }

                    foreach (KeyValuePair<PlaylistSubItem, List<PlaylistSubItem>> subitems in submenu)
                    {
                        OPMToolStripMenuItem subItem = new OPMToolStripMenuItem(subitems.Key.Name);
                        subItem.Click += clickHandler;
                        subItem.Tag = subitems.Key;

                        if (subitems.Value != null)
                        {
                            foreach (PlaylistSubItem ssitem in subitems.Value)
                            {
                                OPMToolStripMenuItem subSubItem = null;

                                if (ssitem is DvdSubItem)
                                {
                                    subSubItem = new OPMToolStripMenuItem(ssitem.Name);
                                    subSubItem.Click += clickHandler;
                                    subSubItem.Tag = ssitem;

                                    DvdSubItem si = ssitem as DvdSubItem;
                                    DvdRenderingStartHint hint = (si != null) ?
                                        si.StartHint as DvdRenderingStartHint : null;

                                    if (hint != null && hint.IsSubtitleHint)
                                    {
                                        subSubItem.Checked = (hint.SID == MediaRenderer.DefaultInstance.SubtitleStream);
                                    }
                                }
                                else if (ssitem is BookmarkSubItem)
                                {
                                    BookmarkSubItem bsi = (ssitem as BookmarkSubItem);
                                    BookmarkStartHint hint = (bsi != null) ?
                                        bsi.StartHint as BookmarkStartHint : new BookmarkStartHint(Bookmark.Empty);

                                    string name = string.Format("{0} - '{1}'", hint.Bookmark.PlaybackTime, bsi.Name);
                                    subSubItem = new OPMToolStripMenuItem(name);
                                    subSubItem.Click += clickHandler;
                                    subSubItem.Tag = ssitem;
                                }

                                if (subSubItem != null)
                                {
                                    subItem.DropDownItems.Add(subSubItem);
                                }
                            }
                        }

                        menuToAlter.AddSingleEntry(subItem);
                    }
                }

                if (menuType == MenuType.SingleItem)
                {
                    if (plItem is DvdPlaylistItem)
                    {
                        AttachDvdMenuItems(plItem as DvdPlaylistItem, menuToAlter, clickHandler);
                    }
                    else
                    {
                        AttachFileMenuItems(plItem as PlaylistItem, menuToAlter, clickHandler);
                    }
                }
            }
        }

        public void AttachCommonPlaylistToolsMenu(MenuWrapper<T> menu, MenuType menuType, EventHandler clickHandler, PlaylistItem plItem)
        {
            //OPMShortcut cmdStart = (menuType == MenuType.SingleItem) ? 
              //  OPMShortcut.CmdMoveUp : OPMShortcut.CmdClear;

            for (OPMShortcut cmd = OPMShortcut.CmdMoveUp; cmd <= OPMShortcut.CmdSavePlaylist; cmd++)
            {
                switch (cmd)
                {
                    case OPMShortcut.CmdMoveUp:
                    case OPMShortcut.CmdMoveDown:
                    case OPMShortcut.CmdDelete:
                        BuildMenuEntry(cmd, menu, clickHandler, -1, plItem != null);
                        break;

                    default:
                        BuildMenuEntry(cmd, menu, clickHandler);
                        break;
                }
            }
        }

        private void BuildMenuEntry(OPMShortcut cmd, MenuWrapper<T> menu, EventHandler clickHandler, int index = -1, bool enabled = true)
        {
            string shortcuts = ShortcutMapper.GetShortcutString(cmd);
            string menuName = cmd.ToString().ToUpperInvariant().Replace("CMD", "MNU");
            string imageName = "btn" + cmd.ToString().Replace("Cmd", "");

            string desc = Translator.Translate("TXT_" + menuName);

            OPMToolStripMenuItem tsmi = new OPMToolStripMenuItem(desc);
            tsmi.Click += clickHandler;
            tsmi.Tag = cmd;
            tsmi.ShortcutKeyDisplayString = shortcuts;
            tsmi.Image = Resources.ResourceManager.GetImage(imageName);
            tsmi.Enabled = enabled;

            if (index >= 0)
            {
                menu.InsertSingleEntry(index, tsmi);
            }
            else
            {
                menu.AddSingleEntry(tsmi);
            }
        }

        private void AttachFileMenuItems(PlaylistItem playlistItem, MenuWrapper<T> menu, EventHandler clickHandler)
        {
            if (EnableSubtitleEntry(playlistItem))
            {
                if (menu.MenuItemsCount > 0)
                {
                    menu.AddSingleEntry(new OPMMenuStripSeparator());
                }

                string str = Translator.Translate("TXT_SEARCH_SUBTITLES");
                OPMToolStripMenuItem tsmi = new OPMToolStripMenuItem(str);
                tsmi.Click += clickHandler;
                tsmi.Tag = OPMShortcut.CmdSearchSubtitles;
                tsmi.ShortcutKeyDisplayString = ShortcutMapper.GetShortcutString(OPMShortcut.CmdSearchSubtitles);

                menu.AddSingleEntry(tsmi);
            }
        }

        private void AttachDvdMenuItems(DvdPlaylistItem dvdPlaylistItem, MenuWrapper<T> menu, EventHandler clickHandler)
        {
            //cmsInsert.DropDownItems.Add("DVD menu item");
            // Nothing to add specifically for DVD's right now ...
        }

        private bool EnableSubtitleEntry(PlaylistItem plItem)
        {
            return 
                plItem != null &&
                plItem.IsVideo && 
                SubtitleDownloadProcessor.CanPerformSubtitleDownload(plItem.Path, 
                (int)plItem.Duration.TotalSeconds);
        }

    }
}
