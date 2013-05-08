using OPMedia.Runtime.Shortcuts;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
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
            this.volumeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.VolumeScale();
            this.timeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.TimeScale();
            this.playbackPanel = new OPMedia.UI.ProTONE.Controls.MediaPlayer.PlaybackControlPanel();
            this.mediaInfo = new OPMedia.UI.ProTONE.Controls.MediaPlayer.MediaInfo();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.volumeScale, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.timeScale, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.playbackPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mediaInfo, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(3100, 78);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(310, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 78);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // volumeScale
            // 
            this.volumeScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.volumeScale, 3);
            this.volumeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeScale.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.volumeScale.Location = new System.Drawing.Point(5, 56);
            this.volumeScale.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.volumeScale.Name = "volumeScale";
            this.volumeScale.OverrideBackColor = System.Drawing.Color.Empty;
            this.volumeScale.Position = 5000;
            this.volumeScale.Size = new System.Drawing.Size(300, 19);
            this.volumeScale.TabIndex = 5;
            // 
            // timeScale
            // 
            this.timeScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.timeScale, 3);
            this.timeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeScale.ElapsedSeconds = 0D;
            this.timeScale.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.timeScale.IsOnMenuBar = false;
            this.timeScale.Location = new System.Drawing.Point(5, 30);
            this.timeScale.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.timeScale.Name = "timeScale";
            this.timeScale.OverrideBackColor = System.Drawing.Color.Empty;
            this.timeScale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timeScale.Size = new System.Drawing.Size(300, 23);
            this.timeScale.TabIndex = 4;
            this.timeScale.TotalSeconds = 0D;
            // 
            // playbackPanel
            // 
            this.playbackPanel.AutoSize = true;
            this.playbackPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playbackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playbackPanel.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.playbackPanel.Location = new System.Drawing.Point(4, 0);
            this.playbackPanel.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.playbackPanel.MinimumSize = new System.Drawing.Size(225, 25);
            this.playbackPanel.Name = "playbackPanel";
            this.playbackPanel.OverrideBackColor = System.Drawing.Color.Empty;
            this.playbackPanel.Size = new System.Drawing.Size(312, 25);
            this.playbackPanel.TabIndex = 2;
            // 
            // mediaInfo
            // 
            this.mediaInfo.AutoSize = true;
            this.mediaInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mediaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaInfo.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.mediaInfo.Location = new System.Drawing.Point(230, 0);
            this.mediaInfo.Margin = new System.Windows.Forms.Padding(0);
            this.mediaInfo.MediaName = "";
            this.mediaInfo.MediaState = OPMedia.Runtime.ProTONE.Rendering.Base.MediaState.Stopped;
            this.mediaInfo.MediaType = OPMedia.Runtime.ProTONE.Rendering.Base.MediaTypes.None;
            this.mediaInfo.MinimumSize = new System.Drawing.Size(80, 25);
            this.mediaInfo.Name = "mediaInfo";
            this.mediaInfo.OverrideBackColor = System.Drawing.Color.Empty;
            this.mediaInfo.Size = new System.Drawing.Size(80, 25);
            this.mediaInfo.TabIndex = 3;
            // 
            // RenderingPanel
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.HasBorder = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RenderingPanel";
            this.Size = new System.Drawing.Size(309, 78);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlaybackControlPanel playbackPanel;
        private TimeScale timeScale;
        private VolumeScale volumeScale;
        private MediaInfo mediaInfo;
        private OPMTableLayoutPanel tableLayoutPanel1;

    }
}
