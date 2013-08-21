using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OPMedia.Core.Logging;
using OPMedia.Runtime.InterProcessCommunication;

namespace OPMedia.Runtime.ProTONE.RemoteControl
{
    public class RemoteControlProxy : IDisposable, IRemoteControl
    {
        static IRemoteControl _proxy = null;
        string _server, _appName;
        int _port = 8080;

        public RemoteControlProxy(string server, string appName, int port = 8080)
        {
            _server = server;
            _appName = appName;
            _port = port;

            Open();
        }

        protected virtual void Open()
        {
            string uri = string.Format("http://{0}:{1}/{2}/RemoteControl.svc", _server, _port, _appName);

            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(uri);
            var myChannelFactory = new ChannelFactory<IRemoteControl>(myBinding, myEndpoint);
            _proxy = myChannelFactory.CreateChannel();
        }

        protected void Abort()
        {
            ((ICommunicationObject)_proxy).Abort();
        }

        public void Dispose()
        {
            ((ICommunicationObject)_proxy).Close();
            _proxy = null;
        }

        string IRemoteControl.SendRequest(string request)
        {
            try
            {
                return _proxy.SendRequest(request);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                Abort();
                Open();
            }

            return null;
        }

        public static string SendRequest(string request, string server, string appName, int port = 8080)
        {
            try
            {
                using (RemoteControlProxy rcp = new RemoteControlProxy(server, appName, port))
                {
                    return (rcp as IRemoteControl).SendRequest(request);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return null;
        }
    }

    public class RemoteControlHost
    {
        public event OnSendRequestHandler OnSendRequest = null;

        ServiceHost _host = null;
        RemoteControlImpl _remoteControl = null;

        string _appName;
        int _port = 8080;

        public RemoteControlHost(string appName, int port = 8080)
        {
            _appName = appName;
            _port = port;
        }

        public void StartInternal()
        {
            string uri = string.Format("http://{0}:{1}/{2}/RemoteControl.svc", Environment.MachineName, _port, _appName);

            BasicHttpBinding binding = new BasicHttpBinding();

            _remoteControl = new RemoteControlImpl();
            _remoteControl.OnSendRequest += new OnSendRequestHandler(_remoteControl_OnSendRequest);

            _host = new ServiceHost(_remoteControl);
            _host.AddServiceEndpoint(typeof(IRemoteControl), binding, uri);

            _host.Open();
        }

        public void StopInternal()
        {
            _host.Close();
            _host = null;

            _remoteControl.OnSendRequest -= new OnSendRequestHandler(_remoteControl_OnSendRequest);
            _remoteControl = null;
        }

        string _remoteControl_OnSendRequest(string request)
        {
            if (OnSendRequest != null)
            {
                return OnSendRequest(request);
            }

            return null;
        }
    }
}
