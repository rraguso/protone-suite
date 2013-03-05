using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime;
using System.IO;
using System.Drawing;
using OPMedia.UI.Controls;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.Runtime.Addons;
using OPMedia.Core.TranslationSupport;
using System.ComponentModel;
using OPMedia.Addons.Builtin.Navigation.CatalogExplorer.DataLayer;
using OPMedia.Core.Utilities;
using OPMedia.Addons.Builtin.Properties;

namespace OPMedia.Addons.Builtin.CatalogExplorer.Controls
{
    public delegate void NavigateUpHandler();

    public class CatalogListView : OPMListView
    {
        private ImageList ilItems;
        private Catalog _cat = null;

        public readonly ColumnHeader colImage = new ColumnHeader();
        public readonly ColumnHeader colItemName = new ColumnHeader();
        public readonly ColumnHeader colDate = new ColumnHeader();
        public readonly ColumnHeader colPath = new ColumnHeader();

        public event NavigateUpHandler NavigateUp = null;

        [ReadOnly(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private new ColumnHeaderCollection Columns
        {
            get
            {
                return base.Columns;
            }
        }

        #region Events
        /// <summary>
        /// Occurs when a directory is double clicked.
        /// Directory path is part of the event data.
        /// </summary>
        public event DoubleClickDirectoryEventHandler DoubleClickDirectory = null;
        /// <summary>
        /// Occurs when a file is double clicked.
        /// File path is part of the event data.
        /// </summary>
        public event DoubleClickFileEventHandler DoubleClickFile = null;
        /// <summary>
        /// Occurs when a directory is selected.
        /// Directory path is part of the event data.
        /// </summary>
        public event SelectDirectoryEventHandler SelectDirectory = null;
        /// <summary>
        /// Occurs when a file is selected.
        /// File path is part of the event data.
        /// </summary>
        public event SelectFileEventHandler SelectFile = null;
        /// <summary>
        /// Occurs when multiple items are selected.
        /// Items paths are part of the event data.
        /// </summary>
        public event SelectMultipleItemsEventHandler SelectMultipleItems = null;
        #endregion

        public Image GetImageOfItemType(int itemType)
        {
            return ilItems.Images[itemType + 1];
        }

        public CatalogListView()
            : base()
        {
            CreateColumns();

            ilItems = new ImageList();
            ilItems.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilItems.ImageSize = new System.Drawing.Size(16, 16);
            ilItems.TransparentColor = System.Drawing.Color.Gainsboro;
            ilItems.Images.Clear();

            this.SmallImageList = ilItems;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            ilItems.Images.Add(Resources.Catalog16);
            
            LoadShell32Image(Shell32Icon.DriveUnknown);
            LoadShell32Image(Shell32Icon.DriveNoRoot);
            LoadShell32Image(Shell32Icon.DriveRemovable);
            LoadShell32Image(Shell32Icon.DriveFixed);
            LoadShell32Image(Shell32Icon.DriveNetwork);
            LoadShell32Image(Shell32Icon.DriveCdrom);
            LoadShell32Image(Shell32Icon.DriveRamdisk);
            LoadShell32Image(Shell32Icon.GenericFolder);
            LoadShell32Image(Shell32Icon.GenericFile);

            this.DoubleClick += new EventHandler(this.OnDoubleClick);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            this.Resize += new EventHandler(CatalogListView_Resize);

            this.ShowItemToolTips = true;
            this.LabelEdit = true;
            this.BeforeLabelEdit += new LabelEditEventHandler(OnCellBeginEdit);
            this.AfterLabelEdit += new LabelEditEventHandler(OnCellEndEdit);

            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        }

        void CatalogListView_Resize(object sender, EventArgs e)
        {
            colDate.Width = 110;
            int w = this.Width - colDate.Width - SystemInformation.VerticalScrollBarWidth;

            colItemName.Width = (int)(w / 3);
            colPath.Width = w - colItemName.Width;
        }

        /// <summary>
        /// Occurs when a key was pressed.
        /// </summary>
        private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None)
            {
                if (e.KeyCode == Keys.Back && NavigateUp != null)
                {
                    NavigateUp();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    OnDoubleClick(sender, e);
                }
            }
        }

