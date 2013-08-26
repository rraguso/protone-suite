
using OPMedia.UI.Controls;

namespace OPMedia.UI.Dialogs
{
    partial class ProgramStartupInfoForm
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
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.btnOk = new OPMedia.UI.Controls.OPMButton();
            this.btnChangeDir = new OPMedia.UI.Controls.OPMButton();
            this.txtWorkDir = new OPMedia.UI.Controls.OPMTextBox();
            this.txtArguments = new OPMedia.UI.Controls.OPMTextBox();
            this.btnChangePath = new OPMedia.UI.Controls.OPMButton();
            this.txtLaunchPath = new OPMedia.UI.Controls.OPMTextBox();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.flowLayoutPanel1 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(236, 139);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(80, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "TXT_CANCEL";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(153, 139);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.MinimumSize = new System.Drawing.Size(80, 25);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOk.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(80, 25);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "TXT_OK";
            // 
            // btnChangeDir
            // 
            this.btnChangeDir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeDir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeDir.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.btnChangeDir.Location = new System.Drawing.Point(296, 104);
            this.btnChangeDir.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnChangeDir.Name = "btnChangeDir";
            this.btnChangeDir.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnChangeDir.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnChangeDir.Size = new System.Drawing.Size(20, 22);
            this.btnChangeDir.TabIndex = 7;
            this.btnChangeDir.Text = ". . .";
            this.btnChangeDir.Click += new System.EventHandler(this.OnChooseWorkDir);
            // 
            // txtWorkDir
            // 
            this.txtWorkDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtWorkDir, 3);
            this.txtWorkDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkDir.Location = new System.Drawing.Point(0, 104);
            this.txtWorkDir.Margin = new System.Windows.Forms.Padding(0);
            this.txtWorkDir.MaxLength = 50;
            this.txtWorkDir.Name = "txtWorkDir";
            this.txtWorkDir.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtWorkDir.Size = new System.Drawing.Size(294, 22);
            this.txtWorkDir.TabIndex = 6;
            this.txtWorkDir.TextChanged += new System.EventHandler(this.OnInfoChanged);
            // 
            // txtArguments
            // 
            this.txtArguments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtArguments, 4);
            this.txtArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArguments.Location = new System.Drawing.Point(0, 62);
            this.txtArguments.Margin = new System.Windows.Forms.Padding(0);
            this.txtArguments.MaxLength = 50;
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtArguments.Size = new System.Drawing.Size(316, 22);
            this.txtArguments.TabIndex = 4;
            this.txtArguments.TextChanged += new System.EventHandler(this.OnInfoChanged);
            // 
            // btnChangePath
            // 
            this.btnChangePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePath.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.btnChangePath.Location = new System.Drawing.Point(296, 20);
            this.btnChangePath.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnChangePath.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnChangePath.Size = new System.Drawing.Size(20, 22);
            this.btnChangePath.TabIndex = 2;
            this.btnChangePath.Text = ". . .";
            this.btnChangePath.Click += new System.EventHandler(this.OnChoosePath);
            // 
            // txtLaunchPath
            // 
            this.txtLaunchPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtLaunchPath, 3);
            this.txtLaunchPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLaunchPath.Location = new System.Drawing.Point(0, 20);
            this.txtLaunchPath.Margin = new System.Windows.Forms.Padding(0);
            this.txtLaunchPath.MaxLength = 50;
            this.txtLaunchPath.Name = "txtLaunchPath";
            this.txtLaunchPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtLaunchPath.Size = new System.Drawing.Size(294, 22);
            this.txtLaunchPath.TabIndex = 1;
            this.txtLaunchPath.TextChanged += new System.EventHandler(this.OnInfoChanged);
            // 
            // label3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 4);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(0, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(316, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "TXT_WORKDIR";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(316, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "TXT_ARGUMENTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(316, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_PATH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLaunchPath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtWorkDir, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtArguments, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnChangePath, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeDir, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 164);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(233, 132);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // ProgramStartupInfoForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(326, 192);
            this.Name = "ProgramStartupInfoForm";
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMButton btnCancel;
        private OPMButton btnOk;
        private OPMButton btnChangeDir;
        private OPMTextBox txtWorkDir;
        private OPMTextBox txtArguments;
        private OPMButton btnChangePath;
        private OPMTextBox txtLaunchPath;
        private OPMLabel label3;
        private OPMLabel label2;
        private OPMLabel label1;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMFlowLayoutPanel flowLayoutPanel1;

    }
}