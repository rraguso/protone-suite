using OPMedia.UI.Controls;
using System.Windows.Forms;
namespace OPMedia.Runtime.Addons.Configuration
{
    partial class AddonListCtl
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
            this.tvAddons = new OPMedia.UI.Controls.OPMTreeView();
            this.SuspendLayout();
            // 
            // tvAddons
            // 
            this.tvAddons.CheckBoxes = true;
            this.tvAddons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAddons.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvAddons.Location = new System.Drawing.Point(0, 0);
            this.tvAddons.Name = "tvAddons";
            this.tvAddons.Size = new System.Drawing.Size(668, 411);
            this.tvAddons.TabIndex = 0;
            // 
            // AddonListCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tvAddons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AddonListCtl";
            this.Size = new System.Drawing.Size(668, 411);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTreeView tvAddons;



    }
}
