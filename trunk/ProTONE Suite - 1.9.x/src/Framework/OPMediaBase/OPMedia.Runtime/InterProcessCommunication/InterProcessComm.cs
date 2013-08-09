using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.InterProcessCommunication
{
    [ServiceContract]
    public interface IRemoteControl
    {
        [OperationContract]
        string SendRequest(string request);
    }

    public delegate string OnSendRequestHandler(string request);

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class RemoteControlImpl : IRemoteControl
    {
        public event OnSendRequestHandler OnSendRequest = null;

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.AfterCall)]
        public string SendRequest(string request)
        {
            if (OnSendRequest != null)
            {
                return OnSendRequest(request);
            }

            return null;
        }
    }

    public class IPCRemoteControlProxy : IDisposable, IRemoteControl
    {
        static IRemoteControl _proxy = null;
        string _appName;

        public IPCRemoteControlProxy(string appName)
        {
            _appName = appName;
            Open();
        }

        protected virtual void Open()
        {
            string uri = string.Format("net.pipe://localhost/{0}/RemoteControl.svc", _appName);

            var myBinding = new NetNamedPipeBinding();
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

        public static string SendRequest(string appName, string request)
        {
            try
            {
                using (IPCRemoteControlProxy rcp = new IPCRemoteControlProxy(appName))
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

    public class IPCRemoteControlHost : IDisposable
    {
        public event OnSendRequestHandler OnSendRequest = null;

        ServiceHost _host = null;
        RemoteControlImpl _remoteControl = null;

        string _appName;

        public IPCRemoteControlHost(string appName)
        {
            _appName = appName;
            StartInternal();
        }

        public void StartInternal()
        {
            string uri = string.Format("net.pipe://localhost/{0}/RemoteControl.svc", _appName);

            NetNamedPipeBinding binding = new NetNamedPipeBinding();

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

        public void Dispose()
        {
            StopInternal();
        }
    }
}
