namespace GuiTester
{
    partial class MainForm
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
            this.opmButton1 = new OPMedia.UI.Controls.OPMButton();
            this.opmTextBox21 = new OPMedia.UI.Controls.OPMTextBox();
            this.opmComboBox1 = new OPMedia.UI.Controls.OPMComboBox();
            this.opmComboBox2 = new OPMedia.UI.Controls.OPMComboBox();
            this.peDisplay = new OPMedia.UI.Controls.PropertyEditor.OPMPropertyEditor();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmPanel1 = new OPMedia.UI.Controls.OPMPanel();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.opmPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmButton1
            // 
            this.opmButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmButton1.Location = new System.Drawing.Point(139, 14);
            this.opmButton1.Name = "opmButton1";
            this.opmButton1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmButton1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmButton1.ShowDropDown = false;
            this.opmButton1.Size = new System.Drawing.Size(75, 23);
            this.opmButton1.TabIndex = 1;
            this.opmButton1.Text = "opmButton1";
            this.opmButton1.UseVisualStyleBackColor = true;
            // 
            // opmTextBox21
            // 
            this.opmTextBox21.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.opmTextBox21.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.opmTextBox21.Location = new System.Drawing.Point(12, 14);
            this.opmTextBox21.Margin = new System.Windows.Forms.Padding(0);
            this.opmTextBox21.MaximumSize = new System.Drawing.Size(2000, 20);
            this.opmTextBox21.MaxLength = 32767;
            this.opmTextBox21.MinimumSize = new System.Drawing.Size(20, 20);
            this.opmTextBox21.Multiline = false;
            this.opmTextBox21.Name = "opmTextBox21";
            this.opmTextBox21.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTextBox21.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmTextBox21.Padding = new System.Windows.Forms.Padding(3);
            this.opmTextBox21.PasswordChar = '\0';
            this.opmTextBox21.ReadOnly = false;
            this.opmTextBox21.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.opmTextBox21.ShortcutsEnabled = true;
            this.opmTextBox21.Size = new System.Drawing.Size(121, 20);
            this.opmTextBox21.TabIndex = 2;
            this.opmTextBox21.Text = "fsfsdfdasf";
            this.opmTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.opmTextBox21.UseSystemPasswordChar = false;
            this.opmTextBox21.WordWrap = true;
            // 
            // opmComboBox1
            // 
            this.opmComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.opmComboBox1.FormattingEnabled = true;
            this.opmComboBox1.Items.AddRange(new object[] {
            "AAAAAAAA",
            "BBBBBB",
            "CCCCCCC",
            "111111",
            "4444444",
            "irutir"});
            this.opmComboBox1.Location = new System.Drawing.Point(12, 37);
            this.opmComboBox1.Name = "opmComboBox1";
            this.opmComboBox1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmComboBox1.Size = new System.Drawing.Size(121, 23);
            this.opmComboBox1.TabIndex = 3;
            // 
            // opmComboBox2
            // 
            this.opmComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.opmComboBox2.FormattingEnabled = true;
            this.opmComboBox2.Items.AddRange(new object[] {
            "AAAAAAAA",
            "BBBBBB",
            "CCCCCCC",
            "111111",
            "4444444",
            "irutir"});
            this.opmComboBox2.Location = new System.Drawing.Point(12, 66);
            this.opmComboBox2.Name = "opmComboBox2";
            this.opmComboBox2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmComboBox2.Size = new System.Drawing.Size(121, 23);
            this.opmComboBox2.TabIndex = 4;
            // 
            // peDisplay
            // 
            this.peDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peDisplay.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.peDisplay.Location = new System.Drawing.Point(3, 109);
            this.peDisplay.Name = "peDisplay";
            this.peDisplay.OverrideBackColor = System.Drawing.Color.Empty;
            this.peDisplay.Size = new System.Drawing.Size(341, 213);
            this.peDisplay.TabIndex = 5;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.peDisplay, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.opmPanel1, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(347, 325);
            this.opmTableLayoutPanel1.TabIndex = 6;
            // 
            // opmPanel1
            // 
            this.opmPanel1.Controls.Add(this.opmTextBox21);
            this.opmPanel1.Controls.Add(this.opmComboBox2);
            this.opmPanel1.Controls.Add(this.opmButton1);
            this.opmPanel1.Controls.Add(this.opmComboBox1);
            this.opmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmPanel1.Location = new System.Drawing.Point(3, 3);
            this.opmPanel1.Name = "opmPanel1";
            this.opmPanel1.Size = new System.Drawing.Size(341, 100);
            this.opmPanel1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(349, 348);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "MainForm";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMedia.UI.Controls.OPMButton opmButton1;
        private OPMedia.UI.Controls.OPMTextBox opmTextBox21;
        private OPMedia.UI.Controls.OPMComboBox opmComboBox1;
        private OPMedia.UI.Controls.OPMComboBox opmComboBox2;
        private OPMedia.UI.Controls.PropertyEditor.OPMPropertyEditor peDisplay;
        private OPMedia.UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.Controls.OPMPanel opmPanel1;



    }
}

