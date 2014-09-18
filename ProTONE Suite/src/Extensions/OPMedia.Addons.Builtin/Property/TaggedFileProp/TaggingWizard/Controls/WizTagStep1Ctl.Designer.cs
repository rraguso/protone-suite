using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    partial class WizTagStep1Ctl
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
            this.btnAddFiles = new OPMButton();
            this.btnAddFolder = new OPMButton();
            this.btnRemoveItems = new OPMButton();
            this.lvFiles = new OPMListView(ColumnHeaderStyle.None);
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new OPMTableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(390, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_WIZTAGGINGSTEP1_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFiles.AutoSize = true;
            this.btnAddFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFiles.Location = new System.Drawing.Point(3, 212);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAddFiles.Size = new System.Drawing.Size(94, 25);
            this.btnAddFiles.TabIndex = 2;
            this.btnAddFiles.Text = "TXT_ADD_FILES";
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFolder.AutoSize = true;
            this.btnAddFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Location = new System.Drawing.Point(103, 212);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAddFolder.Size = new System.Drawing.Size(109, 25);
            this.btnAddFolder.TabIndex = 3;
            this.btnAddFolder.Text = "TXT_ADD_FOLDER";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemoveItems
            // 
            this.btnRemoveItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItems.AutoSize = true;
            this.btnRemoveItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItems.Location = new System.Drawing.Point(277, 212);
            this.btnRemoveItems.Name = "btnRemoveItems";
            this.btnRemoveItems.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnRemoveItems.Size = new System.Drawing.Size(116, 25);
            this.btnRemoveItems.TabIndex = 4;
            this.btnRemoveItems.Text = "TXT_REMOVE_FILES";
            this.btnRemoveItems.Click += new System.EventHandler(this.btnRemoveItems_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath});
            this.tableLayoutPanel1.SetColumnSpan(this.lvFiles, 3);
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.Location = new System.Drawing.Point(3, 16);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(390, 190);
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.Resize += new System.EventHandler(this.lvFiles_Resize);
            // 
            // colPath
            // 
            this.colPath.Name = "colPath";
            this.colPath.Text = "-";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lvFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveItems, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddFolder, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAddFiles, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 240);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // WizId3Step1Ctl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "WizId3Step1Ctl";
            this.Size = new System.Drawing.Size(396, 240);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label1;
        private OPMButton btnAddFiles;
        private OPMButton btnAddFolder;
        private OPMButton btnRemoveItems;
        private OPMListView lvFiles;
        private ColumnHeader colPath;
        private OPMTableLayoutPanel tableLayoutPanel1;
    }
}
