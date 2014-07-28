using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Configuration;
using OPMedia.Core.Logging;

namespace GuiTester
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

            try
            {
                LoggedApplication.Start("GuiTester");

                AppConfig.AllowRealtimeGUISetup = false;


                Application.Run(new MainForm());
            }
            finally
            {
                LoggedApplication.Stop();
            }
        }
    }
}
