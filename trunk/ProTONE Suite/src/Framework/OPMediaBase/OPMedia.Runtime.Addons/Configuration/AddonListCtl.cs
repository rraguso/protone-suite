using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;

using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core;
using OPMedia.UI.Generic;
using OPMedia.Runtime.Addons.Properties;
using System.Runtime.InteropServices;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.Addons.Configuration
{
    public delegate void SelectedAddonLibraryChangedHandler(AddonLibraryInfo selectedAddonLibrary);

    public partial class AddonListCtl : OPMBaseControl
    {
        public List<AddonInfo> NavigationAddons { get; set; }
        public List<AddonInfo> PropertyAddons { get; set; }
        public List<AddonInfo> PreviewAddons { get; set; }

        Dictionary<string, TreeNode> _libNodes = new Dictionary<string, TreeNode>();

        public AddonLibraryInfo SelectedAddonLibrary { get; private set; }

        public event SelectedAddonLibraryChangedHandler SelectedAddonLibraryChanged = null;

        public List<AddonInfo> AllAddons
        {
            get
            {
                List<AddonInfo> list = new List<AddonInfo>();

                list.AddRange(NavigationAddons);
                list.AddRange(PropertyAddons);
                list.AddRange(PreviewAddons);

                return list;
            }
        }

        public void RemoveAddon(AddonInfo ai)
        {
            if (NavigationAddons.Contains(ai))
            {
                NavigationAddons.Remove(ai);
            }
            else if (PropertyAddons.Contains(ai))
            {
                PropertyAddons.Remove(ai);
            }
            else if (PreviewAddons.Contains(ai))
            {
                PreviewAddons.Remove(ai);
            }
        }

        public AddonListCtl()
        {
            this.SelectedAddonLibrary = null;

            InitializeComponent();
            this.Load += new EventHandler(AddonListCtl_Load);
        }

        void AddonListCtl_Load(object sender, EventArgs e)
        {
            tvAddons.KeyDown += new KeyEventHandler(tvAddons_KeyDown);

            //tvAddons.ForeColor = ThemeManager.LinkColor;
            tvAddons.Font = ThemeManager.NormalBoldFont;
            tvAddons.Nodes.Clear();

            foreach (AddonInfo ai in AllAddons)
            {
                if (!_libNodes.ContainsKey(ai.LibraryName))
                {
                    TreeNode tnLibrary = new TreeNode(ai.LibraryName);
                    tnLibrary.NodeFont = ThemeManager.LargeFont;
                    tnLibrary.Tag = new AddonLibraryInfo(ai);
                    tvAddons.Nodes.Add(tnLibrary);
                    _libNodes.Add(ai.LibraryName, tnLibrary);

                    TreeNode tnCategory = new TreeNode(Translator.Translate("TXT_NAV_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.NormalBoldFont;
                    tnCategory.Tag = "nav";
                    tnLibrary.Nodes.Add(tnCategory);

                    tnCategory = new TreeNode(Translator.Translate("TXT_PROP_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.NormalBoldFont;
                    tnCategory.Tag = "prop";
                    tnLibrary.Nodes.Add(tnCategory);

                    tnCategory = new TreeNode(Translator.Translate("TXT_PREVIEW_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.NormalBoldFont;
                    tnCategory.Tag = "preview";
                    tnLibrary.Nodes.Add(tnCategory);
                }
            }
            
            foreach (AddonInfo ai in NavigationAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[0];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallFont;
                tn.Tag = ai;
                catNode.Nodes.Add(tn);
            }
            foreach (AddonInfo ai in PropertyAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[1];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallFont; 
                tn.Tag = ai;
                catNode.Nodes.Add(tn);
            }
            foreach (AddonInfo ai in PreviewAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[2];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallFont;
                tn.Tag = ai;
                catNode.Nodes.Add(tn);
            }

            UpdateTreeNodes(); 
           
            tvAddons.AfterSelect += new TreeViewEventHandler(tvAddons_AfterSelect);

            tvAddons.ExpandAll();
            tvAddons.SelectedNode = tvAddons.Nodes[0];
        }

        protected override void OnThemeUpdatedInternal()
        {
            UpdateTreeNodes();
        }

        private void UpdateTreeNodes()
        {
            tvAddons.AfterCheck -= new TreeViewEventHandler(OnNodeChecked);
            foreach (TreeNode tn in tvAddons.Nodes)
            {
                UpdateTreeNode(tn);
            }
            tvAddons.AfterCheck += new TreeViewEventHandler(OnNodeChecked);
        }

        private bool UpdateTreeNode(TreeNode tn)
        {
            tn.ForeColor = ThemeManager.ForeColor;

            AddonInfo ai = tn.Tag as AddonInfo;
            if (ai != null)
            {
                tn.Checked = (ai.Selected || ai.IsRequired);
                if (ai.IsRequired)
                    HighlightNode(tn);

                return (ai.Selected || ai.IsRequired);
            }

            bool check = false;
            foreach (TreeNode child in tn.Nodes)
            {
                check |= UpdateTreeNode(child);
            }

            tn.Checked = check;

            if (IsRequiredNode(tn))
                HighlightNode(tn);

            return check;
        }

        public void HighlightNode(TreeNode tn)
        {
            if (!tn.Text.StartsWith("* "))
                tn.Text = "* " + tn.Text;

            tn.ForeColor = ThemeManager.BorderColor;
            //tn.NodeFont = ThemeManager.NormalBoldFont;
        }

        void tvAddons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        void tvAddons_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.SelectedAddonLibrary = e.Node.Tag as AddonLibraryInfo;

            if (SelectedAddonLibraryChanged != null)
            {
                SelectedAddonLibraryChanged(this.SelectedAddonLibrary);
            }
        }

        internal void SelectAll()
        {
            foreach (TreeNode tn in _libNodes.Values)
            {
                tn.Checked = true;
            }
        }

        private void OnNodeChecked(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Collapse ||
                e.Action == TreeViewAction.Expand)
                return;
            
            Logger.LogTrace("OnNodeChecked: " + e);

            try
            {
                tvAddons.AfterCheck -= new TreeViewEventHandler(OnNodeChecked);

                if (IsRequiredNode(e.Node))
                {
                    e.Node.Checked = true;
                }
                else
                {
                    CheckAddon(e.Node);
                    CheckNodeParent(e.Node, e.Node.Checked);
                    CheckNodeTree(e.Node, e.Node.Checked);
                }
            }
            finally
            {
                tvAddons.AfterCheck += new TreeViewEventHandler(OnNodeChecked);
            }
        }

        private bool IsRequiredNode(TreeNode tn)
        {
            if (tn != null)
            {
                AddonInfo ai = tn.Tag as AddonInfo;
                if (ai != null)
                    return ai.IsRequired;

                foreach (TreeNode child in tn.Nodes)
                {
                    if (IsRequiredNode(child))
                        return true;
                }
            }

            return false;
        }

        private bool AnySubNodesChecked(TreeNode treeNode)
        {
            bool anyChildrenChecked = false;
            if (treeNode.Nodes != null && treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode child in treeNode.Nodes)
                {
                    bool nephewChecked = AnySubNodesChecked(child);
                    if (nephewChecked || child.Checked)
                    {
                        anyChildrenChecked = true;
                    }
                }

                treeNode.Checked = anyChildrenChecked;
            }

            return anyChildrenChecked;
        }


        private void CheckNodeParent(TreeNode tn, bool check)
        {
            if (tn.Parent != null)
            {
                bool siblingChecked = false;
                foreach (TreeNode sibling in tn.Parent.Nodes)
                {
                    siblingChecked |= sibling.Checked | IsRequiredNode(sibling);

                }

                tn.Parent.Checked = check || siblingChecked;
                CheckAddon(tn.Parent);

                CheckNodeParent(tn.Parent, check);
            }
        }

        public void CheckNodeTree(TreeNode tn, bool check)
        {
            if (tn.Nodes != null)
            {
                foreach (TreeNode child in tn.Nodes)
                {
                    child.Checked = check;
                    CheckAddon(child);

                    CheckNodeTree(child, check);
                }
            }
        }

        

        private void CheckAddon(TreeNode tn)
        {
            AddonInfo ai = tn.Tag as AddonInfo;
            if (ai != null)
            {
                ai.Selected = tn.Checked;
            }
        }

        
    }

    public class AddonInfo
    {
        public bool IsNative { get; set; }
        public bool Selected { get; set; }
        public string Name { get; set; }
        public string CodeBase { get; set; }
        public string LibraryName { get; set; }
        public bool IsRequired { get; private set; }

        public string TranslatedName
        {
            get
            {
                string tagName = string.Format("TXT_{0}", Name.Replace(".", "").ToUpperInvariant());
                return Translator.Translate(tagName);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} Selected={1}", Name, Selected);
        }

        public AddonInfo(string name, string codeBase, bool selected, bool isRequired)
        {
            this.Name = name;
            this.CodeBase = codeBase;
            this.Selected = selected;
            this.IsNative = name.ToLowerInvariant().Contains("builtin");
            this.LibraryName = codeBase.Split("|".ToCharArray())[0];
            this.IsRequired = isRequired;
        }
    }

    public class AddonLibraryInfo
    {
        public bool IsRequired { get; private set; }
        public bool IsNative { get; private set; }
        public string CodeBase { get; private set; }
        public string LibraryName { get; private set; }

        public List<AddonInfo> NavigationAddons { get; private set; }
        public List<AddonInfo> PropertyAddons { get; private set; }
        public List<AddonInfo> PreviewAddons { get; private set; }

        public AddonLibraryInfo(AddonInfo ai)
        {
            this.IsNative = ai.IsNative;
            this.CodeBase = ai.CodeBase;
            this.LibraryName = ai.LibraryName;

            this.NavigationAddons = new List<AddonInfo>();
            this.PropertyAddons = new List<AddonInfo>();
            this.PreviewAddons = new List<AddonInfo>();
        }
    }
}
