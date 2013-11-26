using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Configuration;
using System.Globalization;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;

using OPMedia.Core;
using OPMedia.UI.Themes;
using OPMedia.Runtime;
using OPMedia.UI.Controls;
using OPMedia.Core.Utilities;
using OPMedia.Runtime.ProTONE.SubtitleDownload.Base;
using OPMedia.UI.ProTONE.Properties;

namespace OPMedia.UI.ProTONE.Configuration
{
    public partial class SubtitleSubtitlePage : BaseCfgPanel
    {
        List<SubtitleLanguage> languages = null;
        bool _subtitleDownloadEnabled = AppSettings.SubtitleDownloadEnabled;

        OPMComboBox _cmbEditServerType = new OPMComboBox();
        YesNoComboBox _cmbEditActive = new YesNoComboBox();
        TextBox _txtEditServer = new TextBox();
        TextBox _txtEditUser = new TextBox();
        TextBox _txtEditPswd = new TextBox();

        readonly int[] widths = new int[] { 0, 65, 120, 45, 50, 50 };

        private string _subtitleDownloadURIs = string.Empty;

        private ToolTip _tip = new ToolTip();

        protected override void SaveInternal()
        {
            AppSettings.SubtitleDownloadEnabled = _subtitleDownloadEnabled;
            AppSettings.SubtitleDownloadURIs = _subtitleDownloadURIs;

            if (cmbLanguages.SelectedItem is SubtitleLanguage)
            {
                AppSettings.PrefferedSubtitleLang =
                    (cmbLanguages.SelectedItem as SubtitleLanguage).LCID;
            }

            AppSettings.SubtitleMinimumMovieDuration = (int)nudMinMovieDuration.Value;
            AppSettings.SubDownloadedNotificationsEnabled = chkNotifySubDownloaded.Checked;
        }

        public SubtitleSubtitlePage()
        {
            InitializeComponent();

            btnAdd.Image = OPMedia.UI.Properties.Resources.Add;
            btnDelete.Image = OPMedia.UI.Properties.Resources.Del;
            btnMoveUp.Image = Resources.MoveUp;
            btnMoveDown.Image = Resources.MoveDown;

            _tip.SetToolTip(btnAdd, Translator.Translate("TXT_ADD"));
            _tip.SetToolTip(btnDelete, Translator.Translate("TXT_DELETE"));
            _tip.SetToolTip(btnMoveUp, Translator.Translate("TXT_MOVEUP"));
            _tip.SetToolTip(btnMoveDown, Translator.Translate("TXT_MOVEDOWN"));

            btnDelete.Visible = false;

            PopulateLanguages();

            ThemeManager.SetFont(lvDownloadAddresses, FontSizes.Small);
            lblMinDuration.Text = Translator.Translate("TXT_MINMOVIEDURATION");

            this.HandleCreated += new EventHandler(OnLoad);

            lvDownloadAddresses.Resize += new EventHandler(lvDownloadAddresses_Resize);
            lvDownloadAddresses.SubItemEdited += new OPMListView.EditableListViewEventHandler(OnListEdited);

            lvDownloadAddresses.RegisterEditControl(_txtEditServer);
            lvDownloadAddresses.RegisterEditControl(_cmbEditServerType);
            lvDownloadAddresses.RegisterEditControl(_cmbEditActive);
            lvDownloadAddresses.RegisterEditControl(_txtEditUser);
            lvDownloadAddresses.RegisterEditControl(_txtEditPswd);

            lvDownloadAddresses.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lvDownloadAddresses_ColumnWidthChanging);
        }

