using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using System.Windows.Forms;
using OPMedia.UI.FileTasks;
using System.Threading;
using System.IO;
using OPMedia.Runtime.FileInformation;
using System.ComponentModel;
using OPMedia.UI.Controls;
using OPMedia.Core.ComTypes;

namespace OPMedia.UI.FileOperations.Tasks
{
    public class FileTaskSupport
    {
        BaseFileTask _task = null;

        public bool RequiresRefresh { get; private set; }

        #region Constructor

        public FileTaskSupport(BaseFileTask task)
        {
            _task = task;
        }

        ~FileTaskSupport()
        {
            _task = null;
        }

        #endregion

        #region Task pause / interrupt support

        ManualResetEvent _fileTaskWaitEvent = new ManualResetEvent(false);
        object _lock = new object();

        public void RequestAbort()
        {

            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (MessageDisplay.Query(Translator.Translate("TXT_CONFIRM_ABORT"),
                    Translator.Translate("TXT_CONFIRM"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CanContinue = false;
                }
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }

        }

        bool _canContinue = true;
        public bool CanContinue 
        {
            get
            {
                lock (_lock)
                {
                    return _canContinue;
                }
            }

            private set
            {
                lock (_lock)
                {
                    _canContinue = value;
                }
            }
        }

        public void CheckIfCanContinue(string path)
        {
            do
            {
                Application.DoEvents();
            }
            while (_fileTaskWaitEvent.WaitOne(20, true));

            if (!_canContinue)
            {
                throw new TaskInterruptedException(path);
            }
        }

        #endregion

        #region Confirmation support

        #region Generic confirmations

        protected class ConfirmationData
        {
            public bool ConfirmationResult { get; set; }
            public bool FlagValue { get; set; }

            public ConfirmationData()
            {
                ConfirmationResult = FlagValue = false;
            }
        }

        protected ConfirmationData ConfirmObjectAction(string tag, string objectName)
        {
            ConfirmationData retVal = new ConfirmationData();

            MainThread.Send(delegate(object x)
            {
                DialogResult dr = DialogResult.Abort;

                if (_task.ObjectsCount == 1)
                {
                    dr = MessageDisplay.Query(
                    Translator.Translate(tag, objectName), "TXT_CONFIRM");
                }
                else
                {
                    dr = MessageDisplay.QueryWithCancelAndAbort(
                    Translator.Translate(tag, objectName),
                    "TXT_CONFIRM", (_task.ObjectsCount > 1));
                }

                switch (dr)
                {
                    case DialogResult.Abort:
                        CanContinue = false;
                        break;

                    case DialogResult.No:
                        retVal.ConfirmationResult = false;
                        break;

                    case DialogResult.Yes:
                        retVal.ConfirmationResult = true;
                        break;

                    case DialogResult.OK: // YES ALL
                        retVal.ConfirmationResult = true;
                        retVal.FlagValue = true;
                        break;
                }
            });

            return retVal;
        }

        protected bool ConfirmObjectAction(string tag, string objectName, ref bool flagValue)
        {
            ConfirmationData data = ConfirmObjectAction(tag, objectName);
            flagValue = data.FlagValue;
            return data.ConfirmationResult;
        }

        #endregion

        #region Overwrite confirmations

        protected bool _overwrite = false;
        protected bool _overwriteReadOnly = false;
        public bool CanOverwrite(FileSystemInfo fi)
        {
            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (!_overwrite)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_OVERWRITE", fi.FullName, ref _overwrite))
                        return false;
                }

                if (PathUtils.ObjectHasAttribute(fi, FileAttributes.ReadOnly) && !_overwriteReadOnly)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_OVERWRITE_RO", fi.FullName, ref _overwriteReadOnly))
                        return false;
                }

