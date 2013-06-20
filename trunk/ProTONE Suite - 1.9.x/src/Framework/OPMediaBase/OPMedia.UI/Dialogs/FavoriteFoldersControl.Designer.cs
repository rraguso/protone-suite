using OPMedia.UI.Controls;
using System.Windows.Forms;
namespace OPMedia.UI.Dialogs
{
    partial class FavoriteFoldersControl
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new OPMedia.UI.Controls.OPMButton();
            this.btnDelete = new OPMedia.UI.Controls.OPMButton();
            this.ilFavorites = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lvFavorites = new OPMedia.UI.Controls.OPMListView();
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(241, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnAdd.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(76, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "TXT_ADD";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(241, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnDelete.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(76, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "TXT_DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ilFavorites
            // 
            this.ilFavorites.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilFavorites.ImageSize = new System.Drawing.Size(16, 16);
            this.ilFavorites.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lvFavorites, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 120);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lvFavorites
            // 
            this.lvFavorites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvFavorites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath});
            this.lvFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFavorites.Location = new System.Drawing.Point(3, 3);
            this.lvFavorites.MultiSelect = false;
            this.lvFavorites.Name = "lvFavorites";
            this.lvFavorites.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.SetRowSpan(this.lvFavorites, 4);
            this.lvFavorites.ShowItemToolTips = true;
            this.lvFavorites.Size = new System.Drawing.Size(232, 114);
            this.lvFavorites.SmallImageList = this.ilFavorites;
            this.lvFavorites.TabIndex = 4;
            this.lvFavorites.UseCompatibleStateImageBehavior = false;
            this.lvFavorites.View = System.Windows.Forms.View.Details;
            this.lvFavorites.Resize += new System.EventHandler(this.lvFavorites_Resize);
            // 
            // colPath
            // 
            this.colPath.Name = "colPath";
            this.colPath.Text = "";
            // 
            // FavoriteFoldersControl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FavoriteFoldersControl";
            this.Size = new System.Drawing.Size(320, 120);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private OPMButton btnAdd;
        private OPMButton btnDelete;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMListView lvFavorites;
        private ColumnHeader colPath;

        private ImageList ilFavorites;
    }
}
