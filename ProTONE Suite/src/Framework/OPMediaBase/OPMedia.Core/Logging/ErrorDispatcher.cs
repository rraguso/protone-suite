using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Security;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.Core.Logging
{
    public static class ErrorDispatcher
    {
        const string ExcFormat = "";
        const string ErrFormat = "";

        public static void DispatchFatalError(Exception ex)
        {
            Logger.LogException(ex);

            string msg = GetErrorMessageForException(ex);
            InnerDisplayFatalError(
                "The application has encountered a fatal error.\nWe are sorry for the inconvenience. Details: \n\n" + msg + "\n\n" +
                "It is strongly recommended to restart the application now.\n" +
                "If the problem persists after restart, activate application logging and send the log files to OPMedia Research",
                Application.ProductName);
        }

        public static void DispatchFatalError(string msg, string title)
        {
            Logger.LogError(msg);
            InnerDisplayFatalError(
                "The application has encountered a fatal error.\nWe are sorry for the inconvenience. Details: \n\n" + msg + "\n\n" +
                "It is strongly recommended to restart the application now.\n" +
                "If the problem persists after restart, activate application logging and send the log files to OPMedia Research",
                Application.ProductName);
        }

        public static void DispatchError(Exception ex)
        {
            Logger.LogException(ex);
            string msg = GetErrorMessageForException(ex);

            InnerDisplayNonFatalError(msg, Translator.Translate("TXT_APP_NAME"));
        }

        public static void DispatchError(string msg, string title)
        {
            Logger.LogError(msg);
            InnerDisplayNonFatalError(msg, Translator.Translate("TXT_APP_NAME"));
        }


        private static void InnerDisplayFatalError(string message, string title)
        {
            EventDispatch.DispatchEvent(EventNames.ShowMessageBox, message, title, MessageBoxIcon.Error);
        }

        private static void InnerDisplayNonFatalError(string message, string title)
        {
            EventDispatch.DispatchEvent(EventNames.ShowMessageBox, message, title, MessageBoxIcon.Warning);
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
