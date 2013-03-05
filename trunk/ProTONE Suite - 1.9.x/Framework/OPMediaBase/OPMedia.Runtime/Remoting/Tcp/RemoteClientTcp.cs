using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using OPMedia.Core;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.Remoting.Tcp
{
    public class RemoteClientTcp : RemoteClient
    {
        public RemoteClientTcp(string serviceLocation)
            : base(serviceLocation)
        {
        }

        protected override void CreateChannel()
        {
            BinaryClientFormatterSinkProvider provider = new BinaryClientFormatterSinkProvider();
            _channel = new TcpClientChannel("TcpClientChannel", provider);
        }
    }
}
