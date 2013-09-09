using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Logging;

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
