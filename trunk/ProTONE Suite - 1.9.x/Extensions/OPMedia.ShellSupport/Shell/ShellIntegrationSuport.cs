using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ProTONE.RemoteControl;
using OPMedia.Core;

using System.Drawing;
using System.ComponentModel;
using OPMedia.Core.ComTypes;
using OPMedia.Runtime;
using OPMedia.Runtime.ProTONE;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Runtime.ProTONE.Rendering;
using System.Runtime.InteropServices.ComTypes;
using OPMedia.ShellSupport.Properties;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Utilities;


namespace OPMedia.ShellSupport
{
    // This GUID is defined inside Constants.cs in OPMedia.Core.
    // If so required change it from there rather than entering a new one here.
    // because the value is used also by the install/uninstall routines.
    // Registration will fail if different GUID's are specified !!
    [Guid(Constants.ShellIntegrationSuportGuid)]
    [ComVisible(true)]
    public class ShellIntegrationSuport : IShellExtInit, IContextMenu
    {
        #region Members
        private List<string> fileList;
        //Bitmap bmp = null;
        IntPtr hBitmap = IntPtr.Zero;
        #endregion

        #region Construction
        public ShellIntegrationSuport()
        {
            try
            {
                hBitmap = Resources.player.GetHbitmap();
            }
            catch(Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
                hBitmap = IntPtr.Zero;
            }
        }
        #endregion

        #region Registration / Unregistration
        [ComRegisterFunction()]
        public static void RegisterServer(string s)
        {
            try
            {
                Logger.LogInfo("Attempt to register OPMedia.ShellSupport ...");

                SuiteRegistrationSupport.Init(MediaRenderer.GetSupportedFileProvider());
                SuiteRegistrationSupport.RegisterContextMenuHandler();
                SuiteRegistrationSupport.RegisterKnownFileTypes();
                SuiteRegistrationSupport.ReloadFileAssociations();

                Logger.LogInfo("OPMedia.ShellSupport was succesfully registered !");
            }
            catch (Exception exception)
            {
                ErrorDispatcher.DispatchFatalError(exception.Message, "Fatal registration error");
            }

            Logger.StopLogger();
        }

        [ComUnregisterFunction()]
        public static void UnregisterServer(string s)
        {
            try
            {
                Logger.LogInfo("Attempt to unregister OPMedia.ShellSupport ...");

                SuiteRegistrationSupport.Init(MediaRenderer.GetSupportedFileProvider());
                SuiteRegistrationSupport.UnregisterKnownFileTypes();
                SuiteRegistrationSupport.UnregisterContextMenuHandler();
                SuiteRegistrationSupport.ReloadFileAssociations();

                Logger.LogInfo("OPMedia.ShellSupport was succesfully unregistered !");
            }
            catch (Exception exception)
            {
                ErrorDispatcher.DispatchFatalError(exception.Message, "Fatal unregistration error");
            }

            Logger.StopLogger();
        }
        #endregion

