namespace SkinBuilder.Property
{
    partial class DropDownColorChooser
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
            this.opmButton1 = new OPMedia.UI.Controls.OPMButton();
            this.colorChooser = new OPMedia.UI.Controls.OPMColorChooserCtl();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmButton1, 1, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.colorChooser, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(437, 182);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(0, 0);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(410, 24);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "opmLabel1";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmButton1
            // 
            this.opmButton1.AutoSize = true;
            this.opmButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmButton1.FontSize = OPMedia.UI.Themes.FontSizes.Smallest;
            this.opmButton1.Location = new System.Drawing.Point(410, 0);
            this.opmButton1.Margin = new System.Windows.Forms.Padding(0);
            this.opmButton1.Name = "opmButton1";
            this.opmButton1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmButton1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmButton1.ShowDropDown = false;
            this.opmButton1.Size = new System.Drawing.Size(27, 24);
            this.opmButton1.TabIndex = 1;
            this.opmButton1.Text = ". . .";
            this.opmButton1.Click += new System.EventHandler(this.opmButton1_Click);
            // 
            // colorChooser
            // 
            this.colorChooser.AutoSize = true;
            this.colorChooser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorChooser.Color = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.SetColumnSpan(this.colorChooser, 2);
            this.colorChooser.Description = "[ edited color description ]";
            this.colorChooser.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.colorChooser.Location = new System.Drawing.Point(3, 27);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.OverrideBackColor = System.Drawing.Color.Empty;
            this.colorChooser.Size = new System.Drawing.Size(431, 152);
            this.colorChooser.TabIndex = 2;
            this.colorChooser.Visible = false;
            // 
            // DropDownColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "DropDownColorChooser";
            this.Size = new System.Drawing.Size(437, 182);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMLabel opmLabel1;
        private OPMedia.UI.Controls.OPMButton opmButton1;
        private OPMedia.UI.Controls.OPMColorChooserCtl colorChooser;
    }
}
