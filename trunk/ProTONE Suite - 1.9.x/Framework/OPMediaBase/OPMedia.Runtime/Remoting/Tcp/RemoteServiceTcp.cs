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

namespace OPMedia.Runtime.Remoting.Tcp
{
    public class RemoteServiceTcp : RemoteService
    {
        protected override void CreateChannel(int port)
        {
            string chanName = "TcpServerChannel@" + port;

            _channel = ChannelServices.GetChannel(chanName);
            if (_channel == null)
            {
                BinaryServerFormatterSinkProvider sinkProvider =
                    new BinaryServerFormatterSinkProvider();
                sinkProvider.TypeFilterLevel = TypeFilterLevel.Full;

                _channel = new TcpServerChannel(chanName, port, sinkProvider);

                ChannelServices.RegisterChannel(_channel, Constants.SecureRemotingChannels);
            }
        }
    }
}
