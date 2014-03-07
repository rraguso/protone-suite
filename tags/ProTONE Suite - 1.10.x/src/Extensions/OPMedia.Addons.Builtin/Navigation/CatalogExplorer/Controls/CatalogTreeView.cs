using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.UI.Controls;
using OPMedia.Core.Logging;
using System.Threading;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;
using OPMedia.Addons.Builtin.Properties;


namespace OPMedia.Addons.Builtin.CatalogExplorer.Controls
{
    public class CatalogTreeView : OPMTreeView
    {
        private ImageList ilItems;
        

        public CatalogTreeView()
            : base()
        {
            ilItems = new ImageList();
            ilItems.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilItems.ImageSize = new System.Drawing.Size(16, 16);
            ilItems.TransparentColor = System.Drawing.Color.Gainsboro;

            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            ilItems.Images.Clear();

            ilItems.Images.Add(Resources.Catalog16);

            LoadShell32Image(Shell32Icon.DriveUnknown);
            LoadShell32Image(Shell32Icon.DriveNoRoot);
            LoadShell32Image(Shell32Icon.DriveRemovable);
            LoadShell32Image(Shell32Icon.DriveFixed);
            LoadShell32Image(Shell32Icon.DriveNetwork);
            LoadShell32Image(Shell32Icon.DriveCdrom);
            LoadShell32Image(Shell32Icon.DriveRamdisk);
            LoadShell32Image(Shell32Icon.GenericFolder);

            this.ImageList = ilItems;


        }

        private void LoadShell32Image(Shell32Icon shell32Icon)
        {
            ilItems.Images.Add(ImageProvider.GetShell32Icon(shell32Icon, false));
        }

        public void DisplayCatalog(Catalog cat)
        {
            DateTime start = DateTime.Now;

            this.Nodes.Clear();

            TreeNode[] nodes = BrowseCatalogFolders(cat);
            TreeNode catNode = new TreeNode(cat.Name, nodes);
            catNode.ImageIndex = catNode.SelectedImageIndex = 0;
            
            this.Nodes.Add(catNode);
            catNode.Expand();

            this.SelectedNode = catNode;
        }

        public void RemoveItem(CatalogItem item)
        {
            if (item != null && this.SelectedNode != null)
            {
                this.SelectedNode.Nodes.RemoveByKey(item.VPath);
                //Refresh();
            }
        }

        public TreeNode FindNode(CatalogItem item)
        {
            return FindNode(this.Nodes[0], item);
        }

        private TreeNode FindNode(TreeNode startNode, CatalogItem item)
        {
            CatalogItem startNodeItem = startNode.Tag as CatalogItem;
            if (startNodeItem != null && startNodeItem.VPath == item.VPath)
            {
                return startNode;
            }

            if (startNode.Nodes != null)
            {
                foreach (TreeNode node in startNode.Nodes)
                {
                    TreeNode xNode = FindNode(node, item);
                    if (xNode != null)
                        return xNode;
                }
            }

            return null;
        }

        private TreeNode[] BrowseCatalogFolders(Catalog cat)
        {
            //Application.DoEvents();

            CatalogItem[] roots = cat.GetRoots();
            TreeNode[] nodes = new TreeNode[roots.Length];

            for (int i = 0; i < roots.Length; i++)
            {
                TreeNode[] rootChildren = BuildChildren(cat, roots[i]);

                nodes[i] = new TreeNode(roots[i].Name, rootChildren);
                nodes[i].Name = roots[i].VPath;
                nodes[i].ImageIndex = nodes[i].SelectedImageIndex = (int)roots[i].ItemType + 1;
                nodes[i].Tag = roots[i];
            }

            return nodes;
        }

        private TreeNode[] BuildChildren(Catalog cat, CatalogItem folder)
        {
            DateTime start = DateTime.Now;

            //Application.DoEvents();

            List<TreeNode> firstLevelNodes = new List<TreeNode>();

            if (folder.IsFolder)
            {
                CatalogItem[] children = cat.FindItems(folder, "FLD", string.Empty, string.Empty, true);

                List<CatalogItem> childList = new List<CatalogItem>(children);

                childList.Sort(delegate(CatalogItem ci1, CatalogItem ci2)
                {
                    if (ci1 == null && ci2 == null)
                        return 0;
                    if (ci1 == null)
                        return -1;
                    if (ci2 == null)
                        return 1;

                    if (ci1.ParentItemID == ci2.ParentItemID)
                    {
                        return (int)(ci1.ItemID - ci2.ItemID);
                    }
                    else
                    {
                        return (int)(ci1.ParentItemID - ci2.ParentItemID);
                    }
                });

                Dictionary<long, TreeNode> treeNodes = new Dictionary<long, TreeNode>();

                for (int i = 0; i < childList.Count; i++)
                {
                    TreeNode node = new TreeNode(childList[i].Name);
                    node.Name = childList[i].VPath;
                    node.Tag = childList[i];
                    node.ImageIndex = node.SelectedImageIndex = (int)childList[i].ItemType + 1;

                    if (treeNodes.ContainsKey(childList[i].ParentItemID))
                    {
                        treeNodes[childList[i].ParentItemID].Nodes.Add(node);
                    }
                    
                    if (!treeNodes.ContainsKey(childList[i].ItemID))
                    {
                        treeNodes.Add(childList[i].ItemID, node);
                    }

                    if (childList[i].ParentItemID == folder.ItemID)
                    {
                        firstLevelNodes.Add(node);
                    }
                }
            }

            return firstLevelNodes.ToArray();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        internal void Reload(CatalogItem target)
        {
            if (target != null)
            {
                foreach (TreeNode node in Nodes)
                {
                    if (target.Equals(node.Tag as CatalogItem))
                    {
                        node.Text = (node.Tag as CatalogItem).Name;
                        return;
                    }
                }
            }

            foreach (TreeNode node in Nodes)
            {
                if (ReloadTreeNode(target, node))
                    return;
            }
        }

        private bool ReloadTreeNode(CatalogItem target, TreeNode tn)
        {
            CatalogItem ci = tn.Tag as CatalogItem;
            if (ci != null)
            {
                if (target != null)
                {
                    if (target.Equals(tn.Tag as CatalogItem))
                    {
                        tn.Text = (tn.Tag as CatalogItem).Name;
                        return true;
                    }
                }
                else
                {
                    tn.Text = ci.Name;
                }
            }

            if (tn.Nodes != null && tn.Nodes.Count > 0)
            {
                if (target != null)
                {
                    foreach (TreeNode node in tn.Nodes)
                    {
                        if (target.Equals(node.Tag as CatalogItem))
                        {
                            node.Text = (node.Tag as CatalogItem).Name;
                            return true;
                        }
                    }
                }

                foreach (TreeNode node in tn.Nodes)
                {
                    if (ReloadTreeNode(target, node))
                        return true;
                }
            }

            return false;
        }
    }
}
