using OPMedia.UI.Controls;
using System;
using System.Windows.Forms;

namespace OPMedia.UI.ProTONE.Configuration
{
    partial class SubtitleSettingsPanel
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
            this.tabSubtitlesOsd = new OPMedia.UI.Controls.OPMTabControl();
            this.tpSubtitles = new OPMedia.UI.Controls.OPMTabPage();
            this.pageSubtitles = new OPMedia.UI.ProTONE.Configuration.SubtitleSubtitlePage();
            this.tpOsd = new OPMedia.UI.Controls.OPMTabPage();
            this.pageOsd = new OPMedia.UI.ProTONE.Configuration.SubtitleOsdPage();
            this.tabSubtitlesOsd.SuspendLayout();
            this.tpSubtitles.SuspendLayout();
            this.tpOsd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSubtitlesOsd
            // 
            this.tabSubtitlesOsd.AccessibleName = "tabSubtitlesOsd";
            this.tabSubtitlesOsd.Controls.Add(this.tpSubtitles);
            this.tabSubtitlesOsd.Controls.Add(this.tpOsd);
            this.tabSubtitlesOsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSubtitlesOsd.Location = new System.Drawing.Point(0, 0);
            this.tabSubtitlesOsd.Margin = new System.Windows.Forms.Padding(0);
            this.tabSubtitlesOsd.Name = "tabSubtitlesOsd";
            this.tabSubtitlesOsd.SelectedIndex = 0;
            this.tabSubtitlesOsd.Size = new System.Drawing.Size(514, 330);
            this.tabSubtitlesOsd.TabIndex = 0;
            // 
            // tpSubtitles
            // 
            this.tpSubtitles.AccessibleName = "TXT_SUBTITLES";
            this.tpSubtitles.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpSubtitles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpSubtitles.Controls.Add(this.pageSubtitles);
            this.tpSubtitles.Location = new System.Drawing.Point(4, 23);
            this.tpSubtitles.Name = "tpSubtitles";
            this.tpSubtitles.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpSubtitles.Size = new System.Drawing.Size(506, 303);
            this.tpSubtitles.TabIndex = 0;
            this.tpSubtitles.Text = "TXT_SUBTITLES";
            // 
            // pageSubtitles
            // 
            this.pageSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageSubtitles.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageSubtitles.Location = new System.Drawing.Point(5, 10);
            this.pageSubtitles.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageSubtitles.Name = "pageSubtitles";
            this.pageSubtitles.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageSubtitles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pageSubtitles.Size = new System.Drawing.Size(496, 288);
            this.pageSubtitles.TabIndex = 0;
            // 
            // tpOsd
            // 
            this.tpOsd.AccessibleName = "TXT_SUBFONTS";
            this.tpOsd.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tpOsd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpOsd.Controls.Add(this.pageOsd);
            this.tpOsd.Location = new System.Drawing.Point(4, 23);
            this.tpOsd.Name = "tpOsd";
            this.tpOsd.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpOsd.Size = new System.Drawing.Size(506, 303);
            this.tpOsd.TabIndex = 0;
            this.tpOsd.Text = "TXT_SUBFONTS";
            // 
            // pageOsd
            // 
            this.pageOsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageOsd.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.pageOsd.Location = new System.Drawing.Point(5, 10);
            this.pageOsd.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pageOsd.Name = "pageOsd";
            this.pageOsd.OverrideBackColor = System.Drawing.Color.Empty;
            this.pageOsd.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pageOsd.Size = new System.Drawing.Size(496, 288);
            this.pageOsd.TabIndex = 0;
            // 
            // SubtitleSettingsPanel
            // 
            this.Controls.Add(this.tabSubtitlesOsd);
            this.Name = "SubtitleSettingsPanel";
            this.Size = new System.Drawing.Size(514, 330);
            this.tabSubtitlesOsd.ResumeLayout(false);
            this.tpSubtitles.ResumeLayout(false);
            this.tpOsd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTabControl tabSubtitlesOsd;
        private OPMTabPage tpSubtitles;
        private OPMTabPage tpOsd;
        private SubtitleSubtitlePage pageSubtitles;
        private SubtitleOsdPage pageOsd;




    }
}
