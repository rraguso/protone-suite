using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Core.ApplicationSettings;
namespace OPMedia.UI.Configuration
{
    partial class TroubleshootingPanel
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
            this.tcTroubleshootingPages = new OPMedia.UI.Controls.OPMTabControl();
            this.SuspendLayout();
            // 
            // tcTroubleshootingPages
            // 
            this.tcTroubleshootingPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTroubleshootingPages.Location = new System.Drawing.Point(0, 0);
            this.tcTroubleshootingPages.Name = "tcTroubleshootingPages";
            this.tcTroubleshootingPages.SelectedIndex = 0;
            this.tcTroubleshootingPages.Size = new System.Drawing.Size(377, 305);
            this.tcTroubleshootingPages.TabIndex = 0;
            // 
            // NetworkSettingsPanel
            // 
            this.Controls.Add(this.tcTroubleshootingPages);
            this.Name = "NetworkSettingsPanel";
            this.Size = new System.Drawing.Size(377, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTabControl tcTroubleshootingPages;

    }
}