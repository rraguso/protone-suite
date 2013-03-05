using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslationEditor
{
    public partial class EntryNameDialog : Form
    {
        public EntryNameDialog()
        {
            InitializeComponent();
        }

        public EntryNameDialog(string entry, string english, string translated, bool readOnly) : this()
        {
            txtName.Text = entry;
            txtEnglish.Text = english;
            txtTRanslation.Text = translated;

            txtEnglish.AcceptsReturn = true;
            txtTRanslation.AcceptsReturn = true;

            if (readOnly)
            {
                txtName.Enabled = false;
                txtEnglish.Enabled = false;
                txtTRanslation.Enabled = false;
                btnOK.Enabled = false;
            }
        }

        public string EntryName { get { return txtName.Text; } }
        public string EnglishString { get { return txtEnglish.Text; } }
        public string TranslatedString { get { return txtTRanslation.Text; } }
    }
}
