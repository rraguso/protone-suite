namespace OPMedia.UI.ProTONE.Dialogs
{
    partial class StreamingServerChooserDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvServers = new OPMedia.UI.Controls.OPMListView();
            this.colEmpty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.txtSearchGenre = new OPMedia.UI.Controls.OPMLabel();
            this.txtSearch = new OPMedia.UI.Controls.OPMTextBox();
            this.cmbSearchgenre = new OPMedia.UI.Controls.OPMComboBox();
            this.txtSelectedURL = new OPMedia.UI.Controls.OPMTextBox();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // lvServers
            // 
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmpty,
            this.colURL,
            this.colTitle,
            this.colGenre});
            this.opmTableLayoutPanel1.SetColumnSpan(this.lvServers, 3);
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServers.Location = new System.Drawing.Point(3, 65);
            this.lvServers.MultiSelect = false;
            this.lvServers.Name = "lvServers";
            this.lvServers.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvServers.Size = new System.Drawing.Size(623, 284);
            this.lvServers.TabIndex = 0;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            this.lvServers.SelectedIndexChanged += new System.EventHandler(this.lvServers_SelectedIndexChanged);
            // 
            // colEmpty
            // 
            this.colEmpty.Text = "";
            this.colEmpty.Width = 0;
            // 
            // colURL
            // 
            this.colURL.Text = "TXT_SERVERURL";
            // 
            // colTitle
            // 
            this.colTitle.Text = "TXT_TITLE";
            // 
            // colGenre
            // 
            this.colGenre.Text = "TXT_GENRE";
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.lvServers, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 2, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearchGenre, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbSearchgenre, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearch, 1, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSelectedURL, 1, 4);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 5;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(629, 383);
            this.opmTableLayoutPanel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(571, 355);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.ShowDropDown = false;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.opmLabel1.Location = new System.Drawing.Point(3, 10);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(76, 20);
            this.opmLabel1.TabIndex = 1;
            this.opmLabel1.Text = "TXT_SEARCH:";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchGenre
            // 
            this.txtSearchGenre.AutoSize = true;
            this.txtSearchGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtSearchGenre.Location = new System.Drawing.Point(3, 33);
            this.txtSearchGenre.Name = "txtSearchGenre";
            this.txtSearchGenre.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtSearchGenre.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchGenre.Size = new System.Drawing.Size(76, 29);
            this.txtSearchGenre.TabIndex = 5;
            this.txtSearchGenre.Text = "TXT_GENRE:";
            this.txtSearchGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.txtSearch.Location = new System.Drawing.Point(82, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.txtSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtSearch.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearch.Padding = new System.Windows.Forms.Padding(3);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ReadOnly = false;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(486, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WordWrap = true;
            // 
            // cmbSearchgenre
            // 
            this.cmbSearchgenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchgenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSearchgenre.FormattingEnabled = true;
            this.cmbSearchgenre.Location = new System.Drawing.Point(85, 36);
            this.cmbSearchgenre.Name = "cmbSearchgenre";
            this.cmbSearchgenre.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbSearchgenre.Size = new System.Drawing.Size(480, 23);
            this.cmbSearchgenre.TabIndex = 8;
            // 
            // txtSelectedURL
            // 
            this.txtSelectedURL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtSelectedURL.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSelectedURL.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.txtSelectedURL.Location = new System.Drawing.Point(85, 355);
            this.txtSelectedURL.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSelectedURL.MaxLength = 32767;
            this.txtSelectedURL.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSelectedURL.Multiline = false;
            this.txtSelectedURL.Name = "txtSelectedURL";
            this.txtSelectedURL.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtSelectedURL.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSelectedURL.Padding = new System.Windows.Forms.Padding(3);
            this.txtSelectedURL.PasswordChar = '\0';
            this.txtSelectedURL.ReadOnly = false;
            this.txtSelectedURL.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSelectedURL.ShortcutsEnabled = true;
            this.txtSelectedURL.Size = new System.Drawing.Size(480, 20);
            this.txtSelectedURL.TabIndex = 9;
            this.txtSelectedURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSelectedURL.UseSystemPasswordChar = false;
            this.txtSelectedURL.WordWrap = true;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(3, 352);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(76, 31);
            this.opmLabel2.TabIndex = 10;
            this.opmLabel2.Text = "TXT_SERVERURL";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StreamingServerChooserDlg
            // 
            this.ClientSize = new System.Drawing.Size(631, 406);
            this.MinimumSize = new System.Drawing.Size(200, 85);
            this.Name = "StreamingServerChooserDlg";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMListView lvServers;
        private UI.Controls.OPMLabel opmLabel1;
        private UI.Controls.OPMButton btnOK;
        private System.Windows.Forms.ColumnHeader colEmpty;
        private System.Windows.Forms.ColumnHeader colURL;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colGenre;
        private UI.Controls.OPMLabel txtSearchGenre;
        private UI.Controls.OPMTextBox txtSearch;
        private UI.Controls.OPMComboBox cmbSearchgenre;
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.OPMTextBox txtSelectedURL;
    }
}