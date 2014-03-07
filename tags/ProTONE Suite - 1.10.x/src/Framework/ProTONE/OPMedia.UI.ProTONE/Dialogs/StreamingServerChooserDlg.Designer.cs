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
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.txtSearchGenre = new OPMedia.UI.Controls.OPMLabel();
            this.txtSearchUrlPart = new OPMedia.UI.Controls.OPMTextBox();
            this.txtSearchServerTitlePart = new OPMedia.UI.Controls.OPMTextBox();
            this.cmbSearchgenre = new OPMedia.UI.Controls.OPMComboBox();
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
            this.lvServers.Location = new System.Drawing.Point(3, 121);
            this.lvServers.MultiSelect = false;
            this.lvServers.Name = "lvServers";
            this.lvServers.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvServers.Size = new System.Drawing.Size(615, 223);
            this.lvServers.TabIndex = 0;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
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
            this.opmTableLayoutPanel1.Controls.Add(this.lvServers, 0, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 2, 6);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel3, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearchGenre, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearchUrlPart, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.txtSearchServerTitlePart, 1, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbSearchgenre, 1, 3);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 7;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(621, 378);
            this.opmTableLayoutPanel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(563, 350);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmLabel1, 3);
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.opmLabel1.Location = new System.Drawing.Point(3, 10);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(615, 13);
            this.opmLabel1.TabIndex = 1;
            this.opmLabel1.Text = "TXT_SEARCH_BY:";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(3, 33);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(91, 28);
            this.opmLabel2.TabIndex = 3;
            this.opmLabel2.Text = "TXT_URLPART";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.Location = new System.Drawing.Point(3, 61);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(91, 28);
            this.opmLabel3.TabIndex = 4;
            this.opmLabel3.Text = "TXT_SERVERTITLE";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchGenre
            // 
            this.txtSearchGenre.AutoSize = true;
            this.txtSearchGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtSearchGenre.Location = new System.Drawing.Point(3, 89);
            this.txtSearchGenre.Name = "txtSearchGenre";
            this.txtSearchGenre.OverrideBackColor = System.Drawing.Color.Empty;
            this.txtSearchGenre.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchGenre.Size = new System.Drawing.Size(91, 29);
            this.txtSearchGenre.TabIndex = 5;
            this.txtSearchGenre.Text = "TXT_GENRE:";
            this.txtSearchGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchUrlPart
            // 
            this.txtSearchUrlPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSearchUrlPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchUrlPart.Location = new System.Drawing.Point(100, 36);
            this.txtSearchUrlPart.Name = "txtSearchUrlPart";
            this.txtSearchUrlPart.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchUrlPart.Size = new System.Drawing.Size(457, 22);
            this.txtSearchUrlPart.TabIndex = 6;
            // 
            // txtSearchServerTitlePart
            // 
            this.txtSearchServerTitlePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSearchServerTitlePart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchServerTitlePart.Location = new System.Drawing.Point(100, 64);
            this.txtSearchServerTitlePart.Name = "txtSearchServerTitlePart";
            this.txtSearchServerTitlePart.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtSearchServerTitlePart.Size = new System.Drawing.Size(457, 22);
            this.txtSearchServerTitlePart.TabIndex = 7;
            // 
            // cmbSearchgenre
            // 
            this.cmbSearchgenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchgenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSearchgenre.FormattingEnabled = true;
            this.cmbSearchgenre.Location = new System.Drawing.Point(100, 92);
            this.cmbSearchgenre.Name = "cmbSearchgenre";
            this.cmbSearchgenre.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbSearchgenre.Size = new System.Drawing.Size(457, 23);
            this.cmbSearchgenre.TabIndex = 8;
            // 
            // StreamingServerChooserDlg
            // 
            this.ClientSize = new System.Drawing.Size(631, 406);
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
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.OPMLabel opmLabel3;
        private UI.Controls.OPMLabel txtSearchGenre;
        private UI.Controls.OPMTextBox txtSearchUrlPart;
        private UI.Controls.OPMTextBox txtSearchServerTitlePart;
        private UI.Controls.OPMComboBox cmbSearchgenre;
    }
}