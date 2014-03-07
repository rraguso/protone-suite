using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.UI.ProTONE.Properties;

namespace OPMedia.UI.ProTONE.Dialogs
{
    partial class ID3ArtworkDlg
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
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.lblItem = new OPMedia.UI.Controls.OPMLabel();
            this.btnBrowse = new OPMedia.UI.Controls.OPMButton();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmPanel1 = new OPMedia.UI.Controls.OPMPanel();
            this.btnSave = new OPMedia.UI.Controls.OPMButton();
            this.lblSep = new OPMedia.UI.Controls.OPMLabel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lvPictures = new OPMedia.UI.Controls.OPMListView();
            this.colImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImageType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.opmFlowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.opmLayoutPanel1.SuspendLayout();
            this.opmPanel1.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.opmFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
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
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(517, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(456, 254);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "TXT_OK";
            // 
            // pbPicture
            // 
            this.pbPicture.BackColor = System.Drawing.Color.Transparent;
            this.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture.Location = new System.Drawing.Point(0, 0);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(218, 223);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPicture.TabIndex = 29;
            this.pbPicture.TabStop = false;
            this.pbPicture.DoubleClick += new System.EventHandler(this.pbPicture_DoubleClick);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.lblItem, 4);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblItem.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblItem.Location = new System.Drawing.Point(3, 3);
            this.lblItem.Margin = new System.Windows.Forms.Padding(3);
            this.lblItem.Name = "lblItem";
            this.lblItem.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblItem.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblItem.Size = new System.Drawing.Size(594, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "label1";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnLoadPlaylist;
            this.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowse.Location = new System.Drawing.Point(195, 200);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnBrowse.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnBrowse.Size = new System.Drawing.Size(21, 21);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Click += new System.EventHandler(this.pbPicture_DoubleClick);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 4;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.Controls.Add(this.btnCancel, 3, 5);
            this.opmLayoutPanel1.Controls.Add(this.btnOK, 2, 5);
            this.opmLayoutPanel1.Controls.Add(this.lblItem, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.opmPanel1, 1, 1);
            this.opmLayoutPanel1.Controls.Add(this.lblSep, 0, 4);
            this.opmLayoutPanel1.Controls.Add(this.opmTableLayoutPanel1, 0, 1);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 6;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(600, 282);
            this.opmLayoutPanel1.TabIndex = 0;
            // 
            // opmPanel1
            // 
            this.opmPanel1.AutoSize = true;
            this.opmPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel1.SetColumnSpan(this.opmPanel1, 3);
            this.opmPanel1.Controls.Add(this.btnSave);
            this.opmPanel1.Controls.Add(this.btnBrowse);
            this.opmPanel1.Controls.Add(this.pbPicture);
            this.opmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmPanel1.Location = new System.Drawing.Point(379, 22);
            this.opmPanel1.Name = "opmPanel1";
            this.opmPanel1.Size = new System.Drawing.Size(218, 223);
            this.opmPanel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnSavePlaylist;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(173, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnSave.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(21, 21);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSep
            // 
            this.opmLayoutPanel1.SetColumnSpan(this.lblSep, 4);
            this.lblSep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep.Location = new System.Drawing.Point(3, 248);
            this.lblSep.Name = "lblSep";
            this.lblSep.OverrideBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblSep.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSep.Size = new System.Drawing.Size(594, 3);
            this.lblSep.TabIndex = 32;
            this.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Controls.Add(this.lvPictures, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lblDesc, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.opmFlowLayoutPanel1, 1, 4);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 5;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(370, 223);
            this.opmTableLayoutPanel1.TabIndex = 34;
            // 
            // lvPictures
            // 
            this.lvPictures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImage,
            this.colImageType,
            this.colDescription});
            this.opmTableLayoutPanel1.SetColumnSpan(this.lvPictures, 2);
            this.lvPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPictures.Location = new System.Drawing.Point(0, 0);
            this.lvPictures.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lvPictures.MultiSelect = false;
            this.lvPictures.Name = "lvPictures";
            this.lvPictures.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.SetRowSpan(this.lvPictures, 4);
            this.lvPictures.Size = new System.Drawing.Size(370, 200);
            this.lvPictures.TabIndex = 0;
            this.lvPictures.UseCompatibleStateImageBehavior = false;
            this.lvPictures.View = System.Windows.Forms.View.Details;
            this.lvPictures.SubItemEdited += new OPMedia.UI.Controls.OPMListView.EditableListViewEventHandler(this.lvPictures_SubItemEdited);
            this.lvPictures.SelectedIndexChanged += new System.EventHandler(this.lvPictures_SelectionChanged);
            this.lvPictures.Resize += new System.EventHandler(this.lvPictures_Resize);
            // 
            // colImage
            // 
            this.colImage.Text = "TXT_PICTURE";
            this.colImage.Width = 85;
            // 
            // colImageType
            // 
            this.colImageType.Text = "TXT_PICTURE_TYPE";
            this.colImageType.Width = 87;
            // 
            // colDescription
            // 
            this.colDescription.Text = "TXT_PICTURE_TEXT";
            this.colDescription.Width = 104;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.lblDesc.Location = new System.Drawing.Point(0, 203);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(330, 20);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "TXT_CLICK_LIST_TO_EDIT";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmFlowLayoutPanel1
            // 
            this.opmFlowLayoutPanel1.AutoSize = true;
            this.opmFlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmFlowLayoutPanel1.Controls.Add(this.pbAdd);
            this.opmFlowLayoutPanel1.Controls.Add(this.pbDelete);
            this.opmFlowLayoutPanel1.Location = new System.Drawing.Point(330, 203);
            this.opmFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmFlowLayoutPanel1.Name = "opmFlowLayoutPanel1";
            this.opmFlowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmFlowLayoutPanel1.Size = new System.Drawing.Size(40, 20);
            this.opmFlowLayoutPanel1.TabIndex = 2;
            this.opmFlowLayoutPanel1.WrapContents = false;
            // 
            // pbAdd
            // 
            this.pbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAdd.Location = new System.Drawing.Point(2, 2);
            this.pbAdd.Margin = new System.Windows.Forms.Padding(2);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(16, 16);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAdd.TabIndex = 34;
            this.pbAdd.TabStop = false;
            this.pbAdd.Tag = "TXT_NEW_BMDESC";
            this.pbAdd.Text = "...";
            this.pbAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDelete.Location = new System.Drawing.Point(22, 2);
            this.pbDelete.Margin = new System.Windows.Forms.Padding(2);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(16, 16);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDelete.TabIndex = 35;
            this.pbDelete.TabStop = false;
            this.pbDelete.Tag = "TXT_DELETE_BMDESC";
            this.pbDelete.Text = "...";
            this.pbDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ID3ArtworkDlg
            // 
            this.ClientSize = new System.Drawing.Size(610, 310);
            this.Name = "ID3ArtworkDlg";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.opmPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.opmFlowLayoutPanel1.ResumeLayout(false);
            this.opmFlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton btnCancel;
        private OPMButton btnOK;
        private System.Windows.Forms.PictureBox pbPicture;
        private OPMLabel lblItem;
        private OPMButton btnBrowse;
        private OPMTableLayoutPanel opmLayoutPanel1;
        private OPMPanel opmPanel1;
        private OPMLabel lblSep;
        private OPMListView lvPictures;
        private ColumnHeader colImage;
        private ColumnHeader colImageType;
        private ColumnHeader colDescription;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private PictureBox pbAdd;
        private PictureBox pbDelete;
        private OPMLabel lblDesc;
        private OPMButton btnSave;
        private OPMFlowLayoutPanel opmFlowLayoutPanel1;
    }
}