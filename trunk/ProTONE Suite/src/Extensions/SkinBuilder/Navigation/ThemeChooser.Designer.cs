namespace SkinBuilder.Navigation
{
    partial class ThemeChooser
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.lbThemes = new System.Windows.Forms.ListBox();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmTextBox1 = new OPMedia.UI.Controls.OPMTextBox();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.btnOk, 1, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 2, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.lbThemes, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmTextBox1, 0, 1);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 5;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(379, 199);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(235, 171);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.ShowDropDown = false;
            this.btnOk.Size = new System.Drawing.Size(55, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "TXT_OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(296, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbThemes
            // 
            this.lbThemes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lbThemes, 3);
            this.lbThemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbThemes.FormattingEnabled = true;
            this.lbThemes.Location = new System.Drawing.Point(3, 70);
            this.lbThemes.Name = "lbThemes";
            this.lbThemes.Size = new System.Drawing.Size(373, 95);
            this.lbThemes.TabIndex = 2;
            this.lbThemes.SelectedIndexChanged += new System.EventHandler(this.lbThemes_SelectedIndexChanged);
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmLabel1, 3);
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(3, 54);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(373, 13);
            this.opmLabel1.TabIndex = 3;
            this.opmLabel1.Text = "TXT_SELECT_THEME_FROM_FILE";
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmLabel2, 3);
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(3, 0);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(373, 13);
            this.opmLabel2.TabIndex = 4;
            this.opmLabel2.Text = "TXT_THEME_NAME:";
            // 
            // opmTextBox1
            // 
            this.opmTextBox1.BackColor = System.Drawing.Color.White;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmTextBox1, 3);
            this.opmTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTextBox1.Location = new System.Drawing.Point(3, 16);
            this.opmTextBox1.Name = "opmTextBox1";
            this.opmTextBox1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmTextBox1.Size = new System.Drawing.Size(373, 22);
            this.opmTextBox1.TabIndex = 5;
            this.opmTextBox1.Text = "New Theme";
            // 
            // ThemeChooser
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(381, 222);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "ThemeChooser";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMButton btnOk;
        private OPMedia.UI.Controls.OPMButton btnCancel;
        private System.Windows.Forms.ListBox lbThemes;
        private OPMedia.UI.Controls.OPMLabel opmLabel1;
        private OPMedia.UI.Controls.OPMLabel opmLabel2;
        private OPMedia.UI.Controls.OPMTextBox opmTextBox1;
    }
}