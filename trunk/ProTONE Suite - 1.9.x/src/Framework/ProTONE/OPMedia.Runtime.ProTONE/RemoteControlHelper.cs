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
using OPMedia.Runtime.Remoting;
using System.Runtime.Remoting;

using OPMedia.Runtime.Remoting.Tcp;
using System.Security.AccessControl;
using OPMedia.Runtime.InterProcessCommunication;
//using OPMedia.Runtime.UdpCommunication;

namespace OPMedia.Runtime.ProTONE
{
    public enum CommandTargetPort
    {
        Player = 10201,
        RccService = 10202,
        MediaHost = 10203,
    }
  

    public static class RemoteControlHelper
    {
        const int MaxStartupAttempts = 20;

        #region Player commands
        public static void SendPlayerCommand(BasicCommand command)
        {
            // See if player is started; if not - start it
            int i = 0;
            while((!IsPlayerRunning() && i < MaxStartupAttempts))
            {
                Process.Start(SuiteConfiguration.PlayerInstallationPath);
                i++;

                Thread.Sleep(1000);
            }

            if (i >= MaxStartupAttempts && !IsPlayerRunning())
            {
                Logger.LogError("Could not send command because the player could not be launched from path: {0}",
                    SuiteConfiguration.PlayerInstallationPath);
                return;
            }

            //// If we came to this poin the player is running. 
            //// Send the command (it should arrive to player).
            WmCopyDataSender.SendData(Constants.PlayerName, command.ToString());
        }

        public static void SendPlayerCommand(CommandType cmdType, string[] args)
        {
            SendPlayerCommand(BasicCommand.Create(cmdType, args));
        }
        #endregion

        #region Service Commands
        public static void SendServiceCommand(string serverMachineName,
            CommandType cmdType, string[] args)
        {
            string serviceLocation = string.Format("tcp://{0}:{1}/{2}", serverMachineName, 
                Constants.RCCServiceRemotingPort, Constants.RCCServiceShortName);

            BasicCommand command = BasicCommand.Create(cmdType, args);

            RemoteClient client = null;

            client = RemoteClient.Create(false, serviceLocation);

            try
            {
                client.SendRequest(command);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public static void SendServiceData(string serverMachineName, string data)
        {
            string serviceLocation = string.Format("tcp://{0}:{1}/{2}", serverMachineName,
                Constants.RCCServiceRemotingPort, Constants.RCCServiceShortName);

            RemoteClient client = RemoteClient.Create(false, serviceLocation);

            try
            {
                client.SendRequest(new RemoteString(data));
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
        #endregion

        #region Media host commands
        public static void SendMediaHostCommand(BasicCommand command)
        {
            // See if player is started; if not - start it
            int i = 0;
            while ((!IsMediaHostRunning() && i < MaxStartupAttempts))
            {
                Process.Start(SuiteConfiguration.MediaHostInstallationPath);
                i++;

                Thread.Sleep(200);
            }

            if (i >= MaxStartupAttempts && !IsMediaHostRunning())
            {
                Logger.LogError("Could not send command because the media host could not be launched from path: {0}",
                    SuiteConfiguration.MediaHostInstallationPath);
                return;
            }

            // If we came to this poin the player is running. 
            // Send the command (it should arrive to player).
            WmCopyDataSender.SendData(Constants.MediaHostName, command.ToString());
        }

        public static void SendMediaHostCommand(CommandType cmdType, string[] args)
        {
            SendMediaHostCommand(BasicCommand.Create(cmdType, args));
        }
        #endregion

        public static bool IsPlayerRunning()
        {
            string mutexName = Constants.PlayerName.Replace(" ", "").ToLowerInvariant() + @".mutex"; 
            try
            {
                using (Mutex m = Mutex.OpenExisting(mutexName, MutexRights.ReadPermissions))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsMediaHostRunning()
        {
            string mutexName = Constants.MediaHostName.Replace(" ", "").ToLowerInvariant() + @".mutex";
            try
            {
                using (Mutex m = Mutex.OpenExisting(mutexName, MutexRights.ReadPermissions))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
