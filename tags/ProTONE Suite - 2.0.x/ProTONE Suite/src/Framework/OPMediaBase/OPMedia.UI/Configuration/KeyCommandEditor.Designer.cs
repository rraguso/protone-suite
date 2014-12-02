
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
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.pnlContentAll = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.pnlContent.SuspendLayout();
            this.pnlContentAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlContentAll);
            this.pnlContent.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(5, 41);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // pnlContentAll
            // 
            this.pnlContentAll.AutoSize = true;
            this.pnlContentAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContentAll.ColumnCount = 5;
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContentAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.pnlContentAll.Controls.Add(this.lblDesc, 1, 1);
            this.pnlContentAll.Controls.Add(this.btnCancel, 2, 3);
            this.pnlContentAll.Location = new System.Drawing.Point(0, 0);
            this.pnlContentAll.Name = "pnlContentAll";
            this.pnlContentAll.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlContentAll.RowCount = 4;
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContentAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContentAll.Size = new System.Drawing.Size(90, 66);
            this.pnlContentAll.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.pnlContentAll.SetColumnSpan(this.lblDesc, 3);
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(10, 5);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(5, 0, 0, 10);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(75, 26);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "qqqq\r\neeee";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KeyCommandEditor
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(478, 200);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "KeyCommandEditor";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlContentAll.ResumeLayout(false);
            this.pnlContentAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton btnCancel;
        private OPMTableLayoutPanel pnlContentAll;
        private OPMLabel lblDesc;

    }
}