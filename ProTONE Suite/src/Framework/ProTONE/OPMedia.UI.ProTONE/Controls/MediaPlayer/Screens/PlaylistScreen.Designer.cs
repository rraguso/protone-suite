using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Themes;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class PlaylistScreen
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
            this.cmsPlaylist = new OPMedia.UI.Controls.OPMContextMenuStrip();
            this.dummyToolStripMenuItem = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.lvPlaylist = new OPMedia.UI.Controls.OPMListView(ColumnHeaderStyle.None);
            this.colDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMisc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLayout = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblTotal = new OPMedia.UI.Controls.OPMLabel();
            this.lblSep = new OPMedia.UI.Controls.OPMLabel();
            this.cmsPlaylist.SuspendLayout();
            this.pnlLayout.SuspendLayout();
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
            this.cmsPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cmsPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
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
            // lvPlaylist
            // 
            this.lvPlaylist.AllowEditing = true;
            this.lvPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy,
            this.colMisc,
            this.colIcon,
            this.colTime,
            this.colFile});
            this.lvPlaylist.ContextMenuStrip = this.cmsPlaylist;
            this.lvPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlaylist.Location = new System.Drawing.Point(0, 10);
            this.lvPlaylist.Margin = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.lvPlaylist.MultiSelect = false;
            this.lvPlaylist.Name = "lvPlaylist";
            this.lvPlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvPlaylist.Size = new System.Drawing.Size(355, 196);
            this.lvPlaylist.TabIndex = 3;
            this.lvPlaylist.UseCompatibleStateImageBehavior = false;
            this.lvPlaylist.View = System.Windows.Forms.View.Details;
            this.lvPlaylist.SelectedIndexChanged += new System.EventHandler(this.lvPlaylist_SelectedIndexChanged);
            this.lvPlaylist.DragLeave += new System.EventHandler(this.lvPlaylist_DragLeave);
            this.lvPlaylist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseClick);
            this.lvPlaylist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseDoubleClick);
            this.lvPlaylist.Resize += new System.EventHandler(this.lvPlaylist_Resize);
            // 
            // pnlLayout
            // 
            this.pnlLayout.ColumnCount = 1;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.Controls.Add(this.lvPlaylist, 0, 0);
            this.pnlLayout.Controls.Add(this.lblTotal, 0, 2);
            this.pnlLayout.Controls.Add(this.lblSep, 0, 1);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlLayout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlLayout.RowCount = 3;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLayout.Size = new System.Drawing.Size(355, 225);
            this.pnlLayout.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.lblTotal.Location = new System.Drawing.Point(2, 211);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblTotal.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblTotal.Size = new System.Drawing.Size(353, 12);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "opmLabel1";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSep
            // 
            this.lblSep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep.Location = new System.Drawing.Point(0, 208);
            this.lblSep.Margin = new System.Windows.Forms.Padding(0);
            this.lblSep.Name = "lblSep";
            this.lblSep.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblSep.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSep.Size = new System.Drawing.Size(355, 1);
            this.lblSep.TabIndex = 5;
            // 
            // PlaylistScreen
            // 
            this.Controls.Add(this.pnlLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlaylistScreen";
            this.Size = new System.Drawing.Size(355, 225);
            this.cmsPlaylist.ResumeLayout(false);
            this.pnlLayout.ResumeLayout(false);
            this.pnlLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilImages;
        private OPMToolStripMenuItem dummyToolStripMenuItem;
        private OPMListView lvPlaylist;
        private ColumnHeader colDummy;
        private ColumnHeader colIcon;
        private ColumnHeader colMisc;
        private ColumnHeader colTime;
        private ColumnHeader colFile;
        private OPMContextMenuStrip cmsPlaylist;
        private OPMTableLayoutPanel pnlLayout;
        private OPMLabel lblTotal;
        private OPMLabel lblSep;
    }
}
