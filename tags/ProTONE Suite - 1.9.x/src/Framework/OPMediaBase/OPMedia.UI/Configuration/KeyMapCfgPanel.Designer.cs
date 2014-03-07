using OPMedia.UI.Controls;

using System.Windows.Forms;
namespace OPMedia.UI.Configuration
{
    partial class KeyMapCfgPanel
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
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.lvShortcuts = new OPMedia.UI.Controls.OPMListView();
            this.hdrCmdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrCmdDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrAltkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kryptonButton1 = new OPMedia.UI.Controls.OPMButton();
            this.kryptonLabel1 = new OPMedia.UI.Controls.OPMLabel();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(333, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_KEYMAP_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvShortcuts
            // 
            this.lvShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrCmdName,
            this.hdrCmdDesc,
            this.hdrKey,
            this.hdrAltkey});
            this.lvShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShortcuts.Location = new System.Drawing.Point(3, 16);
            this.lvShortcuts.MultiSelect = false;
            this.lvShortcuts.Name = "lvShortcuts";
            this.lvShortcuts.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvShortcuts.ShowItemToolTips = true;
            this.lvShortcuts.Size = new System.Drawing.Size(327, 195);
            this.lvShortcuts.TabIndex = 1;
            this.lvShortcuts.UseCompatibleStateImageBehavior = false;
            this.lvShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // hdrCmdName
            // 
            this.hdrCmdName.Name = "hdrCmdName";
            this.hdrCmdName.Text = "TXT_COMMAND";
            this.hdrCmdName.Width = 112;
            // 
            // hdrCmdDesc
            // 
            this.hdrCmdDesc.Name = "hdrCmdDesc";
            this.hdrCmdDesc.Text = "TXT_DESC";
            // 
            // hdrKey
            // 
            this.hdrKey.Name = "hdrKey";
            this.hdrKey.Text = "TXT_KEY";
            this.hdrKey.Width = 51;
            // 
            // hdrAltkey
            // 
            this.hdrAltkey.Name = "hdrAltkey";
            this.hdrAltkey.Text = "TXT_ALTKEY";
            this.hdrAltkey.Width = 68;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonButton1.Location = new System.Drawing.Point(3, 3);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonButton1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Size = new System.Drawing.Size(137, 25);
            this.kryptonButton1.TabIndex = 1;
            this.kryptonButton1.Text = "TXT_RESTOREDEFAULTS";
            this.kryptonButton1.Click += new System.EventHandler(this.OnRestoreDefaults);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = true;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kryptonLabel1.FontSize = OPMedia.UI.Themes.FontSizes.Small;
            this.kryptonLabel1.Location = new System.Drawing.Point(146, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.OverrideForeColor = System.Drawing.Color.Empty;
            this.kryptonLabel1.Size = new System.Drawing.Size(184, 31);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Text = "TXT_RESTORESHORTCUTSDESC";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvShortcuts, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(333, 245);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 214);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(333, 31);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // KeyMapCfgPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KeyMapCfgPanel";
            this.Size = new System.Drawing.Size(333, 245);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label1;
        private OPMListView lvShortcuts;
        private System.Windows.Forms.ColumnHeader hdrCmdName;
        private System.Windows.Forms.ColumnHeader hdrCmdDesc;
        private System.Windows.Forms.ColumnHeader hdrKey;
        private System.Windows.Forms.ColumnHeader hdrAltkey;
        private OPMButton kryptonButton1;
        private OPMLabel kryptonLabel1;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMTableLayoutPanel tableLayoutPanel2;

    }
}
