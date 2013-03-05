using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.UI.Themes;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.UI.Controls;


namespace OPMedia.UI.ProTONE.Dialogs
{
    public class JumpToItemDlg : ThemeForm
    {
        private OPMButton btnCancel;
        private OPMButton btnOk;
        private OPMLabel label2;
        private ListBox lbMatchingItems;
        private OPMLabel label1;
        private OPMTextBox txtKeyword;
        private OPMTableLayoutPanel opmLayoutPanel1;

        private Playlist _playlist = null;

        public PlaylistItem SelectedItem
        {
            get { return lbMatchingItems.SelectedItem as PlaylistItem; }
        }
        
        public JumpToItemDlg(Playlist playlist)
            : base("TXT_JUMP_TO_ITEM")
        {
            _playlist = playlist;

            InitializeComponent();
            this.Load += new EventHandler(OnLoad);
        }

        void OnLoad(object sender, EventArgs e)
        {
            PerformSearch();
            txtKeyword.Focus();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void InitializeComponent()
        {
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.lbMatchingItems = new System.Windows.Forms.ListBox();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.txtKeyword = new OPMedia.UI.Controls.OPMTextBox();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(193, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(115, 244);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(72, 25);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "TXT_OK";
            // 
            // lbMatchingItems
            // 
            this.opmLayoutPanel1.SetColumnSpan(this.lbMatchingItems, 3);
            this.lbMatchingItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMatchingItems.FormattingEnabled = true;
            this.lbMatchingItems.Location = new System.Drawing.Point(0, 48);
            this.lbMatchingItems.Margin = new System.Windows.Forms.Padding(0);
            this.lbMatchingItems.Name = "lbMatchingItems";
            this.lbMatchingItems.Size = new System.Drawing.Size(276, 188);
            this.lbMatchingItems.TabIndex = 3;
            this.lbMatchingItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMatchingItems_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(276, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TXT_MATCHING_ITEMS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TXT_ENTER_KEYWORD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKeyword
            // 
            this.txtKeyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.opmLayoutPanel1.SetColumnSpan(this.txtKeyword, 3);
            this.txtKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyword.Location = new System.Drawing.Point(0, 13);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(0);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtKeyword.Size = new System.Drawing.Size(276, 22);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 3;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.Controls.Add(this.btnCancel, 2, 5);
            this.opmLayoutPanel1.Controls.Add(this.lbMatchingItems, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.txtKeyword, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.opmLayoutPanel1.Controls.Add(this.btnOk, 1, 5);
            this.opmLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 6;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(276, 272);
            this.opmLayoutPanel1.TabIndex = 6;
            // 
            // JumpToItemDlg
            // 
            this.ClientSize = new System.Drawing.Size(286, 300);
            this.Name = "JumpToItemDlg";
            this.ShowIcon = false;
            this.pnlContent.ResumeLayout(false);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void PerformSearch()
        {
            string fullKeyword = txtKeyword.Text.ToLowerInvariant();

            string[] keywords =
                fullKeyword.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            PerformSearch(keywords);
        }

        private void PerformSearch(string[] keywords)
        {
            lbMatchingItems.Items.Clear();
            foreach (PlaylistItem plItem in _playlist.AllItems)
            {
                if (TestForMatch(plItem, keywords))
                {
                    lbMatchingItems.Items.Add(plItem);
                }
            }

            if (lbMatchingItems.Items.Count > 0)
            {
                lbMatchingItems.SelectedIndex = 0;
            }
        }

        private bool TestForMatch(PlaylistItem plItem, string[] keywords)
        {
            if (keywords == null || keywords.Length < 1)
                return true; // In absence of a keyword, all items match.

            bool match = true;

            foreach (string keyword in keywords)
            {
                string lowercaseName = plItem.DisplayName.ToLowerInvariant();

                match &= lowercaseName.Contains(keyword);

                if (!match)
                    break;
            }

            return match;
        }

        private void lbMatchingItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MoveItemSelection(int amount)
        {
            if (lbMatchingItems.Items.Count > 0)
            {
                int newIndex = lbMatchingItems.SelectedIndex + amount;

                if (0 <= newIndex && newIndex <= lbMatchingItems.Items.Count - 1)
                {
                    lbMatchingItems.SelectedIndex = newIndex;
                }
            }
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    MoveItemSelection(1);
                    break;

                case Keys.Up:
                    e.SuppressKeyPress = true;
                    MoveItemSelection(-1);
                    break;
            }
        }
    }
}
