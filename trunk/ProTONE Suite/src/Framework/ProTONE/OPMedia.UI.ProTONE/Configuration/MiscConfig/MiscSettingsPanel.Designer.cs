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
            this.components = new System.ComponentModel.Container();
            this.tabMisc = new OPMedia.UI.Controls.OPMTabControl();
            this.tpDisksOptions = new OPMedia.UI.Controls.OPMTabPage();
            this.pageDisksOptions = new OPMedia.UI.ProTONE.Configuration.MiscConfig.DisksOptionsPage();
            this.tpPlaylist = new OPMedia.UI.Controls.OPMTabPage();
            this.pagePlaylist = new OPMedia.UI.ProTONE.Configuration.MiscConfig.PlaylistOptionsPage();
            this.tpScheduler = new OPMedia.UI.Controls.OPMTabPage();
            this.pageScheduler = new OPMedia.UI.ProTONE.Configuration.MiscConfig.SchedulerSettingsPage();
            this.tpFavoriteFolders = new OPMedia.UI.Controls.OPMTabPage();
            this.pageFavoriteFolders = new OPMedia.UI.ProTONE.Configuration.MiscConfig.FavoriteFoldersPage();
            this.tabMisc.SuspendLayout();
            this.tpDisksOptions.SuspendLayout();
            this.tpPlaylist.SuspendLayout();
            this.tpScheduler.SuspendLayout();
            this.tpFavoriteFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMisc
            // 
            this.tabMisc.AccessibleName = "tabMisc";
            this.tabMisc.Controls.Add(this.tpDisksOptions);
            this.tabMisc.Controls.Add(this.tpPlaylist);
            this.tabMisc.Controls.Add(this.tpScheduler);
            this.tabMisc.Controls.Add(this.tpFavoriteFolders);
            this.tabMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMisc.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMisc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabMisc.Location = new System.Drawing.Point(0, 0);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.SelectedIndex = 3;
            this.tabMisc.Size = new System.Drawing.Size(655, 393);
            this.tabMisc.TabIndex = 0;
            // 
            // tpDisksOptions
            // 
            this.tpDisksOptions.AccessibleName = "TXT_DISKS_OPTIONS";
            this.tpDisksOptions.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpDisksOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpDisksOptions.Controls.Add(this.pageDisksOptions);
            this.tpDisksOptions.Location = new System.Drawing.Point(4, 23);
            this.tpDisksOptions.Name = "tpDisksOptions";
            this.tpDisksOptions.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpDisksOptions.Size = new System.Drawing.Size(647, 366);
            this.tpDisksOptions.TabIndex = 3;
            this.tpDisksOptions.Text = "TXT_DISKS_OPTIONS";
            // 
            // pageDisksOptions
            // 
            this.pageDisksOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDisksOptions.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageDisksOptions.Location = new System.Drawing.Point(5, 10);
            this.pageDisksOptions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageDisksOptions.Modified = false;
            this.pageDisksOptions.Name = "pageDisksOptions";
            this.pageDisksOptions.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageDisksOptions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pageDisksOptions.Size = new System.Drawing.Size(637, 351);
            this.pageDisksOptions.TabIndex = 0;
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
            // tpScheduler
            // 
            this.tpScheduler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpScheduler.Controls.Add(this.pageScheduler);
            this.tpScheduler.Location = new System.Drawing.Point(4, 23);
            this.tpScheduler.Name = "tpScheduler";
            this.tpScheduler.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpScheduler.Size = new System.Drawing.Size(647, 366);
            this.tpScheduler.TabIndex = 5;
            this.tpScheduler.Text = "TXT_S_SCHEDULERSETTINGS";
            // 
            // pageScheduler
            // 
            this.pageScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageScheduler.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageScheduler.Location = new System.Drawing.Point(5, 10);
            this.pageScheduler.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageScheduler.Modified = true;
            this.pageScheduler.Name = "pageScheduler";
            this.pageScheduler.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageScheduler.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pageScheduler.Size = new System.Drawing.Size(637, 351);
            this.pageScheduler.TabIndex = 0;
            // 
            // tpFavoriteFolders
            // 
            this.tpFavoriteFolders.AccessibleName = "TXT_FAVORITES";
            this.tpFavoriteFolders.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpFavoriteFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpFavoriteFolders.Controls.Add(this.pageFavoriteFolders);
            this.tpFavoriteFolders.Location = new System.Drawing.Point(4, 23);
            this.tpFavoriteFolders.Name = "tpFavoriteFolders";
            this.tpFavoriteFolders.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpFavoriteFolders.Size = new System.Drawing.Size(647, 366);
            this.tpFavoriteFolders.TabIndex = 3;
            this.tpFavoriteFolders.Text = "TXT_FAVORITES";
            // 
            // pageFavoriteFolders
            // 
            this.pageFavoriteFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageFavoriteFolders.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageFavoriteFolders.Location = new System.Drawing.Point(5, 10);
            this.pageFavoriteFolders.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageFavoriteFolders.Modified = false;
            this.pageFavoriteFolders.Name = "pageFavoriteFolders";
            this.pageFavoriteFolders.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageFavoriteFolders.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pageFavoriteFolders.Size = new System.Drawing.Size(637, 351);
            this.pageFavoriteFolders.TabIndex = 0;
            // 
            // MiscellaneousSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMisc);
            this.Name = "MiscellaneousSettingsPanel";
            this.Size = new System.Drawing.Size(655, 393);
            this.tabMisc.ResumeLayout(false);
            this.tpDisksOptions.ResumeLayout(false);
            this.tpPlaylist.ResumeLayout(false);
            this.tpScheduler.ResumeLayout(false);
            this.tpFavoriteFolders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTabControl tabMisc;
        private UI.Controls.OPMTabPage tpPlaylist;
        private UI.Controls.OPMTabPage tpFavoriteFolders;
        private UI.Controls.OPMTabPage tpDisksOptions;
        private UI.Controls.OPMTabPage tpScheduler;
        private MiscConfig.PlaylistOptionsPage pagePlaylist;
        private MiscConfig.FavoriteFoldersPage pageFavoriteFolders;
        private MiscConfig.DisksOptionsPage pageDisksOptions;
        private MiscConfig.SchedulerSettingsPage pageScheduler;
    }
}
