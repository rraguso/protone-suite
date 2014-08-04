using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Web;

namespace TranslationEditor
{
    public partial class EntryNameDialog : Form
    {
        string lang = "";

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

            this.lang = lang;
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
            string s = WebTranslator.WebsiteTranslate(p, "en", lang);
            this.Invoke((MethodInvoker)(() => 
            { 
                txtTRanslation.Text = s;
                Application.UseWaitCursor = false;
                btnTranslate.Enabled = true;
            }));
        }

    }

    public class WebTranslator
    {
        public static string WebsiteTranslate(string input, string sourceLanguage, string targetLanguage)
        {
            input = input.Replace(Environment.NewLine, "<br/>");
            input = input.Replace("'", "&apos;");
            string address = string.Format("http://translate.google.com/?hl=en&eotf=1&sl={0}&tl={1}&q={2}", sourceLanguage, targetLanguage, 
                HttpUtility.UrlEncode(input));

            string str2 = "";

            try
            {
                str2 = new WebClient 
                { 
                    Proxy = null, 
                    Encoding = Encoding.Default 
                }.DownloadString(address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                str2 = input;
            }

            Encoding enc = Encoding.Default;
            StringBuilder builder = new StringBuilder();
            int index = str2.IndexOf("charset=");
            if (index > 0)
            {
                int idx2 = str2.IndexOf("\"", index);
                if (idx2 > 0)
                {
                    enc = Encoding.GetEncoding(str2.Substring(index + 8, (idx2 - index) - 8).ToLowerInvariant().Trim());
                }
            }
            index = str2.IndexOf("<span id=result_box");
            if (index > 0)
            {
                index = str2.IndexOf("<span title=", index);
                while (index > 0)
                {
                    index = str2.IndexOf(">", index);
                    if (index > 0)
                    {
                        index++;
                        int num2 = str2.IndexOf("</span>", index);
                        string str15 = str2.Substring(index, num2 - index);
                        string str4 = HttpUtility.HtmlDecode(enc.GetString(Encoding.Default.GetBytes(str15))).Replace(" </ P>", "</ p>").Replace(" <P>", "<p>").Replace(" <P >", "<p>").Replace(" < P >", "<p>").Replace(" </ p>", "</p>").Replace("</ p>", "</p>").Replace("</ P>", "</p>").Replace("</P>", "</p>").Replace("< /P >", "</p>");
                        builder.Append(str4);
                        index = str2.IndexOf("<span title=", index);
                    }
                }
            }
            string str5 = builder.ToString().Replace(" <br/>", Environment.NewLine).Replace("<br/>", Environment.NewLine).Replace("<br />", Environment.NewLine).Replace("< p >", "<p>").Replace("< p>", "<p>").Replace("<p >", "<p>").Replace("</ p>", "</p>").Replace("< / p >", "</p>").Replace("< / p>", "</p>").Replace(" </p>", "</p>").Replace(" </p>", "</p>").Replace("</p>  ", "</p>").Replace("</p> ", "</p>").Replace("</p> ", "</p>").Replace("</p><p>", "@__P_TAG").Replace("</p>", "</p><p>").Replace("@__P_TAG", "</p><p>");
            int length = str5.LastIndexOf("<p>");
            if (length > 0)
            {
                str5 = str5.Substring(0, length);
            }
            return str5;
        }
    }
}
