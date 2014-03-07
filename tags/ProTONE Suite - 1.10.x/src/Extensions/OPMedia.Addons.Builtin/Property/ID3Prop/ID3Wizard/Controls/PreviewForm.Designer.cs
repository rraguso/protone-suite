using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.ID3Prop.ID3Wizard.Controls
{
    partial class PreviewForm
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
            this.okButton = new OPMButton();
            this.label1 = new OPMLabel();
            this.lvPreview = new OPMListView();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lvPreview);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.okButton);
            this.pnlContent.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(779, 329);
            this.okButton.Name = "okButton";
            this.okButton.OverrideForeColor = System.Drawing.Color.Empty;
            this.okButton.Size = new System.Drawing.Size(72, 24);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "TXT_OK";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(409, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_PREVIEW_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvPreview
            // 
            this.lvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPreview.Location = new System.Drawing.Point(0, 0);
            this.lvPreview.MultiSelect = false;
            this.lvPreview.Name = "lvPreview";
            this.lvPreview.ShowItemToolTips = true;
            this.lvPreview.Size = new System.Drawing.Size(858, 323);
            this.lvPreview.TabIndex = 1;
            this.lvPreview.UseCompatibleStateImageBehavior = false;
            this.lvPreview.View = System.Windows.Forms.View.Details;
            // 
            // PreviewForm
            // 
            this.ClientSize = new System.Drawing.Size(868, 388);
            this.Name = "PreviewForm";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton okButton;
        private OPMLabel label1;
        private OPMListView lvPreview;
    }
}