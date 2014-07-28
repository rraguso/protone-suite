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
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmComboBox2);
            this.pnlContent.Controls.Add(this.opmComboBox1);
            this.pnlContent.Controls.Add(this.opmTextBox21);
            this.pnlContent.Controls.Add(this.opmButton1);
            // 
            // opmButton1
            // 
            this.opmButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmButton1.Location = new System.Drawing.Point(77, 93);
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
            this.opmTextBox21.Location = new System.Drawing.Point(77, 55);
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
            this.opmTextBox21.Size = new System.Drawing.Size(106, 20);
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
            this.opmComboBox1.Location = new System.Drawing.Point(77, 144);
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
            this.opmComboBox2.Location = new System.Drawing.Point(77, 186);
            this.opmComboBox2.Name = "opmComboBox2";
            this.opmComboBox2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmComboBox2.Size = new System.Drawing.Size(121, 23);
            this.opmComboBox2.TabIndex = 4;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(349, 348);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "MainForm";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMedia.UI.Controls.OPMButton opmButton1;
        private OPMedia.UI.Controls.OPMTextBox opmTextBox21;
        private OPMedia.UI.Controls.OPMComboBox opmComboBox1;
        private OPMedia.UI.Controls.OPMComboBox opmComboBox2;



    }
}

