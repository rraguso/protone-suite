using OPMedia.UI.Controls;
using System.Windows.Forms;
using OPMedia.Core.Configuration;
namespace OPMedia.UI.Configuration
{
    partial class ControlAppPanel
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
            this.tcControlPages = new OPMedia.UI.Controls.OPMTabControl();
            this.SuspendLayout();
            // 
            // tcTroubleshootingPages
            // 
            this.tcControlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcControlPages.Location = new System.Drawing.Point(0, 0);
            this.tcControlPages.Name = "tcTroubleshootingPages";
            this.tcControlPages.SelectedIndex = 0;
            this.tcControlPages.Size = new System.Drawing.Size(377, 305);
            this.tcControlPages.TabIndex = 0;
            // 
            // NetworkSettingsPanel
            // 
            this.Controls.Add(this.tcControlPages);
            this.Name = "NetworkSettingsPanel";
            this.Size = new System.Drawing.Size(377, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTabControl tcControlPages;

    }
}