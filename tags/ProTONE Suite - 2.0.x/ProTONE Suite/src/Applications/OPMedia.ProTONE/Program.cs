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
using OPMedia.Core.Configuration;
using OPMedia.Runtime;

using OPMedia.Core;
using OPMedia.UI;

using System.Runtime.InteropServices;

using OPMedia.UI.Themes;
using OPMedia.UI.ProTONE.Controls.MediaPlayer;
using OPMedia.Runtime.ProTONE;
using OPMedia.Core.Utilities;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.HelpSupport;
using System.Drawing;
using OPMedia.Runtime.ProTONE.Utilities;
using OPMedia.Runtime.ProTONE.Configuration;

namespace OPMedia.ProTONE
{
    static class Program
    {
        static MainForm mainFrm;

        static List<BasicCommand> _commandQueue = new List<BasicCommand>();

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
                if (!ProcessCommandLine(true))
                {
                    try
                    {
                        RemoteControllableApplication.Start(ProTONEConstants.PlayerName);

                        ProcessCommandLine(false);

                        Translator.SetInterfaceLanguage(AppConfig.LanguageID);
                        Translator.RegisterTranslationAssembly(typeof(MediaPlayer).Assembly);
                        Translator.RegisterTranslationAssembly(typeof(MainForm).Assembly);

                        ShortcutMapper.IsPlayer = true;

                        mainFrm = new MainForm();

                        foreach(BasicCommand cmd in _commandQueue)
                        {
                            mainFrm.EnqueueCommand(cmd);
                        }

                        Application.Run(mainFrm);
                        mainFrm.Dispose();

                        AppConfig.Save();
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
                        ProTONEConfig.ExplorerLaunchType);

                    if (SuiteRegistrationSupport.IsContextMenuHandlerRegistered() &&
                        (cmdType == CommandType.PlayFiles || cmdType == CommandType.EnqueueFiles))
                    {
                        if (RemoteControlHelper.IsPlayerRunning())
                        {
                            // There is another player instance that is running.
                            // Just pass the command to that instance and exit.
                            RemoteControlHelper.SendPlayerCommand(cmdType, files.ToArray());
                        }
                        else
                        {
                            // There is no other player instance. 
                            // This instance needs to process the command itself.
                            
                            // Note: when player is launched like this - clear previous playlist first.
                            _commandQueue.Add(BasicCommand.Create(CommandType.ClearPlaylist));
                            
                            _commandQueue.Add(BasicCommand.Create(cmdType, files.ToArray()));

                            return false; // Don't exit
                        }
                    }
                }
                catch(Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }

                return true;
            }

            return false;
        }

    }
}