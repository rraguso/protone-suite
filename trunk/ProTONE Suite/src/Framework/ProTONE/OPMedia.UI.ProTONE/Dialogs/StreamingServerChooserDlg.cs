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
        public string Uri 
        {
            get { return txtSelectedURL.Text; }
            //set { txtSelectedURL.Text = value; }
        }

        Timer _tmrSearch = null;

        RadioStationsData _allData = null;
        List<RadioStation> _displayData = null;

        public StreamingServerChooserDlg() : base("TXT_SELECT_RADIO_STATION")
        {
            InitializeComponent();

            AdjustColumns();
            lvServers.Resize += new EventHandler(lvServers_Resize);

            this.Load += new EventHandler(StreamingServerChooserDlg_Load);

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

        void StreamingServerChooserDlg_Load(object sender, EventArgs e)
        {
            lvServers.Items.Clear();

            // Get the list from persistency support
            _allData = RadioStationsData.Load();
            if (_allData != null && _allData.RadioStations != null)
            {
                var genres = (from rs in _allData.RadioStations
                              orderby rs.Genre ascending
                              select rs.Genre).Distinct();

                cmbSearchgenre.Items.Add(string.Empty);
                foreach (var genre in genres)
                {
                    cmbSearchgenre.Items.Add(genre);
                }

                this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
                this.cmbSearchgenre.SelectedIndexChanged += new System.EventHandler(this.cmbSearchgenre_SelectedIndexChanged);

                DisplayData();
            }
        }

        private void DisplayData()
        {
            lvServers.Items.Clear();
            _displayData = PrepareDisplayData();
            foreach (RadioStation rs in _displayData)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", rs.Url, rs.Title, rs.Genre });
                lvServers.Items.Add(lvi);
            }

            if (lvServers.Items.Count > 0)
            {
                lvServers.Items[0].Selected = true;
                lvServers.Items[0].Focused = true;
            }
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


        private void cmbSearchgenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartSearchTimer();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            StartSearchTimer();
        }

        private void StartSearchTimer()
        {
            if (_tmrSearch == null)
            {
                _tmrSearch = new Timer();
                _tmrSearch.Interval = 300;
                _tmrSearch.Tick += new EventHandler(_tmrSearch_Tick);
            }

            _tmrSearch.Start();
        }

        void _tmrSearch_Tick(object sender, EventArgs e)
        {
            _tmrSearch.Stop();
            DisplayData();
        }

        private List<RadioStation> PrepareDisplayData()
        {
            if (_allData != null && _allData.RadioStations != null)
            {
                string searchText = txtSearch.Text.ToLowerInvariant();
                string searchGenre = cmbSearchgenre.Text.ToLowerInvariant();

                var x = from rs in _allData.RadioStations 
                        where 
                            (searchText.Length < 1 || 
                                (rs.Url.ToLowerInvariant().Contains(searchText) || rs.Title.ToLowerInvariant().Contains(searchText))) &&
                            
                            (cmbSearchgenre.Text.Length < 1 || rs.Genre == cmbSearchgenre.Text)

                        orderby rs.Genre ascending
                        select rs;

                return x.ToList();
            }

            return new List<RadioStation>();
        }

        private void lvServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = string.Empty;
            try
            {
                url = lvServers.SelectedItems[0].SubItems[colURL.Index].Text;
            }
            catch { }

            txtSelectedURL.Text = url;
        }

        void lvServers_DoubleClick(object sender, System.EventArgs e)
        {
            string url = string.Empty;
            try
            {
                url = lvServers.SelectedItems[0].SubItems[colURL.Index].Text;
            }
            catch { }

            txtSelectedURL.Text = url;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}
