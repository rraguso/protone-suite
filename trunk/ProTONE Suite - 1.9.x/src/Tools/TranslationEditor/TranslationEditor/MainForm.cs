using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace TranslationEditor
{
    public partial class MainForm : Form
    {
        const string KeyPath = @"SOFTWARE\TranslationEditor";
        string _lookupPath = string.Empty;
        TranslationFile _tf = null;

        public MainForm()
        {
            InitializeComponent();

            cmbLanguage.Items.Clear();
            cmbLanguage.Items.AddRange(TranslationFile.SupportedLanguages);

            SizeColumns();

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            WindowState = FormWindowState.Maximized;

            cmbLanguage.SelectedIndex = 0;
            DisplayItem(null);

            EnableMenus();

            chkReadOnly.Checked = true;

            RegistryKey key = RegKey;
            if (key != null)
            {
                _lookupPath = key.GetValue("LastLookupPath", string.Empty) as string;
                chkReadOnly.Checked = ((int)key.GetValue("ReadOnly", (int)1) != 0);

                try
                {
                    string lang = key.GetValue("SelectedLanguage", "ro") as string;
                    if (!string.IsNullOrEmpty(lang))
                    {
                        int i = cmbLanguage.FindStringExact(lang);
                        if (i >= 0 && i < cmbLanguage.Items.Count)
                        {
                            cmbLanguage.SelectedIndex = i;
                        }
                    }
                }
                finally
                {
                    cmbLanguage.SelectedIndexChanged += new EventHandler(cmbLanguage_SelectedIndexChanged);
                }
            }

            if (_lookupPath != string.Empty)
            {
                PerformLookup(_lookupPath);
            }
            else
            {
                btnBrowseFiles_Click(null, null);
            }
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTranslations();


            RegistryKey key = RegKey;
            if (key != null)
            {
                key.SetValue("ReadOnly", (int)(chkReadOnly.Checked ? 1 : 0));
            }
        }

        private void SaveTranslations()
        {
            if (_tf != null)
            {
                if (chkReadOnly.Checked && _tf.IsModified)
                {
                    MessageBox.Show("Read-Only mode => Your changes will be lost !!");
                }
                else
                {
                    _tf.Save();
                }
            }
        }

        RegistryKey _regKey = null;

        private RegistryKey RegKey
        {
            get
            {
                if (_regKey == null)
                {

                    _regKey = Registry.LocalMachine.OpenSubKey(KeyPath, true);
                    if (_regKey == null)
                    {
                        _regKey = Registry.LocalMachine.CreateSubKey(KeyPath);
                    }
                }

                return _regKey;
            }
        }

        private void lvTranslations_Resize(object sender, EventArgs e)
        {
            SizeColumns();
        }

        private void SizeColumns()
        {
            hdrStringName.Width = 200;
            hdrBaseText.Width = hdrTranslatedText.Width =
                (lvTranslations.Width - 200 - SystemInformation.VerticalScrollBarWidth) / 2;

        }

        private void btnBrowseFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Choose a folder where to look for translation files:";
            dlg.ShowNewFolderButton = false;

            _lookupPath = string.Empty;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _lookupPath = dlg.SelectedPath;
                lblSearchPath.Text = _lookupPath;

                PerformLookup(_lookupPath);
            }
        }

        private void PerformLookup(string lookupPath)
        {
            try
            {
                lbTranslationFiles.Items.Clear();

                string[] files =
                    Directory.EnumerateFiles(lookupPath, TranslationFile.TranslationFileEnglishName, SearchOption.AllDirectories).ToArray();

                lbTranslationFiles.Items.AddRange(files);

                 RegistryKey key = RegKey;
                 if (key != null)
                 {
                     key.SetValue("LastLookupPath", _lookupPath);
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PerformLookup failed: " + ex.Message);
                lbTranslationFiles.Items.Clear();
            }

            EnableMenus();
        }

        private void lbTranslationFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTranslations();
        }

        private void ReloadTranslations()
        {
            // Save data first
            SaveTranslations();

            string stringName = string.Empty;

            if (lvTranslations.SelectedItems.Count == 1)
            {
                stringName = lvTranslations.SelectedItems[0].SubItems[0].Text;
            }

            lvTranslations.Items.Clear();

            string file = lbTranslationFiles.SelectedItem as string;
            if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                try
                {
                    _tf = new TranslationFile(file, cmbLanguage.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ReloadTranslations failed: " + ex.Message);
                    _tf = null;
                }

                if (_tf != null && _tf.Items != null)
                {
                    foreach (TranslationItem ti in _tf.Items.Values)
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                            ti.StringName, ti.BaseString, ti.TranslatedString
                        });

                        item.Tag = ti;

                        lvTranslations.Items.Add(item);
                    }

                    lvTranslations.SelectedItems.Clear();
                    lvTranslations.Select();
                    lvTranslations.Focus();

                    if (!string.IsNullOrEmpty(stringName))
                    {
                        foreach (ListViewItem lvi in lvTranslations.Items)
                        {
                            if (lvi.SubItems[0].Text == stringName)
                            {
                                lvi.Selected = true;
                                lvi.Focused = true;
                                lvi.EnsureVisible();
                                break;
                            }
                        }
                    }

                }
            }

            EnableMenus();
        }

        private void DisplayItem(ListViewItem listViewItem)
        {
            lblBaseText.Text = lblTranslatedText.Text = string.Empty;

            if (listViewItem != null)
            {
                try
                {
                    lblBaseText.Rtf = listViewItem.SubItems[hdrBaseText.Index].Text;
                }
                catch
                {
                    lblBaseText.Text = listViewItem.SubItems[hdrBaseText.Index].Text;
                }

                try
                {
                    lblTranslatedText.Rtf = listViewItem.SubItems[hdrTranslatedText.Index].Text;
                }
                catch
                {
                    lblTranslatedText.Text = listViewItem.SubItems[hdrTranslatedText.Index].Text;
                }
            }

            EnableMenus();
        }

        private void lvTranslations_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvTranslations.SelectedItems != null && lvTranslations.SelectedItems.Count > 0)
            {
                DisplayItem(lvTranslations.SelectedItems[0]);
            }
            else
            {
                DisplayItem(null);
            }
        }

        int _lastIndex = 0;
        string _find = "";
        bool doneSearching = false;

        private void lvTranslations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                OnEditEntry(sender, e);
                return;
            }

            if (e.KeyCode == Keys.F3)
            {
                if (doneSearching)
                {
                    if (MessageBox.Show("Do you want to re-start search from the beginning ?", "Question", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        doneSearching = false;
                        _lastIndex = 0;
                    }
                }
                else
                {
                    _lastIndex++;
                }

                FindNextItem();
                return;
            }

            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    FindDialog dlg = new FindDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _find = dlg.TextToFind.ToLowerInvariant();
                        _lastIndex = 0;

                        FindNextItem();
                    }
                }
                else if (e.KeyCode == Keys.M)
                {
                    string[] files =
                        Directory.EnumerateFiles(_lookupPath, TranslationFile.TranslationFileEnglishName, SearchOption.AllDirectories).ToArray();

                    CopyAndMoveDialog dlg = new CopyAndMoveDialog(files);
                    dlg.ShowDialog();
                }
            }

            if (e.Modifiers == (Keys.Control | Keys.Shift))
            {
                if (e.KeyCode == Keys.V)
                {
                    string[] files =
                        Directory.EnumerateFiles(_lookupPath, TranslationFile.TranslationFileEnglishName, SearchOption.AllDirectories).ToArray();

                    ResourceValidationDialog dlg = new ResourceValidationDialog(files);
                    dlg.Show();
                }
            }
        }

        private void FindNextItem()
        {
            for (int i = _lastIndex; i < lvTranslations.Items.Count; i++ )
            {
                ListViewItem item = lvTranslations.Items[i];

                string s1 = item.SubItems[0].Text.ToLowerInvariant();
                string s2 = item.SubItems[1].Text.ToLowerInvariant();
                string s3 = item.SubItems[2].Text.ToLowerInvariant();

                if (s1.Contains(_find) || s2.Contains(_find) || s3.Contains(_find))
                {
                    lvTranslations.SelectedItems.Clear();
                    item.Selected = true;

                    lvTranslations.EnsureVisible(item.Index);

                    _lastIndex = i;

                    return;
                }
            }

            MessageBox.Show("Finished searching. The specified string was not found.");
            doneSearching = true;
        }

        private void OnDeleteEntry(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected entries ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteSelectedEntries();
            }
        }

        private void OnNewEntry(object sender, EventArgs e)
        {
            EntryNameDialog dlg = new EntryNameDialog("TXT_ENTRY_NAME", "", "", chkReadOnly.Checked, cmbLanguage.Text);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TranslationItem ti = new TranslationItem(string.Empty);
                ti.StringName = dlg.EntryName;
                ti.BaseString = dlg.EnglishString;
                ti.TranslatedString = dlg.TranslatedString;

                _tf.Items.Add(ti.StringName, ti);

                ListViewItem item = new ListViewItem(new string[]
                {
                    ti.StringName, ti.BaseString, ti.TranslatedString
                });

                item.Tag = ti;
                lvTranslations.Items.Add(item);

                lvTranslations.SelectedItems.Clear();
                item.Selected = true;

                lvTranslations.EnsureVisible(item.Index);
            }
        }

        private void OnEditEntry(object sender, EventArgs e)
        {
            if (lvTranslations.SelectedItems.Count == 1)
            {
                TranslationItem ti = lvTranslations.SelectedItems[0].Tag as TranslationItem;
                if (ti != null && _tf.Items.ContainsKey(ti.StringName))
                {
                    string oldName = ti.StringName;

                    EntryNameDialog dlg = new EntryNameDialog(oldName, ti.BaseString, ti.TranslatedString, chkReadOnly.Checked, cmbLanguage.Text);
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ti.StringName = dlg.EntryName;
                        ti.BaseString = dlg.EnglishString;
                        ti.TranslatedString = dlg.TranslatedString;

                        _tf.Items.Remove(oldName);
                        _tf.Items.Add(ti.StringName, ti);

                        lvTranslations.SelectedItems[0].SubItems[0].Text = ti.StringName;
                        lvTranslations.SelectedItems[0].SubItems[1].Text = ti.BaseString;
                        lvTranslations.SelectedItems[0].SubItems[2].Text = ti.TranslatedString;
                    }
                }
            }
        }

        private void DeleteSelectedEntries()
        {
            if (lvTranslations.SelectedItems.Count == 1)
            {
                TranslationItem ti = lvTranslations.SelectedItems[0].Tag as TranslationItem;
                if (ti != null && _tf.Items.ContainsKey(ti.StringName))
                {
                    _tf.Items.Remove(ti.StringName);

                    lvTranslations.Items.Remove(lvTranslations.SelectedItems[0]);
                }
            }
        }

        private void EnableMenus()
        {
            mnuNewEntry.Enabled = lbTranslationFiles.SelectedItems.Count == 1;
            mnuDeleteEntry.Enabled = (lvTranslations.SelectedItems.Count == 1);
            mnuRenameEntry.Enabled = lvTranslations.SelectedItems.Count == 1;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTranslations();
            RegKey.SetValue("SelectedLanguage", cmbLanguage.Text);

        }
    }
}
