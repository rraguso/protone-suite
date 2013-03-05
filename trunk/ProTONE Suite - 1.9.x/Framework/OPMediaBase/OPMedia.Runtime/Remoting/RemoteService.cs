using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using OPMedia.Core;
using OPMedia.Core.Logging;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Http;
using OPMedia.Runtime.Remoting.Http;
using OPMedia.Runtime.Remoting.Tcp;

namespace OPMedia.Runtime.Remoting
{
    public abstract class RemoteService
    {
        protected IChannel _channel = null;

        public static RemoteService Create(bool useHttpChannel)
        {
            if (useHttpChannel)
                return new RemoteServiceHttp();
            else
                return new RemoteServiceTcp();
        }

        public void Start(string uri, int port)
        {
            CreateChannel(port);

            WellKnownServiceTypeEntry _wellKnownServiceType =
                new WellKnownServiceTypeEntry(typeof(RemoteObject), uri, WellKnownObjectMode.SingleCall);
            RemotingConfiguration.RegisterWellKnownServiceType(_wellKnownServiceType);

            Logger.LogInfo("Well known type {0} was registered succesfully on channel {1} ...",
                _wellKnownServiceType.ObjectUri, _channel.ChannelName);
        }

        public void Stop()
        {
            if (_channel != null)
            {
                // No need to unregister ... Stop is usually called at process exit.

                //ChannelServices.UnregisterChannel(_channel);

                //Logger.LogInfo("Channel {0} was unregistered succesfully ...",
                  //  _channel.ChannelName);

                //_channel = null;
            }
        }

        protected abstract void CreateChannel(int port);
    }
}
