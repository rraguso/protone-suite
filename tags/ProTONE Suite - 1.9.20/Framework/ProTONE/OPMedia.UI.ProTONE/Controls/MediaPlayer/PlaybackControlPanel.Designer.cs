using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    partial class PlaybackControlPanel
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
            this.btnLoad = new OPMedia.UI.Controls.OPMButton();
            this.btnNext = new OPMedia.UI.Controls.OPMButton();
            this.btnPrev = new OPMedia.UI.Controls.OPMButton();
            this.btnStop = new OPMedia.UI.Controls.OPMButton();
            this.btnPause = new OPMedia.UI.Controls.OPMButton();
            this.btnPlay = new OPMedia.UI.Controls.OPMButton();
            this.btnFullScreen = new OPMedia.UI.Controls.OPMButton();
            this.btnOpenDisk = new OPMedia.UI.Controls.OPMButton();
            this.btnOpenSettings = new OPMedia.UI.Controls.OPMButton();
            this.pnlButtons = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.btnLoopPlay = new OPMedia.UI.Controls.OPMButton();
            this.btnPlaylistEnd = new OPMedia.UI.Controls.OPMButton();
            this.btnToggleShuffle = new OPMedia.UI.Controls.OPMButton();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(131, 0);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnLoad.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnLoad.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnLoad.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnLoad.Size = new System.Drawing.Size(25, 25);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.TabStop = false;
            this.btnLoad.Tag = "btnLoad";
            this.btnLoad.UseMnemonic = false;
            this.btnLoad.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(103, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnNext.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnNext.Name = "btnNext";
            this.btnNext.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnNext.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnNext.Size = new System.Drawing.Size(25, 25);
            this.btnNext.TabIndex = 5;
            this.btnNext.TabStop = false;
            this.btnNext.Tag = "btnNext";
            this.btnNext.UseMnemonic = false;
            this.btnNext.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(78, 0);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnPrev.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnPrev.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPrev.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPrev.Size = new System.Drawing.Size(25, 25);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.TabStop = false;
            this.btnPrev.Tag = "btnPrev";
            this.btnPrev.UseMnemonic = false;
            this.btnPrev.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnPrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(50, 0);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnStop.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnStop.Name = "btnStop";
            this.btnStop.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnStop.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnStop.Size = new System.Drawing.Size(25, 25);
            this.btnStop.TabIndex = 3;
            this.btnStop.TabStop = false;
            this.btnStop.Tag = "btnStop";
            this.btnStop.UseMnemonic = false;
            this.btnStop.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(25, 0);
            this.btnPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPause.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnPause.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnPause.Name = "btnPause";
            this.btnPause.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPause.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPause.Size = new System.Drawing.Size(25, 25);
            this.btnPause.TabIndex = 2;
            this.btnPause.TabStop = false;
            this.btnPause.Tag = "btnPause";
            this.btnPause.UseMnemonic = false;
            this.btnPause.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(0, 0);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnPlay.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPlay.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPlay.Size = new System.Drawing.Size(25, 25);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.TabStop = false;
            this.btnPlay.Tag = "btnPlay";
            this.btnPlay.UseMnemonic = false;
            this.btnPlay.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullScreen.Location = new System.Drawing.Point(184, 0);
            this.btnFullScreen.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnFullScreen.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnFullScreen.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnFullScreen.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnFullScreen.Size = new System.Drawing.Size(25, 25);
            this.btnFullScreen.TabIndex = 7;
            this.btnFullScreen.TabStop = false;
            this.btnFullScreen.Tag = "btnFS";
            this.btnFullScreen.UseMnemonic = false;
            this.btnFullScreen.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnFullScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnOpenDisk
            // 
            this.btnOpenDisk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDisk.Location = new System.Drawing.Point(156, 0);
            this.btnOpenDisk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenDisk.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnOpenDisk.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnOpenDisk.Name = "btnOpenDisk";
            this.btnOpenDisk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOpenDisk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOpenDisk.Size = new System.Drawing.Size(25, 25);
            this.btnOpenDisk.TabIndex = 8;
            this.btnOpenDisk.TabStop = false;
            this.btnOpenDisk.Tag = "btnOpenDisk";
            this.btnOpenDisk.UseMnemonic = false;
            this.btnOpenDisk.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnOpenDisk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSettings.Location = new System.Drawing.Point(287, 0);
            this.btnOpenSettings.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnOpenSettings.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnOpenSettings.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOpenSettings.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOpenSettings.Size = new System.Drawing.Size(25, 25);
            this.btnOpenSettings.TabIndex = 9;
            this.btnOpenSettings.TabStop = false;
            this.btnOpenSettings.Tag = "btnOpenSettings";
            this.btnOpenSettings.UseMnemonic = false;
            this.btnOpenSettings.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnOpenSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.Controls.Add(this.btnPlay);
            this.pnlButtons.Controls.Add(this.btnPause);
            this.pnlButtons.Controls.Add(this.btnStop);
            this.pnlButtons.Controls.Add(this.btnPrev);
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Controls.Add(this.btnLoad);
            this.pnlButtons.Controls.Add(this.btnOpenDisk);
            this.pnlButtons.Controls.Add(this.btnFullScreen);
            this.pnlButtons.Controls.Add(this.btnLoopPlay);
            this.pnlButtons.Controls.Add(this.btnPlaylistEnd);
            this.pnlButtons.Controls.Add(this.btnToggleShuffle);
            this.pnlButtons.Controls.Add(this.btnOpenSettings);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlButtons.Size = new System.Drawing.Size(312, 25);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnLoopPlay
            // 
            this.btnLoopPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoopPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoopPlay.Location = new System.Drawing.Point(209, 0);
            this.btnLoopPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoopPlay.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnLoopPlay.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnLoopPlay.Name = "btnLoopPlay";
            this.btnLoopPlay.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnLoopPlay.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnLoopPlay.Size = new System.Drawing.Size(25, 25);
            this.btnLoopPlay.TabIndex = 13;
            this.btnLoopPlay.TabStop = false;
            this.btnLoopPlay.Tag = "btnLoopPlay";
            this.btnLoopPlay.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnLoopPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnPlaylistEnd
            // 
            this.btnPlaylistEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlaylistEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaylistEnd.Location = new System.Drawing.Point(234, 0);
            this.btnPlaylistEnd.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlaylistEnd.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnPlaylistEnd.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnPlaylistEnd.Name = "btnPlaylistEnd";
            this.btnPlaylistEnd.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPlaylistEnd.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPlaylistEnd.Size = new System.Drawing.Size(25, 25);
            this.btnPlaylistEnd.TabIndex = 14;
            this.btnPlaylistEnd.TabStop = false;
            this.btnPlaylistEnd.Tag = "btnPlaylistEnd";
            this.btnPlaylistEnd.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnPlaylistEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // btnToggleShuffle
            // 
            this.btnToggleShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToggleShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleShuffle.Location = new System.Drawing.Point(259, 0);
            this.btnToggleShuffle.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleShuffle.MaximumSize = new System.Drawing.Size(25, 25);
            this.btnToggleShuffle.MinimumSize = new System.Drawing.Size(25, 25);
            this.btnToggleShuffle.Name = "btnToggleShuffle";
            this.btnToggleShuffle.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnToggleShuffle.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnToggleShuffle.Size = new System.Drawing.Size(25, 25);
            this.btnToggleShuffle.TabIndex = 15;
            this.btnToggleShuffle.TabStop = false;
            this.btnToggleShuffle.Tag = "btnToggleShuffle";
            this.btnToggleShuffle.Click += new System.EventHandler(this.OnButtonPressed);
            this.btnToggleShuffle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // PlaybackControlPanel
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlButtons);
            this.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(170, 25);
            this.Name = "PlaybackControlPanel";
            this.Size = new System.Drawing.Size(312, 25);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMButton btnPlay;
        private OPMButton btnPause;
        private OPMButton btnStop;
        private OPMButton btnPrev;
        private OPMButton btnNext;
        private OPMButton btnLoad;
        private OPMButton btnFullScreen;
        private OPMButton btnOpenDisk;
        private OPMButton btnOpenSettings;
        private OPMFlowLayoutPanel pnlButtons;
        private OPMButton btnLoopPlay;
        private OPMButton btnPlaylistEnd;
        private OPMButton btnToggleShuffle;
    }
}