        #region IShellExtInit implementation
        public void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgID)
        {
            if (pDataObj == IntPtr.Zero)
            {
                throw new ArgumentException();
            }

            Translator.RegisterTranslationAssembly(GetType().Assembly);
            Translator.SetInterfaceLanguage(SuiteConfiguration.LanguageID);

            FORMATETC fe = new FORMATETC();
            fe.cfFormat = (short)CLIPFORMAT.CF_HDROP;
            fe.ptd = IntPtr.Zero;
            fe.dwAspect = DVASPECT.DVASPECT_CONTENT;
            fe.lindex = -1;
            fe.tymed = TYMED.TYMED_HGLOBAL;
            STGMEDIUM stm = new STGMEDIUM();

            // The pDataObj pointer contains the objects being acted upon. In this 
            // example, we get an HDROP handle for enumerating the selected files 
            // and folders.
            IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(pDataObj);
            dataObject.GetData(ref fe, out stm);

            try
            {
                // Get an HDROP handle.
                IntPtr hDrop = stm.unionmember;
                if (hDrop == IntPtr.Zero)
                {
                    throw new ArgumentException();
                }

                // Determine how many files are involved in this operation.
                uint nFiles = Shell32.DragQueryFile(hDrop, UInt32.MaxValue, null, 0);

                // Enumerate the selected files and folders.
                if (nFiles > 0)
                {
                    this.fileList = new List<string>();
                    StringBuilder fileName = new StringBuilder(Kernel32.MAX_FILE_BUFFER);
                    for (uint i = 0; i < Math.Min(nFiles, Kernel32.MAX_FILES); i++)
                    {
                        // Get the next file name.
                        if (Shell32.DragQueryFile(hDrop, i, fileName, fileName.Capacity) != 0 &&
                            MediaRenderer.IsSupportedMedia(fileName.ToString()))
                        {
                            // Add the file name to the list.
                            fileList.Add(fileName.ToString());
                        }
                    }
                
                    // If we did not find any files we can work with, throw 
                    // exception.
                    if (fileList.Count == 0)
                    {
                        Marshal.ThrowExceptionForHR(WinError.E_FAIL);
                    }
                }
                else
                {
                    Marshal.ThrowExceptionForHR(WinError.E_FAIL);
                }
            }
            catch(Exception ex)
            {
                //ErrorDispatcher.DispatchException(ex);
                Logger.LogException(ex);
                fileList.Clear();
            }
            finally
            {
                 Ole32.ReleaseStgMedium(ref stm);
            }
        }
        #endregion

        #region IContextMenu implementation
       
        public int QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, uint uFlags)
        {
            if (fileList != null && fileList.Count > 0)
            {
                uint pos = (uint)User32.GetMenuItemCount(hmenu) / 2;

                User32.InsertMenu(hmenu, pos, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR,
                    IntPtr.Zero, string.Empty);

                User32.InsertMenu(hmenu, pos + 1, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING,
                    new IntPtr(idCmdFirst + (int)CommandType.PlayFiles),
                    Translator.Translate("TXT_PLAYMENU"));

                User32.InsertMenu(hmenu, pos + 2, MFMENU.MF_BYPOSITION | MFMENU.MF_STRING,
                    new IntPtr(idCmdFirst + (int)CommandType.EnqueueFiles),
                    Translator.Translate("TXT_ENQUEUEMENU"));

                User32.InsertMenu(hmenu, pos + 3, MFMENU.MF_BYPOSITION | MFMENU.MF_SEPARATOR,
                    IntPtr.Zero, string.Empty);

                if (hBitmap != IntPtr.Zero)
                {
                    User32.SetMenuItemBitmaps(hmenu, pos + 1, MFMENU.MF_BYPOSITION, hBitmap, hBitmap);
                    User32.SetMenuItemBitmaps(hmenu, pos + 2, MFMENU.MF_BYPOSITION, hBitmap, hBitmap);
                }

                return Math.Max((int)CommandType.PlayFiles, (int)CommandType.EnqueueFiles) + 1;
            }

            return 0;
        }

        public void InvokeCommand(IntPtr pici)
        {
            try
            {
                CMINVOKECOMMANDINFO ici = (CMINVOKECOMMANDINFO)Marshal.PtrToStructure(
                    pici, typeof(CMINVOKECOMMANDINFO));

                int cmd = (ici.verb.ToInt32()) & 0xffff;

                switch(cmd)
                {
                    case (int)CommandType.PlayFiles:
                    case (int)CommandType.EnqueueFiles:
                        RemoteControlHelper.SendPlayerCommand((CommandType)cmd, fileList.ToArray()); 
                        break;

                    default:
                        Marshal.ThrowExceptionForHR(WinError.E_FAIL);
                        break;
                }

            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }


        public void GetCommandString(UIntPtr idcmd, uint uflags, IntPtr reserved, StringBuilder commandstring, uint cchMax)
        {
            //commandstring.Clear();
            //commandstring.Append("Launch the files with ProTONE Player");
        }
        #endregion
    }
}
