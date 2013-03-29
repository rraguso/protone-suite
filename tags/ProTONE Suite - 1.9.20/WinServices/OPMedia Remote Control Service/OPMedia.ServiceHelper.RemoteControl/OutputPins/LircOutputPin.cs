using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.Remoting;
using OPMedia.UI;
using System.Windows.Forms;
using OPMedia.UI.ProTONE;
using OPMedia.UI.Configuration;
using OPMedia.ServiceHelper.RCCService.Configuration;
using OPMedia.Core.Logging;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace OPMedia.ServiceHelper.RCCService.OutputPins
{
    public delegate void LircClientDataReceivedDG(LircClient sender, byte[] data);

    public class LircClient
    {
        private TcpClient _client;

        public event LircClientDataReceivedDG LircClientDataReceived = null;

        public bool Inactive { get; protected set; }

        public string RemoteEPAddress { get; protected set; }
        public string LocalEPAddress { get; protected set; }

        Thread _receiveThread = null;

        private object _sync = new object();

        List<byte> _byteList = new List<byte>();
       
        public void Close()
        {
            lock (_sync)
            {
                if (_client != null && _client.Connected)
                {
                    _client.Close();
                    _client = null;
                }
            }
        }

        public void SendMessage(string msg)
        {
            lock (_sync)
            {
                if (_client != null && _client.Connected)
                {
                    msg += "\n";
                    byte[] data = Encoding.Unicode.GetBytes(msg);
                    _client.Client.Send(data);
                }
            }
        }


        public LircClient(TcpClient client)
        {
            _client = client;

            Inactive = false;

            LocalEPAddress = _client.Client.LocalEndPoint.ToString();
            RemoteEPAddress = _client.Client.RemoteEndPoint.ToString();

            _receiveThread = new Thread(new ThreadStart(ReceiveLoop));
            _receiveThread.Priority = ThreadPriority.Normal;
            _receiveThread.Start();

            Logger.LogInfo("LircClient: Created receiver on remote address {0} ...", RemoteEPAddress);
        }

        private void ReceiveLoop()
        {
            Logger.LogInfo("LircClient: Starting receive loop from remote address {0} ...", RemoteEPAddress);

            try
            {
                if (_client != null && _client.Connected)
                {
                    while (true)
                    {
                        byte[] b = new byte[1];


                        int bytesRead = 0;
                        bytesRead = _client.Client.Receive(b, 1, SocketFlags.None);

                        if (bytesRead == 1)
                        {
                            _byteList.AddRange(b);

                            byte[] byteArray = _byteList.ToArray();
                            if (AnalyzeBuffer(byteArray))
                            {
                                if (LircClientDataReceived != null)
                                {
                                    LircClientDataReceived(this, byteArray);
                                }

                                _byteList.Clear();
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

//exit:
            Close();
            Inactive = true;
            Logger.LogInfo("LircClient: Ended receive loop from remote address {0} ...", RemoteEPAddress);
        }

        private bool AnalyzeBuffer(byte[] p)
        {
            string s = Encoding.Unicode.GetString(p);
            if (s.EndsWith("\r\n"))
            {
                Logger.LogInfo("LircClient: Received '{0}' from remote address {1} ...", s.Replace("\r\n", string.Empty), 
                    RemoteEPAddress);

                return true;
            }

            return false;
        }

    }

    public class LircOutputPin : OutputPin
    {
        const int DefaultLircPort = 8765;
        const int MaxClientsCount = 16;

        private int _port = DefaultLircPort;
        private IPAddress _ipAddress = IPAddress.None;
        
        private bool _isConfigured = false;
        private bool _started = false;

        private TcpListener _listener = null;
        private Thread _acceptThread = null;
        private ManualResetEvent _acceptThreadStopEvt = null;

        private List<LircClient> _clients = null;

        public static string ThisMachineName = Environment.MachineName.ToLowerInvariant();

        public override string TranslateToOutputPinFormat(string data, RCCServiceConfig.RemoteButtonsRow button)
        {
            // keyCode repeat command remoteName
            string output = string.Format("{0} {1} {2} {3}",
                data, 0, button.OutputData.Replace(" ", ""), button.RemoteName.Replace(" ", ""));

            return output;
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            LircCfgDlg dlg = new LircCfgDlg();

            if (!string.IsNullOrEmpty(initialCfgData))
            {
                dlg.Uri = initialCfgData;
            }
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.Uri;
            }

            return null;
        }

        public override bool IsConfigurable
        {
            get { return true; }
        }

        protected override void ConfigureInternal()
        {
            try
            {
                string[] uriParts = _cfgData.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                IPAddress[] hostAddresses = null;
                try
                {
                    hostAddresses = Dns.GetHostAddresses(ThisMachineName);
                }
                catch
                {
                }

                if (uriParts.Length > 1)
                {
                    // Both machine name and port are specified
                    // Machine name is quite superflous but anyway ...
                    
                    if (!int.TryParse(uriParts[1], out _port))
                    {
                        _port = DefaultLircPort;
                    }

                    string machineName = uriParts[0].ToLowerInvariant();
                    if (machineName == "." || machineName == "localhost" || machineName == "127.0.0.1")
                    {
                        _ipAddress = IPAddress.Loopback;
                        Logger.LogInfo("LircOutputPin: Binding to loopback address {0}:{1} ...", _ipAddress, _port);
                    }
                    else
                    {
                        _ipAddress = SelectAddress(hostAddresses, false);

                        if (machineName != ThisMachineName)
                        {
                            Logger.LogInfo("LircOutputPin: can only be started on local IP addresses. Binding to address {0}:{1} ...", _ipAddress, _port);
                        }
                        else
                        {
                            Logger.LogInfo("LircOutputPin: Binding to address {0}:{1} ...", _ipAddress, _port);
                        }
                    }
                }
                else if (uriParts.Length == 1)
                {
                    // Only port is specified
                    if (!int.TryParse(uriParts[0], out _port))
                    {
                        _port = DefaultLircPort;
                    }

                    _ipAddress = SelectAddress(hostAddresses, false);

                    Logger.LogInfo("LircOutputPin: Only port info is present in config data. Binding to address {0}:{1} ...", _ipAddress, _port);
                }
                else
                {
                    _port = DefaultLircPort;
                    _ipAddress = SelectAddress(hostAddresses, false);

                    Logger.LogInfo("LircOutputPin: No config data. Binding to address {0}:{1} ...", _ipAddress, _port);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
                _ipAddress = IPAddress.None;
            }

            _isConfigured = (_ipAddress != null && _ipAddress != IPAddress.None);
        }

        private IPAddress SelectAddress(IPAddress[] hostAddresses, bool isLoopback)
        {
            foreach (IPAddress addr in hostAddresses)
            {
                // Only select IPv4
                if (addr.AddressFamily != AddressFamily.InterNetwork)
                    continue;

                if (!isLoopback || (isLoopback && IPAddress.IsLoopback(addr)))
                {
                    return addr;
                }
            }

            return null;
        }

        protected override void StartInternal()
        {
            if (!_isConfigured)
                return;

            try
            {
                Logger.LogInfo("LircOutputPin: Starting on address {0}:{1} ...", _ipAddress, _port);

                _acceptThread = new Thread(new ThreadStart(AcceptLoop));
                _acceptThread.Priority = ThreadPriority.Normal;
                _acceptThread.Start();

                _acceptThreadStopEvt = new ManualResetEvent(false);
                
                _started = true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                _started = false;
            }
        }

        protected override void StopInternal()
        {
            if (_started)
            {
                _acceptThreadStopEvt.Set();

                if (!_acceptThread.Join(3000))
                {
                    Logger.LogInfo("LircOutputPin: Could not stop remotein a timely fashion on address {0}:{1} ...", _ipAddress, _port);
                    _acceptThread.Abort();
                }
                else
                {
                    Logger.LogInfo("LircOutputPin: Succesfully stopped on address {0}:{1} ...", _ipAddress, _port);
                }
            }
        }

        private void AcceptLoop()
        {
            try
            {
                _listener = new TcpListener(_ipAddress, _port);
                _listener.Start();

                _clients = new List<LircClient>();

                Logger.LogInfo("LircOutputPin: Succesfully started on address {0}:{1} ...", _ipAddress, _port);

                while (!_acceptThreadStopEvt.WaitOne(50))
                {
                    while (_listener.Pending() && !_acceptThreadStopEvt.WaitOne(50))
                    {
                        // There are some queued connection attempts
                        // Proceed with accept
                        TcpClient client = _listener.AcceptTcpClient();
                        if (_clients.Count >= MaxClientsCount - 1)
                        {
                            // Sorry ... no more clients allowed.

                            Logger.LogInfo("LircOutputPin: Server is full. Rejecting address {0} ...",
                                client.Client.RemoteEndPoint);

                            client.Close();
                        }
                        else
                        {
                            LircClient lircClient = new LircClient(client);
                            _clients.Add(lircClient);

                            Logger.LogInfo("LircOutputPin: New incoming connection from address {0} (Total active: {1})",
                                lircClient.RemoteEPAddress, _clients.Count);
                        }
                    }

                    foreach (LircClient client in _clients.ToArray())
                    {
                        if (client != null)
                        {
                            if (client.Inactive)
                            {
                                client.Close();
                                _clients.Remove(client);
                                
                                Logger.LogInfo("LircOutputPin: Connection from address {0} is no longer active, closing it (Total active: {1})",
                                    client.RemoteEPAddress, _clients.Count);

                            }
                        }
                        else
                        {
                            _clients.Remove(client);
                            Logger.LogWarning("LircOutputPin: Found null address in clients table. This usually indicates a problem, removing the garbage. (Total active: {0})", _clients.Count);
                        }
                    }
                  
                }

                Logger.LogInfo("LircOutputPin: Preparing to stop. Closing all connected clients.");

                // Thread is stopping. Disconnect all accepted clients.
                foreach (LircClient client in _clients)
                {
                    if (client != null)
                    {
                        Logger.LogInfo("LircOutputPin: Disconnecting from address {0} ...",
                                    client.RemoteEPAddress);

                        client.Close();
                    }
                }

            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        protected override void SendRequestInternal(SerializableObject request)
        {
            if (request is RemoteString)
            {
                // Send message to all connected clients

                string data = (request as RemoteString).Value;

                if (!_acceptThreadStopEvt.WaitOne(50))
                {
                    foreach(LircClient client in _clients)
                    {
                        if (_acceptThreadStopEvt.WaitOne(50))
                            break;

                        if (client != null && !client.Inactive)
                        {
                            Logger.LogInfo("LircOutputPin: Sending to address {0}, message: {1}",
                                client.RemoteEPAddress, (request as RemoteString));

                            client.SendMessage(data);
                        }
                    }
                }
            }
        }
    }
}