                return true;
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }
        }

        #endregion

        #region Delete confirmations

        protected bool _delete = false;
        protected bool _deleteROHS = false;
        public bool CanDelete(FileSystemInfo fi)
        {
            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (!_delete)
                {
                    string confirmMsg = PathUtils.ObjectHasAttribute(fi, FileAttributes.Directory) ?
                        "TXT_CONFIRM_DELETE_EMPTYDIR" : "TXT_CONFIRM_DELETE";

                    if (!ConfirmObjectAction(confirmMsg, fi.FullName, ref _delete))
                        return false;
                }

                if (PathUtils.ObjectHasAttribute(fi, FileAttributes.ReadOnly | FileAttributes.System | FileAttributes.Hidden)
                    && !_deleteROHS)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_DELETE_ROHS", fi.FullName, ref _deleteROHS))
                        return false;
                }

                return true;
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }
        }

        protected bool _deleteNonEmptyFolders = false;
        public bool CanDeleteNonEmptyFolder(FileSystemInfo fi)
        {
            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (!_deleteNonEmptyFolders)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_DELETE_DIR", fi.FullName, ref _deleteNonEmptyFolders))
                        return false;
                }

                return true;
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }
        }

        #endregion

        #region Move confirmations

        protected bool _moveNonEmptyFolders = false;
        public bool CanMoveNonEmptyFolder(FileSystemInfo fi)
        {
            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (!_moveNonEmptyFolders)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_MOVE_DIR", fi.FullName, ref _moveNonEmptyFolders))
                        return false;
                }

                return true;
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }
        }

        protected bool _move = false;
        protected bool _moveROHS = false;
        public bool CanMove(FileSystemInfo fi)
        {
            try
            {
                _fileTaskWaitEvent.Set();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Paused);

                if (!_move)
                {
                    string confirmMsg = PathUtils.ObjectHasAttribute(fi, FileAttributes.Directory) ?
                        "TXT_CONFIRM_MOVE_EMPTYDIR" : "TXT_CONFIRM_MOVE";

                    if (!ConfirmObjectAction(confirmMsg, fi.FullName, ref _move))
                        return false;
                }

                if (PathUtils.ObjectHasAttribute(fi, FileAttributes.ReadOnly | FileAttributes.System | FileAttributes.Hidden)
                    && !_moveROHS)
                {
                    if (!ConfirmObjectAction("TXT_CONFIRM_MOVE_ROHS", fi.FullName, ref _moveROHS))
                        return false;
                }

                return true;
            }
            finally
            {
                _fileTaskWaitEvent.Reset();
                TaskbarThumbnailManager.Instance.SetProgressStatus(TaskbarProgressBarStatus.Normal);
            }
        }

        #endregion

        #endregion

        #region File system support

        #region File operations

        public bool CopyFile(FileInfo fi, string destFile)
        {
            try
            {
                FileInfo fi2 = new FileInfo(destFile);
                if (!fi2.Exists || this.CanOverwrite(fi2))
                {
                    if (!Directory.Exists(fi2.DirectoryName))
                    {
                        Directory.CreateDirectory(fi2.DirectoryName);

                        // File system changed => refresh will be required
                        this.RequiresRefresh = true;
                    }

                    FileRoutines.CopyFile(fi, fi2, Kernel32.CopyFileOptions.None, new Kernel32.CopyFileCallback(this.CopyFileCallback));

                    // File system changed => refresh will be required
                    this.RequiresRefresh = true;
                }
                return true;
            }
            catch (Exception exception)
            {
                Win32Exception winEx = exception as Win32Exception;
                if (winEx == null || winEx.NativeErrorCode != WinError.S_OK)
                {
                    _task.AddToErrorMap(fi.FullName, exception.Message);
                }

                return false;
            }
        }

        public void MoveFile(FileInfo fi, string destFile, bool skipConfirmations)
        {
            if (skipConfirmations || this.CanMove(fi))
            {
                if (PathUtils.PathsAreOnSameRoot(fi.FullName, destFile))
                {
                    FileInfo fi2 = new FileInfo(destFile);
                    if (!fi2.Exists || this.CanOverwrite(fi2))
                    {
                        if (!Directory.Exists(fi2.DirectoryName))
                        {
                            Directory.CreateDirectory(fi2.DirectoryName);

                            // File system changed => refresh will be required
                            this.RequiresRefresh = true;

                        }
                        if (fi2.Exists)
                        {
                            fi2.Attributes ^= fi2.Attributes;

                            // File system changed => refresh will be required
                            this.RequiresRefresh = true;

                        }
                        fi.MoveTo(destFile);

                        // File system changed => refresh will be required
                        this.RequiresRefresh = true;
                    }
                }
                else if (this.CopyFile(fi, destFile))
                {
                    this.DeleteFile(fi, true);
                }
            }
        }

        public void DeleteFile(FileInfo fi, bool skipConfirmations)
        {
            if (skipConfirmations || CanDelete(fi))
            {
                DeleteFileSystemObject(fi);
            }
        }

        public Kernel32.CopyFileCallbackAction CopyFileCallback(
           FileInfo source, FileInfo destination, object state,
           long totalFileSize, long totalBytesTransferred)
        {
            UpdateProgressData data = new UpdateProgressData(totalFileSize, totalBytesTransferred);

            _task.FireTaskProgress(ProgressEventType.Progress, source.FullName, data);

            do
            {
                Application.DoEvents();
            }
            while (_fileTaskWaitEvent.WaitOne(20, true));

            return CanContinue ? 
                Kernel32.CopyFileCallbackAction.Continue : 
                Kernel32.CopyFileCallbackAction.Cancel;
        }

        #endregion

        #region Folder operations

        public void DeleteFolder(DirectoryInfo di)
        {
            if (di.Exists)
            {
                if (di.GetFileSystemInfos().Length == 0)
                {
                    // empty folder
                    if (CanDelete(di))
                    {
                        DeleteFileSystemObject(di);
                    }
                }
                else if (CanDeleteNonEmptyFolder(di))
                {
                    DeleteFileSystemObject(di);
                }
            }
        }

        #endregion

        #region Generic file system operations

        public void DeleteFileSystemObject(FileSystemInfo fsi)
        {
            try
            {
                if (fsi.Exists)
                {
                    DirectoryInfo di = fsi as DirectoryInfo;
                    if (di != null)
                    {
                        PathUtils.DeleteFolderTree(fsi.FullName);

                        // File system changed => refresh will be required
                        this.RequiresRefresh = true;

                        return;
                    }

                    fsi.Attributes ^= fsi.Attributes;
                    fsi.Delete();

                    // File system changed => refresh will be required
                    this.RequiresRefresh = true;
                }
            }
            catch (Exception ex)
            {
                _task.AddToErrorMap(fsi.FullName, ex.Message);
            }
        }

        #endregion

        public virtual List<string> GetLinkedFiles(FileInfo fi, FileTaskType taskType)
        {
            return null;
        }
        public virtual string GetParentFile(FileInfo fi, FileTaskType taskType)
        {
            return null;
        }

        #endregion
    }
}
