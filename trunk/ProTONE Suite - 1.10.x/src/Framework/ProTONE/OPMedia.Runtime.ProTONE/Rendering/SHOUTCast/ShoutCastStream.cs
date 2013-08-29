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
using System.Reflection;
using System.Net.Configuration;
using System.Collections.Specialized;

namespace OPMedia.Runtime.ProTONE.Rendering.SHOUTCast
{
    /// <summary>
    /// Provides the functionality to receive a shoutcast media stream
    /// </summary>
    public class ShoutcastStream : Stream
    {
        private int bitrate = 128;
        private int metaInt = 8192;
        private int receivedBytes;
        private Stream netStream;
        private bool connected = false;

        private string streamTitle;

        /// <summary>
        /// Is fired, when a new StreamTitle is received
        /// </summary>
        public event EventHandler StreamTitleChanged;

        public bool Connected { get { return connected; } }

        public int Bitrate { get { return bitrate; } }

        /// <summary>
        /// Creates a new ShoutcastStream and connects to the specified Url
        /// </summary>
        /// <param name="url">Url of the Shoutcast stream</param>
        public ShoutcastStream(string url, int timeout)
        {
            HttpWebResponse response = null;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers.Clear();
            request.Headers.Add("Icy-MetaData", "1");

            request.Proxy = AppSettings.GetWebProxy();
            request.KeepAlive = false;
            request.UserAgent = Constants.PlayerUserAgent;
            request.ServicePoint.Expect100Continue = false;

            request.Timeout = timeout;

            try
            {
                ToggleAllowUnsafeHeaderParsing(true);
                response = (HttpWebResponse)request.GetResponse();

                Dictionary<string, string> nvc = new Dictionary<string, string>();
                foreach (string key in response.Headers.AllKeys)
                {
                    nvc.Add(key, response.Headers[key]);
                }

                try
                {
                    metaInt = int.Parse(response.Headers["Icy-MetaInt"]);
                }
                catch { }

                try
                {
                    bitrate = int.Parse(response.Headers["Icy-BR"]);
                }
                catch { }
                
                receivedBytes = 0;

                netStream = response.GetResponseStream();
                connected = true;
            }
            catch
            {
                connected = false;
                throw;
            }
            finally
            {
                ToggleAllowUnsafeHeaderParsing(false);
            }
        }

        static bool ToggleAllowUnsafeHeaderParsing(bool enable)
        {
            //Get the assembly that contains the internal class
            Assembly assembly = Assembly.GetAssembly(typeof(SettingsSection));
            if (assembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type settingsSectionType = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (settingsSectionType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created already invoking the property will create it for us.
                    object anInstance = settingsSectionType.InvokeMember("Section",
                    BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework if unsafe header parsing is allowed
                        FieldInfo aUseUnsafeHeaderParsing = settingsSectionType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, enable);
                            return true;
                        }

                    }
                }
            }
            return false;
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
