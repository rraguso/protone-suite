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
		private string m_ProtocolLevel = "6"; // default to level 6 support

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
			public const string CMD_SITES	= "sites";
			public const string CMD_PROTO	= "proto";
			public const string CMD_CATEGORIES	= "cddb lscat";
			public const string CMD_TERMINATOR	= "."; 
		}
		#endregion

		#region Constants for Freedb ResponseCodes
		public class ResponseCodes
		{
			public const string CODE_210 = "210"; // Okay // or in a query multiple exact matches
			public const string CODE_401 = "401"; // sites: no site information available
			public const string CODE_402 = "402"; // Server Error
			
			public const string CODE_500 = "500"; // Invalid command, invalid parameters, etc.
			
            //query codes
            public const string CODE_200 = "200"; // Exact match 
            public const string CODE_201 = "201"; // Partial match 

			public const string CODE_211 = "211"; // InExact matches found - list follows
			public const string CODE_202 = "202"; // No match 
			public const string CODE_403 = "403"; // Database entry is corrupt
			public const string CODE_409 = "409"; // No Handshake

			// our own code
			public const string CODE_INVALID = "-1"; // Invalid code 
		}
		#endregion

		
		/// <summary>
		/// Read Entry from the database. 
		/// </summary>
		/// <param name="qr">A QueryResult object that is created by performing a query</param>
		/// <param name="cdEntry">out parameter - CDEntry object</param>
		/// <returns></returns>
		public string Read(QueryResult qr, out CDEntry cdEntry)
		{
            cdEntry = null;
            return "";
            /*
			Debug.Assert(qr != null);
			cdEntry = null;
			
			StringCollection coll = null;
			StringBuilder builder = new StringBuilder(FreedbHelper.Commands.CMD_READ);
			builder.Append("+");
			builder.Append(qr.Category);
			builder.Append("+");
			builder.Append(qr.Discid);

			//make call
			try
			{
				//coll = Call(builder.ToString());
			}
			
			catch (Exception ex)
			{
				string msg = "Error performing cddb read.";
				Exception newex = new Exception(msg,ex);
				throw newex ;
			}

			// check if results came back
			if (coll.Count < 0)
			{
				string msg = "No results returned from cddb read.";
				Exception ex = new Exception(msg,null);
				throw ex;
			}


			string code = GetCode(coll[0]);
			if (code == ResponseCodes.CODE_INVALID)
			{
				string msg = "Unable to process results for cddb read. Returned Data: " + coll[0];
				Exception ex = new Exception(msg,null);
				throw ex;
			}


			switch (code)
			{
				case ResponseCodes.CODE_500:
					return ResponseCodes.CODE_500;

				case ResponseCodes.CODE_401: // entry not found
				case ResponseCodes.CODE_402: // server error
				case ResponseCodes.CODE_403: // Database entry is corrupt
				case ResponseCodes.CODE_409: // No handshake
					return code;

				case ResponseCodes.CODE_210: // good 
				{
					coll.RemoveAt(0); // remove the 210
					cdEntry = new CDEntry(coll);
					return ResponseCodes.CODE_210;
				}
				default:
					return ResponseCodes.CODE_500;
			}*/
		}


		/// <summary>
		/// Query the freedb server to see if there is information on this cd
		/// </summary>
		/// <param name="querystring"></param>
		/// <param name="queryResult"></param>
		/// <param name="queryResultsColl"></param>
		/// <returns></returns>
		public string Query(string querystring, out QueryResult queryResult, out QueryResultCollection queryResultsColl)
		{
            StringBuilder builder = new StringBuilder(FreedbHelper.Commands.CMD_QUERY);
            builder.Append(" ");
            builder.Append(querystring);

            queryResult = null;
            queryResultsColl = null;
           
			//make call
			try
			{
                List<string> reply = SendRequest(builder.ToString());
				//coll = Call(builder.ToString());
			}
			catch (Exception ex)
			{
				string msg = "Unable to perform cddb query.";
				Exception newex = new Exception(msg,ex);
				throw newex ;
			}

			/*
			// check if results came back
			if (coll.Count < 0)
			{
				string msg = "No results returned from cddb query.";
				Exception ex = new Exception(msg,null);
				throw ex;
			}

			string code = GetCode(coll[0]);
			if (code == ResponseCodes.CODE_INVALID)
			{
				string msg = "Unable to process results returned for query: Data returned: " + coll[0];
				Exception ex = new Exception (msg,null);
				throw ex;
			}


			switch (code)
			{
				case ResponseCodes.CODE_500:
					return ResponseCodes.CODE_500;
			
				// Multiple results were returned
				// Put them into a queryResultCollection object
				case ResponseCodes.CODE_211:
				case ResponseCodes.CODE_210:
				{
					queryResultsColl = new QueryResultCollection();
					//remove the 210 or 211
					coll.RemoveAt(0);
					foreach (string line in coll)
					{
						QueryResult result = new QueryResult(line,true);
						queryResultsColl.Add(result);
					}
				
					return ResponseCodes.CODE_211;
				}
			
			
				// exact match 
				case ResponseCodes.CODE_200:
				{
					queryResult = new QueryResult(coll[0]);
					return ResponseCodes.CODE_200;
				}
			

				//not found
				case ResponseCodes.CODE_202:
					return ResponseCodes.CODE_202;

				//Database entry is corrupt
				case ResponseCodes.CODE_403:
					return ResponseCodes.CODE_403;

					//no handshake
				case ResponseCodes.CODE_409:
					return ResponseCodes.CODE_409;
					
				default:
					return ResponseCodes.CODE_500;
			
			} // end of switch

            */

            return "";
		}

        /*
		/// <summary>
		/// Retrieve the categories
		/// </summary>
		/// <param name="strings"></param>
		/// <returns></returns>
		public string GetCategories(out StringCollection strings)
		{

			StringCollection coll;
			strings = null;

			try
			{
				coll = Call(FreedbHelper.Commands.CMD_CATEGORIES);
			}
			
			catch (Exception ex)
			{
				string msg = "Unable to retrieve Categories.";
				Exception newex = new Exception(msg,ex);
				throw newex;
			}
			
			// check if results came back
			if (coll.Count < 0)
			{
				string msg = "No results returned from categories request.";
				Exception ex = new Exception(msg,null);
				throw ex;
			}

			string code = GetCode(coll[0]);
			if (code == ResponseCodes.CODE_INVALID)
			{
				string msg = "Unable to retrieve Categories. Data Returned: " + coll[0];
				Exception ex = new Exception(msg,null);
				throw ex;
			}

			switch (code)
			{
				case ResponseCodes.CODE_500:
					return ResponseCodes.CODE_500;

				case ResponseCodes.CODE_210:
				{
					strings = coll;
					coll.RemoveAt(0);
					return ResponseCodes.CODE_210;
				}

				default:
				{
					string msg = "Unknown code returned from GetCategories: " + coll[0];
					Exception ex = new Exception(msg,null);
					throw ex;
				}
					
					
			}

		}

        
		/// <summary>
		/// Call the Freedb server using the specified command and the current site
		/// If the current site is null use the default server
		/// </summary>
		/// <param name="command">The command to be exectued</param>
		/// <returns>StringCollection</returns>
		private StringCollection Call(string command)
		{
			if (m_CurrentSite != null)
				return Call(command,m_CurrentSite.GetUrl());
			else
				return Call(command,m_mainSite.GetUrl());
		}

		/// <summary>
		/// Call the Freedb server using the specified command and the specified url
		/// The command should not include the cmd= and hello and proto parameters.
		/// They will be added automatically
		/// </summary>
		/// <param name="command">The command to be exectued</param>
		/// <param name="url">The Freedb server to use</param>
		/// <returns>StringCollection</returns>
		private StringCollection Call(string commandIn, string url)
		{
            //commandIn = "cddb+read+newage+9b0b310c";

			StreamReader reader = null;
			HttpWebResponse response = null;
			StringCollection coll = new StringCollection();
			
			try
			{


				//create our HttpWebRequest which we use to call the freedb server
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Proxy = AppSettings.GetWebProxy();
				req.ContentType = "text/plain";
				// we are using th POST method of calling the http server. We could have also used the GET method
				req.Method="POST";
				//add the hello and proto commands to the request
				string command = BuildCommand(Commands.CMD + commandIn);
				//using Unicode
				byte[] byteArray = Encoding.UTF8.GetBytes(command);
				//get our request stream
				Stream newStream= req.GetRequestStream();
				//write our command data to it
				newStream.Write(byteArray,0,byteArray.Length);
				newStream.Close();
				//Make the call. Note this is a synchronous call
				response = (HttpWebResponse) req.GetResponse();
				//put the results into a StreamReader
				reader = new StreamReader(response.GetResponseStream(),System.Text.Encoding.UTF8);
				// add each line to the StringCollection until we get the terminator
				string line;
				while ((line = reader.ReadLine()) != null) 
				{
					if (line.StartsWith(Commands.CMD_TERMINATOR))
						break;
					else
						coll.Add(line);
				}
			}
			
			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				if (response != null)
					response.Close();
				if (reader != null)
					reader.Close();
			}
			
			return coll;
		}
        */

        ///// <summary>
        ///// Given a specific command add on the hello and proto which are requied for an http call
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //private string BuildCommand(string command)
        //{
        //    StringBuilder builder = new StringBuilder(command);
        //    builder.Append("&");
        //    builder.Append(Hello());
        //    builder.Append("&");
        //    builder.Append(Proto());
        //    return builder.ToString();
        //}

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

        ///// <summary>
        ///// Build the Proto part of the command
        ///// </summary>
        ///// <returns></returns>
        //public string Proto()
        //{
        //    StringBuilder builder = new StringBuilder(Commands.CMD_PROTO);
        //    builder.Append("=");
        //    builder.Append(m_ProtocolLevel );
        //    return builder.ToString();
        //}

        public FreedbHelper(string server, int port)
        {
            m_UserName = Constants.AnonymousUser;
            m_Hostname = Dns.GetHostName();
            m_ClientName = Constants.PlayerUserAgent.Replace(" ", ""); // eat up spaces, FreeDb does not like them.
            m_Version = SuiteVersion.Version;
            m_ProtocolLevel = "6"; // default it

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

            List<string> replyLines = new List<string>();
            while(true)
            {
                try
                {
                    string line = _reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        break;

                    replyLines.Add(line);
                    if (line.EndsWith("."))
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

        private string MapCode(string code)
        {
            return code;
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
            //if (_tcpClient != null)
            //{
            //    _tcpClient.Close();
            //    _tcpClient = null;
            //}
        }
    }
}
