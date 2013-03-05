using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.Addons.Builtin.Navigation.CatalogExplorer.Dialogs
{
    public partial class CatalogFolderBrowserDialog : ToolForm
    {
        public Catalog Catalog { get; set; }
        public string SelectedPath { get; set; }
        public string Description { get; set; }

        public CatalogFolderBrowserDialog()
        {
            InitializeComponent();
            this.Description = Translator.Translate("TXT_SELECT_FOLDER");
            this.Load += new EventHandler(CatalogFolderBrowserDialog_Load);
        }

        void CatalogFolderBrowserDialog_Load(object sender, EventArgs e)
        {
            SetTitle("TXT_SELECT_FOLDER");
            lblDescription.Text = this.Description;
            btnOK.Enabled = false;

            if (Catalog != null)
            {
                tvExplorer.Focus();
                tvExplorer.DisplayCatalog(Catalog);

                tvExplorer.AfterSelect += new TreeViewEventHandler(tvExplorer_AfterSelect);

                CatalogItem ci = Catalog.GetByVPath(SelectedPath);
                if (ci != null)
                {
                    TreeNode selectNode = tvExplorer.FindNode(ci);
                    if (selectNode != null)
                    {
                        tvExplorer.Select();
                        tvExplorer.Focus();

                        selectNode.EnsureVisible();
                        selectNode.Expand();
                        tvExplorer.SelectedNode = selectNode;
                    }
                }
            }
        }

        void tvExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CatalogItem ci = e.Node.Tag as CatalogItem;
            if (ci != null)
            {
                SelectedPath = ci.VPath;
                btnOK.Enabled = true;
            }
            else
            {
                SelectedPath = string.Empty;
                btnOK.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CatalogItem ci = Catalog.GetByVPath(SelectedPath);
            if (ci != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
