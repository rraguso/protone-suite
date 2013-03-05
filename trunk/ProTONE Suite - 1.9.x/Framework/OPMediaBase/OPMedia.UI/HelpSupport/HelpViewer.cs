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

namespace OPMedia.UI.HelpSupport
{
    public class HelpViewer : ToolForm
    {
        private System.Windows.Forms.WebBrowser wbHelpDisplay;
    
        public HelpViewer()
            : base()
        {
            InitializeComponent();

            base.AllowResize = true;

            SetTitle("TXT_APP_NAME");
            this.InheritAppIcon = false;
            this.Icon = SystemIcons.Question;

            wbHelpDisplay.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(wbHelpDisplay_DocumentCompleted);
        }

        private void InitializeComponent()
        {
            this.wbHelpDisplay = new System.Windows.Forms.WebBrowser();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.wbHelpDisplay);
            // 
            // wbHelpDisplay
            // 
            this.wbHelpDisplay.AllowWebBrowserDrop = false;
            this.wbHelpDisplay.CausesValidation = false;
            this.wbHelpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHelpDisplay.Location = new System.Drawing.Point(0, 0);
            this.wbHelpDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHelpDisplay.Name = "wbHelpDisplay";
            this.wbHelpDisplay.ScriptErrorsSuppressed = true;
            this.wbHelpDisplay.Size = new System.Drawing.Size(1014, 740);
            this.wbHelpDisplay.TabIndex = 0;
            this.wbHelpDisplay.TabStop = false;
            this.wbHelpDisplay.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbHelpDisplay_PreviewKeyDown);
            // 
            // HelpViewer
            // 
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HelpViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Shown += new EventHandler(HelpViewer_Shown);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        void HelpViewer_Shown(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(10, 10);
            this.Width = Screen.GetWorkingArea(this).Width / 2;
            this.Height = Screen.GetWorkingArea(this).Height - 20;
        }

        protected override bool AllowCloseOnEnterOrEscape()
        {
            return true;
        }

        string _uri = string.Empty;

        protected override void OnThemeUpdatedInternal()
        {
            OpenURL(_uri);
        }

        internal void OpenURL(string helpUri)
        {
            _uri = helpUri;

            Uri uri = new Uri(helpUri);
            if (uri.Scheme == "file")
            {
                StringBuilder sb = new StringBuilder();

                try
                {
                    
                    string[] docLines = File.ReadAllLines(uri.LocalPath);
                    for (int i = 0; i < docLines.Length; i++)
                    {
                        if (docLines[i].ToLowerInvariant() == "<!-- insert stylesheet here -->")
                        {
                            docLines[i] = GenerateStyleSheet();
                        }
                        else if (docLines[i].ToLowerInvariant().Contains("<img"))
                        {
                            docLines[i] = docLines[i].ToLowerInvariant().Replace("src=\"images", string.Format("src=\"{0}\\docs\\images", 
                                SuiteConfiguration.InstallationPath));
                        }

                        sb.AppendLine(docLines[i]);
                    }
                }
                catch { }

                wbHelpDisplay.DocumentText = sb.ToString();
            }
            else
            {
                wbHelpDisplay.Navigate(helpUri);
            }
        }

        private string GenerateStyleSheet()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<style type=\"text/css\">");

            sb.AppendLine(string.Format("h1 {{ color:{0}; background-color:{1}; font-family:Arial; font-size:12px; font-weight:bold; }}",
                ColorHelper.GetColorCode(ThemeManager.ForeColor), ColorHelper.GetColorCode(ThemeManager.BackColor)));
            sb.AppendLine(string.Format("body {{ color:{0}; background-color:{1}; font-family:Arial; font-size:11px; }}", 
                ColorHelper.GetColorCode(ThemeManager.ForeColor), ColorHelper.GetColorCode(ThemeManager.BackColor)));
            sb.AppendLine(string.Format("td {{ color:{0}; background-color:{1}; font-family:Arial; font-size:10px; }}",
                ColorHelper.GetColorCode(ThemeManager.ForeColor), ColorHelper.GetColorCode(ThemeManager.BackColor)));
            
            sb.AppendLine("</style>");

            return sb.ToString();
        }

        void wbHelpDisplay_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            base.SetTitle(wbHelpDisplay.DocumentTitle);
        }

        private void wbHelpDisplay_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            base.ProcessKeyDown(e.KeyCode, e.Modifiers);
        }

        
    }
}
