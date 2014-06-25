using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OPMedia.Runtime.ProTONE.Rendering
{
    public static class ThreadScheduler
    {
        public static void RunAsThread(WaitCallback c, object state = null)
        {
            if (c != null)
            {
                Thread t = new Thread((s) =>
                {
                    c.Invoke(state);
                });
                t.Priority = ThreadPriority.Normal;
                t.Start();
            };
        }
    }
}
