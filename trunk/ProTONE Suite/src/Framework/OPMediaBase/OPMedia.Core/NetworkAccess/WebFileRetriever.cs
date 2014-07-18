using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Configuration;
using System.Threading;
using System.IO;
using System.Net;
using OPMedia.Core.Logging;

namespace OPMedia.Core.NetworkAccess
{
    public delegate void NewFileRetrievedEventHandler(string path, bool success, string errorDetails);

    public class WebFileRetriever : IDisposable
    {
        ProxySettings _ns = null;
        string _downloadUrl = string.Empty;
        string _destinationPath = string.Empty;
        WebClient _retriever = null;

        public event NewFileRetrievedEventHandler NewFileRetrieved = null;

        public WebFileRetriever(ProxySettings ns, string downloadUrl, string destinationPath, bool runAsBackgroundThread)
        {
            _ns = ns;
            _downloadUrl = downloadUrl;
            _destinationPath = destinationPath;

            if (runAsBackgroundThread)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PerformDownload));
            }
            else
            {
                // Exceptions will be caught at top level
                PerformUnsafeDownload();
            }
        }

        private void PerformDownload(object state)
        {
            try
            {
                PerformUnsafeDownload();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.Message);
                if (NewFileRetrieved != null)
                {
                    NewFileRetrieved(_destinationPath, false, ex.Message);
                }
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

            if (NewFileRetrieved != null)
            {
                NewFileRetrieved(_destinationPath, true, string.Empty);
            }

            Dispose();
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
