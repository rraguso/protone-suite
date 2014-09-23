using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard.Controls
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
            this.okButton = new OPMedia.UI.Controls.OPMButton();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.lvPreview = new OPMedia.UI.Controls.OPMListView();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(808, 337);
            this.okButton.Name = "okButton";
            this.okButton.OverrideBackColor = System.Drawing.Color.Empty;
            this.okButton.OverrideForeColor = System.Drawing.Color.Empty;
            this.okButton.ShowDropDown = false;
            this.okButton.Size = new System.Drawing.Size(55, 25);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "TXT_OK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(860, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_PREVIEW_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvPreview
            // 
            this.lvPreview.AllowEditing = false;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lvPreview, 2);
            this.lvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPreview.Location = new System.Drawing.Point(3, 16);
            this.lvPreview.MultiSelect = false;
            this.lvPreview.Name = "lvPreview";
            this.lvPreview.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvPreview.ShowItemToolTips = true;
            this.lvPreview.Size = new System.Drawing.Size(860, 315);
            this.lvPreview.TabIndex = 1;
            this.lvPreview.UseCompatibleStateImageBehavior = false;
            this.lvPreview.View = System.Windows.Forms.View.Details;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.okButton, 1, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lvPreview, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 3;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(866, 365);
            this.opmTableLayoutPanel1.TabIndex = 3;
            // 
            // PreviewForm
            // 
            this.ClientSize = new System.Drawing.Size(868, 388);
            this.MinimumSize = new System.Drawing.Size(200, 85);
            this.Name = "PreviewForm";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton okButton;
        private OPMLabel label1;
        private OPMListView lvPreview;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
    }
}