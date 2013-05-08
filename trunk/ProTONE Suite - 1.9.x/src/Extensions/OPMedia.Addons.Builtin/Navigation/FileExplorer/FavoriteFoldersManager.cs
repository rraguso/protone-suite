using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.ApplicationSettings;
using OPMedia.UI.Themes;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.Addons.Builtin.Properties;
using System.Drawing;
using OPMedia.UI.Controls;
using OPMedia.UI.Dialogs;

namespace OPMedia.Addons.Builtin.FileExplorer
{
    public class FavoriteFoldersManager : ThemeForm
    {
        private OPMButton btnAdd;
        private OPMButton btnDelete;
        private System.ComponentModel.IContainer components;
        private OPMButton btnOK;
        private OPMTableLayoutPanel tableLayoutPanel1;
        private OPMListView lvFavorites;
        private ColumnHeader colPath;

        private ImageList ilFavorites;

        internal static void Manage()
        {
            new FavoriteFoldersManager().ShowDialog();
        }

        internal static void Add(string path)
        {
            if (GetList().Contains(path))
                return;

            string favorites = AppSettings.FavoriteFolders;
            favorites += path;
            favorites += "?"; // use ? since it does not appear in a normal system path
            AppSettings.FavoriteFolders = favorites;
        }

        internal static List<string> GetList()
        {
            List<string> favList = new List<string>();

            string favorites = AppSettings.FavoriteFolders;
            string[] favParts = favorites.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
            if (favParts != null)
            {
                favList.AddRange(favParts);
            }

            return favList;
        }

        private FavoriteFoldersManager()
            : base("TXT_MANAGE_FAVORITES")
        {
            InitializeComponent();
            this.Load += new EventHandler(FavoriteFoldersManager_Load);
        }

        void FavoriteFoldersManager_Load(object sender, EventArgs e)
        {
            this.InheritAppIcon = false;
            this.Icon = Resources.Favorites16.ToIcon();

            DisplayFavorites();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new OPMButton();
            this.btnDelete = new OPMButton();
            this.btnOK = new OPMButton();
            this.ilFavorites = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new OPMTableLayoutPanel();
            this.lvFavorites = new OPMListView(ColumnHeaderStyle.None);
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(296, 3);
            this.btnAdd.Name = "btnAdd";
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
            this.btnDelete.Location = new System.Drawing.Point(296, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(76, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "TXT_DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(296, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(76, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "TXT_OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 163);
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
            this.tableLayoutPanel1.SetRowSpan(this.lvFavorites, 4);
            this.lvFavorites.ShowItemToolTips = true;
            this.lvFavorites.Size = new System.Drawing.Size(287, 157);
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
            // FavoriteFoldersManager
            // 
            this.ClientSize = new System.Drawing.Size(381, 186);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "FavoriteFoldersManager";
            this.ShowIcon = false;
            
            
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OPMFolderBrowserDialog dlg = CommonDialogHelper.NewOPMFolderBrowserDialog();
            dlg.Description = Translator.Translate("TXT_CHOOSE_FAVORITE");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CreateItem(dlg.SelectedPath);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ListViewItem> itemsToDelete = new List<ListViewItem>();
            foreach (ListViewItem item in lvFavorites.SelectedItems)
            {
                itemsToDelete.Add(item);
            }

            foreach (ListViewItem item in itemsToDelete)
            {
                lvFavorites.Items.Remove(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string favorites = string.Empty;
            foreach (ListViewItem item in lvFavorites.Items)
            {
                favorites += item.Tag as string;
                favorites += "?"; // use ? since it does not appear in a normal system path
            }

            AppSettings.FavoriteFolders = favorites;
        }

        private void DisplayFavorites()
        {
            lvFavorites.Items.Clear();
            ilFavorites.Images.Clear();

            foreach (string path in GetList())
            {
                CreateItem(path);
            }
        }

        private void CreateItem(string path)
        {
            ListViewItem item = new ListViewItem(path);
            item.Tag = path;

            Image icon = ImageProvider.GetIcon(path, false);
            if (icon != null)
            {
                ilFavorites.Images.Add(icon);
                item.ImageIndex = ilFavorites.Images.Count - 1;
            }
            
            lvFavorites.Items.Add(item);
        }

        private void lvFavorites_Resize(object sender, EventArgs e)
        {
            colPath.Width = lvFavorites.Width - SystemInformation.VerticalScrollBarWidth;
        }
    }
}
