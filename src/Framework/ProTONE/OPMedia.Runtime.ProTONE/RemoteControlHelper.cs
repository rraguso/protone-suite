using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ProTONE.RemoteControl;
using System.Threading;
using OPMedia.Core.Logging;
using OPMedia.Core;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using OPMedia.Runtime.ProTONE.Rendering;
using System.Runtime.Remoting;

using System.Security.AccessControl;
using OPMedia.Runtime.InterProcessCommunication;

namespace OPMedia.Runtime.ProTONE
{
    public class CommandTargetPort
    {
        public const int RccService = 10202;
        public const int EmulatorInputPin = 10203;
        public const int SmartPhoneInputPin = 10204;
    }
  
    public static class RemoteControlHelper
    {
        const int MaxStartupAttempts = 20;

        #region Player commands
        public static void SendPlayerCommand(BasicCommand command, bool useIpc = false)
        {
            ThreadPool.QueueUserWorkItem(c =>
                {
                    int i = 0;

                    bool playerWasAlreadyRunning = IsPlayerRunning();
                    if (!useIpc)
                    {
                        // See if player is started; if not - start it
                        while ((!IsPlayerRunning() && i < MaxStartupAttempts))
                        {
                            Process.Start(SuiteConfiguration.PlayerInstallationPath);
                            i++;
                            Thread.Sleep(1000);
                        }
                    }

                    if (IsPlayerRunning())
                    {
                        if (!playerWasAlreadyRunning)
                        {
                        	Thread.Sleep(400);
                        }

                        //// If we came to this poin the player is running. 
                        //// Send the command (it should arrive to player).
                        if (useIpc)
                        {
                            IPCRemoteControlProxy.PostRequest(Constants.PlayerName, command.ToString());
                        }
                        else
                        {
                            WmCopyDataSender.SendData(Constants.PlayerName, command.ToString());
                        }
                    }
                    else
                    {
                        if (useIpc)
                        {
                            Logger.LogError("Could not send command because the player is not running.");
                        }
                        else
                        {
                            Logger.LogError("Could not send command because the player could not be launched from path: {0}",
                                SuiteConfiguration.PlayerInstallationPath);
                        }
                    }
                }
            );
        }

        public static void SendPlayerCommand(CommandType cmdType, string[] args, bool useIpc = false)
        {
            SendPlayerCommand(BasicCommand.Create(cmdType, args), useIpc);
        }
        #endregion

        #region Service Commands
        public static string SendServiceCommand(string serverMachineName,
            CommandType cmdType, string[] args)
        {
            try
            {
                BasicCommand command = BasicCommand.Create(cmdType, args);
                return SendServiceData(serverMachineName, command.ToString());
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return "NAK\r\n";
        }

        public static string SendServiceData(string serverMachineName, string data)
        {
            try
            {
                string res = RemoteControlProxy.SendRequest(data, serverMachineName, Constants.RCCServiceShortName, 
                    CommandTargetPort.RccService);

                if (string.IsNullOrEmpty(res))
                {
                    return "NAK\r\n";
                }

                return res;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return "NAK\r\n";
        }
        #endregion

        #region Media host commands
        //public static void SendMediaHostCommand(BasicCommand command)
        //{
        //    // See if player is started; if not - start it
        //    int i = 0;
        //    while ((!IsMediaHostRunning() && i < MaxStartupAttempts))
        //    {
        //        Process.Start(SuiteConfiguration.MediaHostInstallationPath);
        //        i++;

        //        Thread.Sleep(200);
        //    }

        //    if (i >= MaxStartupAttempts && !IsMediaHostRunning())
        //    {
        //        Logger.LogError("Could not send command because the media host could not be launched from path: {0}",
        //            SuiteConfiguration.MediaHostInstallationPath);
        //        return;
        //    }

        //    // If we came to this poin the player is running. 
        //    // Send the command (it should arrive to player).
        //    WmCopyDataSender.SendData(Constants.MediaHostName, command.ToString());
        //}

        //public static void SendMediaHostCommand(CommandType cmdType, string[] args)
        //{
        //    SendMediaHostCommand(BasicCommand.Create(cmdType, args));
        //}
        #endregion

        public static bool IsPlayerRunning()
        {
            string mutexName = Constants.PlayerName.Replace(" ", "").ToLowerInvariant() + @".mutex"; 
            try
            {
                using (Mutex m = Mutex.OpenExisting("Global\\" + mutexName, MutexRights.ReadPermissions))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static bool IsMediaHostRunning()
        //{
        //    string mutexName = Constants.MediaHostName.Replace(" ", "").ToLowerInvariant() + @".mutex";
        //    try
        //    {
        //        using (Mutex m = Mutex.OpenExisting("Global\\" + mutexName, MutexRights.ReadPermissions))
        //        {
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
