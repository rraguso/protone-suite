#region COPYRIGHT (c) 2004 by Brian Weeres
/* Copyright (c) 2004 by Brian Weeres
 * 
 * Email: bweeres@protegra.com; bweeres@hotmail.com
 * 
 * Permission to use, copy, modify, and distribute this software for any
 * purpose is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * If you modify it then please indicate so. 
 *
 * The software is provided "AS IS" and there are no warranties or implied warranties.
 * In no event shall Brian Weeres and/or Protegra Technology Group be liable for any special, 
 * direct, indirect, or consequential damages or any damages whatsoever resulting for any reason 
 * out of the use or performance of this software
 * 
 */
#endregion
using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Diagnostics;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;
using System.Net.Sockets;
using System.Collections.Generic;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb
{
	/// <summary>
	/// Summary description for FreedbHelper.
	/// </summary>
	public class FreedbHelper : IDisposable
	{
		private string m_UserName;
		private string m_Hostname;
		private string m_ClientName;
		private string m_Version;

        private TcpClient _tcpClient = new TcpClient();
        NetworkStream _ns = null;
        StreamWriter _writer = null;
        StreamReader _reader = null;

		#region Constants for Freedb commands
		public class Commands
		{
			public const string CMD_HELLO	= "cddb hello";
			public const string CMD_READ	= "cddb read";
			public const string CMD_QUERY	= "cddb query";
			public const string CMD_TERMINATOR	= "."; 
		}
		#endregion

		#region Constants for Freedb ResponseCodes
		public class ResponseCodes
		{
            //query codes
            public const string CODE_200 = "200"; // Exact match 
            public const string CODE_201 = "201"; // Partial match 
            public const string CODE_202 = "202"; // No match 
            public const string CODE_210 = "210"; // Okay // or in a query multiple exact matches
			public const string CODE_211 = "211"; // InExact matches found - list follows

            public const string CODE_401 = "401"; // sites: no site information available
            public const string CODE_402 = "402"; // Server Error
            public const string CODE_403 = "403"; // Database entry is corrupt
			public const string CODE_409 = "409"; // No Handshake

            public const string CODE_500 = "500"; // Invalid command, invalid parameters, etc.

			// our own code
			public const string CODE_INVALID = "-1"; // Invalid code 
		}
		#endregion

        static Dictionary<string, string> _codeMap = new Dictionary<string, string>();

        static FreedbHelper()
        {
            _codeMap.Add("200", "OK");
            _codeMap.Add("201", "OK/Partial match");
            _codeMap.Add("202", "Fail - No mathches found");
            _codeMap.Add("210", "OK - multiline response follows (end with .)");
            _codeMap.Add("211", "OK/Partial match - multiline response follows (end with .)");
            _codeMap.Add("401", "CDDB Entry not found");
            _codeMap.Add("402", "Server error");
            _codeMap.Add("403", "Database corrupted");
            _codeMap.Add("409", "Handshake was not yet done");
            _codeMap.Add("431", "Handshake failed");
            _codeMap.Add("432", "Permisssion denied");
            _codeMap.Add("433", "Too many logged on users");
            _codeMap.Add("434", "System load too high");
            _codeMap.Add("500", "Invalid command or parameter");
            _codeMap.Add("-1", "Invalid response");
        }

        private static string MapCode(string code)
        {
            string detail = string.Empty;
            int nCode = 100;
            if (int.TryParse(code, out nCode))
            {
                int d = nCode % 100;
                switch (d)
                {
                    case 0:
                        break;

                    case 1:
                        detail = "Informative message";
                        break;

                    default:
                        detail = _codeMap[code];
                        break;
                }
            }

            if (String.IsNullOrEmpty(detail))
                return code;

            return string.Format("{0} [{1}]", code, detail);
        }
		
		/// <summary>
		/// Read Entry from the database. 
		/// </summary>
		/// <param name="qr">A QueryResult object that is created by performing a query</param>
		/// <param name="cdEntry">out parameter - CDEntry object</param>
		/// <returns></returns>
		public string Read(QueryResult qr, out CDEntry cdEntry)
		{
            StringBuilder builder = new StringBuilder(FreedbHelper.Commands.CMD_READ);
            builder.Append(" ");
            builder.Append(qr.Category);
            builder.Append(" ");
            builder.Append(qr.Discid);

            cdEntry = null;

            try
            {
                string request = builder.ToString();
                List<string> reply = SendRequest(request);

                if (reply.Count <= 0)
                {
                    string msg = "No results returned from cddb query.";
                    Exception ex = new Exception(msg, null);
                    throw ex;
                }

                string code = GetReplyCode(reply, request);
                
                switch (code)
                {
                    case ResponseCodes.CODE_210:
                    case ResponseCodes.CODE_211:
                        {
                            //remove first line, this one has code 210 or 211
                            reply.RemoveAt(0);
                            cdEntry = new CDEntry(reply);
                        }
                        break;
                }

                return code;
            }
            catch (Exception ex)
            {
                string msg = "Unable to perform cddb query.";
                Exception newex = new Exception(msg, ex);
                throw newex;
            }
		}


		/// <summary>
		/// Query the freedb server to see if there is information on this cd
		/// </summary>
		/// <param name="querystring"></param>
		/// <param name="queryResult"></param>
		/// <param name="queryResultsColl"></param>
		/// <returns></returns>
		public string Query(string querystring, out QueryResult queryResult, out List<QueryResult> queryResultsColl)
		{
            StringBuilder builder = new StringBuilder(FreedbHelper.Commands.CMD_QUERY);
            builder.Append(" ");
            builder.Append(querystring);

            queryResult = null;
            queryResultsColl = null;
           
			//make call
			try
			{
                string request = builder.ToString();
                List<string> reply = SendRequest(request);

                if (reply.Count <= 0)
                {
                    string msg = "No results returned from cddb query.";
                    Exception ex = new Exception(msg, null);
                    throw ex;
                }

                string code = GetReplyCode(reply, request);
                switch (code)
                {
                    case ResponseCodes.CODE_200:
                        queryResult = new QueryResult(reply[0]);
                        break;

                    case ResponseCodes.CODE_210:
                    case ResponseCodes.CODE_211:
                        {
                            queryResultsColl = new List<QueryResult>();
                            //remove first line, this one has code 210 or 211
                            reply.RemoveAt(0);
                            foreach (string line in reply)
                            {
                                QueryResult result = new QueryResult(line, true);
                                queryResultsColl.Add(result);
                            }
                        }
                        break;
                }

                return code;
			}
			catch (Exception ex)
			{
				string msg = "Unable to perform cddb query.";
				Exception newex = new Exception(msg,ex);
				throw newex ;
			}
		}

        /// <summary>
        /// Build the hello part of the command 
        /// </summary>
        /// <returns></returns>
        public string BuildHello()
        {
            StringBuilder builder = new StringBuilder(Commands.CMD_HELLO);
            builder.Append(" ");
            builder.Append(m_UserName);
            builder.Append(" ");
            builder.Append(m_Hostname);
            builder.Append(" ");
            builder.Append(m_ClientName);
            builder.Append(" ");
            builder.Append(m_Version);
            return builder.ToString();
        }

        public FreedbHelper(string server, int port)
        {
            m_UserName = Constants.AnonymousUser;
            m_Hostname = Dns.GetHostName();
            m_ClientName = Constants.PlayerUserAgent.Replace(" ", ""); // eat up spaces, FreeDb does not like them.
            m_Version = SuiteVersion.Version;

            _tcpClient.Connect(server, port);
            if (_tcpClient.Connected)
            {
                _ns = _tcpClient.GetStream();
                _writer = new StreamWriter(_ns);
                _reader = new StreamReader(_ns);

                string line = _reader.ReadLine();
                string code = GetReplyCode(line);
                switch (code)
                {
                    case ResponseCodes.CODE_200:
                    case ResponseCodes.CODE_201:
                        Handshake();
                        break;

                    default:
                        throw new Exception(string.Format("Handshake init Error: {0}", MapCode(code)));
                }
            }
        }

        private void Handshake()
        {
            string hello = BuildHello();
            List<string> reply = SendRequest(hello);
            string code = GetReplyCode(reply, hello);
            switch (code)
            {
                case ResponseCodes.CODE_200:
                    break;

                default:
                    throw new Exception(string.Format("Handshake Error: {0}", MapCode(code)));
            }
        }

        public List<string> SendRequest(string request)
        {
            _writer.WriteLine(request);
            _writer.Flush();

            bool expectMultiLineReply = false;

            List<string> replyLines = new List<string>();
            while(true)
            {
                try
                {
                    string line = _reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        break;

                    if (!expectMultiLineReply)
                    {
                        string code = GetReplyCode(line);
                        Logger.LogTrace("CDDB Request: {0} -> Reply Code: {1}", request, MapCode(code));

                        expectMultiLineReply = (code == ResponseCodes.CODE_210 || code == ResponseCodes.CODE_211);
                    }

                    Logger.LogTrace("CDDB Reply line: {0}", line);
                    replyLines.Add(line);

                    if (!expectMultiLineReply || line.Equals(Commands.CMD_TERMINATOR))
                        break;
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    break;
                }
            }

            return replyLines;
        }

       

        private string GetReplyCode(List<string> reply, string request)
        {
            if (reply == null || reply.Count < 1)
                throw new Exception("Empty response for command: " + request);

            return GetReplyCode(reply[0]);
        }

        private string GetReplyCode(string line)
        {
            string code = line.Trim();

            //find first white space after start
            int index = code.IndexOf(' ');
            if (index != -1)
                code = code.Substring(0, index);
            else
            {
                return ResponseCodes.CODE_INVALID;
            }

            return code;
        }

        public void Dispose()
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
        }
    }
}
