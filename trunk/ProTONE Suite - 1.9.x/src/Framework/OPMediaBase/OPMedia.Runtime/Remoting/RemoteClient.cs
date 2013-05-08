using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.Remoting.Http;
using OPMedia.Runtime.Remoting.Tcp;

namespace OPMedia.Runtime.Remoting
{
    public abstract class RemoteClient
    {
        protected IChannel _channel = null;

        IRemoteObject _proxy = null;

        object _proxyLock = new object();
        string _serviceLocation = string.Empty;

        public static RemoteClient Create(bool useHttpChannel, string serviceLocation)
        {
            if (useHttpChannel)
                return new RemoteClientHttp(serviceLocation);
            else    
                return new RemoteClientTcp(serviceLocation);
        }

        public RemoteClient(string serviceLocation)
        {
            _serviceLocation = serviceLocation;
        }

        public void SendRequest(SerializableObject request)
        {
            try
            {
                CreateChannel();
                ChannelServices.RegisterChannel(_channel, Constants.SecureRemotingChannels);

                string errMsg;
                if (Connect(out errMsg))
                {
                    _proxy.SendRequest(request);
                    return;
                }

                string err = string.Format("Could not communicate with remote service at: {0}.\nError message is: {1}",
                    _serviceLocation, errMsg);

                throw new RemotingException(err);
            }
            finally
            {
                if (_channel != null)
                {
                    ChannelServices.UnregisterChannel(_channel);
                }
            }
        }

        public void RequestAsync(SerializableObject request)
        {
            try
            {
                CreateChannel();
                ChannelServices.RegisterChannel(_channel, Constants.SecureRemotingChannels);

                string errMsg;
                if (Connect(out errMsg))
                {
                    _proxy.SendRequest(request);
                    return;
                }

                string err = string.Format("Could not communicate with remote service at: {0}.\nError message is: {1}", 
                    _serviceLocation, errMsg);

                throw new RemotingException(err);
            }
            finally
            {
                if (_channel != null)
                {
                    ChannelServices.UnregisterChannel(_channel);
                }

            }
        }

        private bool Connect(out string err)
        {
            err = "The operation is succesfull.";

            lock (_proxyLock)
            {
                try
                {
                    if (_proxy == null)
                    {
                        _proxy = Activator.GetObject(typeof(IRemoteObject), _serviceLocation) as IRemoteObject;
                    }

                    // Check if alive ...
                    // If Activator.GetObject this would raise an exception.
                    _proxy.Ping();

                    return true;
                }
                catch(Exception ex)
                {
                    err = ex.Message;
                    return false;
                }
            }
        }

        protected abstract void CreateChannel();
    }
}
