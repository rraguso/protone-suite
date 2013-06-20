namespace OPMedia.UI.Controls.Dialogs
{
    partial class OPMFileDialog
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbDiskDrives = new OPMedia.UI.Controls.OPMComboBox();
            this.cmbFilter = new OPMedia.UI.Controls.OPMComboBox();
            this.txtFileNames = new OPMedia.UI.Controls.OPMTextBox();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.lvExplorer = new OPMedia.UI.Controls.OPMShellListView();
            this.lblCurrentPath = new OPMedia.UI.Controls.OPMLabel();
            this.tsSpecialFolders = new OPMedia.UI.Controls.OPMToolStrip();
            this.btnAddToFavorites = new OPMedia.UI.Controls.OPMButton();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.ColumnCount = 5;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel3, 0, 6);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbDiskDrives, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbFilter, 1, 6);
            this.opmTableLayoutPanel1.Controls.Add(this.txtFileNames, 1, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 3, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 3, 6);
            this.opmTableLayoutPanel1.Controls.Add(this.lvExplorer, 1, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.lblCurrentPath, 1, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.tsSpecialFolders, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.btnAddToFavorites, 4, 3);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 7;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(640, 492);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(0, 5);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(82, 23);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "TXT_LOOK_IN:";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(0, 430);
            this.opmLabel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(82, 31);
            this.opmLabel2.TabIndex = 4;
            this.opmLabel2.Text = "TXT_FILENAME:";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.Location = new System.Drawing.Point(0, 461);
            this.opmLabel3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(82, 31);
            this.opmLabel3.TabIndex = 6;
            this.opmLabel3.Text = "TXT_FILE_TYPE:";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDiskDrives
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.cmbDiskDrives, 4);
            this.cmbDiskDrives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDiskDrives.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDiskDrives.FormattingEnabled = true;
            this.cmbDiskDrives.Location = new System.Drawing.Point(85, 5);
            this.cmbDiskDrives.Margin = new System.Windows.Forms.Padding(0);
            this.cmbDiskDrives.Name = "cmbDiskDrives";
            this.cmbDiskDrives.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbDiskDrives.Size = new System.Drawing.Size(555, 23);
            this.cmbDiskDrives.TabIndex = 1;
            // 
            // cmbFilter
            // 
            this.cmbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(85, 466);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbFilter.Size = new System.Drawing.Size(439, 23);
            this.cmbFilter.TabIndex = 7;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // txtFileNames
            // 
            this.txtFileNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFileNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileNames.Location = new System.Drawing.Point(85, 435);
            this.txtFileNames.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.txtFileNames.Name = "txtFileNames";
            this.txtFileNames.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtFileNames.Size = new System.Drawing.Size(439, 22);
            this.txtFileNames.TabIndex = 5;
            this.txtFileNames.TextChanged += new System.EventHandler(this.txtFileNames_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.SetColumnSpan(this.btnOK, 2);
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(557, 433);
            this.btnOK.MinimumSize = new System.Drawing.Size(70, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnOK);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(557, 464);
            this.btnCancel.MinimumSize = new System.Drawing.Size(70, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // lvExplorer
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.lvExplorer, 4);
            this.lvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExplorer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvExplorer.LabelEdit = true;
            this.lvExplorer.Location = new System.Drawing.Point(85, 55);
            this.lvExplorer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lvExplorer.MultiSelect = false;
            this.lvExplorer.Name = "lvExplorer";
            this.lvExplorer.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvExplorer.Size = new System.Drawing.Size(555, 370);
            this.lvExplorer.TabIndex = 3;
            this.lvExplorer.UseCompatibleStateImageBehavior = false;
            this.lvExplorer.View = System.Windows.Forms.View.Details;
            // 
            // lblCurrentPath
            // 
            this.lblCurrentPath.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblCurrentPath, 3);
            this.lblCurrentPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentPath.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.lblCurrentPath.Location = new System.Drawing.Point(85, 36);
            this.lblCurrentPath.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblCurrentPath.Name = "lblCurrentPath";
            this.lblCurrentPath.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblCurrentPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblCurrentPath.Size = new System.Drawing.Size(523, 16);
            this.lblCurrentPath.TabIndex = 9;
            this.lblCurrentPath.Text = "opmLabel4";
            this.lblCurrentPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsSpecialFolders
            // 
            this.tsSpecialFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tsSpecialFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsSpecialFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsSpecialFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSpecialFolders.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsSpecialFolders.Location = new System.Drawing.Point(0, 55);
            this.tsSpecialFolders.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsSpecialFolders.Name = "tsSpecialFolders";
            this.tsSpecialFolders.ShowBorder = true;
            this.tsSpecialFolders.Size = new System.Drawing.Size(85, 370);
            this.tsSpecialFolders.TabIndex = 2;
            this.tsSpecialFolders.Text = "opmToolStrip1";
            this.tsSpecialFolders.VerticalGradient = false;
            // 
            // btnAddToFavorites
            // 
            this.btnAddToFavorites.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddToFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToFavorites.Location = new System.Drawing.Point(619, 34);
            this.btnAddToFavorites.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddToFavorites.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnAddToFavorites.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnAddToFavorites.Name = "btnAddToFavorites";
            this.btnAddToFavorites.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnAddToFavorites.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAddToFavorites.Size = new System.Drawing.Size(20, 20);
            this.btnAddToFavorites.TabIndex = 10;
            this.btnAddToFavorites.UseVisualStyleBackColor = true;
            this.btnAddToFavorites.Click += new System.EventHandler(this.btnAddToFavorites_Click);
            // 
            // OPMFileDialog
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(650, 520);
            this.MinimumSize = new System.Drawing.Size(650, 520);
            this.Name = "OPMFileDialog";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMLabel opmLabel1;
        private OPMedia.UI.Controls.OPMComboBox cmbDiskDrives;
        private OPMedia.UI.Controls.OPMLabel opmLabel2;
        private OPMedia.UI.Controls.OPMLabel opmLabel3;
        private OPMedia.UI.Controls.OPMComboBox cmbFilter;
        private OPMedia.UI.Controls.OPMTextBox txtFileNames;
        private OPMedia.UI.Controls.OPMButton btnOK;
        private OPMedia.UI.Controls.OPMButton btnCancel;
        private OPMedia.UI.Controls.OPMLabel lblCurrentPath;
        protected internal OPMedia.UI.Controls.OPMShellListView lvExplorer;
        private OPMToolStrip tsSpecialFolders;
        private OPMButton btnAddToFavorites;
    }
}