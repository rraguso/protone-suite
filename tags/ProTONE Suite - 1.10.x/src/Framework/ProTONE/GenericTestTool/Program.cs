using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPMedia.Runtime.ProTONE.Playlists;
using System.Net;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE.Rendering.SHOUTCast;
using OPMedia.Core.NetworkAccess;

namespace GenericTestTool
{
    static class Program
    {
        static RadioStationsData data = new RadioStationsData();
        static RadioStationsData data2 = new RadioStationsData();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int j = 0;

            //using (StreamReader sr = new StreamReader(@"c:\radio_stations.csv"))
            //{
            //    int j = 0;
            //    while (!sr.EndOfStream)
            //    {

            //        string line = sr.ReadLine();
            //        string[] fields = line.Split(",".ToCharArray());

            //        int i = 0;
            //        string url = fields[i++];
            //        string title = fields[i++];
            //        string genre = fields[i++];

            //        RadioStation rs = new RadioStation();
            //        rs.Url = url;
            //        rs.Title = title;
            //        rs.Genre = genre;

            //        Console.WriteLine(">> {0} / {1}", j++, 857);
            //        ValidateUrl(url, title, genre);
            //    }

            //    data.SavePersistentList();
            //}

            data = RadioStationsData.Load();

            foreach(RadioStation rs in data.RadioStations)
            {
                Console.WriteLine(">> {0} / {1}", j++, data.RadioStations.Count);
                Console.WriteLine("Trying url: {0}", rs.Url);

                try
                {
                    ShoutcastStream ss = new ShoutcastStream(rs.Url, 500);
                    if (ss.Connected)
                    {
                        if (ss.Bitrate >= 128)
                        {
                            data2.RadioStations.Add(rs);
                        }
                    }
                }
                catch { }

                data2.SavePersistentList();
            }

            string xml = PersistenceProxy.ReadObject("RadioStationsData", string.Empty);
            using (StreamWriter sw = new StreamWriter(@"c:\radio_stations.xml"))
            {
                sw.Write(xml);
            }
        }

        private static void ValidateUrl(string url, string title, string genre)
        {
            Console.WriteLine("Trying url: {0}", url);

            try
            {
                Uri uri = new Uri(url);
                string hostName = uri.DnsSafeHost;

                //if (!QueryDnsWithTimeout(hostName, 300))
                //{
                //    Console.WriteLine("\t   -> Url: {0} is not valid (DNS error)", url);
                //    return;
                //}

                List<String> urlsToCkeck = new List<string>();

                if (IsPlaylist(url))
                {
                    string fileName = Path.GetFileName(uri.LocalPath);
                    string tempFile = @"c:\temp.pls";

                    using (WebClientWithTimeout wc = new WebClientWithTimeout())
                    {
                        wc.Timeout = 500;
                        wc.Proxy = AppSettings.GetWebProxy();
                        wc.DownloadFile(uri, tempFile);
                    }

                    if (File.Exists(tempFile))
                    {
                        Playlist p = new Playlist();
                        p.LoadPlaylist(tempFile);

                        File.Delete(tempFile);

                        foreach (PlaylistItem item in p.AllItems)
                        {
                            urlsToCkeck.Add(item.Path);
                        }
                    }
                }
                else
                {
                    urlsToCkeck.Add(url);
                }

                foreach(string url2 in urlsToCkeck)
                {
                    //if (!QueryDnsWithTimeout(url2, 300))
                      //  continue;

                    ShoutcastStream ss = new ShoutcastStream(url2, 500);
                    if (ss.Connected)
                    {
                        RadioStation rs = new RadioStation { Genre = genre, Title = title, Url = url2 };
                        data.RadioStations.Add(rs);

                        Console.WriteLine("\t   -> Added radio station: {0}", url2);

                        ss.Close();
                        ss.Dispose();
                        ss = null;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\t   ->" + ex.Message);
            }

            Console.WriteLine("\t   -> Url: {0} is not valid", url);

        }

        private static bool QueryDnsWithTimeout(string hostName, int p)
        {
            try
            {
                IAsyncResult ar = Dns.BeginGetHostAddresses(hostName, null, null);
                if (ar.AsyncWaitHandle.WaitOne(p, false))
                {
                    IPAddress[] addrs = Dns.EndGetHostAddresses(ar);
                    return (addrs != null && addrs.Length > 0);
                }
            }
            catch { }

            return false;
        }

        private static bool IsPlaylist(string file)
        {
            try
            {
                Uri uri = new Uri(file);
                string ext = PathUtils.GetExtension(uri.LocalPath);
                return MediaRenderer.SupportedPlaylists.Contains(ext);
            }
            catch
            {
                return false;
            }
        }
    }
}
