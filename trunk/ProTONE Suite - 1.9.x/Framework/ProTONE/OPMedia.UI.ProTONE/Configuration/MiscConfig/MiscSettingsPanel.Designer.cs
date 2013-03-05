using OPMedia.UI.Controls;
namespace OPMedia.UI.ProTONE.Configuration
{
    partial class MiscellaneousSettingsPanel
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
            this.tabMisc = new OPMedia.UI.Controls.OPMTabControl();
            this.tpPlaylist = new OPMedia.UI.Controls.OPMTabPage();
            this.pagePlaylist = new OPMedia.UI.ProTONE.Configuration.MiscConfig.PlaylistOptionsPage();
            this.tpRemote = new OPMedia.UI.Controls.OPMTabPage();
            this.pageRemote = new OPMedia.UI.ProTONE.Configuration.MiscConfig.RemoteControlPage();
            this.tpDiagnostics = new OPMedia.UI.Controls.OPMTabPage();
            this.pageDiagnostics = new OPMedia.UI.ProTONE.Configuration.MiscConfig.DiagnosticsPage();
            this.tabMisc.SuspendLayout();
            this.tpPlaylist.SuspendLayout();
            this.tpRemote.SuspendLayout();
            this.tpDiagnostics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMisc
            // 
            this.tabMisc.AccessibleName = "tabMisc";
            this.tabMisc.Controls.Add(this.tpPlaylist);
            this.tabMisc.Controls.Add(this.tpRemote);
            this.tabMisc.Controls.Add(this.tpDiagnostics);
            this.tabMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMisc.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMisc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabMisc.Location = new System.Drawing.Point(0, 0);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.SelectedIndex = 3;
            this.tabMisc.Size = new System.Drawing.Size(655, 393);
            this.tabMisc.TabIndex = 0;
            // 
            // tpPlaylist
            // 
            this.tpPlaylist.AccessibleName = "TXT_PLAYLISTOPTIONS";
            this.tpPlaylist.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpPlaylist.Controls.Add(this.pagePlaylist);
            this.tpPlaylist.Location = new System.Drawing.Point(4, 23);
            this.tpPlaylist.Name = "tpPlaylist";
            this.tpPlaylist.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpPlaylist.Size = new System.Drawing.Size(647, 366);
            this.tpPlaylist.TabIndex = 4;
            this.tpPlaylist.Text = "TXT_PLAYLISTOPTIONS";
            // 
            // pagePlaylist
            // 
            this.pagePlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePlaylist.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pagePlaylist.Location = new System.Drawing.Point(5, 10);
            this.pagePlaylist.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pagePlaylist.Modified = false;
            this.pagePlaylist.Name = "pagePlaylist";
            this.pagePlaylist.OverrideBackColor = System.Drawing.Color.Empty;
            this.pagePlaylist.Size = new System.Drawing.Size(637, 351);
            this.pagePlaylist.TabIndex = 0;
            // 
            // tpRemote
            // 
            this.tpRemote.AccessibleName = "TXT_REMOTECONTROLCFG";
            this.tpRemote.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpRemote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpRemote.Controls.Add(this.pageRemote);
            this.tpRemote.Location = new System.Drawing.Point(4, 23);
            this.tpRemote.Name = "tpRemote";
            this.tpRemote.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpRemote.Size = new System.Drawing.Size(647, 366);
            this.tpRemote.TabIndex = 1;
            this.tpRemote.Text = "TXT_REMOTECONTROLCFG";
            // 
            // pageRemote
            // 
            this.pageRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageRemote.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageRemote.Location = new System.Drawing.Point(5, 10);
            this.pageRemote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageRemote.Modified = false;
            this.pageRemote.Name = "pageRemote";
            this.pageRemote.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageRemote.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pageRemote.Size = new System.Drawing.Size(637, 351);
            this.pageRemote.TabIndex = 0;
            // 
            // tpDiagnostics
            // 
            this.tpDiagnostics.AccessibleName = "TXT_SYSTEMDIAGNOSTICS";
            this.tpDiagnostics.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpDiagnostics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpDiagnostics.Controls.Add(this.pageDiagnostics);
            this.tpDiagnostics.Location = new System.Drawing.Point(4, 23);
            this.tpDiagnostics.Name = "tpDiagnostics";
            this.tpDiagnostics.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpDiagnostics.Size = new System.Drawing.Size(647, 366);
            this.tpDiagnostics.TabIndex = 3;
            this.tpDiagnostics.Text = "TXT_ASSISTANCE";
            // 
            // pageDiagnostics
            // 
            this.pageDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDiagnostics.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageDiagnostics.Location = new System.Drawing.Point(5, 10);
            this.pageDiagnostics.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageDiagnostics.Modified = false;
            this.pageDiagnostics.Name = "pageDiagnostics";
            this.pageDiagnostics.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageDiagnostics.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pageDiagnostics.Size = new System.Drawing.Size(637, 351);
            this.pageDiagnostics.TabIndex = 0;
            // 
            // MiscellaneousSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMisc);
            this.Name = "MiscellaneousSettingsPanel";
            this.Size = new System.Drawing.Size(655, 393);
            this.tabMisc.ResumeLayout(false);
            this.tpPlaylist.ResumeLayout(false);
            this.tpRemote.ResumeLayout(false);
            this.tpDiagnostics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTabControl tabMisc;
        private UI.Controls.OPMTabPage tpRemote;
        private UI.Controls.OPMTabPage tpDiagnostics;
        private UI.Controls.OPMTabPage tpPlaylist;
        private MiscConfig.RemoteControlPage pageRemote;
        private MiscConfig.DiagnosticsPage pageDiagnostics;
        private MiscConfig.PlaylistOptionsPage pagePlaylist;
    }
}
