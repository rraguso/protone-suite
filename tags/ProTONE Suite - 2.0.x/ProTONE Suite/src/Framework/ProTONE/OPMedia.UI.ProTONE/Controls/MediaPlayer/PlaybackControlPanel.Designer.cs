using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using OPMedia.Runtime.Shortcuts;

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
            this.pnlButtons = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.opmToolStrip1 = new OPMedia.UI.Controls.OPMToolStrip();
            this.tsmPlay = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmPause = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmStop = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmPrev = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmNext = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmLoad = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmOpenDisk = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator3 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmFullScreen = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmLoopPlay = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmPlaylistEnd = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsmToggleShuffle = new OPMedia.UI.Controls.OPMToolStripButton();
            this.opmToolStripSeparator4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmOpenSettings = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tslFileType = new System.Windows.Forms.ToolStripLabel();
            this.tslFilterState = new System.Windows.Forms.ToolStripLabel();
            this.tslAudioOn = new System.Windows.Forms.ToolStripLabel();
            this.tslVideoOn = new System.Windows.Forms.ToolStripLabel();
            this.opmToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlButtons.Size = new System.Drawing.Size(0, 0);
            this.pnlButtons.TabIndex = 10;
            // 
            // opmToolStrip1
            // 
            this.opmToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.opmToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmToolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.opmToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.opmToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlay,
            this.tsmPause,
            this.tsmStop,
            this.opmToolStripSeparator1,
            this.tsmPrev,
            this.tsmNext,
            this.opmToolStripSeparator2,
            this.tsmLoad,
            this.tsmOpenDisk,
            this.opmToolStripSeparator3,
            this.tsmFullScreen,
            this.tsmLoopPlay,
            this.tsmPlaylistEnd,
            this.tsmToggleShuffle,
            this.opmToolStripSeparator4,
            this.tsmOpenSettings,
            this.tslFileType,
            this.tslFilterState,
            this.tslAudioOn,
            this.tslVideoOn});
            this.opmToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.opmToolStrip1.Name = "opmToolStrip1";
            this.opmToolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.opmToolStrip1.ShowBorder = false;
            this.opmToolStrip1.Size = new System.Drawing.Size(370, 25);
            this.opmToolStrip1.TabIndex = 11;
            this.opmToolStrip1.Text = "opmToolStrip1";
            this.opmToolStrip1.VerticalGradient = true;
            // 
            // tsmPlay
            // 
            this.tsmPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPlay.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPlay;
            this.tsmPlay.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPlay.Name = "tsmPlay";
            this.tsmPlay.Size = new System.Drawing.Size(23, 22);
            this.tsmPlay.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPlay;
            this.tsmPlay.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPlay.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPlay.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmPause
            // 
            this.tsmPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPause.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPause;
            this.tsmPause.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPause.Name = "tsmPause";
            this.tsmPause.Size = new System.Drawing.Size(23, 22);
            this.tsmPause.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPause;
            this.tsmPause.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPause.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPause.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmStop
            // 
            this.tsmStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmStop.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnStop;
            this.tsmStop.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.Size = new System.Drawing.Size(23, 22);
            this.tsmStop.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdStop;
            this.tsmStop.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmStop.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmStop.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator1
            // 
            this.opmToolStripSeparator1.Name = "opmToolStripSeparator1";
            this.opmToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmPrev
            // 
            this.tsmPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPrev.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPrev;
            this.tsmPrev.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPrev.Name = "tsmPrev";
            this.tsmPrev.Size = new System.Drawing.Size(23, 22);
            this.tsmPrev.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPrev;
            this.tsmPrev.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPrev.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPrev.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmNext
            // 
            this.tsmNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmNext.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnNext;
            this.tsmNext.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmNext.Name = "tsmNext";
            this.tsmNext.Size = new System.Drawing.Size(23, 22);
            this.tsmNext.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdNext;
            this.tsmNext.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmNext.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmNext.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator2
            // 
            this.opmToolStripSeparator2.Name = "opmToolStripSeparator2";
            this.opmToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.opmToolStripSeparator2.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tsmLoad
            // 
            this.tsmLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmLoad.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnLoad;
            this.tsmLoad.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmLoad.Name = "tsmLoad";
            this.tsmLoad.Size = new System.Drawing.Size(23, 22);
            this.tsmLoad.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdLoad;
            this.tsmLoad.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmLoad.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmLoad.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmOpenDisk
            // 
            this.tsmOpenDisk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmOpenDisk.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnOpenDisk;
            this.tsmOpenDisk.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmOpenDisk.Name = "tsmOpenDisk";
            this.tsmOpenDisk.Size = new System.Drawing.Size(23, 22);
            this.tsmOpenDisk.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdOpenDisk;
            this.tsmOpenDisk.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmOpenDisk.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmOpenDisk.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmOpenDisk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator3
            // 
            this.opmToolStripSeparator3.Name = "opmToolStripSeparator3";
            this.opmToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmFullScreen
            // 
            this.tsmFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmFullScreen.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnFullScreen;
            this.tsmFullScreen.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmFullScreen.Name = "tsmFullScreen";
            this.tsmFullScreen.Size = new System.Drawing.Size(23, 22);
            this.tsmFullScreen.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdFullScreen;
            this.tsmFullScreen.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmFullScreen.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmFullScreen.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmFullScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmLoopPlay
            // 
            this.tsmLoopPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmLoopPlay.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnLoopPlay;
            this.tsmLoopPlay.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmLoopPlay.Name = "tsmLoopPlay";
            this.tsmLoopPlay.Size = new System.Drawing.Size(23, 22);
            this.tsmLoopPlay.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdLoopPlay;
            this.tsmLoopPlay.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmLoopPlay.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmLoopPlay.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmLoopPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmPlaylistEnd
            // 
            this.tsmPlaylistEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPlaylistEnd.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPlaylistEnd;
            this.tsmPlaylistEnd.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPlaylistEnd.Name = "tsmPlaylistEnd";
            this.tsmPlaylistEnd.Size = new System.Drawing.Size(23, 22);
            this.tsmPlaylistEnd.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPlaylistEnd;
            this.tsmPlaylistEnd.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPlaylistEnd.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPlaylistEnd.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPlaylistEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmToggleShuffle
            // 
            this.tsmToggleShuffle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmToggleShuffle.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnToggleShuffle;
            this.tsmToggleShuffle.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmToggleShuffle.Name = "tsmToggleShuffle";
            this.tsmToggleShuffle.Size = new System.Drawing.Size(23, 22);
            this.tsmToggleShuffle.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdToggleShuffle;
            this.tsmToggleShuffle.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmToggleShuffle.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmToggleShuffle.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmToggleShuffle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator4
            // 
            this.opmToolStripSeparator4.Name = "opmToolStripSeparator4";
            this.opmToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmOpenSettings
            // 
            this.tsmOpenSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmOpenSettings.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnOpenSettings;
            this.tsmOpenSettings.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmOpenSettings.Name = "tsmOpenSettings";
            this.tsmOpenSettings.Size = new System.Drawing.Size(23, 22);
            this.tsmOpenSettings.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdOpenSettings;
            this.tsmOpenSettings.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmOpenSettings.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmOpenSettings.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmOpenSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tslFileType
            // 
            this.tslFileType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFileType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslFileType.Margin = new System.Windows.Forms.Padding(0, 1, 7, 2);
            this.tslFileType.Name = "tslFileType";
            this.tslFileType.Size = new System.Drawing.Size(0, 22);
            this.tslFileType.Text = "tslFileType";
            this.tslFileType.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslFileType.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslFilterState
            // 
            this.tslFilterState.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFilterState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslFilterState.Margin = new System.Windows.Forms.Padding(0, 1, 7, 2);
            this.tslFilterState.Name = "tslFilterState";
            this.tslFilterState.Size = new System.Drawing.Size(0, 22);
            this.tslFilterState.Text = "tslFilterState";
            this.tslFilterState.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslFilterState.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslAudioOn
            // 
            this.tslAudioOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAudioOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslAudioOn.Margin = new System.Windows.Forms.Padding(0, 1, 7, 2);
            this.tslAudioOn.Name = "tslAudioOn";
            this.tslAudioOn.Size = new System.Drawing.Size(0, 22);
            this.tslAudioOn.Text = "tslAudioOn";
            this.tslAudioOn.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslAudioOn.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslVideoOn
            // 
            this.tslVideoOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslVideoOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslVideoOn.Margin = new System.Windows.Forms.Padding(0, 1, 7, 2);
            this.tslVideoOn.Name = "tslVideoOn";
            this.tslVideoOn.Size = new System.Drawing.Size(0, 22);
            this.tslVideoOn.Text = "tslVideoOn";
            this.tslVideoOn.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslVideoOn.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // PlaybackControlPanel
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmToolStrip1);
            this.Controls.Add(this.pnlButtons);
            this.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(170, 25);
            this.Name = "PlaybackControlPanel";
            this.Size = new System.Drawing.Size(370, 25);
            this.opmToolStrip1.ResumeLayout(false);
            this.opmToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMFlowLayoutPanel pnlButtons;
        private OPMToolStrip opmToolStrip1;
        private OPMToolStripButton tsmPlay;
        private OPMToolStripButton tsmPause;
        private OPMToolStripButton tsmStop;
        private OPMToolStripSeparator opmToolStripSeparator1;
        private OPMToolStripButton tsmPrev;
        private OPMToolStripButton tsmNext;
        private OPMToolStripSeparator opmToolStripSeparator2;
        private OPMToolStripButton tsmLoad;
        private OPMToolStripButton tsmOpenDisk;
        private OPMToolStripSeparator opmToolStripSeparator3;
        private OPMToolStripButton tsmFullScreen;
        private OPMToolStripButton tsmLoopPlay;
        private OPMToolStripButton tsmPlaylistEnd;
        private OPMToolStripButton tsmToggleShuffle;
        private OPMToolStripSeparator opmToolStripSeparator4;
        private OPMToolStripButton tsmOpenSettings;
        private ToolStripLabel tslFileType;
        private ToolStripLabel tslFilterState;
        private ToolStripLabel tslAudioOn;
        private ToolStripLabel tslVideoOn;
    }
}
