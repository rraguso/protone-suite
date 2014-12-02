using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Configuration;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;

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

                //AppConfig.AllowRealtimeGUISetup = false;
                Translator.SetInterfaceLanguage(AppConfig.LanguageID);


                Application.Run(new MainForm());
            }
            finally
            {
                LoggedApplication.Stop();
            }
        }
    }
}
