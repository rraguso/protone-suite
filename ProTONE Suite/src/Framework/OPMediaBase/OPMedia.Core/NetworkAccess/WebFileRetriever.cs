using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Configuration;
using System.Threading;
using System.IO;
using System.Net;
using OPMedia.Core.Logging;
using System.ComponentModel;

namespace OPMedia.Core.NetworkAccess
{
    public delegate void FileRetrieveCompleteEventHandler(string path, bool success, string errorDetails);

    public class WebFileRetriever : IDisposable
    {
        ProxySettings _ns = null;
        string _downloadUrl = string.Empty;
        string _destinationPath = string.Empty;
        WebClient _retriever = null;

        public event FileRetrieveCompleteEventHandler FileRetrieveComplete = null;

        BackgroundWorker _bw = null;

        public WebFileRetriever(ProxySettings ns, string downloadUrl, string destinationPath, bool runAsBackgroundThread)
        {
            _ns = ns;
            _downloadUrl = downloadUrl;
            _destinationPath = destinationPath;

            if (runAsBackgroundThread)
            {
                _bw = new BackgroundWorker();
                _bw.WorkerReportsProgress = _bw.WorkerSupportsCancellation = false;
                _bw.DoWork += new DoWorkEventHandler(OnBackgroundDownload);
                _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnBackgroundDownloadCompleted);
                _bw.RunWorkerAsync();
            }
            else
            {
                // Exceptions will be caught at top level
                PerformUnsafeDownload();
            }
        }

        void OnBackgroundDownload(object sender, DoWorkEventArgs e)
        {
            PerformUnsafeDownload();
        }

        void OnBackgroundDownloadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool isSuccess = true;
            string message = string.Empty;

            if (e.Error != null)
            {
                isSuccess = false;
                message = e.Error.Message;
                Logger.LogWarning(message);
            }

            if (FileRetrieveComplete != null)
            {
                FileRetrieveComplete(_destinationPath, isSuccess, message);
            }

        }

        private void PerformUnsafeDownload()
        {
            string destFolder = Path.GetDirectoryName(_destinationPath);

            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            _retriever = new WebClient();
            _retriever.Proxy = AppConfig.GetWebProxy();
            _retriever.DownloadFile(new Uri(_downloadUrl), _destinationPath);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_retriever != null)
            {
                _retriever.Dispose();
                _retriever = null;
            }
        }

        #endregion
    }
}
