using OPMedia.Addons.Builtin.CatalogExplorer.Controls;
using System.Drawing;
using OPMedia.UI.Controls;

namespace OPMedia.Addons.Builtin.CatalogExplorer.ImportWizard.Controls
{
    partial class WizImportStep1Ctl
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
            this.lblX = new OPMedia.UI.Controls.OPMLabel();
            this.lblCatalogPath = new OPMedia.UI.Controls.OPMLabel();
            this.btnBrowse = new OPMedia.UI.Controls.OPMButton();
            this.txtCatDesc = new OPMedia.UI.Controls.OPMTextBox();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tvCatFolders = new OPMedia.Addons.Builtin.CatalogExplorer.Controls.CatalogTreeView();
            this.opmLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(357, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_WIZCATSTEP1_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.lblX, 2);
            this.lblX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblX.Location = new System.Drawing.Point(3, 93);
            this.lblX.Margin = new System.Windows.Forms.Padding(3);
            this.lblX.Name = "lblX";
            this.lblX.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblX.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblX.Size = new System.Drawing.Size(357, 13);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "TXT_SELECTINSERTPOINT";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalogPath
            // 
            this.lblCatalogPath.AutoSize = true;
            this.lblCatalogPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCatalogPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCatalogPath.FontSize = OPMedia.UI.Themes.FontSizes.NormalBold;
            this.lblCatalogPath.Location = new System.Drawing.Point(3, 22);
            this.lblCatalogPath.Margin = new System.Windows.Forms.Padding(3);
            this.lblCatalogPath.Name = "lblCatalogPath";
            this.lblCatalogPath.OverrideBackColor = System.Drawing.Color.Empty;
            this.lblCatalogPath.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblCatalogPath.Size = new System.Drawing.Size(271, 24);
            this.lblCatalogPath.TabIndex = 1;
            this.lblCatalogPath.Text = "TXT_NO_CATALOG";
            this.lblCatalogPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(277, 19);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowse.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnBrowse.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnBrowse.Size = new System.Drawing.Size(86, 30);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "TXT_BROWSE";
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.Click += new System.EventHandler(this.OnBrowseCatalog);
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.opmLayoutPanel1.SetColumnSpan(this.txtCatDesc, 2);
            this.txtCatDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCatDesc.Location = new System.Drawing.Point(0, 68);
            this.txtCatDesc.Margin = new System.Windows.Forms.Padding(0);
            this.txtCatDesc.MaxLength = 50;
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.OverrideForeColor = System.Drawing.Color.Empty;
            this.txtCatDesc.Size = new System.Drawing.Size(363, 22);
            this.txtCatDesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.opmLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(357, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "TXT_CATALOG_DESC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 2;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.tvCatFolders, 0, 5);
            this.opmLayoutPanel1.Controls.Add(this.txtCatDesc, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.lblX, 0, 4);
            this.opmLayoutPanel1.Controls.Add(this.lblCatalogPath, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.opmLayoutPanel1.Controls.Add(this.btnBrowse, 1, 1);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 6;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Size = new System.Drawing.Size(363, 268);
            this.opmLayoutPanel1.TabIndex = 7;
            // 
            // tvCatFolders
            // 
            this.tvCatFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opmLayoutPanel1.SetColumnSpan(this.tvCatFolders, 2);
            this.tvCatFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCatFolders.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvCatFolders.ImageIndex = 0;
            this.tvCatFolders.Location = new System.Drawing.Point(0, 112);
            this.tvCatFolders.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tvCatFolders.Name = "tvCatFolders";
            this.tvCatFolders.SelectedImageIndex = 0;
            this.tvCatFolders.Size = new System.Drawing.Size(363, 153);
            this.tvCatFolders.TabIndex = 6;
            // 
            // WizImportStep1Ctl
            // 
            this.Controls.Add(this.opmLayoutPanel1);
            this.Name = "WizImportStep1Ctl";
            this.Size = new System.Drawing.Size(363, 268);
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPMLabel label1;
        private OPMLabel lblX;
        private CatalogTreeView tvCatFolders;
        private OPMLabel lblCatalogPath;
        private OPMButton btnBrowse;
        private OPMTextBox txtCatDesc;
        private OPMLabel label2;
        private OPMTableLayoutPanel opmLayoutPanel1;
    }
}
