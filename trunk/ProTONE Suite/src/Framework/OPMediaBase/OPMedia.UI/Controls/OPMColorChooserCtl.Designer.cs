namespace OPMedia.UI.Controls
{
    partial class OPMColorChooserCtl
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
            this.opmLabel4 = new OPMedia.UI.Controls.OPMLabel();
            this.lblColorName = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.cgR = new OPMedia.UI.Controls.ControlGauge();
            this.cgG = new OPMedia.UI.Controls.ControlGauge();
            this.cgB = new OPMedia.UI.Controls.ControlGauge();
            this.nudR = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.nudG = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.nudB = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.txtColor = new System.Windows.Forms.MaskedTextBox();
            this.cmbKnownColors = new OPMedia.UI.Controls.ColorComboBox();
            this.lblResultingColor = new OPMedia.UI.Controls.OPMLabel();
            this.opmTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            this.SuspendLayout();
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 4;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel4, 0, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.lblColorName, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel2, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel3, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.cgR, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.cgG, 1, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.cgB, 1, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.nudR, 3, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.nudG, 3, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.nudB, 3, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.txtColor, 1, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbKnownColors, 2, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.lblResultingColor, 2, 5);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 6;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(427, 143);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel4
            // 
            this.opmLabel4.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.opmLabel4, 2);
            this.opmLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel4.Location = new System.Drawing.Point(3, 123);
            this.opmLabel4.Name = "opmLabel4";
            this.opmLabel4.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel4.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel4.Size = new System.Drawing.Size(191, 20);
            this.opmLabel4.TabIndex = 12;
            this.opmLabel4.Text = "TXT_RESULTING_COLOR:";
            this.opmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblColorName
            // 
            this.lblColorName.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblColorName, 4);
            this.lblColorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblColorName.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblColorName.Location = new System.Drawing.Point(3, 0);
            this.lblColorName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblColorName.Name = "lblColorName";
            this.lblColorName.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblColorName.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblColorName.Size = new System.Drawing.Size(421, 13);
            this.lblColorName.TabIndex = 10;
            this.lblColorName.Text = "[ edited color description ]";
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.opmLabel1.Location = new System.Drawing.Point(3, 19);
            this.opmLabel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(11, 23);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "R";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.opmLabel2.Location = new System.Drawing.Point(3, 45);
            this.opmLabel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(11, 23);
            this.opmLabel2.TabIndex = 1;
            this.opmLabel2.Text = "G";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.opmLabel3.Location = new System.Drawing.Point(3, 71);
            this.opmLabel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(11, 23);
            this.opmLabel3.TabIndex = 2;
            this.opmLabel3.Text = "B";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cgR
            // 
            this.cgR.AllowDragging = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.cgR, 2);
            this.cgR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgR.Dock = System.Windows.Forms.DockStyle.Top;
            this.cgR.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgR.Location = new System.Drawing.Point(17, 19);
            this.cgR.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cgR.Maximum = 255D;
            this.cgR.MaximumSize = new System.Drawing.Size(2550, 20);
            this.cgR.MinimumSize = new System.Drawing.Size(55, 5);
            this.cgR.Name = "cgR";
            this.cgR.NrTicks = 10;
            this.cgR.OverrideBackColor = System.Drawing.Color.Red;
            this.cgR.ShowTicks = true;
            this.cgR.Size = new System.Drawing.Size(357, 20);
            this.cgR.TabIndex = 3;
            this.cgR.Value = 127D;
            this.cgR.Vertical = false;
            // 
            // cgG
            // 
            this.cgG.AllowDragging = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.cgG, 2);
            this.cgG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgG.Dock = System.Windows.Forms.DockStyle.Top;
            this.cgG.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgG.Location = new System.Drawing.Point(17, 45);
            this.cgG.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cgG.Maximum = 255D;
            this.cgG.MaximumSize = new System.Drawing.Size(2550, 20);
            this.cgG.MinimumSize = new System.Drawing.Size(55, 5);
            this.cgG.Name = "cgG";
            this.cgG.NrTicks = 10;
            this.cgG.OverrideBackColor = System.Drawing.Color.Green;
            this.cgG.ShowTicks = true;
            this.cgG.Size = new System.Drawing.Size(357, 20);
            this.cgG.TabIndex = 4;
            this.cgG.Value = 127D;
            this.cgG.Vertical = false;
            // 
            // cgB
            // 
            this.cgB.AllowDragging = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.cgB, 2);
            this.cgB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgB.Dock = System.Windows.Forms.DockStyle.Top;
            this.cgB.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgB.Location = new System.Drawing.Point(17, 71);
            this.cgB.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cgB.Maximum = 255D;
            this.cgB.MaximumSize = new System.Drawing.Size(2550, 20);
            this.cgB.MinimumSize = new System.Drawing.Size(55, 5);
            this.cgB.Name = "cgB";
            this.cgB.NrTicks = 10;
            this.cgB.OverrideBackColor = System.Drawing.Color.Blue;
            this.cgB.ShowTicks = true;
            this.cgB.Size = new System.Drawing.Size(357, 20);
            this.cgB.TabIndex = 5;
            this.cgB.Value = 127D;
            this.cgB.Vertical = false;
            // 
            // nudR
            // 
            this.nudR.AutoSize = true;
            this.nudR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudR.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudR.Location = new System.Drawing.Point(377, 19);
            this.nudR.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.nudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(47, 19);
            this.nudR.TabIndex = 6;
            // 
            // nudG
            // 
            this.nudG.AutoSize = true;
            this.nudG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudG.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudG.Location = new System.Drawing.Point(377, 45);
            this.nudG.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.nudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudG.Name = "nudG";
            this.nudG.Size = new System.Drawing.Size(47, 19);
            this.nudG.TabIndex = 7;
            // 
            // nudB
            // 
            this.nudB.AutoSize = true;
            this.nudB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudB.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudB.Location = new System.Drawing.Point(377, 71);
            this.nudB.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.nudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(47, 19);
            this.nudB.TabIndex = 8;
            // 
            // txtColor
            // 
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtColor.Location = new System.Drawing.Point(20, 97);
            this.txtColor.Mask = "000 000 000";
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 22);
            this.txtColor.TabIndex = 9;
            // 
            // cmbKnownColors
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.cmbKnownColors, 2);
            this.cmbKnownColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKnownColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbKnownColors.FormattingEnabled = true;
            this.cmbKnownColors.Items.AddRange(new object[] {
            System.Drawing.SystemColors.ActiveBorder,
            System.Drawing.SystemColors.ActiveCaption,
            System.Drawing.SystemColors.ActiveCaptionText,
            System.Drawing.SystemColors.AppWorkspace,
            System.Drawing.SystemColors.Control,
            System.Drawing.SystemColors.ControlDark,
            System.Drawing.SystemColors.ControlDarkDark,
            System.Drawing.SystemColors.ControlLight,
            System.Drawing.SystemColors.ControlLightLight,
            System.Drawing.SystemColors.ControlText,
            System.Drawing.SystemColors.Desktop,
            System.Drawing.SystemColors.GrayText,
            System.Drawing.SystemColors.Highlight,
            System.Drawing.SystemColors.HighlightText,
            System.Drawing.SystemColors.HotTrack,
            System.Drawing.SystemColors.InactiveBorder,
            System.Drawing.SystemColors.InactiveCaption,
            System.Drawing.SystemColors.InactiveCaptionText,
            System.Drawing.SystemColors.Info,
            System.Drawing.SystemColors.InfoText,
            System.Drawing.SystemColors.Menu,
            System.Drawing.SystemColors.MenuText,
            System.Drawing.SystemColors.ScrollBar,
            System.Drawing.SystemColors.Window,
            System.Drawing.SystemColors.WindowFrame,
            System.Drawing.SystemColors.WindowText,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.AliceBlue,
            System.Drawing.Color.AntiqueWhite,
            System.Drawing.Color.Aqua,
            System.Drawing.Color.Aquamarine,
            System.Drawing.Color.Azure,
            System.Drawing.Color.Beige,
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black,
            System.Drawing.Color.BlanchedAlmond,
            System.Drawing.Color.Blue,
            System.Drawing.Color.BlueViolet,
            System.Drawing.Color.Brown,
            System.Drawing.Color.BurlyWood,
            System.Drawing.Color.CadetBlue,
            System.Drawing.Color.Chartreuse,
            System.Drawing.Color.Chocolate,
            System.Drawing.Color.Coral,
            System.Drawing.Color.CornflowerBlue,
            System.Drawing.Color.Cornsilk,
            System.Drawing.Color.Crimson,
            System.Drawing.Color.Cyan,
            System.Drawing.Color.DarkBlue,
            System.Drawing.Color.DarkCyan,
            System.Drawing.Color.DarkGoldenrod,
            System.Drawing.Color.DarkGray,
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.DarkKhaki,
            System.Drawing.Color.DarkMagenta,
            System.Drawing.Color.DarkOliveGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkOrchid,
            System.Drawing.Color.DarkRed,
            System.Drawing.Color.DarkSalmon,
            System.Drawing.Color.DarkSeaGreen,
            System.Drawing.Color.DarkSlateBlue,
            System.Drawing.Color.DarkSlateGray,
            System.Drawing.Color.DarkTurquoise,
            System.Drawing.Color.DarkViolet,
            System.Drawing.Color.DeepPink,
            System.Drawing.Color.DeepSkyBlue,
            System.Drawing.Color.DimGray,
            System.Drawing.Color.DodgerBlue,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.FloralWhite,
            System.Drawing.Color.ForestGreen,
            System.Drawing.Color.Fuchsia,
            System.Drawing.Color.Gainsboro,
            System.Drawing.Color.GhostWhite,
            System.Drawing.Color.Gold,
            System.Drawing.Color.Goldenrod,
            System.Drawing.Color.Gray,
            System.Drawing.Color.Green,
            System.Drawing.Color.GreenYellow,
            System.Drawing.Color.Honeydew,
            System.Drawing.Color.HotPink,
            System.Drawing.Color.IndianRed,
            System.Drawing.Color.Indigo,
            System.Drawing.Color.Ivory,
            System.Drawing.Color.Khaki,
            System.Drawing.Color.Lavender,
            System.Drawing.Color.LavenderBlush,
            System.Drawing.Color.LawnGreen,
            System.Drawing.Color.LemonChiffon,
            System.Drawing.Color.LightBlue,
            System.Drawing.Color.LightCoral,
            System.Drawing.Color.LightCyan,
            System.Drawing.Color.LightGoldenrodYellow,
            System.Drawing.Color.LightGray,
            System.Drawing.Color.LightGreen,
            System.Drawing.Color.LightPink,
            System.Drawing.Color.LightSalmon,
            System.Drawing.Color.LightSeaGreen,
            System.Drawing.Color.LightSkyBlue,
            System.Drawing.Color.LightSlateGray,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.LightYellow,
            System.Drawing.Color.Lime,
            System.Drawing.Color.LimeGreen,
            System.Drawing.Color.Linen,
            System.Drawing.Color.Magenta,
            System.Drawing.Color.Maroon,
            System.Drawing.Color.MediumAquamarine,
            System.Drawing.Color.MediumBlue,
            System.Drawing.Color.MediumOrchid,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.MediumSeaGreen,
            System.Drawing.Color.MediumSlateBlue,
            System.Drawing.Color.MediumSpringGreen,
            System.Drawing.Color.MediumTurquoise,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MidnightBlue,
            System.Drawing.Color.MintCream,
            System.Drawing.Color.MistyRose,
            System.Drawing.Color.Moccasin,
            System.Drawing.Color.NavajoWhite,
            System.Drawing.Color.Navy,
            System.Drawing.Color.OldLace,
            System.Drawing.Color.Olive,
            System.Drawing.Color.OliveDrab,
            System.Drawing.Color.Orange,
            System.Drawing.Color.OrangeRed,
            System.Drawing.Color.Orchid,
            System.Drawing.Color.PaleGoldenrod,
            System.Drawing.Color.PaleGreen,
            System.Drawing.Color.PaleTurquoise,
            System.Drawing.Color.PaleVioletRed,
            System.Drawing.Color.PapayaWhip,
            System.Drawing.Color.PeachPuff,
            System.Drawing.Color.Peru,
            System.Drawing.Color.Pink,
            System.Drawing.Color.Plum,
            System.Drawing.Color.PowderBlue,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Red,
            System.Drawing.Color.RosyBrown,
            System.Drawing.Color.RoyalBlue,
            System.Drawing.Color.SaddleBrown,
            System.Drawing.Color.Salmon,
            System.Drawing.Color.SandyBrown,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.SeaShell,
            System.Drawing.Color.Sienna,
            System.Drawing.Color.Silver,
            System.Drawing.Color.SkyBlue,
            System.Drawing.Color.SlateBlue,
            System.Drawing.Color.SlateGray,
            System.Drawing.Color.Snow,
            System.Drawing.Color.SpringGreen,
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.Tan,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Thistle,
            System.Drawing.Color.Tomato,
            System.Drawing.Color.Turquoise,
            System.Drawing.Color.Violet,
            System.Drawing.Color.Wheat,
            System.Drawing.Color.White,
            System.Drawing.Color.WhiteSmoke,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.YellowGreen,
            System.Drawing.SystemColors.ButtonFace,
            System.Drawing.SystemColors.ButtonHighlight,
            System.Drawing.SystemColors.ButtonShadow,
            System.Drawing.SystemColors.GradientActiveCaption,
            System.Drawing.SystemColors.GradientInactiveCaption,
            System.Drawing.SystemColors.MenuBar,
            System.Drawing.SystemColors.MenuHighlight,
            System.Drawing.SystemColors.ActiveBorder,
            System.Drawing.SystemColors.ActiveCaption,
            System.Drawing.SystemColors.ActiveCaptionText,
            System.Drawing.SystemColors.AppWorkspace,
            System.Drawing.SystemColors.Control,
            System.Drawing.SystemColors.ControlDark,
            System.Drawing.SystemColors.ControlDarkDark,
            System.Drawing.SystemColors.ControlLight,
            System.Drawing.SystemColors.ControlLightLight,
            System.Drawing.SystemColors.ControlText,
            System.Drawing.SystemColors.Desktop,
            System.Drawing.SystemColors.GrayText,
            System.Drawing.SystemColors.Highlight,
            System.Drawing.SystemColors.HighlightText,
            System.Drawing.SystemColors.HotTrack,
            System.Drawing.SystemColors.InactiveBorder,
            System.Drawing.SystemColors.InactiveCaption,
            System.Drawing.SystemColors.InactiveCaptionText,
            System.Drawing.SystemColors.Info,
            System.Drawing.SystemColors.InfoText,
            System.Drawing.SystemColors.Menu,
            System.Drawing.SystemColors.MenuText,
            System.Drawing.SystemColors.ScrollBar,
            System.Drawing.SystemColors.Window,
            System.Drawing.SystemColors.WindowFrame,
            System.Drawing.SystemColors.WindowText,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.AliceBlue,
            System.Drawing.Color.AntiqueWhite,
            System.Drawing.Color.Aqua,
            System.Drawing.Color.Aquamarine,
            System.Drawing.Color.Azure,
            System.Drawing.Color.Beige,
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black,
            System.Drawing.Color.BlanchedAlmond,
            System.Drawing.Color.Blue,
            System.Drawing.Color.BlueViolet,
            System.Drawing.Color.Brown,
            System.Drawing.Color.BurlyWood,
            System.Drawing.Color.CadetBlue,
            System.Drawing.Color.Chartreuse,
            System.Drawing.Color.Chocolate,
            System.Drawing.Color.Coral,
            System.Drawing.Color.CornflowerBlue,
            System.Drawing.Color.Cornsilk,
            System.Drawing.Color.Crimson,
            System.Drawing.Color.Cyan,
            System.Drawing.Color.DarkBlue,
            System.Drawing.Color.DarkCyan,
            System.Drawing.Color.DarkGoldenrod,
            System.Drawing.Color.DarkGray,
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.DarkKhaki,
            System.Drawing.Color.DarkMagenta,
            System.Drawing.Color.DarkOliveGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkOrchid,
            System.Drawing.Color.DarkRed,
            System.Drawing.Color.DarkSalmon,
            System.Drawing.Color.DarkSeaGreen,
            System.Drawing.Color.DarkSlateBlue,
            System.Drawing.Color.DarkSlateGray,
            System.Drawing.Color.DarkTurquoise,
            System.Drawing.Color.DarkViolet,
            System.Drawing.Color.DeepPink,
            System.Drawing.Color.DeepSkyBlue,
            System.Drawing.Color.DimGray,
            System.Drawing.Color.DodgerBlue,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.FloralWhite,
            System.Drawing.Color.ForestGreen,
            System.Drawing.Color.Fuchsia,
            System.Drawing.Color.Gainsboro,
            System.Drawing.Color.GhostWhite,
            System.Drawing.Color.Gold,
            System.Drawing.Color.Goldenrod,
            System.Drawing.Color.Gray,
            System.Drawing.Color.Green,
            System.Drawing.Color.GreenYellow,
            System.Drawing.Color.Honeydew,
            System.Drawing.Color.HotPink,
            System.Drawing.Color.IndianRed,
            System.Drawing.Color.Indigo,
            System.Drawing.Color.Ivory,
            System.Drawing.Color.Khaki,
            System.Drawing.Color.Lavender,
            System.Drawing.Color.LavenderBlush,
            System.Drawing.Color.LawnGreen,
            System.Drawing.Color.LemonChiffon,
            System.Drawing.Color.LightBlue,
            System.Drawing.Color.LightCoral,
            System.Drawing.Color.LightCyan,
            System.Drawing.Color.LightGoldenrodYellow,
            System.Drawing.Color.LightGray,
            System.Drawing.Color.LightGreen,
            System.Drawing.Color.LightPink,
            System.Drawing.Color.LightSalmon,
            System.Drawing.Color.LightSeaGreen,
            System.Drawing.Color.LightSkyBlue,
            System.Drawing.Color.LightSlateGray,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.LightYellow,
            System.Drawing.Color.Lime,
            System.Drawing.Color.LimeGreen,
            System.Drawing.Color.Linen,
            System.Drawing.Color.Magenta,
            System.Drawing.Color.Maroon,
            System.Drawing.Color.MediumAquamarine,
            System.Drawing.Color.MediumBlue,
            System.Drawing.Color.MediumOrchid,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.MediumSeaGreen,
            System.Drawing.Color.MediumSlateBlue,
            System.Drawing.Color.MediumSpringGreen,
            System.Drawing.Color.MediumTurquoise,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MidnightBlue,
            System.Drawing.Color.MintCream,
            System.Drawing.Color.MistyRose,
            System.Drawing.Color.Moccasin,
            System.Drawing.Color.NavajoWhite,
            System.Drawing.Color.Navy,
            System.Drawing.Color.OldLace,
            System.Drawing.Color.Olive,
            System.Drawing.Color.OliveDrab,
            System.Drawing.Color.Orange,
            System.Drawing.Color.OrangeRed,
            System.Drawing.Color.Orchid,
            System.Drawing.Color.PaleGoldenrod,
            System.Drawing.Color.PaleGreen,
            System.Drawing.Color.PaleTurquoise,
            System.Drawing.Color.PaleVioletRed,
            System.Drawing.Color.PapayaWhip,
            System.Drawing.Color.PeachPuff,
            System.Drawing.Color.Peru,
            System.Drawing.Color.Pink,
            System.Drawing.Color.Plum,
            System.Drawing.Color.PowderBlue,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Red,
            System.Drawing.Color.RosyBrown,
            System.Drawing.Color.RoyalBlue,
            System.Drawing.Color.SaddleBrown,
            System.Drawing.Color.Salmon,
            System.Drawing.Color.SandyBrown,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.SeaShell,
            System.Drawing.Color.Sienna,
            System.Drawing.Color.Silver,
            System.Drawing.Color.SkyBlue,
            System.Drawing.Color.SlateBlue,
            System.Drawing.Color.SlateGray,
            System.Drawing.Color.Snow,
            System.Drawing.Color.SpringGreen,
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.Tan,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Thistle,
            System.Drawing.Color.Tomato,
            System.Drawing.Color.Turquoise,
            System.Drawing.Color.Violet,
            System.Drawing.Color.Wheat,
            System.Drawing.Color.White,
            System.Drawing.Color.WhiteSmoke,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.YellowGreen,
            System.Drawing.SystemColors.ButtonFace,
            System.Drawing.SystemColors.ButtonHighlight,
            System.Drawing.SystemColors.ButtonShadow,
            System.Drawing.SystemColors.GradientActiveCaption,
            System.Drawing.SystemColors.GradientInactiveCaption,
            System.Drawing.SystemColors.MenuBar,
            System.Drawing.SystemColors.MenuHighlight,
            System.Drawing.SystemColors.ActiveBorder,
            System.Drawing.SystemColors.ActiveCaption,
            System.Drawing.SystemColors.ActiveCaptionText,
            System.Drawing.SystemColors.AppWorkspace,
            System.Drawing.SystemColors.Control,
            System.Drawing.SystemColors.ControlDark,
            System.Drawing.SystemColors.ControlDarkDark,
            System.Drawing.SystemColors.ControlLight,
            System.Drawing.SystemColors.ControlLightLight,
            System.Drawing.SystemColors.ControlText,
            System.Drawing.SystemColors.Desktop,
            System.Drawing.SystemColors.GrayText,
            System.Drawing.SystemColors.Highlight,
            System.Drawing.SystemColors.HighlightText,
            System.Drawing.SystemColors.HotTrack,
            System.Drawing.SystemColors.InactiveBorder,
            System.Drawing.SystemColors.InactiveCaption,
            System.Drawing.SystemColors.InactiveCaptionText,
            System.Drawing.SystemColors.Info,
            System.Drawing.SystemColors.InfoText,
            System.Drawing.SystemColors.Menu,
            System.Drawing.SystemColors.MenuText,
            System.Drawing.SystemColors.ScrollBar,
            System.Drawing.SystemColors.Window,
            System.Drawing.SystemColors.WindowFrame,
            System.Drawing.SystemColors.WindowText,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.AliceBlue,
            System.Drawing.Color.AntiqueWhite,
            System.Drawing.Color.Aqua,
            System.Drawing.Color.Aquamarine,
            System.Drawing.Color.Azure,
            System.Drawing.Color.Beige,
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black,
            System.Drawing.Color.BlanchedAlmond,
            System.Drawing.Color.Blue,
            System.Drawing.Color.BlueViolet,
            System.Drawing.Color.Brown,
            System.Drawing.Color.BurlyWood,
            System.Drawing.Color.CadetBlue,
            System.Drawing.Color.Chartreuse,
            System.Drawing.Color.Chocolate,
            System.Drawing.Color.Coral,
            System.Drawing.Color.CornflowerBlue,
            System.Drawing.Color.Cornsilk,
            System.Drawing.Color.Crimson,
            System.Drawing.Color.Cyan,
            System.Drawing.Color.DarkBlue,
            System.Drawing.Color.DarkCyan,
            System.Drawing.Color.DarkGoldenrod,
            System.Drawing.Color.DarkGray,
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.DarkKhaki,
            System.Drawing.Color.DarkMagenta,
            System.Drawing.Color.DarkOliveGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkOrchid,
            System.Drawing.Color.DarkRed,
            System.Drawing.Color.DarkSalmon,
            System.Drawing.Color.DarkSeaGreen,
            System.Drawing.Color.DarkSlateBlue,
            System.Drawing.Color.DarkSlateGray,
            System.Drawing.Color.DarkTurquoise,
            System.Drawing.Color.DarkViolet,
            System.Drawing.Color.DeepPink,
            System.Drawing.Color.DeepSkyBlue,
            System.Drawing.Color.DimGray,
            System.Drawing.Color.DodgerBlue,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.FloralWhite,
            System.Drawing.Color.ForestGreen,
            System.Drawing.Color.Fuchsia,
            System.Drawing.Color.Gainsboro,
            System.Drawing.Color.GhostWhite,
            System.Drawing.Color.Gold,
            System.Drawing.Color.Goldenrod,
            System.Drawing.Color.Gray,
            System.Drawing.Color.Green,
            System.Drawing.Color.GreenYellow,
            System.Drawing.Color.Honeydew,
            System.Drawing.Color.HotPink,
            System.Drawing.Color.IndianRed,
            System.Drawing.Color.Indigo,
            System.Drawing.Color.Ivory,
            System.Drawing.Color.Khaki,
            System.Drawing.Color.Lavender,
            System.Drawing.Color.LavenderBlush,
            System.Drawing.Color.LawnGreen,
            System.Drawing.Color.LemonChiffon,
            System.Drawing.Color.LightBlue,
            System.Drawing.Color.LightCoral,
            System.Drawing.Color.LightCyan,
            System.Drawing.Color.LightGoldenrodYellow,
            System.Drawing.Color.LightGray,
            System.Drawing.Color.LightGreen,
            System.Drawing.Color.LightPink,
            System.Drawing.Color.LightSalmon,
            System.Drawing.Color.LightSeaGreen,
            System.Drawing.Color.LightSkyBlue,
            System.Drawing.Color.LightSlateGray,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.LightYellow,
            System.Drawing.Color.Lime,
            System.Drawing.Color.LimeGreen,
            System.Drawing.Color.Linen,
            System.Drawing.Color.Magenta,
            System.Drawing.Color.Maroon,
            System.Drawing.Color.MediumAquamarine,
            System.Drawing.Color.MediumBlue,
            System.Drawing.Color.MediumOrchid,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.MediumSeaGreen,
            System.Drawing.Color.MediumSlateBlue,
            System.Drawing.Color.MediumSpringGreen,
            System.Drawing.Color.MediumTurquoise,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MidnightBlue,
            System.Drawing.Color.MintCream,
            System.Drawing.Color.MistyRose,
            System.Drawing.Color.Moccasin,
            System.Drawing.Color.NavajoWhite,
            System.Drawing.Color.Navy,
            System.Drawing.Color.OldLace,
            System.Drawing.Color.Olive,
            System.Drawing.Color.OliveDrab,
            System.Drawing.Color.Orange,
            System.Drawing.Color.OrangeRed,
            System.Drawing.Color.Orchid,
            System.Drawing.Color.PaleGoldenrod,
            System.Drawing.Color.PaleGreen,
            System.Drawing.Color.PaleTurquoise,
            System.Drawing.Color.PaleVioletRed,
            System.Drawing.Color.PapayaWhip,
            System.Drawing.Color.PeachPuff,
            System.Drawing.Color.Peru,
            System.Drawing.Color.Pink,
            System.Drawing.Color.Plum,
            System.Drawing.Color.PowderBlue,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Red,
            System.Drawing.Color.RosyBrown,
            System.Drawing.Color.RoyalBlue,
            System.Drawing.Color.SaddleBrown,
            System.Drawing.Color.Salmon,
            System.Drawing.Color.SandyBrown,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.SeaShell,
            System.Drawing.Color.Sienna,
            System.Drawing.Color.Silver,
            System.Drawing.Color.SkyBlue,
            System.Drawing.Color.SlateBlue,
            System.Drawing.Color.SlateGray,
            System.Drawing.Color.Snow,
            System.Drawing.Color.SpringGreen,
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.Tan,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Thistle,
            System.Drawing.Color.Tomato,
            System.Drawing.Color.Turquoise,
            System.Drawing.Color.Violet,
            System.Drawing.Color.Wheat,
            System.Drawing.Color.White,
            System.Drawing.Color.WhiteSmoke,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.YellowGreen,
            System.Drawing.SystemColors.ButtonFace,
            System.Drawing.SystemColors.ButtonHighlight,
            System.Drawing.SystemColors.ButtonShadow,
            System.Drawing.SystemColors.GradientActiveCaption,
            System.Drawing.SystemColors.GradientInactiveCaption,
            System.Drawing.SystemColors.MenuBar,
            System.Drawing.SystemColors.MenuHighlight,
            System.Drawing.SystemColors.ActiveBorder,
            System.Drawing.SystemColors.ActiveCaption,
            System.Drawing.SystemColors.ActiveCaptionText,
            System.Drawing.SystemColors.AppWorkspace,
            System.Drawing.SystemColors.Control,
            System.Drawing.SystemColors.ControlDark,
            System.Drawing.SystemColors.ControlDarkDark,
            System.Drawing.SystemColors.ControlLight,
            System.Drawing.SystemColors.ControlLightLight,
            System.Drawing.SystemColors.ControlText,
            System.Drawing.SystemColors.Desktop,
            System.Drawing.SystemColors.GrayText,
            System.Drawing.SystemColors.Highlight,
            System.Drawing.SystemColors.HighlightText,
            System.Drawing.SystemColors.HotTrack,
            System.Drawing.SystemColors.InactiveBorder,
            System.Drawing.SystemColors.InactiveCaption,
            System.Drawing.SystemColors.InactiveCaptionText,
            System.Drawing.SystemColors.Info,
            System.Drawing.SystemColors.InfoText,
            System.Drawing.SystemColors.Menu,
            System.Drawing.SystemColors.MenuText,
            System.Drawing.SystemColors.ScrollBar,
            System.Drawing.SystemColors.Window,
            System.Drawing.SystemColors.WindowFrame,
            System.Drawing.SystemColors.WindowText,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.AliceBlue,
            System.Drawing.Color.AntiqueWhite,
            System.Drawing.Color.Aqua,
            System.Drawing.Color.Aquamarine,
            System.Drawing.Color.Azure,
            System.Drawing.Color.Beige,
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black,
            System.Drawing.Color.BlanchedAlmond,
            System.Drawing.Color.Blue,
            System.Drawing.Color.BlueViolet,
            System.Drawing.Color.Brown,
            System.Drawing.Color.BurlyWood,
            System.Drawing.Color.CadetBlue,
            System.Drawing.Color.Chartreuse,
            System.Drawing.Color.Chocolate,
            System.Drawing.Color.Coral,
            System.Drawing.Color.CornflowerBlue,
            System.Drawing.Color.Cornsilk,
            System.Drawing.Color.Crimson,
            System.Drawing.Color.Cyan,
            System.Drawing.Color.DarkBlue,
            System.Drawing.Color.DarkCyan,
            System.Drawing.Color.DarkGoldenrod,
            System.Drawing.Color.DarkGray,
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.DarkKhaki,
            System.Drawing.Color.DarkMagenta,
            System.Drawing.Color.DarkOliveGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkOrchid,
            System.Drawing.Color.DarkRed,
            System.Drawing.Color.DarkSalmon,
            System.Drawing.Color.DarkSeaGreen,
            System.Drawing.Color.DarkSlateBlue,
            System.Drawing.Color.DarkSlateGray,
            System.Drawing.Color.DarkTurquoise,
            System.Drawing.Color.DarkViolet,
            System.Drawing.Color.DeepPink,
            System.Drawing.Color.DeepSkyBlue,
            System.Drawing.Color.DimGray,
            System.Drawing.Color.DodgerBlue,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.FloralWhite,
            System.Drawing.Color.ForestGreen,
            System.Drawing.Color.Fuchsia,
            System.Drawing.Color.Gainsboro,
            System.Drawing.Color.GhostWhite,
            System.Drawing.Color.Gold,
            System.Drawing.Color.Goldenrod,
            System.Drawing.Color.Gray,
            System.Drawing.Color.Green,
            System.Drawing.Color.GreenYellow,
            System.Drawing.Color.Honeydew,
            System.Drawing.Color.HotPink,
            System.Drawing.Color.IndianRed,
            System.Drawing.Color.Indigo,
            System.Drawing.Color.Ivory,
            System.Drawing.Color.Khaki,
            System.Drawing.Color.Lavender,
            System.Drawing.Color.LavenderBlush,
            System.Drawing.Color.LawnGreen,
            System.Drawing.Color.LemonChiffon,
            System.Drawing.Color.LightBlue,
            System.Drawing.Color.LightCoral,
            System.Drawing.Color.LightCyan,
            System.Drawing.Color.LightGoldenrodYellow,
            System.Drawing.Color.LightGray,
            System.Drawing.Color.LightGreen,
            System.Drawing.Color.LightPink,
            System.Drawing.Color.LightSalmon,
            System.Drawing.Color.LightSeaGreen,
            System.Drawing.Color.LightSkyBlue,
            System.Drawing.Color.LightSlateGray,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.LightYellow,
            System.Drawing.Color.Lime,
            System.Drawing.Color.LimeGreen,
            System.Drawing.Color.Linen,
            System.Drawing.Color.Magenta,
            System.Drawing.Color.Maroon,
            System.Drawing.Color.MediumAquamarine,
            System.Drawing.Color.MediumBlue,
            System.Drawing.Color.MediumOrchid,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.MediumSeaGreen,
            System.Drawing.Color.MediumSlateBlue,
            System.Drawing.Color.MediumSpringGreen,
            System.Drawing.Color.MediumTurquoise,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MidnightBlue,
            System.Drawing.Color.MintCream,
            System.Drawing.Color.MistyRose,
            System.Drawing.Color.Moccasin,
            System.Drawing.Color.NavajoWhite,
            System.Drawing.Color.Navy,
            System.Drawing.Color.OldLace,
            System.Drawing.Color.Olive,
            System.Drawing.Color.OliveDrab,
            System.Drawing.Color.Orange,
            System.Drawing.Color.OrangeRed,
            System.Drawing.Color.Orchid,
            System.Drawing.Color.PaleGoldenrod,
            System.Drawing.Color.PaleGreen,
            System.Drawing.Color.PaleTurquoise,
            System.Drawing.Color.PaleVioletRed,
            System.Drawing.Color.PapayaWhip,
            System.Drawing.Color.PeachPuff,
            System.Drawing.Color.Peru,
            System.Drawing.Color.Pink,
            System.Drawing.Color.Plum,
            System.Drawing.Color.PowderBlue,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Red,
            System.Drawing.Color.RosyBrown,
            System.Drawing.Color.RoyalBlue,
            System.Drawing.Color.SaddleBrown,
            System.Drawing.Color.Salmon,
            System.Drawing.Color.SandyBrown,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.SeaShell,
            System.Drawing.Color.Sienna,
            System.Drawing.Color.Silver,
            System.Drawing.Color.SkyBlue,
            System.Drawing.Color.SlateBlue,
            System.Drawing.Color.SlateGray,
            System.Drawing.Color.Snow,
            System.Drawing.Color.SpringGreen,
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.Tan,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Thistle,
            System.Drawing.Color.Tomato,
            System.Drawing.Color.Turquoise,
            System.Drawing.Color.Violet,
            System.Drawing.Color.Wheat,
            System.Drawing.Color.White,
            System.Drawing.Color.WhiteSmoke,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.YellowGreen,
            System.Drawing.SystemColors.ButtonFace,
            System.Drawing.SystemColors.ButtonHighlight,
            System.Drawing.SystemColors.ButtonShadow,
            System.Drawing.SystemColors.GradientActiveCaption,
            System.Drawing.SystemColors.GradientInactiveCaption,
            System.Drawing.SystemColors.MenuBar,
            System.Drawing.SystemColors.MenuHighlight,
            System.Drawing.SystemColors.ActiveBorder,
            System.Drawing.SystemColors.ActiveCaption,
            System.Drawing.SystemColors.ActiveCaptionText,
            System.Drawing.SystemColors.AppWorkspace,
            System.Drawing.SystemColors.Control,
            System.Drawing.SystemColors.ControlDark,
            System.Drawing.SystemColors.ControlDarkDark,
            System.Drawing.SystemColors.ControlLight,
            System.Drawing.SystemColors.ControlLightLight,
            System.Drawing.SystemColors.ControlText,
            System.Drawing.SystemColors.Desktop,
            System.Drawing.SystemColors.GrayText,
            System.Drawing.SystemColors.Highlight,
            System.Drawing.SystemColors.HighlightText,
            System.Drawing.SystemColors.HotTrack,
            System.Drawing.SystemColors.InactiveBorder,
            System.Drawing.SystemColors.InactiveCaption,
            System.Drawing.SystemColors.InactiveCaptionText,
            System.Drawing.SystemColors.Info,
            System.Drawing.SystemColors.InfoText,
            System.Drawing.SystemColors.Menu,
            System.Drawing.SystemColors.MenuText,
            System.Drawing.SystemColors.ScrollBar,
            System.Drawing.SystemColors.Window,
            System.Drawing.SystemColors.WindowFrame,
            System.Drawing.SystemColors.WindowText,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.AliceBlue,
            System.Drawing.Color.AntiqueWhite,
            System.Drawing.Color.Aqua,
            System.Drawing.Color.Aquamarine,
            System.Drawing.Color.Azure,
            System.Drawing.Color.Beige,
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black,
            System.Drawing.Color.BlanchedAlmond,
            System.Drawing.Color.Blue,
            System.Drawing.Color.BlueViolet,
            System.Drawing.Color.Brown,
            System.Drawing.Color.BurlyWood,
            System.Drawing.Color.CadetBlue,
            System.Drawing.Color.Chartreuse,
            System.Drawing.Color.Chocolate,
            System.Drawing.Color.Coral,
            System.Drawing.Color.CornflowerBlue,
            System.Drawing.Color.Cornsilk,
            System.Drawing.Color.Crimson,
            System.Drawing.Color.Cyan,
            System.Drawing.Color.DarkBlue,
            System.Drawing.Color.DarkCyan,
            System.Drawing.Color.DarkGoldenrod,
            System.Drawing.Color.DarkGray,
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.DarkKhaki,
            System.Drawing.Color.DarkMagenta,
            System.Drawing.Color.DarkOliveGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkOrchid,
            System.Drawing.Color.DarkRed,
            System.Drawing.Color.DarkSalmon,
            System.Drawing.Color.DarkSeaGreen,
            System.Drawing.Color.DarkSlateBlue,
            System.Drawing.Color.DarkSlateGray,
            System.Drawing.Color.DarkTurquoise,
            System.Drawing.Color.DarkViolet,
            System.Drawing.Color.DeepPink,
            System.Drawing.Color.DeepSkyBlue,
            System.Drawing.Color.DimGray,
            System.Drawing.Color.DodgerBlue,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.FloralWhite,
            System.Drawing.Color.ForestGreen,
            System.Drawing.Color.Fuchsia,
            System.Drawing.Color.Gainsboro,
            System.Drawing.Color.GhostWhite,
            System.Drawing.Color.Gold,
            System.Drawing.Color.Goldenrod,
            System.Drawing.Color.Gray,
            System.Drawing.Color.Green,
            System.Drawing.Color.GreenYellow,
            System.Drawing.Color.Honeydew,
            System.Drawing.Color.HotPink,
            System.Drawing.Color.IndianRed,
            System.Drawing.Color.Indigo,
            System.Drawing.Color.Ivory,
            System.Drawing.Color.Khaki,
            System.Drawing.Color.Lavender,
            System.Drawing.Color.LavenderBlush,
            System.Drawing.Color.LawnGreen,
            System.Drawing.Color.LemonChiffon,
            System.Drawing.Color.LightBlue,
            System.Drawing.Color.LightCoral,
            System.Drawing.Color.LightCyan,
            System.Drawing.Color.LightGoldenrodYellow,
            System.Drawing.Color.LightGray,
            System.Drawing.Color.LightGreen,
            System.Drawing.Color.LightPink,
            System.Drawing.Color.LightSalmon,
            System.Drawing.Color.LightSeaGreen,
            System.Drawing.Color.LightSkyBlue,
            System.Drawing.Color.LightSlateGray,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.LightYellow,
            System.Drawing.Color.Lime,
            System.Drawing.Color.LimeGreen,
            System.Drawing.Color.Linen,
            System.Drawing.Color.Magenta,
            System.Drawing.Color.Maroon,
            System.Drawing.Color.MediumAquamarine,
            System.Drawing.Color.MediumBlue,
            System.Drawing.Color.MediumOrchid,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.MediumSeaGreen,
            System.Drawing.Color.MediumSlateBlue,
            System.Drawing.Color.MediumSpringGreen,
            System.Drawing.Color.MediumTurquoise,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MidnightBlue,
            System.Drawing.Color.MintCream,
            System.Drawing.Color.MistyRose,
            System.Drawing.Color.Moccasin,
            System.Drawing.Color.NavajoWhite,
            System.Drawing.Color.Navy,
            System.Drawing.Color.OldLace,
            System.Drawing.Color.Olive,
            System.Drawing.Color.OliveDrab,
            System.Drawing.Color.Orange,
            System.Drawing.Color.OrangeRed,
            System.Drawing.Color.Orchid,
            System.Drawing.Color.PaleGoldenrod,
            System.Drawing.Color.PaleGreen,
            System.Drawing.Color.PaleTurquoise,
            System.Drawing.Color.PaleVioletRed,
            System.Drawing.Color.PapayaWhip,
            System.Drawing.Color.PeachPuff,
            System.Drawing.Color.Peru,
            System.Drawing.Color.Pink,
            System.Drawing.Color.Plum,
            System.Drawing.Color.PowderBlue,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Red,
            System.Drawing.Color.RosyBrown,
            System.Drawing.Color.RoyalBlue,
            System.Drawing.Color.SaddleBrown,
            System.Drawing.Color.Salmon,
            System.Drawing.Color.SandyBrown,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.SeaShell,
            System.Drawing.Color.Sienna,
            System.Drawing.Color.Silver,
            System.Drawing.Color.SkyBlue,
            System.Drawing.Color.SlateBlue,
            System.Drawing.Color.SlateGray,
            System.Drawing.Color.Snow,
            System.Drawing.Color.SpringGreen,
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.Tan,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Thistle,
            System.Drawing.Color.Tomato,
            System.Drawing.Color.Turquoise,
            System.Drawing.Color.Violet,
            System.Drawing.Color.Wheat,
            System.Drawing.Color.White,
            System.Drawing.Color.WhiteSmoke,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.YellowGreen,
            System.Drawing.SystemColors.ButtonFace,
            System.Drawing.SystemColors.ButtonHighlight,
            System.Drawing.SystemColors.ButtonShadow,
            System.Drawing.SystemColors.GradientActiveCaption,
            System.Drawing.SystemColors.GradientInactiveCaption,
            System.Drawing.SystemColors.MenuBar,
            System.Drawing.SystemColors.MenuHighlight});
            this.cmbKnownColors.Location = new System.Drawing.Point(200, 97);
            this.cmbKnownColors.Name = "cmbKnownColors";
            this.cmbKnownColors.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbKnownColors.Size = new System.Drawing.Size(224, 23);
            this.cmbKnownColors.TabIndex = 11;
            // 
            // lblResultingColor
            // 
            this.lblResultingColor.AutoSize = true;
            this.lblResultingColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblResultingColor, 2);
            this.lblResultingColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblResultingColor.Location = new System.Drawing.Point(200, 123);
            this.lblResultingColor.Name = "lblResultingColor";
            this.lblResultingColor.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblResultingColor.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblResultingColor.Size = new System.Drawing.Size(224, 20);
            this.lblResultingColor.TabIndex = 13;
            // 
            // OPMColorChooserCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "OPMColorChooserCtl";
            this.Size = new System.Drawing.Size(427, 143);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMLabel opmLabel1;
        private OPMLabel opmLabel2;
        private OPMLabel opmLabel3;
        private ControlGauge cgR;
        private ControlGauge cgG;
        private ControlGauge cgB;
        private OPMNumericUpDown nudR;
        private OPMNumericUpDown nudG;
        private OPMNumericUpDown nudB;
        private System.Windows.Forms.MaskedTextBox txtColor;
        private OPMLabel lblColorName;
        private ColorComboBox cmbKnownColors;
        private OPMLabel opmLabel4;
        private OPMLabel lblResultingColor;

    }
}
