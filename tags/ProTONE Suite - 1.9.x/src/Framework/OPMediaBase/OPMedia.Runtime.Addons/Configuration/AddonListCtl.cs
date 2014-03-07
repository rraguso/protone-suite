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
            tvAddons.Font = ThemeManager.NormalBoldFont;
            tvAddons.Nodes.Clear();
            
            foreach (AddonInfo ai in AllAddons)
            {
                if (!_libNodes.ContainsKey(ai.LibraryName))
                {
                    TreeNode tnLibrary = new TreeNode(ai.LibraryName);
                    tnLibrary.NodeFont = ThemeManager.NormalBoldFont;
                    tnLibrary.Tag = new AddonLibraryInfo(ai);
                    tvAddons.Nodes.Add(tnLibrary);
                    _libNodes.Add(ai.LibraryName, tnLibrary);

                    TreeNode tnCategory = new TreeNode(Translator.Translate("TXT_NAV_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.SmallFont;
                    tnCategory.Tag = "nav";
                    tnLibrary.Nodes.Add(tnCategory);

                    tnCategory = new TreeNode(Translator.Translate("TXT_PROP_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.SmallFont;
                    tnCategory.Tag = "prop";
                    tnLibrary.Nodes.Add(tnCategory);

                    tnCategory = new TreeNode(Translator.Translate("TXT_PREVIEW_ADDONS"));
                    tnCategory.NodeFont = ThemeManager.SmallFont;
                    tnCategory.Tag = "preview";
                    tnLibrary.Nodes.Add(tnCategory);
                }
            }
            
            foreach (AddonInfo ai in NavigationAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[0];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallestFont;
                tn.Tag = ai;
                tn.Checked = ai.Selected || ai.IsRequired;
                catNode.Nodes.Add(tn);
            }
            foreach (AddonInfo ai in PropertyAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[1];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallestFont; 
                tn.Tag = ai;
                tn.Checked = ai.Selected || ai.IsRequired;
                catNode.Nodes.Add(tn);
            }
            foreach (AddonInfo ai in PreviewAddons)
            {
                TreeNode libNode = _libNodes[ai.LibraryName];
                TreeNode catNode = libNode.Nodes[2];

                TreeNode tn = new TreeNode(ai.TranslatedName);
                tn.NodeFont = ThemeManager.SmallestFont;
                tn.Tag = ai;
                tn.Checked = ai.Selected || ai.IsRequired;
                catNode.Nodes.Add(tn);
            }

            tvAddons.AfterCheck -= new TreeViewEventHandler(OnNodeChecked);
            foreach (TreeNode tn in tvAddons.Nodes)
            {
                CheckNodeState(tn);
            }
            tvAddons.AfterCheck += new TreeViewEventHandler(OnNodeChecked);

            tvAddons.AfterSelect += new TreeViewEventHandler(tvAddons_AfterSelect);

            tvAddons.ExpandAll();
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

            tvAddons.AfterCheck -= new TreeViewEventHandler(OnNodeChecked);

            CheckAddon(e.Node);

            CheckNodeParent(e.Node, e.Node.Checked);
            CheckNodeTree(e.Node, e.Node.Checked);

            tvAddons.AfterCheck += new TreeViewEventHandler(OnNodeChecked);
        }

        private void CheckNodeParent(TreeNode tn, bool check)
        {
            if (tn.Parent != null)
            {
                bool siblingChecked = false;
                foreach (TreeNode sibling in tn.Parent.Nodes)
                {
                    siblingChecked |= sibling.Checked;
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

        private void CheckNodeState(TreeNode treeNode)
        {
            if (treeNode.Nodes != null && treeNode.Nodes.Count > 0)
            {
                bool anyChildChecked = false;

                foreach (TreeNode child in treeNode.Nodes)
                {
                    CheckNodeState(child);
                    anyChildChecked |= child.Checked;
                }

                treeNode.Checked = anyChildChecked;
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
                
                if (IsRequired)
                {
                    return "* " + Translator.Translate(tagName);
                }

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
        public bool IsNative { get; private set; }
        public string CodeBase { get; private set; }
        public string LibraryName { get; private set; }

        public AddonLibraryInfo(AddonInfo ai)
        {
            this.IsNative = ai.IsNative;
            this.CodeBase = ai.CodeBase;
            this.LibraryName = ai.LibraryName;
        }
    }
}