        public void Rename()
        {
            if (this.SelectedItems != null && this.SelectedItems.Count == 1)
            {
                ListViewItem lvi = this.SelectedItems[0];
                lvi.BeginEdit();
            }
        }

        void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (this.SelectedItems == null || this.SelectedItems.Count <= 0)
                {
                    OnSelectFile(string.Empty);
                    return;
                }

                if (this.SelectedItems.Count > 1)
                {
                    OnSelectMultipleItems();
                    return;
                }

                ListViewItem item = this.SelectedItems[0];

                CatalogItem ci = item.Tag as CatalogItem;
                if (ci == null)
                {
                    return;
                }

                if (ci.IsFolder)
                {
                    OnSelectDirectory(ci.VPath);
                }
                else
                {
                    OnSelectFile(ci.VPath);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Occurs when the item was double-clicked.
        /// </summary>
        private void OnDoubleClick(object sender, System.EventArgs e)
        {
            CatalogItem ci = this.SelectedItems[0].Tag as CatalogItem;
            if (ci == null)
            {
                return;
            }

            if (ci.IsFolder)
            {
                OnDoubleClickDirectory(ci.VPath);
            }
            else
            {
                OnDoubleClickFile(ci.VPath);
            }
        }

        /// <summary>
        /// Occurs when a file item was double clicked.
        /// </summary>
        private void OnDoubleClickFile(string strPath)
        {
            if (DoubleClickFile != null)
            {
                DoubleClickFileEventArgs eventArgs = new DoubleClickFileEventArgs();
                eventArgs.m_strPath = strPath;
                DoubleClickFile(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a folder item was double clicked.
        /// </summary>
        private void OnDoubleClickDirectory(string strPath)
        {
            if (DoubleClickDirectory != null)
            {
                DoubleClickDirectoryEventArgs eventArgs = new DoubleClickDirectoryEventArgs();
                eventArgs.m_strPath = strPath;
                DoubleClickDirectory(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a file item was selected.
        /// </summary>
        private void OnSelectFile(string strPath)
        {
            if (SelectFile != null)
            {
                SelectFileEventArgs eventArgs = new SelectFileEventArgs();
                eventArgs.m_strPath = strPath;
                SelectFile(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when a folder item was selected.
        /// </summary>
        private void OnSelectDirectory(string strPath)
        {
            if (SelectDirectory != null)
            {
                SelectDirectoryEventArgs eventArgs = new SelectDirectoryEventArgs();
                eventArgs.m_strPath = strPath;
                SelectDirectory(this, eventArgs);
            }
        }

        /// <summary>
        /// Occurs when multiple items were selected.
        /// </summary>
        private void OnSelectMultipleItems()
        {
            if (SelectMultipleItems != null)
            {
                SelectMultipleItemsEventArgs eventArgs = new SelectMultipleItemsEventArgs();
                eventArgs.m_strPaths = new List<string>();
                foreach (ListViewItem item in this.SelectedItems)
                {
                    CatalogItem ci = item.Tag as CatalogItem;
                    if (ci != null)
                    {
                        eventArgs.m_strPaths.Add(ci.VPath);
                    }
                }

                SelectMultipleItems(this, eventArgs);
            }
        }

        private void LoadShell32Image(Shell32Icon shell32Icon)
        {
            ilItems.Images.Add(ImageProvider.GetShell32Icon(shell32Icon, false));
        }

        /// <summary>
        /// Sets the column names and sizes.
        /// </summary>
        private void CreateColumns()
        {
            Items.Clear();
            base.Columns.Clear();

            base.Columns.Add(colItemName);
            base.Columns.Add(colDate);
            base.Columns.Add(colPath);

            CatalogListView_Resize(null, null);
        }

        public void RemoveItem(CatalogItem item)
        {
            if (item != null)
            {
                foreach (ListViewItem row in this.Items)
                {
                    if (item.Equals(row.Tag as CatalogItem))
                    {
                        this.Items.Remove(row);
                        break;
                    }
                }
            }
        }

        public void DisplayCatalogRoots(Catalog cat)
        {
            this.Items.Clear();

            _cat = cat;

            CatalogItem[] roots = cat.GetRoots();
            foreach (CatalogItem root in roots)
            {
                string[] data = new string[]
                {
                    root.Name,
                    root.DateCreated,
                    root.OrigItemPath
                };

                ListViewItem item = new ListViewItem(data);
                item.ImageIndex = (int)root.ItemType + 1;
                item.Tag = root;

                this.Items.Add(item);
            }
        }

        public void DisplayCatalogFolder(Catalog cat, CatalogItem folder)
        {
            this.Items.Clear();

            _cat = cat;

            if (folder != null)
            {
                CatalogItem[] children = cat.GetByParentItemID(folder.ItemID);
                foreach (CatalogItem child in children)
                {
                    int imgIndex = 0;

                    if (child.IsFolder)
                    {
                        imgIndex = (int)child.ItemType + 1;
                    }
                    else
                    {
                        string ext = PathUtils.GetExtension(child.OrigItemPath);
                        if (ilItems.Images.ContainsKey(ext))
                        {
                            imgIndex = ilItems.Images.IndexOfKey(ext);
                        }
                        else
                        {
                            Image img = ImageProvider.GetIconOfFileType(ext);
                            if (img != null)
                            {
                                ilItems.Images.Add(ext, img);
                                imgIndex = ilItems.Images.Count - 1;
                            }
                        }
                    }

                    string[] data = new string[]
                    {
                        child.Name,
                        child.DateCreated,
                        child.OrigItemPath
                    };

                    ListViewItem item = new ListViewItem(data);
                    item.ImageIndex = imgIndex;
                    item.Tag = child;

                    this.Items.Add(item);
                }


            }
        }

        public void FindNode(CatalogItem item)
        {
            if (this.Items != null)
            {
                foreach (ListViewItem node in this.Items)
                {
                    CatalogItem nodeItem = node.Tag as CatalogItem;
                    if (nodeItem == null)
                        continue;

                    if (nodeItem.VPath == item.VPath)
                    {
                        //node.EnsureVisible();
                        node.Selected = true;
                        return;
                    }
                }
            }
        }

        void OnCellEndEdit(object sender, LabelEditEventArgs e)
        {
            string newName = e.Label;
            if (e.CancelEdit || string.IsNullOrEmpty(newName))
                return;

            ListViewItem row = this.Items[e.Item];

            // rename code here
            CatalogItem ci = row.Tag as CatalogItem;
            if (ci != null)
            {
                if (String.Equals(ci.Name, newName, StringComparison.InvariantCultureIgnoreCase))
                    return;

                ci.Name = newName;
                ci.Save();

                AddonHostForm masterForm = FindForm() as AddonHostForm;
                if (masterForm != null)
                {
                    masterForm.ReloadNavigation(ci);
                }
            }
        }

        void OnCellBeginEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;

            if (this.SelectedItems != null && this.SelectedItems.Count == 1)
            {
                string initialName = this.SelectedItems[0].SubItems[colItemName.Index].Text;
                e.CancelEdit = (initialName == PathUtils.ParentDir);
            }
        }

        internal void Reload(CatalogItem target)
        {
            foreach (ListViewItem item in this.Items)
            {
                CatalogItem ci = item.Tag as CatalogItem;
                if (ci != null)
                {
                    if (target != null)
                    {
                        if (target.Equals(ci))
                        {
                            item.SubItems[colItemName.Index].Text = ci.Name;
                            return;
                        }
                    }
                    else
                    {
                        item.SubItems[colItemName.Index].Text = ci.Name;
                    }
                }
            }
        }

        public void Translateheaders()
        {
            colItemName.Text = Translator.Translate("TXT_ITEMNAME");
            colDate.Text = Translator.Translate("TXT_CREATIONDATE");
            colPath.Text = Translator.Translate("TXT_MEDIAPATH");
        }
    }
}
