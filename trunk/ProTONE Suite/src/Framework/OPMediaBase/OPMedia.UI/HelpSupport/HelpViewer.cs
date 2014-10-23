using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.UI.Themes;
using System.IO;
using System.Drawing;
using OPMedia.UI.Generic;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.Core.GlobalEvents;
using System.Net;
using OPMedia.Core.Logging;
using OPMedia.Core.Configuration;
using OPMedia.Core.TranslationSupport;
using System.ComponentModel;
using OPMedia.UI.Controls;

namespace OPMedia.UI.HelpSupport
{
    public class HelpViewer : ToolForm
    {
        BackgroundWorker _loader;
        private Controls.OPMToolStrip tsMain;
        private OPMToolStripButton tsbPrev;
        private OPMToolStripButton tsbNext;
        private System.Windows.Forms.WebBrowser wbHelpDisplay;

        private Stack<string> bckUrls = new Stack<string>();
        private Stack<string> fwdUrls = new Stack<string>();

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.wbHelpDisplay = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tsMain = new OPMedia.UI.Controls.OPMToolStrip();
            this.tsbPrev = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbNext = new OPMedia.UI.Controls.OPMToolStripButton();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            // 
            // wbHelpDisplay
            // 
            this.wbHelpDisplay.AllowWebBrowserDrop = false;
            this.wbHelpDisplay.CausesValidation = false;
            this.wbHelpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHelpDisplay.IsWebBrowserContextMenuEnabled = false;
            this.wbHelpDisplay.Location = new System.Drawing.Point(3, 25);
            this.wbHelpDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.wbHelpDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHelpDisplay.Name = "wbHelpDisplay";
            this.wbHelpDisplay.ScriptErrorsSuppressed = true;
            this.wbHelpDisplay.Size = new System.Drawing.Size(792, 549);
            this.wbHelpDisplay.TabIndex = 0;
            this.wbHelpDisplay.TabStop = false;
            this.wbHelpDisplay.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbHelpDisplay_PreviewKeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Controls.Add(this.wbHelpDisplay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tsMain, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 577);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.tsMain.ForeColor = System.Drawing.Color.Black;
            this.tsMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrev,
            this.tsbNext});
            this.tsMain.Location = new System.Drawing.Point(1, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.ShowBorder = true;
            this.tsMain.Size = new System.Drawing.Size(796, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "opmToolStrip1";
            this.tsMain.VerticalGradient = true;
            // 
            // tsbPrev
            // 
            this.tsbPrev.AutoToolTip = false;
            this.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrev.Image = global::OPMedia.UI.Properties.Resources.Back;
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(23, 22);
            this.tsbPrev.Text = "toolStripButton1";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.AutoToolTip = false;
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = global::OPMedia.UI.Properties.Resources.Forward;
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.Text = "toolStripButton2";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // HelpViewer
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HelpViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Shown += new System.EventHandler(this.HelpViewer_Shown);
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        public HelpViewer()
            : base()
        {
            InitializeComponent();

            base.AllowResize = true;
            UpdatePrevnextDocuments();

            SetTitle("TXT_APP_NAME");
            this.InheritAppIcon = false;
            this.Icon = SystemIcons.Question;

            _loader = new BackgroundWorker();
            _loader.DoWork += new DoWorkEventHandler(OnLoadHelpDocument);
            _loader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnHelpDocumentLoadCompleted);

            wbHelpDisplay.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(wbHelpDisplay_DocumentCompleted);
        }

        bool _validDocument = false;

        void OnHelpDocumentLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _validDocument = false;
            string docToDisplay = GenerateDocument("[ There is no document to display. ]");

            if (e.Cancelled)
            {
                docToDisplay = GenerateDocument("Navigation cancelled !");
            }
            else if (e.Error != null)
            {
                docToDisplay = GenerateDocument(string.Format("Exception occured: {0}", e.Error));
            }
            else
            {
                string s = e.Result as string;
                if (s != null)
                {
                    docToDisplay = s;
                    _validDocument = true;
                }
            }

            wbHelpDisplay.Navigating -= new WebBrowserNavigatingEventHandler(wbHelpDisplay_Navigating);
            wbHelpDisplay.DocumentText = docToDisplay;
            BringToFront();
        }

        void OnLoadHelpDocument(object sender, DoWorkEventArgs e)
        {
            object result = null;
            string helpUri = e.Argument as String;
            if (helpUri != null)
            {
                result = LoadURL(helpUri);
            }

            e.Result = result;
        }

        void HelpViewer_Shown(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(10, 10);
            this.Width = Screen.GetWorkingArea(this).Width / 2;
            this.Height = Screen.GetWorkingArea(this).Height - 20;
        }

        private TableLayoutPanel tableLayoutPanel1;

        string _uri = string.Empty;

        internal void OpenURL(string helpUri)
        {
            if (string.IsNullOrEmpty(_uri) == false)
            {
                bckUrls.Push(_uri);
                UpdatePrevnextDocuments();
            }

            InternalOpenurl(helpUri);
        }

        private void InternalOpenurl(string helpUri)
        {
            wbHelpDisplay.DocumentText = GenerateDocument("Document is loading, please wait ...");
            _loader.RunWorkerAsync(helpUri);
        }

        private string LoadURL(string helpUri)
        {
            _uri = helpUri;
            StringBuilder sb = new StringBuilder();

            string docText = string.Empty;

            Uri uri = new Uri(helpUri);
            if (uri.Scheme == "file")
            {
                try
                {
                    
                    string[] docLines = File.ReadAllLines(uri.LocalPath);
                    for (int i = 0; i < docLines.Length; i++)
                    {
                        if (docLines[i].ToLowerInvariant() == "<html>")
                        {
                            docLines[i] += GenerateStyleSheet();
                        }
                        else if (docLines[i].ToLowerInvariant().Contains("<img"))
                        {
                            docLines[i] = docLines[i].ToLowerInvariant().Replace("src=\"images", string.Format("src=\"{0}\\docs\\images", 
                                AppConfig.InstallationPath));
                        }

                        sb.AppendLine(docLines[i]);
                    }
                }
                catch(Exception ex)
                { 
					Logger.LogException(ex);
                }

                docText = sb.ToString();
            }
            else
            {
                HttpWebRequest request = WebRequest.Create(helpUri) as HttpWebRequest;

                // execute the request
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string[] docLines = sr.ReadToEnd().Split(Environment.NewLine.ToCharArray());
                        for (int i = 0; i < docLines.Length; i++)
                        {
                            if (docLines[i].ToLowerInvariant() == "<html>")
                            {
                                docLines[i] += GenerateStyleSheet();
                            }
                            else if (docLines[i].ToLowerInvariant().Contains("<img"))
                            {
                                docLines[i] = docLines[i].ToLowerInvariant().Replace("src=\"images", string.Format("src=\"{0}/images",
                                    AppConfig.HelpUriBase));
                            }

                            sb.AppendLine(docLines[i]);
                        }
                    }
                }

                docText = sb.ToString();
            }

            return docText;
        }

        private string GenerateDocument(String text)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine(GenerateStyleSheet());
            sb.AppendLine(text);
            sb.AppendLine("</html>");
            return sb.ToString();
        }

        private string GenerateStyleSheet()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine("h1 {{ font-family:Arial; font-size:12px; font-weight:bold; }}");
            sb.AppendLine("h2 {{ font-family:Arial; font-size:11px; font-weight:bold; text-decoration: underline; }}");
            sb.AppendLine("a {{ font-family:Arial; font-size:11px; font-weight:bold; }}");
            sb.AppendLine("body {{ font-family:Arial; font-size:11px; }}");
            sb.AppendLine("td {{ font-family:Arial; font-size:10px; }}");
            sb.AppendLine("</style>");
            return sb.ToString();
        }

        void wbHelpDisplay_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            string newTitle = string.Format("{0} {1}: {2}", 
                Translator.Translate("TXT_APP_NAME"),
                Translator.Translate("TXT_HELP"),
                wbHelpDisplay.DocumentTitle
                );

            SetTitle(newTitle);

            wbHelpDisplay.Navigating += new WebBrowserNavigatingEventHandler(wbHelpDisplay_Navigating);
        }

        void wbHelpDisplay_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e == null || e.Url == null)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = false;

            if (e.Url.AbsolutePath == null ||
                e.Url.AbsolutePath.ToLowerInvariant() == "blank")
                return;

            string url = CombineURIs(new Uri(_uri), e.Url);
            if (!string.IsNullOrEmpty(url))
            {
                e.Cancel = true;
                OpenURL(url.Replace("\\", "/"));
            }
        }

        private string CombineURIs(Uri baseUri, Uri relativeUri)
        {
            if (relativeUri.Scheme == "about")
            {
                string baseUrl = baseUri.AbsoluteUri;
                string url = baseUrl.Replace(Path.GetFileName(baseUrl), relativeUri.AbsolutePath);
                return url;
            }

            return relativeUri.AbsolutePath;
        }

        private void wbHelpDisplay_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            // TODO identify which keys should be allowed and which not

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (e.Modifiers == Keys.Control)
                        tsbNext_Click(sender, e);
                    return;

                case Keys.Left:
                    if (e.Modifiers == Keys.Control)
                        tsbPrev_Click(sender, e);
                    return;

                case Keys.Back:
                    tsbPrev_Click(sender, e);
                    return;

                case Keys.F1:
                    return;
            }

            base.ProcessKeyDown(sender as Control, e.KeyCode, e.Modifiers);
        }


        private void tsbPrev_Click(object sender, EventArgs e)
        {
            string s = null;

            try
            {
                s = bckUrls.Pop();
            }
            catch
            {
                s = null;
            }

            if (!string.IsNullOrEmpty(s))
            {
                fwdUrls.Push(_uri);
                InternalOpenurl(s);
            }

            UpdatePrevnextDocuments();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            string s = null;

            try
            {
                s = fwdUrls.Pop();
            }
            catch
            {
                s = null;
            }

            if (!string.IsNullOrEmpty(s))
            {
                bckUrls.Push(_uri);
                InternalOpenurl(s);
            }

            UpdatePrevnextDocuments();
        }

        private void UpdatePrevnextDocuments()
        {
            if (bckUrls.Count > 0)
            {
                tsbPrev.Enabled = true;
                tsbPrev.ToolTipText = string.Format("{0}: {1}", 
                  Translator.Translate("TXT_BACK"), bckUrls.Peek());
            }
            else
            {
                tsbPrev.Enabled = false;
                tsbPrev.ToolTipText = string.Empty;
            }

            if (fwdUrls.Count > 0)
            {
                tsbNext.Enabled = true;
                tsbNext.ToolTipText = string.Format("{0}: {1}",
                   Translator.Translate("TXT_FORWARD"), fwdUrls.Peek());
            }
            else
            {
                tsbNext.Enabled = false;
                tsbNext.ToolTipText = string.Empty;
            }
        }
    }
}
