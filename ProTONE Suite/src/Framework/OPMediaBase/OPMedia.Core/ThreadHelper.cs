using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace OPMedia.Core
{
    public static class ThreadHelper
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

        public static void SleepEx(double delaySeconds)
        {
            if (delaySeconds > 0)
            {
                long delayTicks = TimeSpan.FromSeconds(delaySeconds).Ticks;

                Stopwatch sw = Stopwatch.StartNew();
                while (sw.ElapsedTicks < delayTicks)
                    Thread.Yield();

                sw.Stop();
            }
        }
    }
}
