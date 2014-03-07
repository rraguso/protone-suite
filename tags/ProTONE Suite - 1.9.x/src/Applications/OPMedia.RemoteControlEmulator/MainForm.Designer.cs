namespace OPMedia.RemoteControlEmulator
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
            this.tabEmulator = new OPMedia.UI.Controls.OPMTabControl();
            this.tpApi = new System.Windows.Forms.TabPage();
            this.opmTableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmGroupBox1 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.lblPlaybackCmd = new OPMedia.UI.Controls.OPMLabel();
            this.cmbCommandType = new OPMedia.UI.Controls.OPMComboBox();
            this.lblSelectFiles = new OPMedia.UI.Controls.OPMLabel();
            this.cmbPlaybackCmd = new OPMedia.UI.Controls.OPMComboBox();
            this.pnlSelectFiles = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tbFiles = new OPMedia.UI.Controls.OPMTextBox();
            this.opmButton1 = new OPMedia.UI.Controls.OPMButton();
            this.opmGroupBox2 = new OPMedia.UI.Controls.OPMGroupBox();
            this.opmTableLayoutPanel3 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmLabel2 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbDestination = new OPMedia.UI.Controls.OPMComboBox();
            this.opmLabel3 = new OPMedia.UI.Controls.OPMLabel();
            this.txtDestinationName = new OPMedia.UI.Controls.OPMTextBox();
            this.btnExecute = new OPMedia.UI.Controls.OPMButton();
            this.tpRemoteControl = new System.Windows.Forms.TabPage();
            this.txtResult = new OPMedia.UI.Controls.OPMTextBox();
            this.opmTableLayoutPanel4 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tabEmulator.SuspendLayout();
            this.tpApi.SuspendLayout();
            this.opmTableLayoutPanel2.SuspendLayout();
            this.opmGroupBox1.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.pnlSelectFiles.SuspendLayout();
            this.opmGroupBox2.SuspendLayout();
            this.opmTableLayoutPanel3.SuspendLayout();
            this.tpRemoteControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tabEmulator);
            // 
            // tabEmulator
            // 
            this.tabEmulator.Controls.Add(this.tpApi);
            this.tabEmulator.Controls.Add(this.tpRemoteControl);
            this.tabEmulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmulator.Location = new System.Drawing.Point(0, 0);
            this.tabEmulator.Name = "tabEmulator";
            this.tabEmulator.SelectedIndex = 0;
            this.tabEmulator.Size = new System.Drawing.Size(401, 460);
            this.tabEmulator.TabIndex = 0;
            // 
            // tpApi
            // 
            this.tpApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpApi.Controls.Add(this.opmTableLayoutPanel2);
            this.tpApi.Location = new System.Drawing.Point(4, 23);
            this.tpApi.Name = "tpApi";
            this.tpApi.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpApi.Size = new System.Drawing.Size(393, 433);
            this.tpApi.TabIndex = 0;
            this.tpApi.Text = "API Tester";
            // 
            // opmTableLayoutPanel2
            // 
            this.opmTableLayoutPanel2.ColumnCount = 1;
            this.opmTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Controls.Add(this.opmGroupBox1, 0, 0);
            this.opmTableLayoutPanel2.Controls.Add(this.opmGroupBox2, 0, 1);
            this.opmTableLayoutPanel2.Controls.Add(this.btnExecute, 0, 2);
            this.opmTableLayoutPanel2.Controls.Add(this.txtResult, 0, 3);
            this.opmTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel2.Location = new System.Drawing.Point(5, 10);
            this.opmTableLayoutPanel2.Name = "opmTableLayoutPanel2";
            this.opmTableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel2.RowCount = 4;
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Size = new System.Drawing.Size(383, 418);
            this.opmTableLayoutPanel2.TabIndex = 1;
            // 
            // opmGroupBox1
            // 
            this.opmGroupBox1.AutoSize = true;
            this.opmGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmGroupBox1.Controls.Add(this.opmTableLayoutPanel1);
            this.opmGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmGroupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opmGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.opmGroupBox1.Name = "opmGroupBox1";
            this.opmGroupBox1.Size = new System.Drawing.Size(377, 205);
            this.opmGroupBox1.TabIndex = 0;
            this.opmGroupBox1.TabStop = false;
            this.opmGroupBox1.Text = "Command Parameters";
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.opmLabel1, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lblPlaybackCmd, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbCommandType, 1, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lblSelectFiles, 0, 2);
            this.opmTableLayoutPanel1.Controls.Add(this.cmbPlaybackCmd, 1, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.pnlSelectFiles, 1, 2);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 4;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(371, 184);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // opmLabel1
            // 
            this.opmLabel1.AutoSize = true;
            this.opmLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.opmLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel1.Location = new System.Drawing.Point(43, 0);
            this.opmLabel1.Name = "opmLabel1";
            this.opmLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel1.Size = new System.Drawing.Size(87, 29);
            this.opmLabel1.TabIndex = 0;
            this.opmLabel1.Text = "Command type:";
            this.opmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlaybackCmd
            // 
            this.lblPlaybackCmd.AutoSize = true;
            this.lblPlaybackCmd.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlaybackCmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlaybackCmd.Location = new System.Drawing.Point(21, 29);
            this.lblPlaybackCmd.Name = "lblPlaybackCmd";
            this.lblPlaybackCmd.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblPlaybackCmd.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblPlaybackCmd.Size = new System.Drawing.Size(109, 29);
            this.lblPlaybackCmd.TabIndex = 1;
            this.lblPlaybackCmd.Text = "Playback Command:";
            this.lblPlaybackCmd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCommandType
            // 
            this.cmbCommandType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCommandType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCommandType.FormattingEnabled = true;
            this.cmbCommandType.Location = new System.Drawing.Point(136, 3);
            this.cmbCommandType.Name = "cmbCommandType";
            this.cmbCommandType.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbCommandType.Size = new System.Drawing.Size(232, 23);
            this.cmbCommandType.TabIndex = 2;
            this.cmbCommandType.SelectedIndexChanged += new System.EventHandler(this.cmbCommandType_SelectedIndexChanged);
            // 
            // lblSelectFiles
            // 
            this.lblSelectFiles.AutoSize = true;
            this.lblSelectFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelectFiles.Location = new System.Drawing.Point(66, 66);
            this.lblSelectFiles.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblSelectFiles.Name = "lblSelectFiles";
            this.lblSelectFiles.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblSelectFiles.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSelectFiles.Size = new System.Drawing.Size(64, 98);
            this.lblSelectFiles.TabIndex = 3;
            this.lblSelectFiles.Text = "Select files:";
            this.lblSelectFiles.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbPlaybackCmd
            // 
            this.cmbPlaybackCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPlaybackCmd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPlaybackCmd.FormattingEnabled = true;
            this.cmbPlaybackCmd.Location = new System.Drawing.Point(136, 32);
            this.cmbPlaybackCmd.Name = "cmbPlaybackCmd";
            this.cmbPlaybackCmd.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbPlaybackCmd.Size = new System.Drawing.Size(232, 23);
            this.cmbPlaybackCmd.TabIndex = 4;
            // 
            // pnlSelectFiles
            // 
            this.pnlSelectFiles.ColumnCount = 1;
            this.pnlSelectFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSelectFiles.Controls.Add(this.tbFiles, 0, 1);
            this.pnlSelectFiles.Controls.Add(this.opmButton1, 0, 0);
            this.pnlSelectFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectFiles.Location = new System.Drawing.Point(136, 61);
            this.pnlSelectFiles.Name = "pnlSelectFiles";
            this.pnlSelectFiles.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlSelectFiles.RowCount = 2;
            this.pnlSelectFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlSelectFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSelectFiles.Size = new System.Drawing.Size(232, 100);
            this.pnlSelectFiles.TabIndex = 5;
            // 
            // tbFiles
            // 
            this.tbFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFiles.FontSize = OPMedia.UI.Themes.FontSizes.Smallest;
            this.tbFiles.Location = new System.Drawing.Point(0, 29);
            this.tbFiles.Margin = new System.Windows.Forms.Padding(0);
            this.tbFiles.Multiline = true;
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.OverrideForeColor = System.Drawing.Color.Empty;
            this.tbFiles.ReadOnly = true;
            this.tbFiles.Size = new System.Drawing.Size(232, 71);
            this.tbFiles.TabIndex = 6;
            // 
            // opmButton1
            // 
            this.opmButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmButton1.Location = new System.Drawing.Point(3, 3);
            this.opmButton1.Name = "opmButton1";
            this.opmButton1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmButton1.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmButton1.Size = new System.Drawing.Size(226, 23);
            this.opmButton1.TabIndex = 5;
            this.opmButton1.Text = "TXT_BROWSE";
            this.opmButton1.UseVisualStyleBackColor = true;
            // 
            // opmGroupBox2
            // 
            this.opmGroupBox2.AutoSize = true;
            this.opmGroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmGroupBox2.Controls.Add(this.opmTableLayoutPanel3);
            this.opmGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmGroupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opmGroupBox2.Location = new System.Drawing.Point(3, 214);
            this.opmGroupBox2.Name = "opmGroupBox2";
            this.opmGroupBox2.Size = new System.Drawing.Size(377, 78);
            this.opmGroupBox2.TabIndex = 1;
            this.opmGroupBox2.TabStop = false;
            this.opmGroupBox2.Text = "Command Destination";
            // 
            // opmTableLayoutPanel3
            // 
            this.opmTableLayoutPanel3.AutoSize = true;
            this.opmTableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel3.ColumnCount = 2;
            this.opmTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.opmTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel3.Controls.Add(this.opmLabel2, 0, 0);
            this.opmTableLayoutPanel3.Controls.Add(this.cmbDestination, 1, 0);
            this.opmTableLayoutPanel3.Controls.Add(this.opmLabel3, 0, 1);
            this.opmTableLayoutPanel3.Controls.Add(this.txtDestinationName, 1, 1);
            this.opmTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.opmTableLayoutPanel3.Name = "opmTableLayoutPanel3";
            this.opmTableLayoutPanel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel3.RowCount = 2;
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel3.Size = new System.Drawing.Size(371, 57);
            this.opmTableLayoutPanel3.TabIndex = 1;
            // 
            // opmLabel2
            // 
            this.opmLabel2.AutoSize = true;
            this.opmLabel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.opmLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel2.Location = new System.Drawing.Point(27, 0);
            this.opmLabel2.Name = "opmLabel2";
            this.opmLabel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel2.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel2.Size = new System.Drawing.Size(103, 29);
            this.opmLabel2.TabIndex = 0;
            this.opmLabel2.Text = "Send command to:";
            this.opmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDestination
            // 
            this.cmbDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDestination.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Items.AddRange(new object[] {
            "Player",
            "RCC Service"});
            this.cmbDestination.Location = new System.Drawing.Point(136, 3);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbDestination.Size = new System.Drawing.Size(232, 23);
            this.cmbDestination.TabIndex = 2;
            // 
            // opmLabel3
            // 
            this.opmLabel3.AutoSize = true;
            this.opmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opmLabel3.Location = new System.Drawing.Point(3, 29);
            this.opmLabel3.Name = "opmLabel3";
            this.opmLabel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLabel3.OverrideForeColor = System.Drawing.Color.Empty;
            this.opmLabel3.Size = new System.Drawing.Size(127, 28);
            this.opmLabel3.TabIndex = 3;
            this.opmLabel3.Text = "Destination machine \r\nname or IP address:";
            this.opmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDestinationName
            // 
            this.txtDestinationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDestinationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinationName.Location = new System.Drawing.Point(136, 32);
            this.txtDestinationName.Name = "txtDestinationName";
            this.txtDestinationName.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtDestinationName.Size = new System.Drawing.Size(232, 22);
            this.txtDestinationName.TabIndex = 4;
            // 
            // btnExecute
            // 
            this.btnExecute.AutoSize = true;
            this.btnExecute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Location = new System.Drawing.Point(3, 298);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnExecute.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnExecute.Size = new System.Drawing.Size(111, 25);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute command";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // tpRemoteControl
            // 
            this.tpRemoteControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tpRemoteControl.Controls.Add(this.opmTableLayoutPanel4);
            this.tpRemoteControl.Location = new System.Drawing.Point(4, 23);
            this.tpRemoteControl.Name = "tpRemoteControl";
            this.tpRemoteControl.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tpRemoteControl.Size = new System.Drawing.Size(393, 433);
            this.tpRemoteControl.TabIndex = 1;
            this.tpRemoteControl.Text = "Remote Control Simulator";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 326);
            this.txtResult.Margin = new System.Windows.Forms.Padding(0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(383, 92);
            this.txtResult.TabIndex = 3;
            // 
            // opmTableLayoutPanel4
            // 
            this.opmTableLayoutPanel4.ColumnCount = 5;
            this.opmTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.opmTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.opmTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.opmTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.opmTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.opmTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel4.Location = new System.Drawing.Point(5, 10);
            this.opmTableLayoutPanel4.Name = "opmTableLayoutPanel4";
            this.opmTableLayoutPanel4.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel4.RowCount = 10;
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.opmTableLayoutPanel4.Size = new System.Drawing.Size(383, 418);
            this.opmTableLayoutPanel4.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(411, 488);
            this.Name = "MainForm";
            this.pnlContent.ResumeLayout(false);
            this.tabEmulator.ResumeLayout(false);
            this.tpApi.ResumeLayout(false);
            this.opmTableLayoutPanel2.ResumeLayout(false);
            this.opmTableLayoutPanel2.PerformLayout();
            this.opmGroupBox1.ResumeLayout(false);
            this.opmGroupBox1.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.pnlSelectFiles.ResumeLayout(false);
            this.pnlSelectFiles.PerformLayout();
            this.opmGroupBox2.ResumeLayout(false);
            this.opmGroupBox2.PerformLayout();
            this.opmTableLayoutPanel3.ResumeLayout(false);
            this.opmTableLayoutPanel3.PerformLayout();
            this.tpRemoteControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.OPMTabControl tabEmulator;
        private System.Windows.Forms.TabPage tpApi;
        private System.Windows.Forms.TabPage tpRemoteControl;
        private UI.Controls.OPMGroupBox opmGroupBox1;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private UI.Controls.OPMLabel opmLabel1;
        private UI.Controls.OPMLabel lblPlaybackCmd;
        private UI.Controls.OPMComboBox cmbCommandType;
        private UI.Controls.OPMLabel lblSelectFiles;
        private UI.Controls.OPMComboBox cmbPlaybackCmd;
        private UI.Controls.OPMButton opmButton1;
        private UI.Controls.OPMTableLayoutPanel pnlSelectFiles;
        private UI.Controls.OPMTextBox tbFiles;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel2;
        private UI.Controls.OPMGroupBox opmGroupBox2;
        private UI.Controls.OPMButton btnExecute;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel3;
        private UI.Controls.OPMLabel opmLabel2;
        private UI.Controls.OPMComboBox cmbDestination;
        private UI.Controls.OPMLabel opmLabel3;
        private UI.Controls.OPMTextBox txtDestinationName;
        private UI.Controls.OPMTextBox txtResult;
        private UI.Controls.OPMTableLayoutPanel opmTableLayoutPanel4;
    }
}

