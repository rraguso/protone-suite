using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Security;
using OPMedia.OSDependentLayer;

namespace OPMedia.Runtime.Logging
{
    public static class ErrorDispatcher
    {
        const string ExcFormat = "";
        const string ErrFormat = "";

        public static void DispatchException(Exception ex)
        {
            Logger.LogException(ex);

            string msg = GetErrorMessageForException(ex);
            InnerDisplayFatalError(
                "The application has encountered a fatal error.\nWe are sorry for the inconvenience. Details: \n\n" + msg + "\n\n" +
                "It is strongly recommended to restart the application now.\n" +
                "If the problem persists after restart, activate application logging and send the log files to OPMedia Research",
                "FATAL ERROR");
        }

        public static void DispatchError(string msg, string title)
        {
            Logger.LogError(msg);
            InnerDisplayNonFatalError(msg, title);
        }

        public static void DispatchError(Exception ex)
        {
            Logger.LogException(ex);

            string msg = GetErrorMessageForException(ex);
            InnerDisplayNonFatalError(
                "The application has encountered a non-fatal error.\nWe are sorry for the inconvenience. Details: \n\n" + msg,
                Application.ProductName);
        }

        public static void DispatchFatalError(string message, string title)
        {
            Logger.LogError(message);
            InnerDisplayFatalError(message, title);
        }

        private static void InnerDisplayFatalError(string message, string title)
        {
            EventDispatch.SendEventNotification(EventNames.ShowMessageBox, message, title, MessageBoxIcon.Error);
        }

        private static void InnerDisplayNonFatalError(string message, string title)
        {
            EventDispatch.SendEventNotification(EventNames.ShowMessageBox, message, title, MessageBoxIcon.Error);
        }

        private static string GetErrorMessageForException(Exception ex)
        {
            return GetErrorMessageForException(ex, false);
        }

        public static string GetErrorMessageForException(Exception ex, bool detailed)
        {
            string msg = (detailed) ? ex.ToString() : ex.Message;
            if (ex is COMException)
            {
                const int MAX_ERROR_TEXT_LEN = 255;

                // Make a buffer to hold the string
                StringBuilder sb = new StringBuilder(MAX_ERROR_TEXT_LEN, MAX_ERROR_TEXT_LEN);

                COMException cex = ex as COMException;
                
                if (Quartz.AMGetErrorText(cex.ErrorCode, sb, MAX_ERROR_TEXT_LEN) > 0)
                {
                    msg = sb.ToString();
                }
            }

            return msg;
        }
    }
}