        void lvDownloadAddresses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            if (e.ColumnIndex != colServerUrl.Index)
            {
                e.NewWidth = widths[e.ColumnIndex];
            }
            else
            {
                int w = 0;
                foreach (ColumnHeader ch in lvDownloadAddresses.Columns)
                {
                    if (ch != colServerUrl)
                    {
                        w += widths[ch.Index];
                    }
                }
                w += 5;

                e.NewWidth = colServerUrl.Width = (lvDownloadAddresses.Width - w - SystemInformation.VerticalScrollBarWidth);
            }
        }

        void lvDownloadAddresses_Resize(object sender, EventArgs e)
        {
            int w = 0;
            foreach (ColumnHeader ch in lvDownloadAddresses.Columns)
            {
                if (ch != colServerUrl)
                {
                    ch.Width = widths[ch.Index];
                    w += ch.Width;
                }
            }
            w += 1;

            colServerUrl.Width = (lvDownloadAddresses.Width - w - SystemInformation.VerticalScrollBarWidth);
        }

        void OnLoad(object sender, EventArgs e)
        {
            nudMinMovieDuration.Value = AppSettings.SubtitleMinimumMovieDuration;
            nudMinMovieDuration.ValueChanged += new EventHandler(nudMinMovieDuration_ValueChanged);

            chkSubtitleDownload.Checked = _subtitleDownloadEnabled;
            chkSubtitleDownload.CheckedChanged += new EventHandler(chkSubtitleDownload_CheckedChanged);

            _subtitleDownloadURIs = AppSettings.SubtitleDownloadURIs;

            BuildListFromSubtitleDownloadURIs();

            nudMinMovieDuration.ValueChanged += new EventHandler(nudMinMovieDuration_ValueChanged);

            ThemeManager.SetFont(lblClickHint, FontSizes.Small);

            pnlOnlineSubtitles.Enabled = _subtitleDownloadEnabled;

            chkNotifySubDownloaded.Checked = AppSettings.SubDownloadedNotificationsEnabled;
        }

        private void OnAdd(object sender, EventArgs e)
        {
            string[] data = new string[] 
            { string.Empty, "Osdb", "[ URL ]", Translator.Translate("TXT_NO"), string.Empty, string.Empty };

            lvDownloadAddresses.EndEditing(false);

            int i = 0;

            ListViewItem item = new ListViewItem(data[i++]);
            
            OPMListViewSubItem subItem = new OPMListViewSubItem(_cmbEditServerType, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            subItem = new OPMListViewSubItem(_txtEditServer, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            subItem = new OPMListViewSubItem(_cmbEditActive, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            subItem = new OPMListViewSubItem(_txtEditServer, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            subItem = new OPMListViewSubItem(_txtEditUser, item, data[i++]);
            subItem.ReadOnly = false;
            item.SubItems.Add(subItem);

            lvDownloadAddresses.Items.Add(item);

            item.Selected = true;

            BuildSubtitleDownloadURIsFromList();
            Modified = true;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            lvDownloadAddresses.EndEditing(false);

            if (lvDownloadAddresses.SelectedItems != null &&
                lvDownloadAddresses.SelectedItems.Count > 0)
            {
                int selItem = lvDownloadAddresses.SelectedItems[0].Index;
                lvDownloadAddresses.Items.RemoveAt(selItem);

                if (lvDownloadAddresses.SelectedItems.Count > 0)
                {
                    selItem = Math.Min(selItem, lvDownloadAddresses.Items.Count - 1);
                    lvDownloadAddresses.Items[selItem].Selected = true;
                }

                BuildSubtitleDownloadURIsFromList();
                Modified = true;
            }
        }

        private void OnMoveUp(object sender, EventArgs e)
        {
            if (lvDownloadAddresses.SelectedItems != null &&
                lvDownloadAddresses.SelectedItems.Count > 0)
            {
                int x = lvDownloadAddresses.SelectedItems[0].Index;
                if (x > 0)
                {
                    if (SwapItems(x, x - 1))
                    {
                        lvDownloadAddresses.Items[x - 1].Selected = true;

                        Modified = true;
                    }
                }
            }
        }

        private void OnMoveDown(object sender, EventArgs e)
        {
            if (lvDownloadAddresses.SelectedItems != null &&
                lvDownloadAddresses.SelectedItems.Count > 0)
            {
                int x = lvDownloadAddresses.SelectedItems[0].Index;
                if (x < lvDownloadAddresses.Items.Count - 1)
                {
                    if (SwapItems(x, x + 1))
                    {
                        lvDownloadAddresses.Items[x + 1].Selected = true;

                        Modified = true;
                    }
                }
            }
        }

        private void cmbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void OnEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Modified = true;
        }

        private void chkSubtitleDownload_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
            _subtitleDownloadEnabled = chkSubtitleDownload.Checked;
            pnlOnlineSubtitles.Enabled = _subtitleDownloadEnabled;
        }

        private void nudMinMovieDuration_ValueChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        void OnListEdited(object sender, ListViewSubItemEventArgs args)
        {
            BuildSubtitleDownloadURIsFromList();
            Modified = true;
        }

        private bool SwapItems(int item1, int item2)
        {
            try
            {
                lvDownloadAddresses.EndEditing(false);

                if (item1 >= 0 && item2 >= 0 &&
                    item1 != item2 && item1 < lvDownloadAddresses.Items.Count &&
                    item2 < lvDownloadAddresses.Items.Count)
                {
                    ListViewItem lvi1 = lvDownloadAddresses.Items[item1].Clone() as ListViewItem;
                    ListViewItem lvi2 = lvDownloadAddresses.Items[item2].Clone() as ListViewItem;

                    if (lvi1 != null && lvi2 != null)
                    {
                        lvDownloadAddresses.Items[item1] = lvi2;
                        lvDownloadAddresses.Items[item2] = lvi1;

                        return true;
                    }
                }

                return false;
            }
            finally
            {
                BuildSubtitleDownloadURIsFromList();
                BuildListFromSubtitleDownloadURIs();
            }
        }

        private void PopulateLanguages()
        {
            cmbLanguages.Items.Clear();

            languages = new List<SubtitleLanguage>();

            languages.Add(new SubtitleLanguage(-1));

            foreach (CultureInfo ci in SubtitleLanguage.AvailableLanguages)
            {
                languages.Add(new SubtitleLanguage(ci.LCID));
            }

            languages.Sort();

            cmbLanguages.DataSource = languages;
            cmbLanguages.SelectedItem = new SubtitleLanguage(AppSettings.PrefferedSubtitleLang);

            cmbLanguages.SelectedIndexChanged += new EventHandler(cmbLanguages_SelectedIndexChanged);

        }

        private void chkNotifySubDownloaded_CheckedChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void BuildSubtitleDownloadURIsFromList()
        {
            List<string> downloadURIs = new List<string>();
            foreach (ListViewItem row in lvDownloadAddresses.Items)
            {
                List<string> data = new List<string>();
                for (int i = 1; i < row.SubItems.Count; i++)
                {
                    ListViewItem.ListViewSubItem subItem = row.SubItems[i];

                    string str = subItem.Text;
                    if (i == colActive.Index)
                    {
                        if (str == Translator.Translate("TXT_YES"))
                        {
                            str = "1";
                        }
                        else
                        {
                            str = "0";
                        }
                    }

                    data.Add(str);
                }

                downloadURIs.Add(StringUtils.FromStringArray(data.ToArray(), ';'));
            }

            _subtitleDownloadURIs = StringUtils.FromStringArray(downloadURIs.ToArray(), '\\');
        }

        private void BuildListFromSubtitleDownloadURIs()
        {
            lvDownloadAddresses.Items.Clear();

            string[] subtitleDownloadURIs = StringUtils.ToStringArray(_subtitleDownloadURIs, '\\');
            if (subtitleDownloadURIs != null)
            {
                foreach (string url in subtitleDownloadURIs)
                {
                    string[] fields = StringUtils.ToStringArray(url, ';');
                    List<String> lFields = new List<string>(fields);

                    lFields.Insert(0, string.Empty);
                    while (lFields.Count < lvDownloadAddresses.Columns.Count)
                    {
                        lFields.Add(string.Empty);
                    }
                    while (lFields.Count > lvDownloadAddresses.Columns.Count)
                    {
                        lFields.RemoveAt(lFields.Count - 1);
                    }

                    if (lFields[colActive.Index] == "1")
                        lFields[colActive.Index] = Translator.Translate("TXT_YES");
                    else
                        lFields[colActive.Index] = Translator.Translate("TXT_NO");

                    ListViewItem item = new ListViewItem(lFields[0]);

                    bool isDefaultServer = SuiteConfiguration.DefaultSubtitleURIs.ToUpperInvariant().Contains(
                        lFields[colServerUrl.Index].ToUpperInvariant());

                    for(int i = 1; i < lFields.Count; i++)
                    {
                        OPMListViewSubItem subItem = null;
                        string text = lFields[i];

                        if (i == colServerType.Index)
                        {
                            subItem = new OPMListViewSubItem(_cmbEditServerType, item, text);
                            subItem.ReadOnly = isDefaultServer;
                        }
                        else if (i == colServerUrl.Index)
                        {
                            subItem = new OPMListViewSubItem(_txtEditServer, item, text);
                            subItem.ReadOnly = isDefaultServer;
                        }
                        else if (i == colActive.Index)
                        {
                            subItem = new OPMListViewSubItem(_cmbEditActive, item, text);
                            subItem.ReadOnly = false;
                        }
                        else if (i == colUserName.Index)
                        {
                            subItem = new OPMListViewSubItem(_txtEditUser, item, text);
                            subItem.ReadOnly = false;
                        }
                        else if (i == colPassword.Index)
                        {
                            subItem = new OPMListViewSubItem(_txtEditPswd, item, text);
                            subItem.ReadOnly = false;
                        }

                        item.SubItems.Add(subItem);
                    }
                    
                    lvDownloadAddresses.Items.Add(item);
                }
            }
        }

        private void lvDownloadAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = false;

            try
            {
                if (lvDownloadAddresses.SelectedItems != null && lvDownloadAddresses.SelectedItems.Count == 1)
                {
                    ListViewItem item = lvDownloadAddresses.SelectedItems[0];
                    string serverUrl = item.SubItems[colServerUrl.Index].Text;

                    bool isDefaultServer = SuiteConfiguration.DefaultSubtitleURIs.ToUpperInvariant().Contains(
                        serverUrl.ToUpperInvariant());

                    enable = !isDefaultServer;
                }
            }
            finally
            {
                btnDelete.Visible = enable;
            }
        }

        void btnRestoreDefaults_Click(object sender, System.EventArgs e)
        {
            if (MessageDisplay.Query("TXT_CONFIRM_RESTORE", "TXT_RESTORE_DEFAULTSERVERS",
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _subtitleDownloadURIs = SuiteConfiguration.DefaultSubtitleURIs;
                BuildListFromSubtitleDownloadURIs();
                Modified = true;
            }
        }

    }

    #region SubtitleLanguage class

    public class SubtitleLanguage : IComparable
    {
        private static CultureInfo[] __cultures =
            CultureInfo.GetCultures(CultureTypes.NeutralCultures);

        public static CultureInfo[] AvailableLanguages
        {
            get { return __cultures; }
        }

        public int LCID = -1;

        public SubtitleLanguage(int lcid)
        {
            LCID = lcid;
        }

        public override int GetHashCode()
        {
            return LCID.GetHashCode();
        }

        public override string ToString()
        {
            if (LCID > 0)
            {
                CultureInfo ci = new CultureInfo(LCID);

                return string.Format("{0} | {1} | {2}",
                    StringUtils.CapitalizeWords(ci.EnglishName), 
                    StringUtils.CapitalizeWords(ci.NativeName), 
                    ci.TwoLetterISOLanguageName.ToUpperInvariant());
            }

            return "[ " + Translator.Translate("TXT_NO_LANG") + " ]";
        }

        public override bool Equals(object obj)
        {
            if (obj is SubtitleLanguage)
            {
                return this.LCID == (obj as SubtitleLanguage).LCID;
            }

            return false;
        }

        public static bool IsPrefferedLanguage(string lang)
        {
            foreach (CultureInfo ci in __cultures)
            {
                string ciLang = ci.EnglishName;
                int pos = ci.EnglishName.LastIndexOf('(');
                if (pos > 0)
                    ciLang = ciLang.Substring(0, pos).Trim();

                if (lang.ToLowerInvariant() == ciLang.ToLowerInvariant() &&
                    ci.LCID == AppSettings.PrefferedSubtitleLang)
                {
                    return true;
                }
            }

            return false;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is SubtitleLanguage)
            {
                return this.ToString().CompareTo(obj.ToString());
            }

            return 1;
        }

        #endregion
    }

    #endregion
}

