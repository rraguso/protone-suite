
using OPMedia.UI.Controls;
namespace OPMedia.UI.Configuration
{
    partial class KeyCommandEditor
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
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblDesc);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.TabIndex = 0;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(5, 5);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(292, 38);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "qqqq\r\neeee";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(220, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // KeyCommandEditor
            // 
            this.ClientSize = new System.Drawing.Size(308, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KeyCommandEditor";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblDesc;
        private OPMButton btnCancel;

    }
}