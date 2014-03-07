namespace OPMedia.UI.Controls
{
    partial class FileAttributesBrowserCtl
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
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.chkS = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkH = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkA = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkR = new OPMedia.UI.Controls.OPMCheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkS, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkH, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkR, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(89, 64);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // chkS
            // 
            this.chkS.AutoSize = true;
            this.chkS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkS.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.chkS.Location = new System.Drawing.Point(0, 48);
            this.chkS.Margin = new System.Windows.Forms.Padding(0);
            this.chkS.Name = "chkS";
            this.chkS.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkS.Size = new System.Drawing.Size(89, 16);
            this.chkS.TabIndex = 3;
            this.chkS.Text = "TXT_SYSTEM";
            // 
            // chkH
            // 
            this.chkH.AutoSize = true;
            this.chkH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkH.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.chkH.Location = new System.Drawing.Point(0, 32);
            this.chkH.Margin = new System.Windows.Forms.Padding(0);
            this.chkH.Name = "chkH";
            this.chkH.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkH.Size = new System.Drawing.Size(89, 16);
            this.chkH.TabIndex = 2;
            this.chkH.Text = "TXT_HIDDEN";
            // 
            // chkA
            // 
            this.chkA.AutoSize = true;
            this.chkA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkA.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.chkA.Location = new System.Drawing.Point(0, 16);
            this.chkA.Margin = new System.Windows.Forms.Padding(0);
            this.chkA.Name = "chkA";
            this.chkA.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkA.Size = new System.Drawing.Size(89, 16);
            this.chkA.TabIndex = 1;
            this.chkA.Text = "TXT_ARCHIVE";
            // 
            // chkR
            // 
            this.chkR.AutoSize = true;
            this.chkR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkR.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.chkR.Location = new System.Drawing.Point(0, 0);
            this.chkR.Margin = new System.Windows.Forms.Padding(0);
            this.chkR.Name = "chkR";
            this.chkR.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkR.Size = new System.Drawing.Size(89, 16);
            this.chkR.TabIndex = 0;
            this.chkR.Text = "TXT_READONLY";
            // 
            // FileAttributesBrowserCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FileAttributesBrowserCtl";
            this.Size = new System.Drawing.Size(89, 64);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMCheckBox chkS;
        private OPMCheckBox chkH;
        private OPMCheckBox chkA;
        private OPMCheckBox chkR;

    }
}