namespace OPMedia.UI.Controls
{
    partial class ScreenSlider
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new OPMedia.UI.Controls.OPMButton();
            this.btnNext = new OPMedia.UI.Controls.OPMButton();
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.pnlScreen = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnPrev, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDesc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlScreen, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 222);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.AutoSize = true;
            this.btnPrev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(0, 202);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrev.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnPrev.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnPrev.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnPrev.ShowDropDown = false;
            this.btnPrev.Size = new System.Drawing.Size(20, 20);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(214, 202);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnNext.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnNext.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnNext.ShowDropDown = false;
            this.btnNext.Size = new System.Drawing.Size(20, 20);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(20, 202);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDesc.Size = new System.Drawing.Size(194, 20);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "opmLabel1";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlScreen
            // 
            this.pnlScreen.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlScreen, 3);
            this.pnlScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreen.Location = new System.Drawing.Point(3, 3);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.RowCount = 1;
            this.pnlScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlScreen.Size = new System.Drawing.Size(228, 196);
            this.pnlScreen.TabIndex = 3;
            // 
            // ScreenSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScreenSlider";
            this.Size = new System.Drawing.Size(234, 222);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OPMButton btnPrev;
        private OPMButton btnNext;
        private OPMLabel lblDesc;
        private System.Windows.Forms.TableLayoutPanel pnlScreen;
    }
}
