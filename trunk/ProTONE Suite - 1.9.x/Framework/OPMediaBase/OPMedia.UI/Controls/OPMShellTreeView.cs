#region Using directives
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using System.Collections;
using OPMedia.Core;
using OPMedia.Core.ComTypes;
using System.Collections.Generic;
using OPMedia.UI.Controls;

#endregion

namespace OPMedia.UI.Controls
{
	#region OPMShellTreeView Class
	public class OPMShellTreeView : OPMTreeView
    {
        #region Members
        private System.Windows.Forms.ImageList OPMShellTreeViewImageList;
        #endregion

        #region Constructors
        /// <summary>
        /// Default contructor.
        /// </summary>
        public OPMShellTreeView()
            : base()
		{
            this.LabelEdit = false;
            this.ShowSpecialFolders = false;

            this.KeyUp += new KeyEventHandler(OPMShellTreeView_KeyUp);

			this.BeforeExpand += 
                new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewBeforeExpand);

            this.BeforeLabelEdit += new NodeLabelEditEventHandler(OPMShellTreeView_BeforeLabelEdit);
            this.AfterLabelEdit += new NodeLabelEditEventHandler(OPMShellTreeView_AfterLabelEdit);
		}

        void OPMShellTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = PathUtils.IsRootPath(e.Node.FullPath);
        }

        void OPMShellTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (SelectedNode != null)
                {
                    SelectedNode.BeginEdit();
                }
            }
        }

        void OPMShellTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Label))
            {
                string newName = e.Label;
                DirectoryInfo di = new DirectoryInfo(e.Node.FullPath);
                if (di != null && di.Exists && di.Parent != null && di.Parent.Exists)
                {
                    string newPath = Path.Combine(di.Parent.FullName, newName);

                    try
                    {
                        di.MoveTo(newPath);
                        e.Node.Name = di.Name;
                        e.Node.Tag = di;
                        e.CancelEdit = false;

                        SelectedNode = null;
                        SelectedNode = e.Node;

                        return;
                    }
                    catch { }
                }
            }

            e.CancelEdit = true;
        }

        /// <summary>
        /// Initializes the tree vew.
        /// </summary>
        public void InitOPMShellTreeView()
		{
			InitImageList();
            ShellOperations.PopulateTree(this, base.ImageList, ShowSpecialFolders);
            this.SelectedNode = null;
		}

        public TreeNode CreateTreeNode(DirectoryInfo di, bool getIcons = true)
        {
            return ShellOperations.CreateTreeNode(di, base.ImageList, getIcons);
        }

        /// <summary>
        ///  Initializes the system image list.
        /// </summary>
		private void InitImageList()
		{
			// setup the image list to hold the folder icons
			OPMShellTreeViewImageList = new System.Windows.Forms.ImageList();
			OPMShellTreeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			OPMShellTreeViewImageList.ImageSize = new System.Drawing.Size(16, 16);
			OPMShellTreeViewImageList.TransparentColor = System.Drawing.Color.Gainsboro;

			// add the Desktop icon to the image list
			try
			{
				OPMShellTreeViewImageList.Images.Add(ImageProvider.GetDesktopIcon(false));
			}
			catch
			{
				// Create a blank icon if the desktop icon fails for some reason
				Bitmap bmp = new Bitmap(16,16);
				Image img = (Image)bmp;
				OPMShellTreeViewImageList.Images.Add((Image)img.Clone());
				bmp.Dispose();
			}
			this.ImageList = OPMShellTreeViewImageList;
		}

		#endregion

		#region Event Handlers

		private void TreeViewBeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			this.BeginUpdate();
			ShellOperations.ExpandBranch(e.Node, this.ImageList);
			this.EndUpdate();
		}

		#endregion

		#region Properties & Methods

        public bool ShowSpecialFolders { get; set; }

		public string SelectedNodePath
		{
            get
            {
                return ShellOperations.GetFilePath(SelectedNode);
            }
		}

		public bool DrillToFolder(string folderPath)
		{
			bool folderFound = false;
			if(Directory.Exists(folderPath)) // don't bother drilling unless the directory exists
			{
				this.BeginUpdate();
				// if there's a trailing \ on the folderPath, remove it unless it's a drive letter
				if(folderPath.Length > 3 && folderPath.LastIndexOf(PathUtils.DirectorySeparator) == folderPath.Length -1)
					folderPath = folderPath.Substring(0, folderPath.Length -1);
				
                //Start drilling the tree
				DrillTree(this.Nodes, folderPath.ToUpperInvariant(), ref folderFound);
				this.EndUpdate();
			}
            
			return folderFound;
		}

		private void DrillTree(TreeNodeCollection tnc, string path, ref bool folderFound)
		{
			foreach(TreeNode tn in tnc)
			{
				if(!folderFound)
				{
                    // Some brief preconditions checks here ...
                    DirectoryInfo folder = tn.Tag as DirectoryInfo;
                    if (folder == null)
                    {
                        folderFound = false;
                        return;
                    }

                    string tnPath = folder.FullName.ToUpperInvariant();
					if(path == tnPath && !folderFound)
					{
                        // We have found the node !!! Congratulations ...
                        // Probably the path to the node is fully expanded now (at least, it should be !).
                        this.Select();
                        this.Focus();
						this.SelectedNode = tn;

                        // Make sure we have it visible.
						tn.EnsureVisible();
                        // Tell above that we have found the node and to stop searching.
						folderFound = true;
						return;
					}
					else if(path.StartsWith(tnPath) && !folderFound)
					{
                        // Leave the trail of expansion whenever do we go.
						tn.Expand();

                        // We're on the good track but we are not there yet, so drill deeper on. 
						DrillTree(tn.Nodes, path, ref folderFound);
					}
				}
			}
		}

		#endregion
    }
	#endregion

	#region ShellOperations Class
	public static class ShellOperations
	{
        private static Environment.SpecialFolder[] SpecialFolders = new Environment.SpecialFolder[]
            {
                Environment.SpecialFolder.Desktop,
                Environment.SpecialFolder.MyDocuments,
                Environment.SpecialFolder.Recent,
            };

		#region OPMShellTreeView Methods

		#region GetFilePath
		public static string GetFilePath(TreeNode tn)
		{
			try
			{
                return (tn.Tag as DirectoryInfo).FullName;
			}
			catch
			{
				return string.Empty;
			}
		}
		#endregion

		#region Populate Tree
        public static void PopulateTree(OPMTreeView tree, ImageList imageList, bool showSpecialFolders)
		{
			tree.Nodes.Clear();
            AddRootNodes(tree, imageList, true, showSpecialFolders);
		}
		#endregion

		#region Add Root Node
        private static void AddRootNodes(OPMTreeView tree, ImageList imageList, bool getIcons, bool showSpecialFolders)
		{
            CursorHelper.ShowWaitCursor(tree, true);

			tree.Nodes.Clear();

            List<DirectoryInfo> roots = new List<DirectoryInfo>();

            try
            {
                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                foreach (System.IO.DriveInfo di in drives)
                {
                    roots.Add(di.RootDirectory);
                }

                if (showSpecialFolders)
                {
                    foreach (Environment.SpecialFolder sf in SpecialFolders)
                    {
                        string path = Environment.GetFolderPath(sf, Environment.SpecialFolderOption.Create);
                        if (Directory.Exists(path))
                        {
                            roots.Add(new DirectoryInfo(path));
                        }
                    }
                }
            }
            catch
            {
            }
            
            foreach (DirectoryInfo di in roots)
            {
                TreeNode rootNode = CreateTreeNode(di, imageList, true);
                tree.Nodes.Add(rootNode);
                CheckForSubDirs(rootNode, imageList);

                /*
                try
                {
                    foreach (DirectoryInfo sdi in di.EnumerateDirectories())
                    {
                        TreeNode tn = CreateTreeNode(sdi, imageList, getIcons);
                        rootNode.Nodes.Add(tn);
                        
                        CursorHelper.ShowWaitCursor(tree, true);
                    }
                }
                catch
                {

                }*/
            }

            CursorHelper.ShowWaitCursor(tree, false);
		}
		#endregion

		#region Fill Sub Dirs
		private static void FillSubDirectories(TreeNode tn, ref int imageCount, ImageList imageList, bool getIcons)
		{
            if (tn.Tag != null && tn.Tag is DirectoryInfo)
            {
                CursorHelper.ShowWaitCursor(tn.TreeView, true);

                DirectoryInfo di = tn.Tag as DirectoryInfo;

                foreach (DirectoryInfo sdi in di.EnumerateDirectories())
                {
                    TreeNode ntn = CreateTreeNode(sdi, imageList, getIcons);
                    tn.Nodes.Add(ntn);
                    CheckForSubDirs(ntn, imageList);

                    CursorHelper.ShowWaitCursor(tn.TreeView, true);
                }

                CursorHelper.ShowWaitCursor(tn.TreeView, false);
            }
		}
		#endregion

		#region Create Dummy Node

        [DllImport("shlwapi.dll")]
        public static extern bool PathIsDirectoryEmpty(string pszPath);

		private static void CheckForSubDirs(TreeNode tn, ImageList imageList)
		{
            CursorHelper.ShowWaitCursor(tn.TreeView, true);

			if(tn.Nodes.Count == 0)
			{
				try
				{
					// create dummy nodes for any subfolders that have further subfolders
                    DirectoryInfo di = tn.Tag as DirectoryInfo;
                    bool hasFolders = (new List<DirectoryInfo>(di.EnumerateDirectories()).Count) > 0;
					if(hasFolders)
					{
						TreeNode ntn = new TreeNode();
						ntn.Tag = "DUMMYNODE";
						tn.Nodes.Add(ntn);
					}
				}
				catch
                {
                }
			}

            CursorHelper.ShowWaitCursor(tn.TreeView, false);
		}
		#endregion

		#region Expand Branch
		public static void ExpandBranch(TreeNode tn, ImageList imageList)
		{
            CursorHelper.ShowWaitCursor(tn.TreeView, true);

			// if there's a dummy node present, clear it and replace with actual contents
			if(tn.Nodes.Count == 1 && tn.Nodes[0].Tag.ToString() == "DUMMYNODE")
			{
				tn.Nodes.Clear();

                DirectoryInfo di = tn.Tag as DirectoryInfo;

                foreach (DirectoryInfo sdi in di.EnumerateDirectories())
				{
					TreeNode ntn = CreateTreeNode(sdi, imageList, true);
					tn.Nodes.Add(ntn);
					CheckForSubDirs(ntn, imageList);

                    CursorHelper.ShowWaitCursor(tn.TreeView, true);
				}
			}

            CursorHelper.ShowWaitCursor(tn.TreeView, false);
		}
		#endregion

		public static TreeNode CreateTreeNode(DirectoryInfo di, ImageList imageList, bool getIcons)
		{
			TreeNode tn = new TreeNode();
			tn.Text = di.Name;
			tn.Tag = di;

			if(getIcons)
			{
				try
				{
                    imageList.Images.Add(ImageProvider.GetIcon(di.FullName, false)); // normal icon
                    tn.ImageIndex = imageList.Images.Count - 1;
                    imageList.Images.Add(ImageProvider.GetIcon(di.FullName, true)); // selected icon
                    tn.SelectedImageIndex = imageList.Images.Count - 1;
				}
				catch // use default 
				{
					tn.ImageIndex = 1;
					tn.SelectedImageIndex = 2;
				}
			}
			else // use default
			{
				tn.ImageIndex = 1;
				tn.SelectedImageIndex = 2;
			}
			return tn;
		}

		#endregion
	}

	#endregion
}

