using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Properties;

namespace OPMedia.UI.Configuration
{
    public partial class ConnectedFilesConfigCtl : BaseCfgPanel
    {
        Dictionary<string, string> _tableConnFiles = new Dictionary<string, string>();

        MultilineEditTextBox _txtEditPFT = new MultilineEditTextBox();
        MultilineEditTextBox _txtEditCFT = new MultilineEditTextBox();

        private ToolTip _tip = new ToolTip();

        public ConnectedFilesConfigCtl()
        {
            InitializeComponent();
            
            lvConnFiles.RegisterEditControl(_txtEditPFT);
            lvConnFiles.RegisterEditControl(_txtEditCFT);

            btnAdd.Image = Resources.Add;

            _tip.SetToolTip(btnAdd, Translator.Translate("TXT_ADD"));

            lvConnFiles.Visible = false;

            lvConnFiles.Resize += new EventHandler(lvConnFiles_Resize);
            this.Load += new EventHandler(ConnectedFilesConfigCtl_Load);
        }

        void lvConnFiles_Resize(object sender, EventArgs e)
        {
            int w = lvConnFiles.Width - SystemInformation.VerticalScrollBarWidth;
            colID.Width = 0;
            colPFT.Width = colCFT.Width = w / 2;
        }

        void ConnectedFilesConfigCtl_Load(object sender, EventArgs e)
        {
            chkUseLinkedFiles.Checked = SuiteConfiguration.UseLinkedFiles;
            lvConnFiles.Visible = chkUseLinkedFiles.Checked;
            chkUseLinkedFiles.CheckedChanged += new System.EventHandler(this.chkUseLinkedFiles_CheckedChanged);

            _tableConnFiles = SuiteConfiguration.LinkedFilesTable;
            FillData();

            lvConnFiles_Resize(sender, e);
            lvConnFiles.SubItemEdited += new OPMListView.EditableListViewEventHandler(lvConnFiles_SubItemEdited);
        }

        private void FillData()
        {
            int sel = -1;

            if (lvConnFiles.SelectedIndices.Count > 0)
            {
                sel = lvConnFiles.SelectedIndices[0];
            }

            lvConnFiles.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in _tableConnFiles)
            {
                string[] data = new string[] { string.Empty, kvp.Key.ToUpperInvariant(), kvp.Value.ToUpperInvariant() };

                int i = 0;

                ListViewItem item = new ListViewItem(data[i++]);

                OPMListViewSubItem subItem = new OPMListViewSubItem(_txtEditPFT, item, data[i++]);
                subItem.ReadOnly = false;
                item.SubItems.Add(subItem);

                subItem = new OPMListViewSubItem(_txtEditCFT, item, data[i++]);
                subItem.ReadOnly = false;
                item.SubItems.Add(subItem);

                lvConnFiles.Items.Add(item);
            }

            lvConnFiles.Select();
            lvConnFiles.Focus();

            if (sel > 0 && sel < lvConnFiles.Items.Count)
            {
                lvConnFiles.Items[sel].Selected = true;
            }
        }

        void lvConnFiles_SubItemEdited(object sender, ListViewSubItemEventArgs args)
        {
            RebuildDataTable();
        }

        private void RebuildDataTable()
        {
            bool errors = false;
            Dictionary<string, string> newTable = new Dictionary<string, string>();
            foreach (ListViewItem lvi in lvConnFiles.Items)
            {
                OPMListViewSubItem subItem = lvi.SubItems[colPFT.Index] as OPMListViewSubItem;
                if (subItem != null)
                {
                    if (!string.IsNullOrEmpty(subItem.Text))
                    {
                        try
                        {
                            newTable.Add(lvi.SubItems[colPFT.Index].Text.ToUpperInvariant(), lvi.SubItems[colCFT.Index].Text.ToUpperInvariant());
                            subItem.IsValid = true;
                        }
                        catch
                        {
                            subItem.IsValid = false;
                            errors = true;
                        }
                    }
                }
                else
                {
                    errors = true;
                    break;
                }
            }

            lvConnFiles.Invalidate();


            if (!errors)
            {
                _tableConnFiles = new Dictionary<string, string>(newTable);
                FillData();
                Modified = true;
            }
        }

        void chkUseLinkedFiles_CheckedChanged(object sender, System.EventArgs e)
        {
            lvConnFiles.Visible = chkUseLinkedFiles.Checked;
            Modified = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] data = new string[] { string.Empty, Translator.Translate("TXT_PARENTFILETYPES"), Translator.Translate("TXT_CHILDFILETYPES") };

            lvConnFiles.EndEditing(false);

            int i = 0;

            ListViewItem item = new ListViewItem(data[i++]);

            OPMListViewSubItem subItem = new OPMListViewSubItem(_txtEditPFT, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            subItem = new OPMListViewSubItem(_txtEditCFT, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            lvConnFiles.Items.Add(item);

            item.Selected = true;

            RebuildDataTable();
            Modified = true;
        }

        protected override void SaveInternal()
        {
            SuiteConfiguration.UseLinkedFiles = chkUseLinkedFiles.Checked;
            SuiteConfiguration.LinkedFilesTable = new Dictionary<string, string>(_tableConnFiles);
        }
    }
}
