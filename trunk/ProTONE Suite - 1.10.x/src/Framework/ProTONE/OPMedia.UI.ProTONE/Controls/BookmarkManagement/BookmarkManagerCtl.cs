using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.ProTONE.Properties;
using OPMedia.UI.Generic;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.ProTONE.Dialogs;
using OPMedia.UI.Themes;

using OPMedia.Core.GlobalEvents;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;

namespace OPMedia.UI.ProTONE.Controls.BookmarkManagement
{
    public partial class BookmarkManagerCtl : OPMBaseControl
    {
        readonly int[] widths = new int[] { 0, 75, 120 };

        PlaylistItem _plItem = null;
        ToolTip _tip = new ToolTip();
        Timer _timer = new Timer();

        DateTimePicker _dtpEditTime = new DateTimePicker();
        TextBox _txtEditComment = new TextBox();

        public bool CanAddToCurrent { get; set; }

        public PlaylistItem PlaylistItem
        { 
            get 
            { 
                return _plItem; 
            } 
            
            set 
            {
                try
                {
                    if (value == null && _plItem != null)
                    {
                        SaveBookmarks();
                    }
                }
                catch
                {
                }

                _plItem = value;

                if (_plItem != null && _plItem.MediaFileInfo != null)
                {
                    _plItem.MediaFileInfo.BookmarkCollectionChanged -=
                        new EventHandler(MediaFileInfo_BookmarkCollectionChanged);
                    _plItem.MediaFileInfo.BookmarkCollectionChanged +=
                        new EventHandler(MediaFileInfo_BookmarkCollectionChanged);
                }

                LoadBookmarks();
            } 
        }

        public void ShowSeparator(bool visible)
        {
            lblSep.Visible = visible;
        }

        public BookmarkManagerCtl()
        {
            InitializeComponent();

            ThemeManager.SetFont(lblItem, FontSizes.Large);

            Translator.TranslateControl(this, DesignMode);

            lblSep.Visible = false;
            lblSep.OverrideBackColor = ThemeManager.GradientLTColor;

            lblItem.FontSize = (ApplicationInfo.IsPlayer) ?
                FontSizes.Small : FontSizes.NormalBold;
            
            lblItem.Text = string.Empty;

            pbAdd.Text = pbAddCurrent.Text = pbDelete.Text = string.Empty;

            pbAdd.Image = Resources.Add;
            pbAddCurrent.Image = Resources.Add2;
            pbDelete.Image = Resources.Delete;

            _tip.SetToolTip(pbAdd, Translator.Translate("TXT_NEW_BMDESC"));
            _tip.SetToolTip(pbAddCurrent, Translator.Translate("TXT_NEWNOW_BMDESC"));
            _tip.SetToolTip(pbDelete, Translator.Translate("TXT_DELETE_BMDESC"));

            _timer = new Timer();
            _timer.Interval = 300;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;

            ManageAddCurrentButtonState();

            _dtpEditTime.ShowUpDown = true;
            _dtpEditTime.Format = DateTimePickerFormat.Custom;
            _dtpEditTime.CustomFormat = "HH:mm:ss";
            _dtpEditTime.Enabled = true;
            lvBookmarks.RegisterEditControl(_dtpEditTime);

            _txtEditComment.Enabled = true;
            _txtEditComment.Multiline = true;
            _txtEditComment.Height = lvBookmarks.Font.Height + 4;
            lvBookmarks.RegisterEditControl(_txtEditComment);

            lvBookmarks.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lvBookmarks_ColumnWidthChanging);
            lvBookmarks.Resize += new EventHandler(lvBookmarks_Resize);
            lvBookmarks.SubItemEdited += new OPMListView.EditableListViewEventHandler(lvBookmarks_SubItemEdited);
        }

        void lvBookmarks_SubItemEdited(object sender, ListViewSubItemEventArgs args)
        {
            SaveBookmarks();
            LoadBookmarks();
        }

