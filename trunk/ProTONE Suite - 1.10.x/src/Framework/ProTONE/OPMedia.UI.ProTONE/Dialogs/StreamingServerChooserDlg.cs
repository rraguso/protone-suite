using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.Controls;
using TagLib;

namespace OPMedia.UI.ProTONE.Dialogs
{
    public partial class StreamingServerChooserDlg : ToolForm
    {
        public string Uri { get; set; }

        OPMTextBox txtEditUrl = new OPMTextBox();
        OPMTextBox txtEditTitle = new OPMTextBox();
        OPMComboBox cmbEditGenre = new OPMComboBox();

        RadioStationsData _allData = null;
        List<RadioStation> _displayData = null;

        public StreamingServerChooserDlg()
        {
            InitializeComponent();

            AdjustColumns();
            lvServers.Resize += new EventHandler(lvServers_Resize);

            lvServers.RegisterEditControl(txtEditUrl);
            lvServers.RegisterEditControl(txtEditTitle);
            lvServers.RegisterEditControl(cmbEditGenre);

            foreach (string gi in Genres.Audio)
            {
                cmbEditGenre.Items.Add(gi);
            }

            this.Load += new EventHandler(StreamingServerChooserDlg_Load);

            lvServers.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lvServers_ItemSelectionChanged);
            lvServers.ColumnClick += new ColumnClickEventHandler(lvServers_ColumnClick);
        }

        int _oldColumnIndex = 1;
        SortOrder _sortOrder = SortOrder.Ascending;

        void lvServers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != _oldColumnIndex)
            {
            }
            else
            {
                _sortOrder = (_sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }

            _oldColumnIndex = e.Column;

            lvServers.ShowSortGlyph(e.Column, _sortOrder);
        }

        void lvServers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    Uri = e.Item.SubItems[colURL.Index].Text;
                    return;
                }
            }
            catch { }

            Uri = string.Empty;
        }

        void StreamingServerChooserDlg_Load(object sender, EventArgs e)
        {
            lvServers.Items.Clear();

            // Get the list from persistency support
            _allData = RadioStationsData.Load();
            if (_allData != null && _allData.RadioStations != null)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            _displayData = PrepareDisplayData();
            foreach (RadioStation rs in _displayData)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", rs.Url, rs.Title, rs.Genre });
                lvServers.Items.Add(lvi);
            }
        }

        private List<RadioStation> PrepareDisplayData()
        {
            var x = from rs in _allData.RadioStations
                    orderby rs.Genre
                    select rs;

            return x.ToList();
        }

        void lvServers_Resize(object sender, EventArgs e)
        {
            AdjustColumns();
        }

        private void AdjustColumns()
        {
            colGenre.Width = 120;
            colURL.Width = colTitle.Width = (lvServers.Width - colGenre.Width - SystemInformation.VerticalScrollBarWidth - 5) / 2;
        }

        private void StreamingServerChooserDlg_Load_1(object sender, EventArgs e)
        {

        }
    }
}
