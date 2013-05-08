using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TranslationEditor
{
    public partial class CopyAndMoveDialog : Form
    {
        TranslationFile _srcTranslation = null;

        public CopyAndMoveDialog(string[] files)
        {
            InitializeComponent();

            lbSourceTranslation.Items.Clear();
            lbSourceTranslation.Items.AddRange(files);
            lbDestTranslation.Items.Clear();
            lbDestTranslation.Items.AddRange(files);

            cmbOperation.SelectedIndex = 0; // Default MOVE
        }

        private void lbSourceTranslation_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbTags.Items.Clear();

            string srcFile = lbSourceTranslation.SelectedItem as string;
            if (!string.IsNullOrEmpty(srcFile) && File.Exists(srcFile))
            {
                try
                {
                    _srcTranslation = new TranslationFile(srcFile, "ro");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed: " + ex.Message);
                    _srcTranslation = null;
                    return;
                }

                if (_srcTranslation != null && _srcTranslation.Items != null)
                {
                    foreach (TranslationItem ti in _srcTranslation.Items.Values)
                    {
                        clbTags.Items.Add(ti.StringName);
                    }

                    clbTags.Sorted = true;
                }
                else
                {
                    _srcTranslation = null;
                }
            }
        }

        private void clbTags_Resize(object sender, EventArgs e)
        {
            clbTags.ColumnWidth = (clbTags.Width - SystemInformation.VerticalScrollBarWidth - 5) / 4;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_srcTranslation == null)
            {
                MessageBox.Show("Please select a valid source translation file !");
                return;
            }

            List<String> tags = new List<string>();
            foreach (object item in clbTags.CheckedItems)
            {
                if (item is string)
                {
                    tags.Add(item as string);
                }
            }

            if (tags.Count < 1)
            {
                MessageBox.Show("Please select at least one tag to move or copy !");
                return;
            }

            string destFile = lbDestTranslation.SelectedItem as string;
            if (cmbOperation.Text != "DELETE")
            {
                if (string.IsNullOrEmpty(destFile) || !File.Exists(destFile))
                {
                    MessageBox.Show("Please select a valid destination translation file !");
                    return;
                }
            }

            try
            {
                StartTask(_srcTranslation.Path, destFile, tags, (cmbOperation.Text == "MOVE"), (cmbOperation.Text == "DELETE"));

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }

        private void StartTask(string sourceFile, string destFile, List<string> tags, bool isMove, bool isDelete)
        {
            if (!isDelete)
            {
                foreach (string lang in TranslationFile.SupportedLanguages)
                {
                    TranslationFile srcTranslation = new TranslationFile(sourceFile, lang);
                    TranslationFile destTranslation = new TranslationFile(destFile, lang);

                    foreach (string tag in tags)
                    {
                        TranslationItem ti = srcTranslation.Items[tag];
                        destTranslation.Items[tag] = ti;
                    }

                    destTranslation.ForceSave();
                }
            }

            if (isMove || isDelete)
            {
                foreach (string lang in TranslationFile.SupportedLanguages)
                {
                    TranslationFile srcTranslation = new TranslationFile(sourceFile, lang);

                    foreach (string tag in tags)
                    {
                        srcTranslation.Items.Remove(tag);
                    }

                    srcTranslation.ForceSave();
                }
            }
        }
    }
}
