
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
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.pnlContentAll = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.pnlContentAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlContentAll);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.pnlContentAll.SetColumnSpan(this.lblDesc, 3);
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(3, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(82, 30);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "TXT_PRESS_KEY";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(8, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // pnlContentAll
            // 
            this.pnlContentAll.AutoSize = true;
            this.pnlContentAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContentAll.ColumnCount = 3;
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.Controls.Add(this.btnCancel, 1, 1);
            this.pnlContentAll.Controls.Add(this.lblDesc, 0, 0);
            this.pnlContentAll.Location = new System.Drawing.Point(3, 0);
            this.pnlContentAll.Name = "pnlContentAll";
            this.pnlContentAll.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlContentAll.RowCount = 2;
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.Size = new System.Drawing.Size(88, 60);
            this.pnlContentAll.TabIndex = 2;
            // 
            // KeyPressDefinitionForm
            // 
            this.ClientSize = new System.Drawing.Size(308, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "KeyPressDefinitionForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlContentAll.ResumeLayout(false);
            this.pnlContentAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblDesc;
        private OPMButton btnCancel;
        private OPMTableLayoutPanel pnlContentAll;

    }
}