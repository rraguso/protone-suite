using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;
using OPMedia.Core;
using OPMedia.UI.Dialogs;
using OPMedia.UI.Themes;
using OPMedia.Core.InstanceManagement;
using OPMedia.Core.Configuration;

namespace OPMedia.Utility
{
    static class Program
    {
        static bool _launchFromUninstaller = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoggingConfiguration.LoggingEnabled = false;

            if (ProcessCommandLine())
            {
                Translator.RegisterTranslationAssembly(typeof(MainForm).Assembly);
                Translator.RegisterTranslationAssembly(typeof(ThemeForm).Assembly);

                MainForm frm = new MainForm(_launchFromUninstaller);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Environment.ExitCode = 0;
                    return;
                }
            }

            Environment.ExitCode = 1;
        }

        private static bool ProcessCommandLine()
        {
            string cmdLine = Environment.CommandLine.ToLowerInvariant();

            // Detect whether the app was launched from uninstaller
            if (cmdLine.Contains("9566b126-2205-4e61-8c1c-e6d4d0fc34f0"))
            {
                _launchFromUninstaller = true;
                Translator.SetInterfaceLanguage(AppConfig.InstallLanguageID);
            }
            else if (cmdLine.Contains("cleanup"))
            {
                _launchFromUninstaller = false;
                Translator.SetInterfaceLanguage(AppConfig.LanguageID);
            }
            else
            {
                Translator.SetInterfaceLanguage(AppConfig.LanguageID);

                LoggedApplication.Start(Constants.UtilityName);
                Application.Run(LogFileConsoleDialog.ShowLogConsole(true));
                return false;
            }

            return true;
        }
    }
}
