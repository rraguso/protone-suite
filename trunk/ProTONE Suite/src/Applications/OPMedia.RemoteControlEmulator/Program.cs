using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using System.IO;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.Rendering.SHOUTCast;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering;
using System.Net;
using OPMedia.Core.Configuration;
using OPMedia.Core.NetworkAccess;

namespace OPMedia.RemoteControlEmulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoggedApplication.Start("OPMedia.RemoteControlEmulator");

            try
            {
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            LoggedApplication.Stop();
        }
    }
}
