using OPMedia.Runtime.Shortcuts;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using System.Drawing;
namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class RenderingPanel
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
            this.pbTimeIcon = new System.Windows.Forms.PictureBox();
            this.pbVolIcon = new System.Windows.Forms.PictureBox();
            this.volumeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.VolumeScale();
            this.timeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.TimeScale();
            this.playbackPanel = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaybackControlPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.pbTimeIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.volumeScale, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeScale, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbVolIcon, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.playbackPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(100, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 54);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // pbTimeIcon
            // 
            this.pbTimeIcon.Location = new System.Drawing.Point(0, 1);
            this.pbTimeIcon.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pbTimeIcon.Name = "pbTimeIcon";
            this.pbTimeIcon.Size = new System.Drawing.Size(20, 20);
            this.pbTimeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTimeIcon.TabIndex = 7;
            this.pbTimeIcon.TabStop = false;
            // 
            // pbVolIcon
            // 
            this.pbVolIcon.Location = new System.Drawing.Point(311, 1);
            this.pbVolIcon.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pbVolIcon.Name = "pbVolIcon";
            this.pbVolIcon.Size = new System.Drawing.Size(20, 20);
            this.pbVolIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVolIcon.TabIndex = 6;
            this.pbVolIcon.TabStop = false;
            // 
            // volumeScale
            // 
            this.volumeScale.AutoSize = true;
            this.volumeScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.volumeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeScale.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.volumeScale.IsOnMenuBar = false;
            this.volumeScale.Location = new System.Drawing.Point(331, 7);
            this.volumeScale.Margin = new System.Windows.Forms.Padding(0, 7, 3, 0);
            this.volumeScale.Name = "volumeScale";
            this.volumeScale.OverrideBackColor = System.Drawing.Color.Empty;
            this.volumeScale.Position = 5000;
            this.volumeScale.Size = new System.Drawing.Size(147, 14);
            this.volumeScale.TabIndex = 5;
            // 
            // timeScale
            // 
            this.timeScale.AutoSize = true;
            this.timeScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeScale.ElapsedSeconds = 0D;
            this.timeScale.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.timeScale.IsOnMenuBar = false;
            this.timeScale.Location = new System.Drawing.Point(20, 7);
            this.timeScale.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.timeScale.Name = "timeScale";
            this.timeScale.OverrideBackColor = System.Drawing.Color.Empty;
            this.timeScale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timeScale.Size = new System.Drawing.Size(290, 14);
            this.timeScale.TabIndex = 4;
            this.timeScale.TotalSeconds = 0D;
            // 
            // playbackPanel
            // 
            this.playbackPanel.AutoSize = true;
            this.playbackPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.playbackPanel, 5);
            this.playbackPanel.CompactView = false;
            this.playbackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playbackPanel.ElapsedSeconds = 0D;
            this.playbackPanel.FilterState = OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses.FilterState.Stopped;
            this.playbackPanel.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.playbackPanel.Location = new System.Drawing.Point(0, 24);
            this.playbackPanel.Margin = new System.Windows.Forms.Padding(0);
            this.playbackPanel.MediaName = "";
            this.playbackPanel.MediaType = OPMedia.Runtime.ProTONE.Rendering.Base.MediaTypes.None;
            this.playbackPanel.MinimumSize = new System.Drawing.Size(200, 30);
            this.playbackPanel.Name = "playbackPanel";
            this.playbackPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.playbackPanel.Size = new System.Drawing.Size(481, 30);
            this.playbackPanel.TabIndex = 2;
            this.playbackPanel.TotalSeconds = 0D;
            // 
            // RenderingPanel
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.HasBorder = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(481, 55);
            this.Name = "RenderingPanel";
            this.Size = new System.Drawing.Size(481, 55);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PlaybackControlPanel playbackPanel;
        private TimeScale timeScale;
        private VolumeScale volumeScale;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private PictureBox pbVolIcon;
        private PictureBox pbTimeIcon;

    }
}
