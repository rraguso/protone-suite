using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Configuration.MiscConfig
{
    partial class PlaylistOptionsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.txtHints = new OPMedia.UI.Controls.OPMTextBox();
            this.chkUseMetadata = new OPMedia.UI.Controls.OPMCheckBox();
            this.lblDisplayFileName = new OPMedia.UI.Controls.OPMLabel();
            this.chkFileNameFormat = new OPMedia.UI.Controls.OPMCheckBox();
            this.lblPlaylistFormat = new OPMedia.UI.Controls.OPMLabel();
            this.cmbFileNameFormat = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.cmbPlaylistEntryFormat = new OPMedia.UI.Controls.OPMEditableComboBox();
            this.buttonSpecAny3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtHints, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.chkUseMetadata, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDisplayFileName, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkFileNameFormat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPlaylistFormat, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbFileNameFormat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbPlaylistEntryFormat, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 326);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtHints
            // 
            this.txtHints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtHints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHints.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.txtHints.Location = new System.Drawing.Point(0, 142);
            this.txtHints.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.txtHints.MaxLength = 50;
            this.txtHints.Multiline = true;
            this.txtHints.Name = "txtHints";
            this.txtHints.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtHints.ReadOnly = true;
            this.txtHints.ShortcutsEnabled = false;
            this.txtHints.Size = new System.Drawing.Size(315, 184);
            this.txtHints.TabIndex = 6;
            this.txtHints.Text = "TXT_ID3PATTERNS";
            // 
            // chkUseMetadata
            // 
            this.chkUseMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseMetadata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseMetadata.Location = new System.Drawing.Point(0, 0);
            this.chkUseMetadata.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.chkUseMetadata.Name = "chkUseMetadata";
            this.chkUseMetadata.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkUseMetadata.Size = new System.Drawing.Size(315, 19);
            this.chkUseMetadata.TabIndex = 0;
            this.chkUseMetadata.Text = "TXT_USE_METADATA";
            this.chkUseMetadata.CheckedChanged += new System.EventHandler(this.chkUseMetadata_CheckedChanged);
            // 
            // lblDisplayFileName
            // 
            this.lblDisplayFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisplayFileName.Location = new System.Drawing.Point(0, 126);
            this.lblDisplayFileName.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDisplayFileName.Name = "lblDisplayFileName";
            this.lblDisplayFileName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDisplayFileName.OverrideForeColor = System.Drawing.Color.Red;
            this.lblDisplayFileName.Size = new System.Drawing.Size(315, 13);
            this.lblDisplayFileName.TabIndex = 5;
            this.lblDisplayFileName.Text = "TXT_DISPLAY_FILENAME";
            this.lblDisplayFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDisplayFileName.Visible = false;
            // 
            // chkFileNameFormat
            // 
            this.chkFileNameFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFileNameFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFileNameFormat.Location = new System.Drawing.Point(0, 29);
            this.chkFileNameFormat.Margin = new System.Windows.Forms.Padding(0);
            this.chkFileNameFormat.Name = "chkFileNameFormat";
            this.chkFileNameFormat.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkFileNameFormat.Size = new System.Drawing.Size(315, 19);
            this.chkFileNameFormat.TabIndex = 1;
            this.chkFileNameFormat.Text = "TXT_FILENAME_FORMAT";
            this.chkFileNameFormat.CheckedChanged += new System.EventHandler(this.chkFileNameFormat_CheckedChanged);
            // 
            // lblPlaylistFormat
            // 
            this.lblPlaylistFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlaylistFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlaylistFormat.Location = new System.Drawing.Point(0, 79);
            this.lblPlaylistFormat.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlaylistFormat.Name = "lblPlaylistFormat";
            this.lblPlaylistFormat.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblPlaylistFormat.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblPlaylistFormat.Size = new System.Drawing.Size(315, 17);
            this.lblPlaylistFormat.TabIndex = 3;
            this.lblPlaylistFormat.Text = "TXT_PLAYLIST_FORMAT";
            this.lblPlaylistFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFileNameFormat
            // 
            this.cmbFileNameFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbFileNameFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFileNameFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFileNameFormat.DropDownWidth = 292;
            this.cmbFileNameFormat.FormattingEnabled = true;
            this.cmbFileNameFormat.Items.AddRange(new object[] {
            "<A> - <T>",
            "<#> <A> - <T>"});
            this.cmbFileNameFormat.Location = new System.Drawing.Point(0, 48);
            this.cmbFileNameFormat.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.cmbFileNameFormat.Name = "cmbFileNameFormat";
            this.cmbFileNameFormat.Size = new System.Drawing.Size(315, 21);
            this.cmbFileNameFormat.TabIndex = 2;
            this.cmbFileNameFormat.SelectedIndexChanged += new System.EventHandler(this.OnFileNameFormatChanged);
            this.cmbFileNameFormat.TextChanged += new System.EventHandler(this.OnFileNameFormatChanged);
            // 
            // cmbPlaylistEntryFormat
            // 
            this.cmbPlaylistEntryFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPlaylistEntryFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPlaylistEntryFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPlaylistEntryFormat.DropDownWidth = 292;
            this.cmbPlaylistEntryFormat.FormattingEnabled = true;
            this.cmbPlaylistEntryFormat.Items.AddRange(new object[] {
            "<A> - <T>",
            "<#> <A> - <T>"});
            this.cmbPlaylistEntryFormat.Location = new System.Drawing.Point(0, 96);
            this.cmbPlaylistEntryFormat.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.cmbPlaylistEntryFormat.Name = "cmbPlaylistEntryFormat";
            this.cmbPlaylistEntryFormat.Size = new System.Drawing.Size(315, 21);
            this.cmbPlaylistEntryFormat.TabIndex = 4;
            this.cmbPlaylistEntryFormat.SelectedIndexChanged += new System.EventHandler(this.OnPlaylistEntryFormatChanged);
            this.cmbPlaylistEntryFormat.TextUpdate += new System.EventHandler(this.OnPlaylistEntryFormatChanged);
            // 
            // buttonSpecAny3
            // 
            this.buttonSpecAny3.Location = new System.Drawing.Point(0, 0);
            this.buttonSpecAny3.Name = "buttonSpecAny3";
            this.buttonSpecAny3.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecAny3.TabIndex = 0;
            // 
            // PlaylistOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlaylistOptionsPage";
            this.Size = new System.Drawing.Size(315, 326);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSpecAny3;
        private OPMTextBox txtHints;
        private OPMCheckBox chkUseMetadata;
        private OPMLabel lblDisplayFileName;
        private OPMCheckBox chkFileNameFormat;
        private OPMLabel lblPlaylistFormat;
        private OPMEditableComboBox cmbFileNameFormat;
        private OPMEditableComboBox cmbPlaylistEntryFormat;
    }
}
