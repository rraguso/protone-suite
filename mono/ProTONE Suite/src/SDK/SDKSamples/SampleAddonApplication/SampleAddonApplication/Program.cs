using System;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.Core.Configuration;

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
                Translator.SetInterfaceLanguage(AppConfig.LanguageID);
                Application.Run(new MainForm());

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
