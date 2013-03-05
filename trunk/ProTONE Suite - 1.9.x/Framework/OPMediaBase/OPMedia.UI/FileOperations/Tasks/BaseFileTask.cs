using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OPMedia.Core;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.Logging;
using OPMedia.UI.FileOperations.Tasks;

namespace OPMedia.UI.FileTasks
{
    #region Enums

    public enum FileTaskType
    {
        None = 0,
        Copy,
        Move,
        Delete
    }

    public enum ProgressEventType
    {
        Started = 0,
        KeepAlive,
        Progress,
        Aborted,
        Finished,
    }

    #endregion

    #region Delegates

    public delegate void FileTaskProgressDG(ProgressEventType eventType, string file, UpdateProgressData data);

    #endregion

    #region Helper classes

    public class TaskInterruptedException : Exception
    {
        public TaskInterruptedException(string msg)
            : base(msg)
        {
        }
    }

    public class UpdateProgressData
    {
        public static UpdateProgressData Default = new UpdateProgressData(); 

        public long TotalFileSize { get; private set; }
        public long TotalBytesTransferred { get; private set; }

        private UpdateProgressData()
        {
            this.TotalFileSize = 0;
            this.TotalBytesTransferred = 0;
        }

        public UpdateProgressData(long totalFileSize, long totalBytesTransferred)
        {
            this.TotalFileSize = totalFileSize;
            this.TotalBytesTransferred = totalBytesTransferred;
        }

        public override string ToString()
        {
            return string.Format("t/T: {0}/{1}", TotalBytesTransferred, TotalFileSize);
        }
    }

    #endregion

    public abstract class BaseFileTask
    {
        public event FileTaskProgressDG FileTaskProgress = null;

        public FileTaskType TaskType { get; private set; }

        public Dictionary<string, string> ErrorMap { get; private set; }

        public bool IsFinished { get; private set; }

        public List<string> SrcFiles { get; private set; }
        public string SrcFolder { get; private set; }
        public string DestFolder { get; private set; }
        public int ObjectsCount { get; private set; }

        public long ProcessedObjects { get; protected set; }

        protected Thread _fileTaskThread;
        protected FileTaskSupport _support = null;

        protected System.Timers.Timer _timer = null;

        private bool _requiresRefresh = false;
        public bool RequiresRefresh
        {
            get
            {
                return (_support == null) ? _requiresRefresh : _support.RequiresRefresh;
            }
        }

        public bool CanContinue
        {
            get
            {
                return (_support == null) ? false : _support.CanContinue;
            }
        }

        public BaseFileTask(FileTaskType type, List<string> srcFiles, string srcFolder)
        {
            this.TaskType = type;
            this.ErrorMap = new Dictionary<string, string>();

            this.SrcFiles = srcFiles;
            this.SrcFolder = srcFolder;

            _timer = new System.Timers.Timer(500);
            _timer.AutoReset = true;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);

            _support = InitSupport();
            this.IsFinished = false;
        }

        protected virtual FileTaskSupport InitSupport()
        {
            return new FileTaskSupport(this);
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPath))
            {
                FireTaskProgress(ProgressEventType.KeepAlive, _currentPath, UpdateProgressData.Default);
            }
        }

        public void FireTaskProgress(ProgressEventType eventType, string file, UpdateProgressData data)
        {
            if (FileTaskProgress != null)
            {
                FileTaskProgress(eventType, file, data);
            }
        }

        public void AddToErrorMap(string path, string error)
        {
            if (ErrorMap.ContainsKey(path))
            {
                ErrorMap[path] = error;
            }
            else
            {
                ErrorMap.Add(path, error);
            }
        }

        protected string GetDestinationPath(string srcPath)
        {
            if (TaskType == FileTaskType.Copy || TaskType == FileTaskType.Move)
            {
                string diffPath = srcPath.Replace(SrcFolder, string.Empty);
                return Path.Combine(DestFolder, diffPath.TrimStart(PathUtils.DirectorySeparatorChars));
            }

            return string.Empty;
        }


        public void RunTask(string destFolder)
        {
            this.DestFolder = destFolder ?? string.Empty;

            _fileTaskThread = new Thread(new ThreadStart(RunTaskAsync));
            _fileTaskThread.Priority = ThreadPriority.Normal;
            _fileTaskThread.Start();
        }

        public void RequestAbort()
        {
            _support.RequestAbort();
        }

        string _currentPath = string.Empty;
        private void RunTaskAsync()
        {
            try
            {
                ProcessedObjects = 0;
                ObjectsCount = 0;
                ErrorMap.Clear();

                foreach (string path in SrcFiles)
                {
                    if (Directory.Exists(path))
                    {
                        string[] entries = Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories);
                        if (entries != null && entries.Length > 0)
                        {
                            ObjectsCount += entries.Length;
                        }
                    }
                    else
                    {
                        ObjectsCount++;
                    }
                }

                FireTaskProgress(ProgressEventType.Started, string.Empty, UpdateProgressData.Default);

                _currentPath = string.Empty;
                _timer.Start();

                try
                {
                    foreach (string path in SrcFiles)
                    {
                        _currentPath = path;
                        FireTaskProgress(ProgressEventType.Progress, path, UpdateProgressData.Default);

                        switch (TaskType)
                        {
                            case FileTaskType.Copy:
                                CopyObject(path);
                                break;

                            case FileTaskType.Move:
                                MoveObject(path);
                                break;

                            case FileTaskType.Delete:
                                DeleteObject(path);
                                break;
                        }
                    }
                }
                catch (TaskInterruptedException)
                {
                    FireTaskProgress(ProgressEventType.Aborted, string.Empty, UpdateProgressData.Default);
                    return;
                }
                finally
                {
                    _timer.Stop();
                    _currentPath = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                IsFinished = true;
            }

            FireTaskProgress(ProgressEventType.Finished, string.Empty, UpdateProgressData.Default);
            _requiresRefresh = _support.RequiresRefresh;
            _support = null;
        }

        #region Overridables

        protected virtual bool CopyObject(string path) { return true; }
        protected virtual bool MoveObject(string path) { return true; }
        protected virtual bool DeleteObject(string path) { return true; }
        
        #endregion
    }
}
