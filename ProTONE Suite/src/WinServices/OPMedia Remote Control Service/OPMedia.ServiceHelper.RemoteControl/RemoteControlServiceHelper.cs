using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Runtime.ServiceHelpers;
using System.Diagnostics;

namespace OPMedia.ServiceHelper.RCCService
{
    public class RemoteControlServiceHelper : ServiceHelperBase
    {
        protected override void StartInternal()
        {
            RemoteControlServiceMux.Instance.Start();
        }

        protected override void StopInternal()
        {
            RemoteControlServiceMux.Instance.Stop();
        }
    }
}
