using OPMedia.UI.Controls;
namespace OPMedia.Runtime.Addons.Configuration
{
    partial class AddonSettingsPanel
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
            this.tabAddons = new OPMedia.UI.Controls.OPMTabControl();
            this.SuspendLayout();
            // 
            // tabAddons
            // 
            this.tabAddons.AccessibleName = "tabAddons";
            this.tabAddons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAddons.Location = new System.Drawing.Point(0, 0);
            this.tabAddons.Name = "tabAddons";
            this.tabAddons.SelectedIndex = 0;
            this.tabAddons.Size = new System.Drawing.Size(419, 290);
            this.tabAddons.TabIndex = 0;
            // 
            // AddonSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabAddons);
            this.Name = "AddonSettingsPanel";
            this.Size = new System.Drawing.Size(419, 290);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTabControl tabAddons;

    }
}
