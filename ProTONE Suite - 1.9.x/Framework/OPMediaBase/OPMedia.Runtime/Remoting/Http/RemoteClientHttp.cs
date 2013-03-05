using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using OPMedia.Core;
using System.Collections;
using System.Security.Principal;

namespace OPMedia.Runtime.Remoting.Http
{
    public class RemoteClientHttp : RemoteClient
    {
        public RemoteClientHttp(string serviceLocation) 
            : base(serviceLocation)
        {
        }

        protected override void CreateChannel()
        {
            throw new NotImplementedException();
        }
    }
}
