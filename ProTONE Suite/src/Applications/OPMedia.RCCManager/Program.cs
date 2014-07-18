using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Configuration;
using OPMedia.Core;
using System.ServiceProcess;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime;
using OPMedia.ServiceHelper.RCCService.Configuration;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.UI.Themes;
using OPMedia.UI;
using OPMedia.Core.Utilities;
using OPMedia.UI.HelpSupport;

namespace OPMedia.RCCManager
{
    static class Program
    {
        static MainForm mainFrm;

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
                Translator.SetInterfaceLanguage(AppConfig.LanguageID);

                Translator.RegisterTranslationAssembly(typeof(MainForm).Assembly);
                Translator.RegisterTranslationAssembly(typeof(SerialDeviceCfgPanel).Assembly);
                Translator.RegisterTranslationAssembly(typeof(MediaPlayer).Assembly);

                LoggedApplication.Start(Constants.RCCManagerName);

                if (!AppConfig.CurrentUserIsAdministrator)
                {
                    MessageDisplay.Show(Translator.Translate("TXT_ADMIN_RIGHTS_REQUIRED"),
                        Translator.Translate("TXT_CAUTION"), MessageBoxIcon.Exclamation);

                    Logger.LogInfo("RCC Manager started with non-admin rights. Exiting.");

                    return;
                }

                ServiceControl.StopService();

                mainFrm = new MainForm();
                Application.Run(mainFrm);
                mainFrm.Dispose();

                AppConfig.Save();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
            finally
            {
                LoggedApplication.Stop();
                ServiceControl.StartService();
            }
        }

        
    }
}