        void lvBookmarks_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            if (e.ColumnIndex != colText.Index)
            {
                e.NewWidth = widths[e.ColumnIndex];
            }
            else
            {
                int w = 0;
                foreach (ColumnHeader ch in lvBookmarks.Columns)
                {
                    if (ch != colText)
                    {
                        w += widths[ch.Index];
                    }
                }
                w += 5;

                e.NewWidth = colText.Width = (lvBookmarks.Width - w - SystemInformation.VerticalScrollBarWidth);
            }
        }

        void lvBookmarks_Resize(object sender, EventArgs e)
        {
            int w = 0;
            foreach (ColumnHeader ch in lvBookmarks.Columns)
            {
                if (ch != colText)
                {
                    ch.Width = widths[ch.Index];
                    w += ch.Width;
                }
            }
            w += 1;

            colText.Width = (lvBookmarks.Width - w);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            ManageAddCurrentButtonState();
        }
        
        public void ManageAddCurrentButtonState()
        {
            try
            {
                // Add to current possible only if we are currently playing this item.
                pbAddCurrent.Visible = CanAddToCurrent &&
                    _plItem != null &&
                    MediaRenderer.DefaultInstance.RenderedMediaInfo != null &&
                    MediaRenderer.DefaultInstance.RenderedMediaInfo.Equals(_plItem.MediaFileInfo) &&
                    MediaRenderer.DefaultInstance.FilterState != FilterState.NotOpened &&
                    MediaRenderer.DefaultInstance.FilterState != FilterState.Stopped;
            }
            catch
            {
            }
        }

        private void LoadBookmarks()
        {
            lvBookmarks.Items.Clear();
            lblItem.Text = string.Empty;

            if (_plItem == null)
            {
                this.Enabled = false;
                return;
            }

            try
            {
                this.Enabled = true;
                lblItem.Text = _plItem.MediaFileInfo.Path;

                if (_plItem.MediaFileInfo.Bookmarks != null)
                {
                    List<Bookmark> bmkList =
                        new List<Bookmark>(_plItem.MediaFileInfo.Bookmarks.Values);

                    bmkList.Sort(Bookmark.CompareByTime);

                    foreach (Bookmark bmk in bmkList)
                    {
                        string[] subItems = new string[]
                        {
                            string.Empty,
                            bmk.PlaybackTime.ToString(),
                            bmk.Title
                        };

                        
                        int i = 0;
                        ListViewItem item = new ListViewItem(subItems[i++]);
                        item.Tag = bmk;

                        OPMListViewSubItem si = new OPMListViewSubItem(_dtpEditTime, item, subItems[i++]);
                        si.ReadOnly = false;
                        item.SubItems.Add(si);

                        si = new OPMListViewSubItem(_txtEditComment, item, subItems[i++]);
                        si.ReadOnly = false;
                        item.SubItems.Add(si);

                        lvBookmarks.Items.Add(item);
                    }

                    if (lvBookmarks.Items.Count > 0)
                    {
                        lvBookmarks.Select();
                        lvBookmarks.Focus();
                        lvBookmarks.Items[0].Selected = true;
                    }
                }
                
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        void MediaFileInfo_BookmarkCollectionChanged(object sender, EventArgs e)
        {
            LoadBookmarks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] subItems = new string[]
            {
                string.Empty,
                "00:00:00",
                Translator.Translate("TXT_NEW_BOOKMARK")
            };

            int i = 0;
            ListViewItem item = new ListViewItem(subItems[i++]);
            //item.Tag = bmk;

            OPMListViewSubItem si = new OPMListViewSubItem(_dtpEditTime, item, subItems[i++]);
            si.ReadOnly = false;
            item.SubItems.Add(si);

            si = new OPMListViewSubItem(_txtEditComment, item, subItems[i++]);
            si.ReadOnly = false;
            item.SubItems.Add(si);

            item = lvBookmarks.Items.Add(item);

            item.Selected = true;

            lvBookmarks.StartEditing(item, si);
        }

        private void btnAddCurrent_Click(object sender, EventArgs e)
        {
            MediaRenderer.DefaultInstance.PauseRenderer();

            TimeSpan ts = TimeSpan.FromSeconds((int)MediaRenderer.DefaultInstance.MediaPosition);

            string[] subItems = new string[]
            {
                string.Empty,
                ts.ToString(),
                Translator.Translate("TXT_NEW_BOOKMARK")
            };

            int i = 0;
            ListViewItem item = new ListViewItem(subItems[i++]);
            //item.Tag = bmk;

            OPMListViewSubItem si = new OPMListViewSubItem(_dtpEditTime, item, subItems[i++]);
            si.ReadOnly = false;
            item.SubItems.Add(si);

            si = new OPMListViewSubItem(_txtEditComment, item, subItems[i++]);
            si.ReadOnly = false;
            item.SubItems.Add(si);

            item = lvBookmarks.Items.Add(item);

            item.Selected = true;

            lvBookmarks.StartEditing(item, si);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvBookmarks.SelectedItems.Count > 0)
            {
                lvBookmarks.Items.Remove(lvBookmarks.SelectedItems[0]);

                SaveBookmarks();
                LoadBookmarks();

                lvBookmarks.Select();
                lvBookmarks.Focus();

                if (lvBookmarks.Items.Count > 0)
                {
                    lvBookmarks.Items[0].Selected = true;
                }

            }
        }

        public void SaveBookmarks()
        {
            if (_plItem != null)
            {
                _plItem.MediaFileInfo.Bookmarks.Clear();

                foreach (ListViewItem row in lvBookmarks.Items)
                {
                    string time = row.SubItems[colTime.Index].Text;
                    string desc = row.SubItems[colText.Index].Text;
                    
                    if (!string.IsNullOrEmpty(time))
                    {
                        TimeSpan ts = (TimeSpan)new TimeSpanConverter().ConvertFromInvariantString(time);
                            //- Bookmark.MinimumDate;
                        
                        Bookmark bmk = new Bookmark(desc, ts);
                        _plItem.MediaFileInfo.Bookmarks.Add(ts, bmk);
                    }
                }

                _plItem.MediaFileInfo.SaveBookmarks();
            }

        }

        private void lvBookmarks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBookmarks.SelectedItems.Count > 0)
            {
                Bookmark bmk = lvBookmarks.SelectedItems[0].Tag as Bookmark;
                if (bmk != null)
                {
                    BookmarkSubItem subItem = new BookmarkSubItem(_plItem, bmk);
                    EventDispatch.DispatchEvent(LocalEventNames.JumpToBookmark, subItem);
                }
            }
        }
    }
}
