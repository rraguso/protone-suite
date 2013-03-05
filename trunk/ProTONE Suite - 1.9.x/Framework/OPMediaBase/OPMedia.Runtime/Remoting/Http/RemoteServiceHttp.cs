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

namespace OPMedia.Runtime.Remoting.Http
{
    public class RemoteServiceHttp : RemoteService
    {
        protected override void CreateChannel(int port)
        {
            throw new NotImplementedException();
        }
    }
}
