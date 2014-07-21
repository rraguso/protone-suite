using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.GlobalEvents;
using System.Diagnostics;
using OPMedia.UI.Themes;
using OPMedia.Core.Configuration;

namespace OPMedia.UI.HelpSupport
{
    public static class HelpTarget
    {
        static HelpViewer _helpViewer = null;

        public static void HelpRequest(string sectionName, string topicName = "")
        {
            string helpUri = string.Empty;

            // Help base URI should be something like:
            // http://protone-suite.googlecode.com/svn/wiki/ProTONE Suite - #VERSION#

            if (string.IsNullOrEmpty(topicName))
            {
                helpUri = string.Format("{0}/{1}/{2}.htm", 
                    AppConfig.HelpUriBase, ApplicationInfo.ApplicationName,
                    sectionName);
            }
            else
            {
                helpUri = string.Format("{0}/{1}/{2}/{3}.htm", 
                    AppConfig.HelpUriBase, ApplicationInfo.ApplicationName,
                       sectionName, topicName);
            }

            Logger.LogHelpTrace(helpUri);

            if (_helpViewer == null)
            {
                _helpViewer = new HelpViewer();
                _helpViewer.Show();
                _helpViewer.FormClosed += new FormClosedEventHandler(_helpViewer_FormClosed);
            }
            
            _helpViewer.OpenURL(helpUri);
        }

        static void _helpViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _helpViewer.Dispose();
            _helpViewer = null;
        }

    }
}
