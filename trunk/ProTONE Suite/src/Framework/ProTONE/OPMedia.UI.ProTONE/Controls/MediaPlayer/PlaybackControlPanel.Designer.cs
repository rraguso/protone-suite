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
            this.tsmPlayPause = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmStop = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.opmToolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmPrev = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmNext = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.opmToolStripSeparator2 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmLoad = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmOpenDisk = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmOpenURL = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.opmToolStripSeparator3 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmOpenSettings = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.opmToolStripSeparator4 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.opmToolStripSeparator5 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tslTime = new System.Windows.Forms.ToolStripLabel();
            this.tslFileType = new System.Windows.Forms.ToolStripLabel();
            this.tslFilterState = new System.Windows.Forms.ToolStripLabel();
            this.tslAudioOn = new System.Windows.Forms.ToolStripLabel();
            this.tslVideoOn = new System.Windows.Forms.ToolStripLabel();
            this.tsmPlaylistEnd = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmLoopPlay = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
            this.tsmToggleShuffle = new OPMedia.UI.Controls.OPMTriStateToolStripButton();
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
            this.opmToolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.opmToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.opmToolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.opmToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            
            this.tsmPlayPause,
            this.tsmStop,
            this.opmToolStripSeparator1,
            
            this.tsmPrev,
            this.tsmNext,
            this.opmToolStripSeparator2,
            
            this.tsmLoad,
            this.tsmOpenDisk,
            this.tsmOpenURL,
            this.opmToolStripSeparator3,
            
            this.tsmPlaylistEnd,
            this.tsmLoopPlay,
            this.tsmToggleShuffle,
            this.opmToolStripSeparator5,

            this.tsmOpenSettings,
            this.opmToolStripSeparator4,
            this.tslTime,
            this.tslFileType,
            this.tslFilterState,
            this.tslAudioOn,
            this.tslVideoOn});

            this.opmToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.opmToolStrip1.Name = "opmToolStrip1";
            this.opmToolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.opmToolStrip1.ShowBorder = false;
            this.opmToolStrip1.Size = new System.Drawing.Size(469, 39);
            this.opmToolStrip1.TabIndex = 11;
            this.opmToolStrip1.Text = "opmToolStrip1";
            this.opmToolStrip1.VerticalGradient = true;
            // 
            // tsmPlayPause
            // 
            this.tsmPlayPause.ActiveImage = null;
            this.tsmPlayPause.CheckedImage = null;
            this.tsmPlayPause.DisabledImage = null;
            this.tsmPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPlayPause.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPlay;
            this.tsmPlayPause.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsmPlayPause.InactiveImage = null;
            this.tsmPlayPause.Name = "tsmPlayPause";
            this.tsmPlayPause.Size = new System.Drawing.Size(36, 36);
            this.tsmPlayPause.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPlayPause;
            this.tsmPlayPause.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPlayPause.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPlayPause.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPlayPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmStop
            // 
            this.tsmStop.ActiveImage = null;
            this.tsmStop.CheckedImage = null;
            this.tsmStop.DisabledImage = null;
            this.tsmStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmStop.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPlay;
            this.tsmStop.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmStop.InactiveImage = null;
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.Size = new System.Drawing.Size(36, 36);
            this.tsmStop.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdStop;
            this.tsmStop.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmStop.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmStop.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator1
            // 
            this.opmToolStripSeparator1.Name = "opmToolStripSeparator1";
            this.opmToolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsmPrev
            // 
            this.tsmPrev.ActiveImage = null;
            this.tsmPrev.CheckedImage = null;
            this.tsmPrev.DisabledImage = null;
            this.tsmPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPrev.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnPrev;
            this.tsmPrev.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPrev.InactiveImage = null;
            this.tsmPrev.Name = "tsmPrev";
            this.tsmPrev.Size = new System.Drawing.Size(36, 36);
            this.tsmPrev.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPrev;
            this.tsmPrev.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPrev.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPrev.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmNext
            // 
            this.tsmNext.ActiveImage = null;
            this.tsmNext.CheckedImage = null;
            this.tsmNext.DisabledImage = null;
            this.tsmNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmNext.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnNext;
            this.tsmNext.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmNext.InactiveImage = null;
            this.tsmNext.Name = "tsmNext";
            this.tsmNext.Size = new System.Drawing.Size(36, 36);
            this.tsmNext.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdNext;
            this.tsmNext.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmNext.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmNext.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator2
            // 
            this.opmToolStripSeparator2.Name = "opmToolStripSeparator2";
            this.opmToolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            this.opmToolStripSeparator2.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tsmLoad
            // 
            this.tsmLoad.ActiveImage = null;
            this.tsmLoad.CheckedImage = null;
            this.tsmLoad.DisabledImage = null;
            this.tsmLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmLoad.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnLoad;
            this.tsmLoad.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmLoad.InactiveImage = null;
            this.tsmLoad.Name = "tsmLoad";
            this.tsmLoad.Size = new System.Drawing.Size(36, 36);
            this.tsmLoad.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdLoad;
            this.tsmLoad.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmLoad.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmLoad.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmOpenDisk
            // 
            this.tsmOpenDisk.ActiveImage = null;
            this.tsmOpenDisk.CheckedImage = null;
            this.tsmOpenDisk.DisabledImage = null;
            this.tsmOpenDisk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmOpenDisk.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnOpenDisk;
            this.tsmOpenDisk.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmOpenDisk.InactiveImage = null;
            this.tsmOpenDisk.Name = "tsmOpenDisk";
            this.tsmOpenDisk.Size = new System.Drawing.Size(36, 36);
            this.tsmOpenDisk.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdOpenDisk;
            this.tsmOpenDisk.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmOpenDisk.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmOpenDisk.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmOpenDisk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmOpenURL
            // 
            this.tsmOpenURL.ActiveImage = null;
            this.tsmOpenURL.CheckedImage = null;
            this.tsmOpenURL.DisabledImage = null;
            this.tsmOpenURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmOpenURL.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnOpenURL;
            this.tsmOpenURL.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmOpenURL.InactiveImage = null;
            this.tsmOpenURL.Name = "tsmOpenURL";
            this.tsmOpenURL.Size = new System.Drawing.Size(36, 36);
            this.tsmOpenURL.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdOpenURL;
            this.tsmOpenURL.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmOpenURL.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmOpenURL.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmOpenURL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator3
            // 
            this.opmToolStripSeparator3.Name = "opmToolStripSeparator3";
            this.opmToolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsmOpenSettings
            // 
            this.tsmOpenSettings.ActiveImage = null;
            this.tsmOpenSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmOpenSettings.CheckedImage = null;
            this.tsmOpenSettings.DisabledImage = null;
            this.tsmOpenSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmOpenSettings.Image = global::OPMedia.UI.ProTONE.Properties.Resources.btnOpenSettings;
            this.tsmOpenSettings.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmOpenSettings.InactiveImage = null;
            this.tsmOpenSettings.Name = "tsmOpenSettings";
            this.tsmOpenSettings.Size = new System.Drawing.Size(36, 36);
            this.tsmOpenSettings.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdOpenSettings;
            this.tsmOpenSettings.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmOpenSettings.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmOpenSettings.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmOpenSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // opmToolStripSeparator4
            // 
            this.opmToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.opmToolStripSeparator4.Name = "opmToolStripSeparator4";
            this.opmToolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tslTime
            // 
            this.tslTime.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tslTime.Name = "tslTime";
            this.tslTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tslTime.Size = new System.Drawing.Size(0, 36);
            // 
            // tslFileType
            // 
            this.tslFileType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFileType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslFileType.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tslFileType.Name = "tslFileType";
            this.tslFileType.Size = new System.Drawing.Size(0, 36);
            this.tslFileType.Text = "tslFileType";
            this.tslFileType.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslFileType.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslFilterState
            // 
            this.tslFilterState.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFilterState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslFilterState.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tslFilterState.Name = "tslFilterState";
            this.tslFilterState.Size = new System.Drawing.Size(0, 36);
            this.tslFilterState.Text = "tslFilterState";
            this.tslFilterState.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslFilterState.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslAudioOn
            // 
            this.tslAudioOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAudioOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslAudioOn.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tslAudioOn.Name = "tslAudioOn";
            this.tslAudioOn.Size = new System.Drawing.Size(0, 36);
            this.tslAudioOn.Text = "tslAudioOn";
            this.tslAudioOn.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslAudioOn.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tslVideoOn
            // 
            this.tslVideoOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslVideoOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslVideoOn.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tslVideoOn.Name = "tslVideoOn";
            this.tslVideoOn.Size = new System.Drawing.Size(0, 36);
            this.tslVideoOn.Text = "tslVideoOn";
            this.tslVideoOn.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tslVideoOn.MouseHover += new System.EventHandler(this.OnLabelMouseHover);
            // 
            // tsmPlaylistEnd
            // 
            this.tsmPlaylistEnd.ActiveImage = null;
            this.tsmPlaylistEnd.CheckedImage = null;
            this.tsmPlaylistEnd.DisabledImage = null;
            this.tsmPlaylistEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmPlaylistEnd.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmPlaylistEnd.InactiveImage = null;
            this.tsmPlaylistEnd.Name = "tsmPlaylistEnd";
            this.tsmPlaylistEnd.Size = new System.Drawing.Size(36, 36);
            this.tsmPlaylistEnd.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdPlaylistEnd;
            this.tsmPlaylistEnd.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmPlaylistEnd.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmPlaylistEnd.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmPlaylistEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmLoopPlay
            // 
            this.tsmLoopPlay.ActiveImage = null;
            this.tsmLoopPlay.CheckedImage = null;
            this.tsmLoopPlay.DisabledImage = null;
            this.tsmLoopPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmLoopPlay.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmLoopPlay.InactiveImage = null;
            this.tsmLoopPlay.Name = "tsmLoopPlay";
            this.tsmLoopPlay.Size = new System.Drawing.Size(36, 36);
            this.tsmLoopPlay.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdLoopPlay;
            this.tsmLoopPlay.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmLoopPlay.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmLoopPlay.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmLoopPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tsmToggleShuffle
            // 
            this.tsmToggleShuffle.ActiveImage = null;
            this.tsmToggleShuffle.CheckedImage = null;
            this.tsmToggleShuffle.DisabledImage = null;
            this.tsmToggleShuffle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmToggleShuffle.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmToggleShuffle.InactiveImage = null;
            this.tsmToggleShuffle.Name = "tsmToggleShuffle";
            this.tsmToggleShuffle.Size = new System.Drawing.Size(36, 36);
            this.tsmToggleShuffle.Tag = OPMedia.Runtime.Shortcuts.OPMShortcut.CmdToggleShuffle;
            this.tsmToggleShuffle.Click += new System.EventHandler(this.OnButtonPressed);
            this.tsmToggleShuffle.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tsmToggleShuffle.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.tsmToggleShuffle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // PlaybackControlPanel
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmToolStrip1);
            this.Controls.Add(this.pnlButtons);
            this.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(170, 35);
            this.Name = "PlaybackControlPanel";
            this.Size = new System.Drawing.Size(469, 39);
            this.opmToolStrip1.ResumeLayout(false);
            this.opmToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMFlowLayoutPanel pnlButtons;
        private OPMToolStrip opmToolStrip1;
        private OPMTriStateToolStripButton tsmPlayPause;
        private OPMTriStateToolStripButton tsmStop;
        private OPMToolStripSeparator opmToolStripSeparator1;
        private OPMTriStateToolStripButton tsmPrev;
        private OPMTriStateToolStripButton tsmNext;
        private OPMToolStripSeparator opmToolStripSeparator2;
        private OPMTriStateToolStripButton tsmLoad;
        private OPMTriStateToolStripButton tsmOpenURL;
        private OPMToolStripSeparator opmToolStripSeparator3;
        private OPMTriStateToolStripButton tsmLoopPlay;
        private OPMTriStateToolStripButton tsmPlaylistEnd;
        private OPMTriStateToolStripButton tsmToggleShuffle;
        private OPMToolStripSeparator opmToolStripSeparator4;
        private OPMToolStripSeparator opmToolStripSeparator5;
        private OPMTriStateToolStripButton tsmOpenSettings;
        private ToolStripLabel tslFileType;
        private ToolStripLabel tslFilterState;
        private ToolStripLabel tslAudioOn;
        private ToolStripLabel tslVideoOn;
        private OPMTriStateToolStripButton tsmOpenDisk;
        private ToolStripLabel tslTime;
    }
}
