using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.Addons.AddonsBase;
using OPMedia.Core.Configuration;

namespace OPMedia.SkinBuilder
{
    static class Program
    {
        public static string LaunchPath { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LaunchPath = string.Empty;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                LoggedApplication.Start("SkinBuilder");

                string[] cmdLineArgs = Environment.GetCommandLineArgs();

                if (cmdLineArgs.Length > 2)
                {
                    switch (cmdLineArgs.Length)
                    {
                        case 3:
                            switch (cmdLineArgs[1].ToLowerInvariant())
                            {
                                case "launch":
                                    LaunchPath = cmdLineArgs[2];
                                    break;
                            }
                            break;
                    }
                }

                AppConfig.AllowRealtimeGUISetup = false;

                Translator.RegisterTranslationAssembly(typeof(SkinBuilderForm).Assembly);
                Translator.SetInterfaceLanguage("en"); // Only English
                Application.Run(new SkinBuilderForm());

                AppConfig.Save();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            Logger.StopLogger();
        }
    }
}
