namespace OPMedia.UI.Controls.PropertyEditor
{
    partial class OPMPropertyEditor
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
            this.pnlPropertyChoosers = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmPanel1 = new OPMedia.UI.Controls.OPMPanel();
            this.opmPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPropertyChoosers
            // 
            this.pnlPropertyChoosers.AutoSize = true;
            this.pnlPropertyChoosers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPropertyChoosers.ColumnCount = 1;
            this.pnlPropertyChoosers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPropertyChoosers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPropertyChoosers.Location = new System.Drawing.Point(0, 0);
            this.pnlPropertyChoosers.Name = "pnlPropertyChoosers";
            this.pnlPropertyChoosers.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlPropertyChoosers.RowCount = 1;
            this.pnlPropertyChoosers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPropertyChoosers.Size = new System.Drawing.Size(370, 0);
            this.pnlPropertyChoosers.TabIndex = 0;
            // 
            // opmPanel1
            // 
            this.opmPanel1.Controls.Add(this.pnlPropertyChoosers);
            this.opmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmPanel1.Name = "opmPanel1";
            this.opmPanel1.Size = new System.Drawing.Size(370, 351);
            this.opmPanel1.TabIndex = 1;
            // 
            // OPMPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opmPanel1);
            this.Name = "OPMPropertyEditor";
            this.Size = new System.Drawing.Size(370, 351);
            this.opmPanel1.ResumeLayout(false);
            this.opmPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel pnlPropertyChoosers;
        private OPMPanel opmPanel1;
    }
}
