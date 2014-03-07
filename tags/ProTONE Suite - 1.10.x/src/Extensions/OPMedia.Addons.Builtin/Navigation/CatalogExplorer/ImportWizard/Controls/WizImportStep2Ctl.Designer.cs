using System.Drawing;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Controls
{
    partial class WizImportStep2Ctl
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
            this.label1 = new OPMLabel();
            this.tvImportPath = new OPMShellTreeView();
            this.label2 = new OPMLabel();
            this.txtEntryDesc = new OPMTextBox();
            this.opmLayoutPanel1 = new OPMTableLayoutPanel();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(379, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_WIZCATSTEP2_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvImportPath
            // 
            this.tvImportPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvImportPath.Location = new System.Drawing.Point(3, 22);
            this.tvImportPath.Name = "tvImportPath";
            this.tvImportPath.ShowNodeToolTips = true;
            this.tvImportPath.Size = new System.Drawing.Size(379, 204);
            this.tvImportPath.TabIndex = 1;
            this.tvImportPath.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvImportPath_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(3, 232);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(379, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TXT_ENTRY_DESC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEntryDesc
            // 
            this.txtEntryDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEntryDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEntryDesc.Location = new System.Drawing.Point(0, 248);
            this.txtEntryDesc.Margin = new System.Windows.Forms.Padding(0);
            this.txtEntryDesc.MaxLength = 50;
            this.txtEntryDesc.Multiline = false;
            this.txtEntryDesc.Name = "txtEntryDesc";
            this.txtEntryDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtEntryDesc.Padding = new System.Windows.Forms.Padding(5, 2, 5, 3);
            this.txtEntryDesc.PasswordChar = '\0';
            this.txtEntryDesc.ReadOnly = false;
            this.txtEntryDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEntryDesc.ShortcutsEnabled = true;
            this.txtEntryDesc.Size = new System.Drawing.Size(385, 19);
            this.txtEntryDesc.TabIndex = 3;
            this.txtEntryDesc.UseSystemPasswordChar = false;
            this.txtEntryDesc.TextChanged += new System.EventHandler(this.txtEntryDesc_TextChanged);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 1;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.txtEntryDesc, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.tvImportPath, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.RowCount = 4;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.Size = new System.Drawing.Size(385, 267);
            this.opmLayoutPanel1.TabIndex = 4;
            // 
            // WizImportStep2Ctl
            // 
            this.Controls.Add(this.opmLayoutPanel1);
            this.Name = "WizImportStep2Ctl";
            this.Size = new System.Drawing.Size(385, 267);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label1;
        private OPMShellTreeView tvImportPath;
        private OPMLabel label2;
        private OPMTextBox txtEntryDesc;
        private OPMTableLayoutPanel opmLayoutPanel1;
    }
}
