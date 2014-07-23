namespace SkinBuilder.Property
{
    partial class AddonPanel
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
            this.pnlThemeProperties = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlScrollable = new OPMedia.UI.Controls.OPMPanel();
            this.dropDownColorChooser2 = new SkinBuilder.Property.DropDownColorChooser();
            this.dropDownColorChooser1 = new SkinBuilder.Property.DropDownColorChooser();
            this.pnlThemeProperties.SuspendLayout();
            this.pnlScrollable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlThemeProperties
            // 
            this.pnlThemeProperties.AutoScroll = true;
            this.pnlThemeProperties.AutoSize = true;
            this.pnlThemeProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlThemeProperties.ColumnCount = 1;
            this.pnlThemeProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlThemeProperties.Controls.Add(this.dropDownColorChooser2, 0, 1);
            this.pnlThemeProperties.Controls.Add(this.dropDownColorChooser1, 0, 0);
            this.pnlThemeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThemeProperties.Location = new System.Drawing.Point(5, 5);
            this.pnlThemeProperties.Name = "pnlThemeProperties";
            this.pnlThemeProperties.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlThemeProperties.RowCount = 3;
            this.pnlThemeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlThemeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlThemeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlThemeProperties.Size = new System.Drawing.Size(243, 249);
            this.pnlThemeProperties.TabIndex = 1;
            // 
            // pnlScrollable
            // 
            this.pnlScrollable.Controls.Add(this.pnlThemeProperties);
            this.pnlScrollable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollable.Location = new System.Drawing.Point(0, 0);
            this.pnlScrollable.Name = "pnlScrollable";
            this.pnlScrollable.Padding = new System.Windows.Forms.Padding(5);
            this.pnlScrollable.Size = new System.Drawing.Size(253, 259);
            this.pnlScrollable.TabIndex = 2;
            // 
            // dropDownColorChooser2
            // 
            this.dropDownColorChooser2.AutoSize = true;
            this.dropDownColorChooser2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dropDownColorChooser2.PropertyName = "[ Choose a name for the color ]";
            this.dropDownColorChooser2.PropertyValue = "255, 255, 255";
            this.dropDownColorChooser2.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.dropDownColorChooser2.Location = new System.Drawing.Point(3, 33);
            this.dropDownColorChooser2.Name = "dropDownColorChooser2";
            this.dropDownColorChooser2.OverrideBackColor = System.Drawing.Color.Empty;
            this.dropDownColorChooser2.Size = new System.Drawing.Size(194, 24);
            this.dropDownColorChooser2.TabIndex = 1;
            // 
            // dropDownColorChooser1
            // 
            this.dropDownColorChooser1.AutoSize = true;
            this.dropDownColorChooser1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dropDownColorChooser1.PropertyName = "[ Choose a name for the color ]";
            this.dropDownColorChooser1.PropertyValue = "255, 255, 255";
            this.dropDownColorChooser1.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.dropDownColorChooser1.Location = new System.Drawing.Point(3, 3);
            this.dropDownColorChooser1.Name = "dropDownColorChooser1";
            this.dropDownColorChooser1.OverrideBackColor = System.Drawing.Color.Empty;
            this.dropDownColorChooser1.Size = new System.Drawing.Size(194, 24);
            this.dropDownColorChooser1.TabIndex = 0;
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScrollable);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(253, 259);
            this.pnlThemeProperties.ResumeLayout(false);
            this.pnlThemeProperties.PerformLayout();
            this.pnlScrollable.ResumeLayout(false);
            this.pnlScrollable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DropDownColorChooser dropDownColorChooser1;
        private DropDownColorChooser dropDownColorChooser2;
        private OPMedia.UI.Controls.OPMTableLayoutPanel pnlThemeProperties;
        private OPMedia.UI.Controls.OPMPanel pnlScrollable;
    }
}
