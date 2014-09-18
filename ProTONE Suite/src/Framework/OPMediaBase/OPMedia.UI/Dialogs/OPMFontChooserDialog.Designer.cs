using OPMedia.UI.Themes;
namespace OPMedia.UI.Dialogs
{
    partial class OPMFontChooserDialog
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.ctlFontChooser = new OPMedia.UI.Controls.OPMFontChooserCtl();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.ctlFontChooser, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(414, 234);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(331, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(270, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.ShowDropDown = false;
            this.btnOK.Size = new System.Drawing.Size(55, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ctlFontChooser
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.ctlFontChooser, 3);
            this.ctlFontChooser.Description = "[ edited color description ]";
            this.ctlFontChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFontChooser.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.ctlFontChooser.Location = new System.Drawing.Point(0, 0);
            this.ctlFontChooser.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.ctlFontChooser.Name = "ctlFontChooser";
            this.ctlFontChooser.OverrideBackColor = System.Drawing.Color.Empty;
            this.ctlFontChooser.Size = new System.Drawing.Size(411, 200);
            this.ctlFontChooser.TabIndex = 2;
            // 
            // OPMFontChooserDialog
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 257);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "OPMFontChooserDialog";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private Controls.OPMButton btnCancel;
        private Controls.OPMButton btnOK;
        private Controls.OPMFontChooserCtl ctlFontChooser;
    }
}