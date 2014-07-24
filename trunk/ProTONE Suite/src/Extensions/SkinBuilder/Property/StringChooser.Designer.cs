namespace SkinBuilder.Property
{
    partial class StringChooser
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
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.txtValue = new OPMedia.UI.Controls.OPMTextBox();
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
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.txtValue, 1, 0);
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
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(39, 28);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "Value:";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.White;
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(48, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtValue.Size = new System.Drawing.Size(41, 22);
            this.txtValue.TabIndex = 1;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // StringChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "StringChooser";
            this.Size = new System.Drawing.Size(92, 28);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMLabel opmLabel1;
        private OPMedia.UI.Controls.OPMTextBox txtValue;
    }
}
