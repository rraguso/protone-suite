namespace OPMedia.UI.Controls.PropertyEditor.Choosers
{
    partial class EnumeratedTypeChooser
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblValueName = new OPMedia.UI.Controls.OPMLabel();
            this.cmbValue = new OPMedia.UI.Controls.OPMComboBox();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.lblValueName, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbValue, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 1;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(147, 29);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // lblValueName
            // 
            this.lblValueName.AutoSize = true;
            this.lblValueName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValueName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblValueName.Location = new System.Drawing.Point(3, 0);
            this.lblValueName.Name = "lblValueName";
            this.lblValueName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblValueName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblValueName.Size = new System.Drawing.Size(39, 29);
            this.lblValueName.TabIndex = 0;
            this.lblValueName.Text = "Value:";
            this.lblValueName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbValue
            // 
            this.cmbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(48, 3);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbValue.Size = new System.Drawing.Size(96, 23);
            this.cmbValue.TabIndex = 1;
            // 
            // EnumeratedTypeChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "EnumeratedTypeChooser";
            this.Size = new System.Drawing.Size(147, 29);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMLabel lblValueName;
        private OPMComboBox cmbValue;
    }
}
