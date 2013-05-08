using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core.InstanceManagement;
using System.Text;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Core.TranslationSupport;
using System.Configuration;
using System.Globalization;

using System.Diagnostics;
using System.Threading;

using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;

using OPMedia.Core;
using OPMedia.UI;
using OPMedia.Runtime.Remoting;
using System.Runtime.InteropServices;

using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.Runtime.ProTONE;
using OPMedia.Core.Utilities;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.HelpSupport;
using System.Drawing;

namespace OPMedia.ProTONE
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
            Color c = System.Drawing.Color.Empty;
            Color c1 = Color.FromArgb(0, 0, 0, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                if (!ProcessCommandLine(true))
                {
                    try
                    {
                        RemoteControllableApplication.Start(Constants.PlayerName);

                        ProcessCommandLine(false);

                        Translator.SetInterfaceLanguage(SuiteConfiguration.LanguageID);
                        Translator.RegisterTranslationAssembly(typeof(MediaPlayer).Assembly);
                        Translator.RegisterTranslationAssembly(typeof(MainForm).Assembly);

                        mainFrm = new MainForm();

                        Application.Run(mainFrm);
                        mainFrm.Dispose();

                        AppSettings.Save();
                        ShortcutMapper.Save();
                    }
                    catch (MultipleInstancesException ex)
                    {
                        Logger.LogWarning(ex.Message);

                        // Send an activate command to the main instance
                        RemoteControlHelper.SendPlayerCommand(CommandType.Activate, null);
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(ex);
                    }
                    finally
                    {
                        RemoteControllableApplication.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            Logger.StopLogger();
        }

        public static bool ProcessCommandLine(bool testForShellExec)
        {
            string[] cmdLineArgs = Environment.GetCommandLineArgs();

            if (testForShellExec && cmdLineArgs.Length > 1 && cmdLineArgs[1].ToLowerInvariant() == "launch")
            {
                List<string> files = new List<string>();
                for (int i = 2; i < cmdLineArgs.Length; i++)
                {
                    files.Add(cmdLineArgs[i]);
                }

                try
                {
                    CommandType cmdType = (CommandType)Enum.Parse(typeof(CommandType),
                        AppSettings.ExplorerLaunchType);

                    if (SuiteRegistrationSupport.IsContextMenuHandlerRegistered() &&
                        (cmdType == CommandType.PlayFiles || cmdType == CommandType.EnqueueFiles))
                    {
                        RemoteControlHelper.SendPlayerCommand(cmdType, files.ToArray());
                    }
                }
                catch(Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }

                return true;
            }


            string argStr = string.Empty;
            for (int i = 1; i < cmdLineArgs.Length; i++)
            {
                if (!string.IsNullOrEmpty(cmdLineArgs[i]))
                {
                    argStr += cmdLineArgs[i];
                }
            }

            if (!string.IsNullOrEmpty(argStr))
            {
                mainFrm.EnqueueCommand(BasicCommand.Create(argStr));
            }

            return false;
        }

    }
}