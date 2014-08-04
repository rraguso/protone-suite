
using OPMedia.UI.Controls;
namespace OPMedia.ServiceHelper.RCCService.Configuration
{
    partial class SerialDeviceTuningDlg
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
            this.lblDesc = new OPMedia.UI.Controls.OPMLabel();
            this.cgICWG = new OPMedia.UI.Controls.ControlGauge();
            this.cgMinCW = new OPMedia.UI.Controls.ControlGauge();
            this.cgMaxCW = new OPMedia.UI.Controls.ControlGauge();
            this.cgMinCWOcc = new OPMedia.UI.Controls.ControlGauge();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.label4 = new OPMedia.UI.Controls.OPMLabel();
            this.lblDetCW = new OPMedia.UI.Controls.OPMLabel();
            this.lblERFC = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.btnICWGMinus = new OPMedia.UI.Controls.OPMButton();
            this.btnICWGPlus = new OPMedia.UI.Controls.OPMButton();
            this.btnMinCWMinus = new OPMedia.UI.Controls.OPMButton();
            this.btnMinCWPlus = new OPMedia.UI.Controls.OPMButton();
            this.btnMaxCWMinus = new OPMedia.UI.Controls.OPMButton();
            this.btnMaxCWPlus = new OPMedia.UI.Controls.OPMButton();
            this.btnMinCWOccMinus = new OPMedia.UI.Controls.OPMButton();
            this.btnMinCWOccPlus = new OPMedia.UI.Controls.OPMButton();
            this.label5 = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmFlowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.opmFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(3, 170);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.SetRowSpan(this.lblDesc, 4);
            this.lblDesc.Size = new System.Drawing.Size(38, 80);
            this.lblDesc.TabIndex = 17;
            this.lblDesc.Text = "label1";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cgICWG
            // 
            this.cgICWG.AllowDragging = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cgICWG, 2);
            this.cgICWG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgICWG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgICWG.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgICWG.Location = new System.Drawing.Point(3, 46);
            this.cgICWG.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cgICWG.Maximum = 50000D;
            this.cgICWG.Name = "cgICWG";
            this.cgICWG.NrTicks = 100;
            this.cgICWG.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgICWG.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.cgICWG.ShowTicks = true;
            this.cgICWG.Size = new System.Drawing.Size(526, 15);
            this.cgICWG.TabIndex = 2;
            this.cgICWG.Value = 0D;
            this.cgICWG.Vertical = false;
            this.cgICWG.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.OnDataChanged);
            // 
            // cgMinCW
            // 
            this.cgMinCW.AllowDragging = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cgMinCW, 2);
            this.cgMinCW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgMinCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgMinCW.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgMinCW.Location = new System.Drawing.Point(3, 77);
            this.cgMinCW.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cgMinCW.Maximum = 50D;
            this.cgMinCW.Name = "cgMinCW";
            this.cgMinCW.NrTicks = 20;
            this.cgMinCW.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgMinCW.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.cgMinCW.ShowTicks = true;
            this.cgMinCW.Size = new System.Drawing.Size(526, 15);
            this.cgMinCW.TabIndex = 6;
            this.cgMinCW.Value = 0D;
            this.cgMinCW.Vertical = false;
            this.cgMinCW.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.OnDataChanged);
            // 
            // cgMaxCW
            // 
            this.cgMaxCW.AllowDragging = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cgMaxCW, 2);
            this.cgMaxCW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgMaxCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgMaxCW.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgMaxCW.Location = new System.Drawing.Point(3, 108);
            this.cgMaxCW.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cgMaxCW.Maximum = 100D;
            this.cgMaxCW.Name = "cgMaxCW";
            this.cgMaxCW.NrTicks = 20;
            this.cgMaxCW.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgMaxCW.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.cgMaxCW.ShowTicks = true;
            this.cgMaxCW.Size = new System.Drawing.Size(526, 15);
            this.cgMaxCW.TabIndex = 10;
            this.cgMaxCW.Value = 0D;
            this.cgMaxCW.Vertical = false;
            this.cgMaxCW.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.OnDataChanged);
            // 
            // cgMinCWOcc
            // 
            this.cgMinCWOcc.AllowDragging = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cgMinCWOcc, 2);
            this.cgMinCWOcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cgMinCWOcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgMinCWOcc.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.cgMinCWOcc.Location = new System.Drawing.Point(3, 139);
            this.cgMinCWOcc.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cgMinCWOcc.Maximum = 10D;
            this.cgMinCWOcc.Name = "cgMinCWOcc";
            this.cgMinCWOcc.NrTicks = 5;
            this.cgMinCWOcc.OverrideBackColor = System.Drawing.Color.Empty;
            this.cgMinCWOcc.OverrideElapsedBackColor = System.Drawing.Color.Empty;
            this.cgMinCWOcc.ShowTicks = true;
            this.cgMinCWOcc.Size = new System.Drawing.Size(526, 15);
            this.cgMinCWOcc.TabIndex = 14;
            this.cgMinCWOcc.Value = 0D;
            this.cgMinCWOcc.Vertical = false;
            this.cgMinCWOcc.PositionChanged += new OPMedia.UI.Controls.ValueChangedEventHandler(this.OnDataChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(523, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TXT_INTERCODEWORDSGAP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(523, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "TXT_MINCODEWORDLENGTH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(523, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "TXT_MAXCODEWORDLENGTH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.OverrideBackColor = System.Drawing.Color.Empty;
            this.label4.OverrideForeColor = System.Drawing.Color.Empty;
            this.label4.Size = new System.Drawing.Size(523, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "TXT_MINCODEWORDOCCURENCES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetCW
            // 
            this.lblDetCW.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDetCW, 4);
            this.lblDetCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDetCW.Location = new System.Drawing.Point(47, 193);
            this.lblDetCW.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblDetCW.Name = "lblDetCW";
            this.lblDetCW.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDetCW.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDetCW.Size = new System.Drawing.Size(518, 14);
            this.lblDetCW.TabIndex = 18;
            this.lblDetCW.Text = "TXT_DETECTEDCODEWORD";
            this.lblDetCW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblERFC
            // 
            this.lblERFC.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblERFC, 4);
            this.lblERFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblERFC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblERFC.Location = new System.Drawing.Point(47, 213);
            this.lblERFC.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblERFC.Name = "lblERFC";
            this.lblERFC.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblERFC.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblERFC.Size = new System.Drawing.Size(518, 14);
            this.lblERFC.TabIndex = 19;
            this.lblERFC.Text = "TXT_ERRORFACTOR";
            this.lblERFC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(481, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ShowDropDown = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(420, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.ShowDropDown = false;
            this.btnOk.Size = new System.Drawing.Size(55, 25);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "TXT_OK";
            // 
            // btnICWGMinus
            // 
            this.btnICWGMinus.AutoSize = true;
            this.btnICWGMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnICWGMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnICWGMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnICWGMinus.Location = new System.Drawing.Point(534, 46);
            this.btnICWGMinus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnICWGMinus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnICWGMinus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnICWGMinus.Name = "btnICWGMinus";
            this.btnICWGMinus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnICWGMinus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnICWGMinus.ShowDropDown = false;
            this.btnICWGMinus.Size = new System.Drawing.Size(15, 15);
            this.btnICWGMinus.TabIndex = 3;
            this.btnICWGMinus.Text = "-";
            this.btnICWGMinus.Click += new System.EventHandler(this.btnICWGMinus_Click);
            // 
            // btnICWGPlus
            // 
            this.btnICWGPlus.AutoSize = true;
            this.btnICWGPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnICWGPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnICWGPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnICWGPlus.Location = new System.Drawing.Point(552, 46);
            this.btnICWGPlus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnICWGPlus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnICWGPlus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnICWGPlus.Name = "btnICWGPlus";
            this.btnICWGPlus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnICWGPlus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnICWGPlus.ShowDropDown = false;
            this.btnICWGPlus.Size = new System.Drawing.Size(15, 15);
            this.btnICWGPlus.TabIndex = 4;
            this.btnICWGPlus.Text = "+";
            this.btnICWGPlus.Click += new System.EventHandler(this.btnICWGPlus_Click);
            // 
            // btnMinCWMinus
            // 
            this.btnMinCWMinus.AutoSize = true;
            this.btnMinCWMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinCWMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinCWMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinCWMinus.Location = new System.Drawing.Point(534, 77);
            this.btnMinCWMinus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMinCWMinus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWMinus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWMinus.Name = "btnMinCWMinus";
            this.btnMinCWMinus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMinCWMinus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMinCWMinus.ShowDropDown = false;
            this.btnMinCWMinus.Size = new System.Drawing.Size(15, 15);
            this.btnMinCWMinus.TabIndex = 7;
            this.btnMinCWMinus.Text = "-";
            this.btnMinCWMinus.Click += new System.EventHandler(this.btnMinCWMinus_Click);
            // 
            // btnMinCWPlus
            // 
            this.btnMinCWPlus.AutoSize = true;
            this.btnMinCWPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinCWPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinCWPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinCWPlus.Location = new System.Drawing.Point(552, 77);
            this.btnMinCWPlus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMinCWPlus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWPlus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWPlus.Name = "btnMinCWPlus";
            this.btnMinCWPlus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMinCWPlus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMinCWPlus.ShowDropDown = false;
            this.btnMinCWPlus.Size = new System.Drawing.Size(15, 15);
            this.btnMinCWPlus.TabIndex = 8;
            this.btnMinCWPlus.Text = "+";
            this.btnMinCWPlus.Click += new System.EventHandler(this.btnMinCWPlus_Click);
            // 
            // btnMaxCWMinus
            // 
            this.btnMaxCWMinus.AutoSize = true;
            this.btnMaxCWMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMaxCWMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxCWMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxCWMinus.Location = new System.Drawing.Point(534, 108);
            this.btnMaxCWMinus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMaxCWMinus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMaxCWMinus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMaxCWMinus.Name = "btnMaxCWMinus";
            this.btnMaxCWMinus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMaxCWMinus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMaxCWMinus.ShowDropDown = false;
            this.btnMaxCWMinus.Size = new System.Drawing.Size(15, 15);
            this.btnMaxCWMinus.TabIndex = 11;
            this.btnMaxCWMinus.Text = "-";
            this.btnMaxCWMinus.Click += new System.EventHandler(this.btnMaxCWMinus_Click);
            // 
            // btnMaxCWPlus
            // 
            this.btnMaxCWPlus.AutoSize = true;
            this.btnMaxCWPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMaxCWPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxCWPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxCWPlus.Location = new System.Drawing.Point(552, 108);
            this.btnMaxCWPlus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMaxCWPlus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMaxCWPlus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMaxCWPlus.Name = "btnMaxCWPlus";
            this.btnMaxCWPlus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMaxCWPlus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMaxCWPlus.ShowDropDown = false;
            this.btnMaxCWPlus.Size = new System.Drawing.Size(15, 15);
            this.btnMaxCWPlus.TabIndex = 12;
            this.btnMaxCWPlus.Text = "+";
            this.btnMaxCWPlus.Click += new System.EventHandler(this.btnMaxCWPlus_Click);
            // 
            // btnMinCWOccMinus
            // 
            this.btnMinCWOccMinus.AutoSize = true;
            this.btnMinCWOccMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinCWOccMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinCWOccMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinCWOccMinus.Location = new System.Drawing.Point(534, 139);
            this.btnMinCWOccMinus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMinCWOccMinus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWOccMinus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWOccMinus.Name = "btnMinCWOccMinus";
            this.btnMinCWOccMinus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMinCWOccMinus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMinCWOccMinus.ShowDropDown = false;
            this.btnMinCWOccMinus.Size = new System.Drawing.Size(15, 15);
            this.btnMinCWOccMinus.TabIndex = 15;
            this.btnMinCWOccMinus.Text = "-";
            this.btnMinCWOccMinus.Click += new System.EventHandler(this.btnMinCWOccMinus_Click);
            // 
            // btnMinCWOccPlus
            // 
            this.btnMinCWOccPlus.AutoSize = true;
            this.btnMinCWOccPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinCWOccPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinCWOccPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinCWOccPlus.Location = new System.Drawing.Point(552, 139);
            this.btnMinCWOccPlus.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnMinCWOccPlus.MaximumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWOccPlus.MinimumSize = new System.Drawing.Size(15, 15);
            this.btnMinCWOccPlus.Name = "btnMinCWOccPlus";
            this.btnMinCWOccPlus.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnMinCWOccPlus.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnMinCWOccPlus.ShowDropDown = false;
            this.btnMinCWOccPlus.Size = new System.Drawing.Size(15, 15);
            this.btnMinCWOccPlus.TabIndex = 16;
            this.btnMinCWOccPlus.Text = "+";
            this.btnMinCWOccPlus.Click += new System.EventHandler(this.btnMinCWOccPlus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.OverrideBackColor = System.Drawing.Color.Empty;
            this.label5.OverrideForeColor = System.Drawing.Color.Empty;
            this.label5.Size = new System.Drawing.Size(523, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "TXT_FINETUNEDESC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.opmFlowLayoutPanel1, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.btnMinCWOccPlus, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDesc, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblERFC, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDetCW, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnMinCWOccMinus, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnICWGPlus, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnICWGMinus, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnMinCWPlus, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnMinCWMinus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnMaxCWPlus, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnMaxCWMinus, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.cgICWG, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cgMinCW, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cgMaxCW, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cgMinCWOcc, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 287);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // opmFlowLayoutPanel1
            // 
            this.opmFlowLayoutPanel1.AutoSize = true;
            this.opmFlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.opmFlowLayoutPanel1, 5);
            this.opmFlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.opmFlowLayoutPanel1.Controls.Add(this.btnOk);
            this.opmFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.opmFlowLayoutPanel1.Location = new System.Drawing.Point(3, 253);
            this.opmFlowLayoutPanel1.Name = "opmFlowLayoutPanel1";
            this.opmFlowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmFlowLayoutPanel1.Size = new System.Drawing.Size(564, 31);
            this.opmFlowLayoutPanel1.TabIndex = 23;
            // 
            // SerialDeviceTuningDlg
            // 
            this.ClientSize = new System.Drawing.Size(572, 310);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "SerialDeviceTuningDlg";
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.opmFlowLayoutPanel1.ResumeLayout(false);
            this.opmFlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel lblDesc;
        private ControlGauge cgICWG;
        private OPMLabel label1;
        private ControlGauge cgMinCWOcc;
        private ControlGauge cgMaxCW;
        private ControlGauge cgMinCW;
        private OPMLabel label4;
        private OPMLabel label3;
        private OPMLabel label2;
        private OPMLabel lblERFC;
        private OPMLabel lblDetCW;
        private OPMButton btnCancel;
        private OPMButton btnOk;
        private OPMButton btnMinCWOccMinus;
        private OPMButton btnMinCWOccPlus;
        private OPMButton btnMaxCWMinus;
        private OPMButton btnMaxCWPlus;
        private OPMButton btnMinCWMinus;
        private OPMButton btnMinCWPlus;
        private OPMButton btnICWGMinus;
        private OPMButton btnICWGPlus;
        private OPMLabel label5;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMFlowLayoutPanel opmFlowLayoutPanel1;
    }
}