using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using OPMedia.Core.ApplicationSettings;
using System.IO;
using OPMedia.Core;
using System.Text.RegularExpressions;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.ProTONE.Rendering.SHOUTCast
{
    /// <summary>
    /// Provides the functionality to receive a shoutcast media stream
    /// </summary>
    public class ShoutcastStream : Stream
    {
        private int metaInt;
        private int receivedBytes;
        private Stream netStream;
        private bool connected = false;

        private string streamTitle;

        /// <summary>
        /// Is fired, when a new StreamTitle is received
        /// </summary>
        public event EventHandler StreamTitleChanged;

        /// <summary>
        /// Creates a new ShoutcastStream and connects to the specified Url
        /// </summary>
        /// <param name="url">Url of the Shoutcast stream</param>
        public ShoutcastStream(string url)
        {
            IWebProxy wp = null;
            ProxySettings ps = AppSettings.ProxySettings;

            if (ps == null || ps.ProxyType == ProxyType.NoProxy)
            {
                wp = new WebProxy();
            }
            else if (ps.ProxyType != ProxyType.InternetExplorerProxy)
            {
                wp = new WebProxy(ps.ProxyAddress, ps.ProxyPort);
                wp.Credentials = new NetworkCredential(ps.ProxyUser, ps.ProxyPassword);
                (wp as WebProxy).BypassProxyOnLocal = true;
            }



            HttpWebResponse response = null;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers.Clear();
            request.Headers.Add("Icy-MetaData", "1");

            request.Proxy = wp;
            request.KeepAlive = false;
            request.UserAgent = Constants.PlayerUserAgent;
            request.ServicePoint.Expect100Continue = false;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            metaInt = int.Parse(response.Headers["Icy-MetaInt"]);
            receivedBytes = 0;

            netStream = response.GetResponseStream();

            connected = true;
        }

        /// <summary>
        /// Parses the received Meta Info
        /// </summary>
        /// <param name="metaInfo"></param>
        private void ParseMetaInfo(byte[] metaInfo)
        {
            string metaString = Encoding.Unicode.GetString(metaInfo);

            string newStreamTitle = Regex.Match(metaString, "(StreamTitle=')(.*)(';StreamUrl)").Groups[2].Value.Trim();
            if (!newStreamTitle.Equals(streamTitle))
            {
                streamTitle = newStreamTitle;
                OnStreamTitleChanged();
            }
        }

        /// <summary>
        /// Fires the StreamTitleChanged event
        /// </summary>
        protected virtual void OnStreamTitleChanged()
        {
            if (StreamTitleChanged != null)
                StreamTitleChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets a value that indicates whether the ShoutcastStream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return connected; }
        }

        /// <summary>
        /// Gets a value that indicates whether the ShoutcastStream supports seeking.
        /// This property will always be false.
        /// </summary>
        public override bool CanSeek
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value that indicates whether the ShoutcastStream supports writing.
        /// This property will always be false.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the title of the stream
        /// </summary>
        public string StreamTitle
        {
            get { return streamTitle; }
        }

        /// <summary>
        /// Flushes data from the stream.
        /// This method is currently not supported
        /// </summary>
        public override void Flush()
        {
            return;
        }

        /// <summary>
        /// Gets the length of the data available on the Stream.
        /// This property is not currently supported and always thows a <see cref="NotSupportedException"/>.
        /// </summary>
        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets or sets the current position in the stream.
        /// This property is not currently supported and always thows a <see cref="NotSupportedException"/>.
        /// </summary>
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Reads data from the ShoutcastStream.
        /// </summary>
        /// <param name="buffer">An array of bytes to store the received data from the ShoutcastStream.</param>
        /// <param name="offset">The location in the buffer to begin storing the data to.</param>
        /// <param name="count">The number of bytes to read from the ShoutcastStream.</param>
        /// <returns>The number of bytes read from the ShoutcastStream.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                if (receivedBytes == metaInt)
                {
                    int metaLen = netStream.ReadByte();
                    if (metaLen > 0)
                    {
                        byte[] metaInfo = new byte[metaLen * 16];
                        int len = 0;
                        while ((len += netStream.Read(metaInfo, len, metaInfo.Length - len)) < metaInfo.Length) ;
                        ParseMetaInfo(metaInfo);
                    }
                    receivedBytes = 0;
                }

                int bytesLeft = ((metaInt - receivedBytes) > count) ? count : (metaInt - receivedBytes);
                int result = netStream.Read(buffer, offset, bytesLeft);
                receivedBytes += result;
                return result;
            }
            catch (Exception e)
            {
                connected = false;
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        /// <summary>
        /// Closes the ShoutcastStream.
        /// </summary>
        public override void Close()
        {
            connected = false;
            netStream.Close();
        }

        /// <summary>
        /// Sets the current position of the stream to the given value.
        /// This Method is not currently supported and always throws a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Sets the length of the stream.
        /// This Method always throws a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Writes data to the ShoutcastStream.
        /// This method is not currently supported and always throws a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
}
