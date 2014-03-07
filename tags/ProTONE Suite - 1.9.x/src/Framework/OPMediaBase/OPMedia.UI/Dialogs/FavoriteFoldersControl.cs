using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;

namespace OPMedia.UI.Dialogs
{
    public partial class FavoriteFoldersControl : UserControl
    {
        public event EventHandler OnModified = null;

        public string FavoriteFoldersHiveName { get; set; }

        public List<string> FavoriteFolders
        {
            get
            {
                List<String> favorites = new List<string>();
                foreach (ListViewItem item in lvFavorites.Items)
                {
                    favorites.Add(item.Tag as string);
                }

                return favorites;
            }
        }

        public FavoriteFoldersControl()
        {
            InitializeComponent();

            this.Load += new EventHandler(FavoriteFoldersControl_Load);
            btnDelete.Enabled = false;

            lvFavorites.SelectedIndexChanged += new EventHandler(lvFavorites_SelectedIndexChanged);
            lvFavorites.MultiSelect = true;
        }

        void lvFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (lvFavorites.SelectedItems != null && lvFavorites.SelectedItems.Count > 0) ;
        }

        void FavoriteFoldersControl_Load(object sender, EventArgs e)
        {
            DisplayFavorites();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OPMFolderBrowserDialog dlg = CommonDialogHelper.NewOPMFolderBrowserDialog();
            dlg.Description = Translator.Translate("TXT_CHOOSE_FAVORITE");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CreateItem(dlg.SelectedPath);

                if (OnModified != null)
                {
                    OnModified(sender, e);
                }
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

            if (OnModified != null)
            {
                OnModified(sender, e);
            }
        }

        public void DisplayFavorites()
        {
            lvFavorites.Items.Clear();
            ilFavorites.Images.Clear();

            foreach (string path in SuiteConfiguration.GetFavoriteFolders(FavoriteFoldersHiveName))
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
