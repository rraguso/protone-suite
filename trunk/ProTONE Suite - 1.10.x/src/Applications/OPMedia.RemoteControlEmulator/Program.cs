﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using System.IO;
using OPMedia.Runtime.ProTONE.Playlists;
using OPMedia.Runtime.ProTONE.Rendering.SHOUTCast;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering;
using System.Net;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core.NetworkAccess;

namespace OPMedia.RemoteControlEmulator
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

            LoggedApplication.Start("OPMedia.RemoteControlEmulator");

            try
            {
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            LoggedApplication.Stop();
        }

        private delegate IPAddress[] GetHostAddressesHandler(string name);

        public static bool ValidateServerName(string name, int timeout)
        {
            IPAddress[] addr = null;

            try
            {
                GetHostAddressesHandler callback = new GetHostAddressesHandler(Dns.GetHostAddresses);
                IAsyncResult result = callback.BeginInvoke(name, null, null);
                if (result.AsyncWaitHandle.WaitOne(timeout, false))
                {
                    addr = callback.EndInvoke(result);
                }

                //addr = Dns.GetHostAddresses(name);
            }
            catch (Exception ex)
            {
            }

            return (addr != null && addr.Length > 0);
        }

        private static bool IsPlaylist(string file)
        {
            try
            {
                Uri uri = new Uri(file);
                string ext = PathUtils.GetExtension(uri.LocalPath);
                return MediaRenderer.SupportedPlaylists.Contains(ext);
            }
            catch
            {
                return false;
            }
        }
    }
}
