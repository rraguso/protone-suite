using OPMedia.Runtime.ProTONE.RemoteControl;
using System;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.UI.Controls;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
namespace OPMedia.ProTONE
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new OPMedia.UI.Controls.OPMContextMenuStrip();
            this.toolStripSeparator7 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.mnuPlaylistPlaceholder = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.timeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.ToolStripTimeScale();
            this.volumeScale = new OPMedia.UI.ProTONE.Controls.MediaPlayer.ToolStripVolumeScale();
            this.mnuMediaState = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new OPMedia.UI.Controls.OPMMenuStripSeparator();
            this.mnuTools = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.mnuAbout = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.mnuExit = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.mediaPlayer = new OPMedia.UI.ProTONE.Controls.MediaPlayer.MediaPlayer();
            this.pnlContent.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.mediaPlayer);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
            // 
            // cmsMain
            // 
            this.cmsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cmsMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmsMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.mnuPlaylistPlaceholder,
            this.timeScale,
            this.volumeScale,
            this.mnuMediaState,
            this.toolStripSeparator5,
            this.mnuTools,
            this.mnuAbout,
            this.mnuExit});
            this.cmsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(261, 172);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMain_Opening);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(257, 6);
            // 
            // mnuPlaylistPlaceholder
            // 
            this.mnuPlaylistPlaceholder.MergeIndex = 2;
            this.mnuPlaylistPlaceholder.Name = "mnuPlaylistPlaceholder";
            this.mnuPlaylistPlaceholder.Size = new System.Drawing.Size(260, 22);
            this.mnuPlaylistPlaceholder.Text = "TXT_PLAYLIST";
            // 
            // timeScale
            // 
            this.timeScale.AutoSize = false;
            this.timeScale.BackColor = System.Drawing.SystemColors.Window;
            this.timeScale.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.timeScale.Name = "timeScale";
            this.timeScale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timeScale.Size = new System.Drawing.Size(200, 23);
            this.timeScale.Text = "TIME";
            this.timeScale.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.TimeScalePositionChanged);
            // 
            // volumeScale
            // 
            this.volumeScale.AutoSize = false;
            this.volumeScale.BackColor = System.Drawing.SystemColors.Window;
            this.volumeScale.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.volumeScale.Name = "volumeScale";
            this.volumeScale.Size = new System.Drawing.Size(200, 23);
            this.volumeScale.Text = "VOL";
            this.volumeScale.ToolTipText = "VOL";
            this.volumeScale.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.VolumeScalePositionChanged);
            // 
            // mnuMediaState
            // 
            this.mnuMediaState.Name = "mnuMediaState";
            this.mnuMediaState.Size = new System.Drawing.Size(88, 13);
            this.mnuMediaState.Text = "mnuMediaState";
            this.mnuMediaState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuMediaState.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(257, 6);
            // 
            // mnuTools
            // 
            this.mnuTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(260, 22);
            this.mnuTools.Text = "TXT_MNUTOOLS";
            // 
            // mnuAbout
            // 
            this.mnuAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(260, 22);
            this.mnuAbout.Text = "mnuAbout";
            this.mnuAbout.Click += new System.EventHandler(this.OnAbout);
            // 
            // mnuExit
            // 
            this.mnuExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(260, 22);
            this.mnuExit.Text = "TXT_BTNCLOSE";
            this.mnuExit.Click += new System.EventHandler(this.OnExit);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.CompactView = false;
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPlayer.MinimumSize = new System.Drawing.Size(160, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OverrideBackColor = System.Drawing.Color.Empty;
            this.mediaPlayer.Size = new System.Drawing.Size(415, 242);
            this.mediaPlayer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 270);
            this.MinimumSize = new System.Drawing.Size(420, 270);
            this.Name = "MainForm";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlContent.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private OPMContextMenuStrip cmsMain;
        private OPMToolStripMenuItem mnuTools;
        private ToolStripVolumeScale volumeScale;
        private ToolStripTimeScale timeScale;

        private OPMToolStripMenuItem mnuAbout;
        private OPMToolStripMenuItem mnuExit;
        private OPMMenuStripSeparator toolStripSeparator5;
        private MediaPlayer mediaPlayer;
        private OPMMenuStripSeparator toolStripSeparator7;
        private ToolStripLabel mnuMediaState;
        private OPMToolStripMenuItem mnuPlaylistPlaceholder;
    }

 
}

