using OPMedia.Runtime;
using OPMedia.Core.Configuration;
using System.Net;
using OPMedia.Core.Logging;
using System.Threading;
using System.IO;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using OPMedia.Core.NetworkAccess;
using OPMedia.Core;
using OPMedia.Core.Utilities;
using System.Collections.Generic;

namespace OPMedia.Runtime.Processors
{
    

    public class BackgroundRetriever : Processor
    {
        private object _syncRoot = new object();
        private WebClient _retriever = new WebClient();
        private string _pendingDownloadFile = string.Empty;

        public event NewFileRetrievedEventHandler NewFileRetrieved = null;

        ProxySettings _ns = null;
        string _descName = string.Empty;
        string _downloadUrl = string.Empty;
        string _repositoryPath = string.Empty;
        int _downloadInterval = 0;

        public BackgroundRetriever(ProxySettings ns, string descName, string downloadUrl, 
            string repositoryPath, int downloadInterval)
        {
            _ns = ns;
            _descName = descName;
            _downloadUrl = downloadUrl;
            _downloadInterval = downloadInterval;
            _repositoryPath = repositoryPath;
        }

        protected override bool CanStart()
        {
            return true;
        }

        protected override void OnStarted()
        {
        }

        protected override bool CanStop()
        {
            return true;
        }

        protected override void OnStopped()
        {
        }

        protected override bool ProcessInternal()
        {
            try
            {
                DateTime fileTimeStamp = DateTime.MinValue;
                string filePath = string.Empty;
                string fileName = "~" + _descName + ".frtmp";
                _pendingDownloadFile = Path.Combine(_repositoryPath, fileName);

                using (WebFileRetriever downloader =
                    new WebFileRetriever(_ns, _downloadUrl, _pendingDownloadFile, false))
                {
                }

                string ext = PathUtils.GetExtension(_downloadUrl);

                if (!AreFilesIdentical(GetLatestFileInRepository(), _pendingDownloadFile))
                {
                    DateTime dt = DateTime.MinValue;
                    string newFileName = StringUtils.GetUniqueFileName(ref dt);
                    string newFilePath = Path.Combine(_repositoryPath, newFileName + ext);
                    File.Move(_pendingDownloadFile, newFilePath);

                    if (NewFileRetrieved != null)
                    {
                        NewFileRetrieved(newFilePath, true, string.Empty);
                    }
                }

                DeleteFile(_pendingDownloadFile);
                _pendingDownloadFile = string.Empty;
            }
            catch (ThreadAbortException)
            {
                if (!string.IsNullOrEmpty(_pendingDownloadFile) && File.Exists(_pendingDownloadFile))
                {
                    EventDispatch.DispatchEvent(EventNames.ShowMessageBox, "Download cancelled.", _descName, MessageBoxIcon.Warning);

                    _retriever.Dispose();
                    _retriever = null;

                    DeleteFile(_pendingDownloadFile);
                    _pendingDownloadFile = string.Empty;
                }

                return false;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchException(ex);
            }

            // DownloadInterval is in seconds
            Thread.Sleep(_downloadInterval * 1000);

            return true;
        }

        private bool AreFilesIdentical(string path1, string path2)
        {
            try
            {
                FileInfo fi1 = new FileInfo(path1);
                FileInfo fi2 = new FileInfo(path2);
                return (fi1.Length == fi2.Length);
            }
            catch
            {
                return false;
            }
        }

        private string GetLatestFileInRepository()
        {
            string ext = PathUtils.GetExtension(_downloadUrl);

            List<string> files = new List<string>(Directory.EnumerateFiles(_repositoryPath, "*" + ext));
            if (files.Count > 0)
            {
                return files[files.Count - 1];
            }

            return null;
        }

        private void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchException(ex);
            }
        }
    }
}
