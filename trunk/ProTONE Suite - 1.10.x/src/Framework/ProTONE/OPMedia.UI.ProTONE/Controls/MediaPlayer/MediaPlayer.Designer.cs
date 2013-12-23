using OPMedia.UI.Controls;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.UI.ProTONE.Controls;
using System.Windows.Forms;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Themes;
namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class MediaPlayer
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
            this.layoutPanel = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlPlaylist = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaylistPanel();
            this.pnlRendering = new OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingPanel();
            this.cmsOpenFiles = new ContextMenuStrip();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 1;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.pnlPlaylist, 0, 0);
            this.layoutPanel.Controls.Add(this.pnlRendering, 0, 1);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.Size = new System.Drawing.Size(365, 303);
            this.layoutPanel.TabIndex = 0;
            // 
            // pnlPlaylist
            // 
            this.pnlPlaylist.AllowDrop = true;
            this.pnlPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlaylist.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pnlPlaylist.Location = new System.Drawing.Point(3, 0);
            this.pnlPlaylist.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.pnlPlaylist.MinimumSize = new System.Drawing.Size(160, 160);
            this.pnlPlaylist.Name = "pnlPlaylist";
            this.pnlPlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlPlaylist.Size = new System.Drawing.Size(359, 220);
            this.pnlPlaylist.TabIndex = 0;
            this.pnlPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlaylist_DragDrop);
            this.pnlPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPlaylist_DragEnter);
            this.pnlPlaylist.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlPlaylist_DragOver);
            this.pnlPlaylist.DragLeave += new System.EventHandler(this.pnlPlaylist_DragLeave);
            // 
            // pnlRendering
            // 
            this.pnlRendering.AllowDrop = true;
            this.pnlRendering.AutoSize = true;
            this.pnlRendering.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRendering.BaseColor = System.Drawing.Color.Empty;
            this.pnlRendering.BorderWidth = 0;
            this.pnlRendering.CompactView = false;
            this.pnlRendering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRendering.ElapsedSeconds = 0D;
            this.pnlRendering.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.pnlRendering.HasBorder = false;
            this.pnlRendering.Highlight = false;
            this.pnlRendering.Location = new System.Drawing.Point(0, 225);
            this.pnlRendering.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRendering.Name = "pnlRendering";
            this.pnlRendering.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlRendering.ProjectedVolume = 5000;
            this.pnlRendering.Size = new System.Drawing.Size(365, 78);
            this.pnlRendering.TabIndex = 1;
            this.pnlRendering.TimeScaleEnabled = true;
            this.pnlRendering.TotalSeconds = 0D;
            this.pnlRendering.VolumeScaleEnabled = true;
            this.pnlRendering.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlRendering_DragDrop);
            this.pnlRendering.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlRendering_DragEnter);
            this.pnlRendering.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlRendering_DragOver);
            this.pnlRendering.DragLeave += new System.EventHandler(this.pnlRendering_DragLeave);
            // 
            // MediaPlayer
            // 
            this.Controls.Add(this.layoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(365, 255);
            this.Name = "MediaPlayer";
            this.Size = new System.Drawing.Size(365, 303);
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RenderingPanel pnlRendering;
        private OPMTableLayoutPanel layoutPanel;
        private PlaylistPanel pnlPlaylist;
        private ContextMenuStrip cmsOpenFiles;
    }
}
