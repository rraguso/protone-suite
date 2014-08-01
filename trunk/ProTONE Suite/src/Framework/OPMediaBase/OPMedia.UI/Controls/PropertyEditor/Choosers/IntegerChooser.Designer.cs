namespace OPMedia.UI.Controls.PropertyEditor.Choosers
{
    partial class IntegerChooser
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
            this.opmNumericUpDown1 = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.opmTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opmNumericUpDown1)).BeginInit();
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
            this.opmTableLayoutPanel1.Controls.Add(this.opmNumericUpDown1, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 1;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(92, 28);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.lblValueName.AutoSize = true;
            this.lblValueName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValueName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblValueName.Location = new System.Drawing.Point(3, 0);
            this.lblValueName.Name = "opmLabel1";
            this.lblValueName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblValueName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblValueName.Size = new System.Drawing.Size(39, 28);
            this.lblValueName.TabIndex = 0;
            this.lblValueName.Text = "Value:";
            this.lblValueName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmNumericUpDown1
            // 
            this.opmNumericUpDown1.AutoSize = true;
            this.opmNumericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmNumericUpDown1.Location = new System.Drawing.Point(48, 3);
            this.opmNumericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.opmNumericUpDown1.Name = "opmNumericUpDown1";
            this.opmNumericUpDown1.Size = new System.Drawing.Size(41, 22);
            this.opmNumericUpDown1.TabIndex = 1;
            this.opmNumericUpDown1.ValueChanged += new System.EventHandler(this.opmNumericUpDown1_ValueChanged);
            // 
            // IntegerChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "IntegerChooser";
            this.Size = new System.Drawing.Size(92, 28);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opmNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMLabel lblValueName;
        private OPMedia.UI.Controls.OPMNumericUpDown opmNumericUpDown1;
    }
}
