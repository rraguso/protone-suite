namespace OPMedia.UI.Controls
{
    partial class OPMTimePicker
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
            this.TheTimeBox = new System.Windows.Forms.TextBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TheTimeBox
            // 
            this.TheTimeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TheTimeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TheTimeBox.Location = new System.Drawing.Point(1, 1);
            this.TheTimeBox.Margin = new System.Windows.Forms.Padding(0);
            this.TheTimeBox.Multiline = true;
            this.TheTimeBox.Name = "TheTimeBox";
            this.tableLayoutPanel1.SetRowSpan(this.TheTimeBox, 3);
            this.TheTimeBox.Size = new System.Drawing.Size(69, 19);
            this.TheTimeBox.TabIndex = 0;
            this.TheTimeBox.Text = "00:00:00.000";
            this.TheTimeBox.Click += new System.EventHandler(this.TheTimeBox_Click);
            this.TheTimeBox.TextChanged += new System.EventHandler(this.TheTimeBox_TextChanged);
            this.TheTimeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TheTimeBox_KeyDown);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Location = new System.Drawing.Point(71, 1);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlus.MaximumSize = new System.Drawing.Size(13, 10);
            this.btnPlus.MinimumSize = new System.Drawing.Size(13, 10);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(13, 10);
            this.btnPlus.TabIndex = 1;
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Location = new System.Drawing.Point(71, 10);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinus.MaximumSize = new System.Drawing.Size(13, 10);
            this.btnMinus.MinimumSize = new System.Drawing.Size(13, 10);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(13, 10);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.Tag = "-";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnPlus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TheTimeBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMinus, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(85, 21);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // OPMTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(85, 21);
            this.MinimumSize = new System.Drawing.Size(85, 21);
            this.Name = "OPMTimePicker";
            this.Size = new System.Drawing.Size(85, 21);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TheTimeBox;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}
