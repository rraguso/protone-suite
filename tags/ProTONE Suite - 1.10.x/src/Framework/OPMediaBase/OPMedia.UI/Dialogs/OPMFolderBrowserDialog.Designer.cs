namespace OPMedia.UI.Dialogs
{
    partial class OPMFolderBrowserDialog
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
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.btnOK = new OPMedia.UI.Controls.OPMButton();
            this.btnCancel = new OPMedia.UI.Controls.OPMButton();
            this.tvExplorer = new OPMedia.UI.Controls.OPMShellTreeView();
            this.lblDescription = new OPMedia.UI.Controls.OPMLabel();
            this.btnNewFolder = new OPMedia.UI.Controls.OPMButton();
            this.pnlContent.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.opmTableLayoutPanel1);
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 4;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.Controls.Add(this.btnOK, 2, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.btnCancel, 3, 5);
            this.opmTableLayoutPanel1.Controls.Add(this.tvExplorer, 0, 3);
            this.opmTableLayoutPanel1.Controls.Add(this.lblDescription, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.btnNewFolder, 0, 5);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 6;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(390, 372);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(231, 344);
            this.btnOK.MinimumSize = new System.Drawing.Size(70, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(307, 344);
            this.btnCancel.MinimumSize = new System.Drawing.Size(70, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnCancel.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "TXT_CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tvExplorer
            // 
            this.opmTableLayoutPanel1.SetColumnSpan(this.tvExplorer, 4);
            this.tvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvExplorer.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvExplorer.Location = new System.Drawing.Point(0, 23);
            this.tvExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.tvExplorer.Name = "tvExplorer";
            this.tvExplorer.ShowSpecialFolders = false;
            this.tvExplorer.Size = new System.Drawing.Size(390, 313);
            this.tvExplorer.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.opmTableLayoutPanel1.SetColumnSpan(this.lblDescription, 4);
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDescription.Location = new System.Drawing.Point(3, 5);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblDescription.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblDescription.Size = new System.Drawing.Size(384, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "opmLabel1";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.AutoSize = true;
            this.btnNewFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFolder.Location = new System.Drawing.Point(3, 344);
            this.btnNewFolder.MinimumSize = new System.Drawing.Size(70, 20);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnNewFolder.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnNewFolder.Size = new System.Drawing.Size(111, 25);
            this.btnNewFolder.TabIndex = 2;
            this.btnNewFolder.Text = "TXT_NEW_FOLDER";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // OPMFolderBrowserDialog
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "OPMFolderBrowserDialog";
            this.pnlContent.ResumeLayout(false);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.OPMTableLayoutPanel opmTableLayoutPanel1;
        private Controls.OPMButton btnOK;
        private Controls.OPMButton btnCancel;
        private Controls.OPMLabel lblDescription;
        private Controls.OPMShellTreeView tvExplorer;
        private Controls.OPMButton btnNewFolder;
    }
}