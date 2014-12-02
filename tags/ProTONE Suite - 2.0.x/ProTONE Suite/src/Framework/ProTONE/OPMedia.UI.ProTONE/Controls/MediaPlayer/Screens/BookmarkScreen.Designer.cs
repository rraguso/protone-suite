using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.UI.ProTONE.Controls.BookmarkManagement
{
    partial class BookmarkScreen
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
            this.lblItem = new OPMedia.UI.Controls.OPMLabel();
            this.lvBookmarks = new OPMedia.UI.Controls.OPMListView();
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.pbAddCurrent = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pnlLayout = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlBookmarkEdit = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlButtons = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.playlistScreen = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaylistScreen();
            this.lblNoInfo = new OPMedia.UI.Controls.OPMLabel();
            this.layoutPanelInner = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            this.pnlLayout.SuspendLayout();
            this.pnlBookmarkEdit.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.layoutPanelInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.pnlLayout.SetColumnSpan(this.lblItem, 2);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblItem.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblItem.Location = new System.Drawing.Point(0, 3);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblItem.Name = "lblItem";
            this.lblItem.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblItem.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblItem.Size = new System.Drawing.Size(572, 13);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "[ item ]";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvBookmarks
            // 
            this.lvBookmarks.AllowEditing = true;
            this.lvBookmarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colTime,
            this.colText});
            this.lvBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBookmarks.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.lvBookmarks.Location = new System.Drawing.Point(0, 0);
            this.lvBookmarks.Margin = new System.Windows.Forms.Padding(0);
            this.lvBookmarks.MultiSelect = false;
            this.lvBookmarks.Name = "lvBookmarks";
            this.lvBookmarks.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlBookmarkEdit.SetRowSpan(this.lvBookmarks, 3);
            this.lvBookmarks.Size = new System.Drawing.Size(260, 352);
            this.lvBookmarks.TabIndex = 2;
            this.lvBookmarks.UseCompatibleStateImageBehavior = false;
            this.lvBookmarks.View = System.Windows.Forms.View.Details;
            this.lvBookmarks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBookmarks_MouseDoubleClick);
            // 
            // colIcon
            // 
            this.colIcon.Name = "colIcon";
            this.colIcon.Text = "";
            this.colIcon.Width = 20;
            // 
            // colTime
            // 
            this.colTime.Name = "colTime";
            this.colTime.Text = "TXT_BOOKMARK_TIME";
            this.colTime.Width = 106;
            // 
            // colText
            // 
            this.colText.Name = "colText";
            this.colText.Text = "TXT_BOOKMARK_DESC";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.pnlBookmarkEdit.SetColumnSpan(this.lblDesc, 2);
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.lblDesc.Location = new System.Drawing.Point(0, 352);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(280, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "TXT_CLICK_LIST_TO_EDIT";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbAddCurrent
            // 
            this.pbAddCurrent.Location = new System.Drawing.Point(2, 22);
            this.pbAddCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.pbAddCurrent.Name = "pbAddCurrent";
            this.pbAddCurrent.Size = new System.Drawing.Size(16, 16);
            this.pbAddCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddCurrent.TabIndex = 0;
            this.pbAddCurrent.TabStop = false;
            this.pbAddCurrent.Tag = "TXT_NEWNOW_BMDESC";
            this.pbAddCurrent.Text = "...";
            this.pbAddCurrent.Click += new System.EventHandler(this.btnAddCurrent_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbAdd.Location = new System.Drawing.Point(2, 2);
            this.pbAdd.Margin = new System.Windows.Forms.Padding(2);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(16, 16);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAdd.TabIndex = 1;
            this.pbAdd.TabStop = false;
            this.pbAdd.Tag = "TXT_NEW_BMDESC";
            this.pbAdd.Text = "...";
            this.pbAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Location = new System.Drawing.Point(2, 42);
            this.pbDelete.Margin = new System.Windows.Forms.Padding(2);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(16, 16);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDelete.TabIndex = 2;
            this.pbDelete.TabStop = false;
            this.pbDelete.Tag = "TXT_DELETE_BMDESC";
            this.pbDelete.Text = "...";
            this.pbDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlLayout
            // 
            this.pnlLayout.ColumnCount = 3;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlLayout.Controls.Add(this.layoutPanelInner, 1, 1);
            this.pnlLayout.Controls.Add(this.lblItem, 0, 0);
            this.pnlLayout.Controls.Add(this.playlistScreen, 0, 1);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlLayout.RowCount = 2;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.Size = new System.Drawing.Size(572, 403);
            this.pnlLayout.TabIndex = 1;
            // 
            // pnlBookmarkEdit
            // 
            this.pnlBookmarkEdit.ColumnCount = 2;
            this.pnlBookmarkEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBookmarkEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlBookmarkEdit.Controls.Add(this.lvBookmarks, 0, 0);
            this.pnlBookmarkEdit.Controls.Add(this.lblDesc, 0, 3);
            this.pnlBookmarkEdit.Controls.Add(this.pnlButtons, 1, 1);
            this.pnlBookmarkEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookmarkEdit.Location = new System.Drawing.Point(3, 16);
            this.pnlBookmarkEdit.Name = "pnlBookmarkEdit";
            this.pnlBookmarkEdit.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlBookmarkEdit.RowCount = 4;
            this.pnlBookmarkEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBookmarkEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBookmarkEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBookmarkEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlBookmarkEdit.Size = new System.Drawing.Size(280, 365);
            this.pnlBookmarkEdit.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.Controls.Add(this.pbAdd);
            this.pnlButtons.Controls.Add(this.pbAddCurrent);
            this.pnlButtons.Controls.Add(this.pbDelete);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlButtons.Location = new System.Drawing.Point(260, 20);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlBookmarkEdit.SetRowSpan(this.pnlButtons, 2);
            this.pnlButtons.Size = new System.Drawing.Size(20, 332);
            this.pnlButtons.TabIndex = 3;
            // 
            // playlistScreen
            // 
            this.playlistScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistScreen.CompactMode = true;
            this.playlistScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistScreen.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.playlistScreen.Location = new System.Drawing.Point(0, 19);
            this.playlistScreen.Margin = new System.Windows.Forms.Padding(0);
            this.playlistScreen.Name = "playlistScreen";
            this.playlistScreen.OverrideBackColor = System.Drawing.Color.Empty;
            this.playlistScreen.Size = new System.Drawing.Size(286, 384);
            this.playlistScreen.TabIndex = 5;
            // 
            // lblNoInfo
            // 
            this.lblNoInfo.AutoSize = true;
            this.lblNoInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoInfo.Location = new System.Drawing.Point(3, 0);
            this.lblNoInfo.Name = "lblNoInfo";
            this.lblNoInfo.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNoInfo.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNoInfo.Size = new System.Drawing.Size(280, 13);
            this.lblNoInfo.TabIndex = 6;
            this.lblNoInfo.Text = "TXT_THEREARENOITEMS";
            // 
            // layoutPanelInner
            // 
            this.layoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanelInner.Controls.Add(this.lblNoInfo, 0, 0);
            this.layoutPanelInner.Controls.Add(this.pnlBookmarkEdit, 0, 1);
            this.layoutPanelInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelInner.Location = new System.Drawing.Point(286, 19);
            this.layoutPanelInner.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanelInner.Name = "layoutPanelInner";
            this.layoutPanelInner.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanelInner.RowCount = 2;
            this.layoutPanelInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanelInner.Size = new System.Drawing.Size(286, 384);
            this.layoutPanelInner.TabIndex = 7;
            // 
            // BookmarkScreen
            // 
            this.Controls.Add(this.pnlLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BookmarkScreen";
            this.Size = new System.Drawing.Size(572, 403);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.pnlLayout.ResumeLayout(false);
            this.pnlLayout.PerformLayout();
            this.pnlBookmarkEdit.ResumeLayout(false);
            this.pnlBookmarkEdit.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.layoutPanelInner.ResumeLayout(false);
            this.layoutPanelInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblItem;
        private OPMListView lvBookmarks;
        private OPMLabel lblDesc;
        private PictureBox pbAddCurrent;
        private PictureBox pbAdd;
        private PictureBox pbDelete;
        private ColumnHeader colIcon;
        private ColumnHeader colTime;
        private ColumnHeader colText;
        private OPMTableLayoutPanel pnlLayout;
        private OPMFlowLayoutPanel pnlButtons;
        private MediaPlayer.PlaylistScreen playlistScreen;
        private OPMTableLayoutPanel pnlBookmarkEdit;
        private OPMLabel lblNoInfo;
        private OPMTableLayoutPanel layoutPanelInner;
    }
}
