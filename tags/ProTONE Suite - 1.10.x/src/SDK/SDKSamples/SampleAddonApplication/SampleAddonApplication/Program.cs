using System;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;

namespace WindowsFormsApplication1
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
                LoggedApplication.Start("SampleAddonApplication");

                Translator.RegisterTranslationAssembly(typeof(MainForm).Assembly);
                Translator.SetInterfaceLanguage(SuiteConfiguration.LanguageID);
                Application.Run(new MainForm());

                AppSettings.Save();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            Logger.StopLogger();

        }
    }
}
