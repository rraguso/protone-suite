using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class PlaylistPanel
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
            this.components = new System.ComponentModel.Container();
            this.ilImages = new System.Windows.Forms.ImageList(this.components);
            this.cmsPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dummyToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.layoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.subLayoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lvPlaylist = new OPMedia.UI.Controls.OPMListView(ColumnHeaderStyle.None);
            this.colDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMisc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playlistControlPanel = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaylistControlPanel();
            this.bookmarkManagerCtl = new OPMedia.UI.ProTONE.Controls.BookmarkManagement.BookmarkManagerCtl();
            this.btnShowHideBM = new OPMedia.UI.Controls.OPMButton();
            this.lblTotal = new OPMedia.UI.Controls.OPMLabel();
            this.btnShowHidePLControls = new OPMedia.UI.Controls.OPMButton();
            this.cmsPlaylist.SuspendLayout();
            this.layoutPanel.SuspendLayout();
            this.subLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilImages
            // 
            this.ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilImages.ImageSize = new System.Drawing.Size(16, 16);
            this.ilImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsPlaylist
            // 
            this.cmsPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem});
            this.cmsPlaylist.Name = "cmsPlaylist";
            this.cmsPlaylist.Size = new System.Drawing.Size(117, 26);
            this.cmsPlaylist.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPlaylist_Opening);
            // 
            // dummyToolStripMenuItem
            // 
            this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
            this.dummyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.dummyToolStripMenuItem.Text = "dummy";
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 3;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.Controls.Add(this.subLayoutPanel, 0, 1);
            this.layoutPanel.Controls.Add(this.btnShowHideBM, 2, 2);
            this.layoutPanel.Controls.Add(this.lblTotal, 1, 2);
            this.layoutPanel.Controls.Add(this.btnShowHidePLControls, 0, 2);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanel.RowCount = 3;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.Size = new System.Drawing.Size(355, 225);
            this.layoutPanel.TabIndex = 0;
            // 
            // opmTableLayoutPanel1
            // 
            this.subLayoutPanel.ColumnCount = 3;
            this.layoutPanel.SetColumnSpan(this.subLayoutPanel, 3);
            this.subLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.subLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.subLayoutPanel.Controls.Add(this.lvPlaylist, 1, 0);
            this.subLayoutPanel.Controls.Add(this.playlistControlPanel, 0, 0);
            this.subLayoutPanel.Controls.Add(this.bookmarkManagerCtl, 2, 0);
            this.subLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subLayoutPanel.Location = new System.Drawing.Point(0, 2);
            this.subLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.subLayoutPanel.Name = "opmTableLayoutPanel1";
            this.subLayoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.subLayoutPanel.RowCount = 1;
            this.subLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subLayoutPanel.Size = new System.Drawing.Size(355, 203);
            this.subLayoutPanel.TabIndex = 6;
            // 
            // lvPlaylist
            // 
            this.lvPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy,
            this.colIcon,
            this.colMisc,
            this.colTime,
            this.colFile});
            this.lvPlaylist.ContextMenuStrip = this.cmsPlaylist;
            this.lvPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlaylist.Location = new System.Drawing.Point(29, 0);
            this.lvPlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.lvPlaylist.MultiSelect = false;
            this.lvPlaylist.Name = "lvPlaylist";
            this.lvPlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvPlaylist.Size = new System.Drawing.Size(124, 203);
            this.lvPlaylist.TabIndex = 3;
            this.lvPlaylist.UseCompatibleStateImageBehavior = false;
            this.lvPlaylist.View = System.Windows.Forms.View.Details;
            this.lvPlaylist.SelectedIndexChanged += new System.EventHandler(this.lvPlaylist_SelectionChanged);
            this.lvPlaylist.DragLeave += new System.EventHandler(this.lvPlaylist_DragLeave);
            this.lvPlaylist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseClick);
            this.lvPlaylist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseDoubleClick);
            this.lvPlaylist.Resize += new System.EventHandler(this.lvPlaylist_Resize);
            // 
            // playlistControlPanel1
            // 
            this.playlistControlPanel.AutoSize = true;
            this.playlistControlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playlistControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistControlPanel.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.playlistControlPanel.Location = new System.Drawing.Point(0, 0);
            this.playlistControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.playlistControlPanel.Name = "playlistControlPanel1";
            this.playlistControlPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.playlistControlPanel.Size = new System.Drawing.Size(29, 203);
            this.playlistControlPanel.TabIndex = 4;
            // 
            // bookmarkManagerCtl
            // 
            this.bookmarkManagerCtl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bookmarkManagerCtl.CanAddToCurrent = true;
            this.bookmarkManagerCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookmarkManagerCtl.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.bookmarkManagerCtl.Location = new System.Drawing.Point(155, 0);
            this.bookmarkManagerCtl.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.bookmarkManagerCtl.Name = "bookmarkManagerCtl";
            this.bookmarkManagerCtl.OverrideBackColor = System.Drawing.Color.Empty;
            this.bookmarkManagerCtl.PlaylistItem = null;
            this.bookmarkManagerCtl.Size = new System.Drawing.Size(200, 203);
            this.bookmarkManagerCtl.TabIndex = 2;
            // 
            // btnShowHideBM
            // 
            this.btnShowHideBM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHideBM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideBM.Location = new System.Drawing.Point(343, 210);
            this.btnShowHideBM.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnShowHideBM.MaximumSize = new System.Drawing.Size(12, 12);
            this.btnShowHideBM.MinimumSize = new System.Drawing.Size(12, 12);
            this.btnShowHideBM.Name = "btnShowHideBM";
            this.btnShowHideBM.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnShowHideBM.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnShowHideBM.Size = new System.Drawing.Size(12, 12);
            this.btnShowHideBM.TabIndex = 7;
            this.btnShowHideBM.Text = ">";
            this.btnShowHideBM.UseVisualStyleBackColor = true;
            this.btnShowHideBM.Click += new System.EventHandler(this.OnShowHideBM);
            this.btnShowHideBM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblTotal.Location = new System.Drawing.Point(15, 210);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3, 5, 0, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblTotal.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblTotal.Size = new System.Drawing.Size(328, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total: 999:99:99";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // btnShowHidePLControls
            // 
            this.btnShowHidePLControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHidePLControls.Location = new System.Drawing.Point(0, 210);
            this.btnShowHidePLControls.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnShowHidePLControls.MaximumSize = new System.Drawing.Size(12, 12);
            this.btnShowHidePLControls.MinimumSize = new System.Drawing.Size(12, 12);
            this.btnShowHidePLControls.Name = "btnShowHidePLControls";
            this.btnShowHidePLControls.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnShowHidePLControls.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnShowHidePLControls.Size = new System.Drawing.Size(12, 12);
            this.btnShowHidePLControls.TabIndex = 6;
            this.btnShowHidePLControls.Text = ">";
            this.btnShowHidePLControls.UseVisualStyleBackColor = true;
            this.btnShowHidePLControls.Click += new System.EventHandler(this.OnShowHidePLControls);
            this.btnShowHidePLControls.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // PlaylistPanel
            // 
            this.Controls.Add(this.layoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(355, 225);
            this.Name = "PlaylistPanel";
            this.Size = new System.Drawing.Size(355, 225);
            this.cmsPlaylist.ResumeLayout(false);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.subLayoutPanel.ResumeLayout(false);
            this.subLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilImages;
        private OPMTableLayoutPanel layoutPanel;
        private ContextMenuStrip cmsPlaylist;
        private BookmarkManagement.BookmarkManagerCtl bookmarkManagerCtl;
        private OPMToolStripMenuItem dummyToolStripMenuItem;
        private OPMListView lvPlaylist;
        private ColumnHeader colDummy;
        private ColumnHeader colIcon;
        private ColumnHeader colTime;
        private ColumnHeader colFile;
        private ColumnHeader colMisc;
        private PlaylistControlPanel playlistControlPanel;
        private OPMLabel lblTotal;
        private OPMButton btnShowHidePLControls;
        private OPMButton btnShowHideBM;
        private OPMTableLayoutPanel subLayoutPanel;
    }
}
