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
            this.pnlContent = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlThemeProperties = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblNodeName = new OPMedia.UI.Controls.OPMLabel();
            this.txtNodeName = new OPMedia.UI.Controls.OPMTextBox();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.ColumnCount = 2;
            this.pnlContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlContent.Controls.Add(this.pnlThemeProperties, 0, 1);
            this.pnlContent.Controls.Add(this.lblNodeName, 0, 0);
            this.pnlContent.Controls.Add(this.txtNodeName, 1, 0);
            this.pnlContent.Location = new System.Drawing.Point(3, 3);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlContent.RowCount = 2;
            this.pnlContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContent.Size = new System.Drawing.Size(437, 34);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlThemeProperties
            // 
            this.pnlThemeProperties.AutoSize = true;
            this.pnlThemeProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlThemeProperties.ColumnCount = 1;
            this.pnlContent.SetColumnSpan(this.pnlThemeProperties, 2);
            this.pnlThemeProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlThemeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThemeProperties.Location = new System.Drawing.Point(3, 31);
            this.pnlThemeProperties.Name = "pnlThemeProperties";
            this.pnlThemeProperties.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlThemeProperties.RowCount = 1;
            this.pnlThemeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlThemeProperties.Size = new System.Drawing.Size(431, 1);
            this.pnlThemeProperties.TabIndex = 0;
            // 
            // lblNodeName
            // 
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNodeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNodeName.Location = new System.Drawing.Point(3, 0);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblNodeName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblNodeName.Size = new System.Drawing.Size(69, 28);
            this.lblNodeName.TabIndex = 1;
            this.lblNodeName.Text = "Node name:";
            this.lblNodeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNodeName
            // 
            this.txtNodeName.BackColor = System.Drawing.Color.White;
            this.txtNodeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNodeName.Location = new System.Drawing.Point(78, 3);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtNodeName.Size = new System.Drawing.Size(356, 22);
            this.txtNodeName.TabIndex = 2;
            this.txtNodeName.TextChanged += new System.EventHandler(this.OnPropertyChanged);
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(691, 512);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel pnlContent;
        private OPMedia.UI.Controls.OPMTableLayoutPanel pnlThemeProperties;
        private OPMedia.UI.Controls.OPMLabel lblNodeName;
        private OPMedia.UI.Controls.OPMTextBox txtNodeName;

    }
}
