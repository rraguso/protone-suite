using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.UI.Wizards
{
    partial class WizardBaseCtl
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
            this.SuspendLayout();
            // 
            // WizardBaseCtl
            // 
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WizardBaseCtl";
            this.Size = new System.Drawing.Size(512, 400);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
