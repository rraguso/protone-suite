
using OPMedia.UI.Controls;
namespace OPMedia.RCCManager
{
    partial class KeyPressDefinitionForm
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
            this.lblDesc = new OPMLabel();
            this.btnCancel = new OPMButton();
            
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Controls.Add(this.lblDesc);
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.Location = new System.Drawing.Point(8, 5);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(285, 37);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "TXT_PRESS_KEY";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // KeyPressDefinitionForm
            // 
            this.ClientSize = new System.Drawing.Size(308, 100);
            
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KeyPressDefinitionForm";
            
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblDesc;
        private OPMButton btnCancel;

    }
}