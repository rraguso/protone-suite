using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Translate;
using RoboTranslator;
using System.Threading;

namespace TranslationEditor
{
    public partial class EntryNameDialog : Form
    {
        Language lang = "";

        public EntryNameDialog()
        {
            InitializeComponent();
        }

        public EntryNameDialog(string entry, string english, string translated, bool readOnly, string lang) : this()
        {
            txtName.Text = entry;
            txtEnglish.Text = english;
            txtTRanslation.Text = translated;

            txtEnglish.AcceptsReturn = true;
            txtTRanslation.AcceptsReturn = true;

            switch (lang)
            {
                case "de":
                    this.lang = Language.German;
                    break;
                case "ro":
                    this.lang = Language.Romanian;
                    break;
                case "fr":
                    this.lang = Language.French;
                    break;

                case "hu":
                    this.lang = Language.Hungarian;
                    break;
                case "ru":
                    this.lang = Language.Russian;
                    break;
                case "it":
                    this.lang = Language.Italian;
                    break;
                case "pt":
                    this.lang = Language.Portuguese;
                    break;
                case "es":
                    this.lang = Language.Spanish;
                    break;
            }

            if (readOnly)
            {
                txtName.Enabled = false;
                txtEnglish.Enabled = false;
                txtTRanslation.Enabled = false;
                btnOK.Enabled = false;
                btnTranslate.Enabled = false;
            }
        }

        public string EntryName { get { return txtName.Text; } }
        public string EnglishString { get { return txtEnglish.Text; } }
        public string TranslatedString { get { return txtTRanslation.Text; } }

        private void OnTranslate(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            btnTranslate.Enabled = false;

            ThreadPool.QueueUserWorkItem(c => DoTranslate(txtEnglish.Text));
            
        }

        private void DoTranslate(string p)
        {
            string s = WebTranslator.WebsiteTranslate(p, Language.English, lang);
            this.Invoke((MethodInvoker)(() => 
            { 
                txtTRanslation.Text = s;
                Application.UseWaitCursor = false;
                btnTranslate.Enabled = true;
            }));
        }

    }
}
