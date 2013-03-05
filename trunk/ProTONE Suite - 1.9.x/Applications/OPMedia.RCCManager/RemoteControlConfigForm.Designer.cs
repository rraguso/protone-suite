using OPMedia.UI.Controls;
using System.Windows.Forms;
using System;

namespace OPMedia.RCCManager
{
    partial class RemoteControlConfigForm
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
            this.components = new System.ComponentModel.Container();
            this.llInputCfgData = new OPMedia.UI.Controls.OPMLinkLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.groupBox2 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.llOutputCfgData = new OPMedia.UI.Controls.OPMLinkLabel();
            this.label8 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbOutputPins = new OPMedia.UI.Controls.OPMComboBox();
            this.label6 = new OPMedia.UI.Controls.OPMLabel();
            this.groupBox1 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel3 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.label7 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbInputPins = new OPMedia.UI.Controls.OPMComboBox();
            this.label5 = new OPMedia.UI.Controls.OPMLabel();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.chkEnabled = new OPMedia.UI.Controls.OPMCheckBox();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.btnDelete = new OPMedia.UI.Controls.OPMButton();
            this.btnChange = new OPMedia.UI.Controls.OPMButton();
            this.label4 = new OPMedia.UI.Controls.OPMLabel();
            this.lvButtons = new OPMedia.UI.Controls.OPMListView();
            this.colActionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInputData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutputData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTargetWnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChange = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiDelete = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsmiEnable = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.btnAdd = new OPMedia.UI.Controls.OPMButton();
            this.txtRemoteName = new OPMedia.UI.Controls.OPMTextBox();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.opmTableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.opmTableLayoutPanel3.SuspendLayout();
            this.cmsList.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // llInputCfgData
            // 
            this.llInputCfgData.AutoSize = true;
            this.llInputCfgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llInputCfgData.Location = new System.Drawing.Point(0, 58);
            this.llInputCfgData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.llInputCfgData.Name = "llInputCfgData";
            this.llInputCfgData.Size = new System.Drawing.Size(240, 15);
            this.llInputCfgData.TabIndex = 3;
            this.llInputCfgData.TabStop = true;
            this.llInputCfgData.Text = "TXT_ENTERDATA";
            this.llInputCfgData.Click += new System.EventHandler(this.OnDefineCfgData);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 104);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.opmTableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.Location = new System.Drawing.Point(255, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TXT_OUTPUTPINDATA";
            // 
            // opmTableLayoutPanel2
            // 
            this.opmTableLayoutPanel2.AutoSize = true;
            this.opmTableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel2.ColumnCount = 1;
            this.opmTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Controls.Add(this.llOutputCfgData, 0, 3);
            this.opmTableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.opmTableLayoutPanel2.Controls.Add(this.cmbOutputPins, 0, 1);
            this.opmTableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.opmTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.opmTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.opmTableLayoutPanel2.Name = "opmTableLayoutPanel2";
            this.opmTableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel2.RowCount = 4;
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Size = new System.Drawing.Size(241, 76);
            this.opmTableLayoutPanel2.TabIndex = 4;
            // 
            // llOutputCfgData
            // 
            this.llOutputCfgData.AutoSize = true;
            this.llOutputCfgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llOutputCfgData.Location = new System.Drawing.Point(0, 58);
            this.llOutputCfgData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.llOutputCfgData.Name = "llOutputCfgData";
            this.llOutputCfgData.Size = new System.Drawing.Size(241, 15);
            this.llOutputCfgData.TabIndex = 3;
            this.llOutputCfgData.TabStop = true;
            this.llOutputCfgData.Text = "TXT_ENTERDATA";
            this.llOutputCfgData.Click += new System.EventHandler(this.OnDefineCfgData);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.label8.Location = new System.Drawing.Point(0, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label8.Name = "label8";
            this.label8.OverrideBackColor = System.Drawing.Color.Empty;
            this.label8.OverrideForeColor = System.Drawing.Color.Empty;
            this.label8.Size = new System.Drawing.Size(241, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "TXT_CFGDATA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOutputPins
            // 
            this.cmbOutputPins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOutputPins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbOutputPins.FormattingEnabled = true;
            this.cmbOutputPins.Location = new System.Drawing.Point(0, 16);
            this.cmbOutputPins.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbOutputPins.Name = "cmbOutputPins";
            this.cmbOutputPins.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbOutputPins.Size = new System.Drawing.Size(241, 23);
            this.cmbOutputPins.TabIndex = 1;
            this.cmbOutputPins.SelectedIndexChanged += new System.EventHandler(this.OnOutputPinChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Name = "label6";
            this.label6.OverrideBackColor = System.Drawing.Color.Empty;
            this.label6.OverrideForeColor = System.Drawing.Color.Empty;
            this.label6.Size = new System.Drawing.Size(241, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "TXT_PINTYPE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.opmTableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TXT_INPUTPINDATA";
            // 
            // opmTableLayoutPanel3
            // 
            this.opmTableLayoutPanel3.AutoSize = true;
            this.opmTableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel3.ColumnCount = 1;
            this.opmTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel3.Controls.Add(this.llInputCfgData, 0, 3);
            this.opmTableLayoutPanel3.Controls.Add(this.label7, 0, 2);
            this.opmTableLayoutPanel3.Controls.Add(this.cmbInputPins, 0, 1);
            this.opmTableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.opmTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.opmTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.opmTableLayoutPanel3.Name = "opmTableLayoutPanel3";
            this.opmTableLayoutPanel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel3.RowCount = 4;
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel3.Size = new System.Drawing.Size(240, 76);
            this.opmTableLayoutPanel3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.label7.Location = new System.Drawing.Point(0, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label7.Name = "label7";
            this.label7.OverrideBackColor = System.Drawing.Color.Empty;
            this.label7.OverrideForeColor = System.Drawing.Color.Empty;
            this.label7.Size = new System.Drawing.Size(240, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "TXT_CFGDATA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbInputPins
            // 
            this.cmbInputPins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInputPins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbInputPins.FormattingEnabled = true;
            this.cmbInputPins.Location = new System.Drawing.Point(0, 16);
            this.cmbInputPins.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cmbInputPins.Name = "cmbInputPins";
            this.cmbInputPins.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbInputPins.Size = new System.Drawing.Size(240, 23);
            this.cmbInputPins.TabIndex = 1;
            this.cmbInputPins.SelectedIndexChanged += new System.EventHandler(this.OnInputPinChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label5.Name = "label5";
            this.label5.OverrideBackColor = System.Drawing.Color.Empty;
            this.label5.OverrideForeColor = System.Drawing.Color.Empty;
            this.label5.Size = new System.Drawing.Size(240, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "TXT_PINTYPE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(427, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnabled.Location = new System.Drawing.Point(411, 3);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkEnabled.Size = new System.Drawing.Size(91, 17);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.Text = "TXT_ENABLED";
            this.chkEnabled.Click += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(330, 538);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "TXT_OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(427, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDelete.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "TXT_DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(427, 203);
            this.btnChange.Name = "btnChange";
            this.btnChange.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnChange.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnChange.Size = new System.Drawing.Size(75, 27);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "TXT_CHANGE";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(3, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.OverrideBackColor = System.Drawing.Color.Empty;
            this.label4.OverrideForeColor = System.Drawing.Color.Empty;
            this.label4.Size = new System.Drawing.Size(499, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "TXT_BUTTONS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvButtons
            // 
            this.lvButtons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colActionName,
            this.colEnabled,
            this.colInputData,
            this.colOutputData,
            this.colTargetWnd});
            this.opmTableLayoutPanel1.SetColumnSpan(this.lvButtons, 2);
            this.lvButtons.ContextMenuStrip = this.cmsList;
            this.lvButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvButtons.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.lvButtons.Location = new System.Drawing.Point(3, 170);
            this.lvButtons.MultiSelect = false;
            this.lvButtons.Name = "lvButtons";
            this.opmTableLayoutPanel1.SetRowSpan(this.lvButtons, 3);
            this.lvButtons.Size = new System.Drawing.Size(402, 357);
            this.lvButtons.TabIndex = 5;
            this.lvButtons.UseCompatibleStateImageBehavior = false;
            this.lvButtons.View = System.Windows.Forms.View.Details;
            // 
            // colActionName
            // 
            this.colActionName.Name = "colActionName";
            this.colActionName.Text = "TXT_BUTTON_NAME";
            this.colActionName.Width = 131;
            // 
            // colEnabled
            // 
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Text = "TXT_ENABLED";
            this.colEnabled.Width = 102;
            // 
            // colInputData
            // 
            this.colInputData.Name = "colInputData";
            this.colInputData.Text = "TXT_INPUT_DATA";
            this.colInputData.Width = 120;
            // 
            // colOutputData
            // 
            this.colOutputData.Name = "colOutputData";
            this.colOutputData.Text = "TXT_OUTPUT_DATA";
            this.colOutputData.Width = 5;
            // 
            // colTargetWnd
            // 
            this.colTargetWnd.Name = "colTargetWnd";
            this.colTargetWnd.Text = "TXT_TARGET_WNDNAME";
            this.colTargetWnd.Width = 153;
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChange,
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiEnable});
            this.cmsList.Name = "cmsTree";
            this.cmsList.Size = new System.Drawing.Size(142, 76);
            this.cmsList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTree_Opening);
            // 
            // tsmiChange
            // 
            this.tsmiChange.Name = "tsmiChange";
            this.tsmiChange.Size = new System.Drawing.Size(141, 22);
            this.tsmiChange.Text = "TXT_CHANGE";
            this.tsmiChange.Click += new System.EventHandler(this.OnMenuChange);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(141, 22);
            this.tsmiDelete.Text = "TXT_DELETE";
            this.tsmiDelete.Click += new System.EventHandler(this.OnMenuDelete);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiEnable
            // 
            this.tsmiEnable.Name = "tsmiEnable";
            this.tsmiEnable.Size = new System.Drawing.Size(141, 22);
            this.tsmiEnable.Text = "TXT_ENABLE";
            this.tsmiEnable.Click += new System.EventHandler(this.OnMenuEnable);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(402, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_REMOTENAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(427, 170);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnAdd.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "TXT_ADD";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRemoteName
            // 
            this.txtRemoteName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.opmTableLayoutPanel1.SetColumnSpan(this.txtRemoteName, 3);
            this.txtRemoteName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemoteName.Location = new System.Drawing.Point(0, 23);
            this.txtRemoteName.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemoteName.MaxLength = 50;
            this.txtRemoteName.Name = "txtRemoteName";
            this.txtRemoteName.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtRemoteName.Size = new System.Drawing.Size(505, 22);
            this.txtRemoteName.TabIndex = 2;
            this.txtRemoteName.TextChanged += new System.EventHandler(this.txtRemoteName_TextChanged);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 3;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 2, 8);
            this.opmTableLayoutPanel1.Controls.Add(this.chkEnabled, 2, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.btnOk, 1, 8);
            this.opmTableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lvButtons, 0, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.txtRemoteName, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.btnAdd, 2, 4);
            this.opmTableLayoutPanel1.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.btnChange, 2, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.btnDelete, 2, 6);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 9;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(505, 568);
            this.opmTableLayoutPanel1.TabIndex = 11;
            // 
            // RemoteControlConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(515, 596);
            this.MinimumSize = new System.Drawing.Size(233, 115);
            this.Name = "RemoteControlConfigForm";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.opmTableLayoutPanel2.ResumeLayout(false);
            this.opmTableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.opmTableLayoutPanel3.ResumeLayout(false);
            this.opmTableLayoutPanel3.PerformLayout();
            this.cmsList.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMGroupBox groupBox2;
        private OPMLinkLabel llOutputCfgData;
        private OPMLabel label8;
        private OPMLabel label6;
        private OPMComboBox cmbOutputPins;
        private OPMGroupBox groupBox1;
        private OPMLinkLabel llInputCfgData;
        private OPMLabel label7;
        private OPMLabel label5;
        private OPMComboBox cmbInputPins;
        private OPMButton btnCancel;
        private OPMCheckBox chkEnabled;
        private OPMButton btnOk;
        private OPMButton btnDelete;
        private OPMButton btnChange;
        private OPMLabel label4;
        private OPMListView lvButtons;
        private OPMLabel label1;
        private OPMButton btnAdd;
        private OPMTextBox txtRemoteName;
        private System.Windows.Forms.ContextMenuStrip cmsList;
        private OPMToolStripMenuItem tsmiChange;
        private OPMToolStripMenuItem tsmiDelete;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripMenuItem tsmiEnable;
        private ColumnHeader colActionName;
        private ColumnHeader colEnabled;
        private ColumnHeader colInputData;
        private ColumnHeader colOutputData;
        private ColumnHeader colTargetWnd;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMTableLayoutPanel opmTableLayoutPanel2;
        private OPMTableLayoutPanel opmTableLayoutPanel3;

    }
}