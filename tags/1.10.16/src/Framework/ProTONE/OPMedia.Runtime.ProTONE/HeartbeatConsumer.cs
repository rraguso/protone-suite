using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OPMedia.Core.Logging;

namespace OPMedia.Runtime.ProTONE
{
    public abstract class HeartbeatConsumer
    {
        ManualResetEvent _isStopRequested = new ManualResetEvent(false);

        string _instanceName = string.Empty;

        System.Timers.Timer _timer = null;

        protected void StopAndDisconnect()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;

            _isStopRequested.Set();
        }

        protected HeartbeatConsumer(string instanceName)
        {
            _instanceName = instanceName;

            _isStopRequested.Reset();

            _timer = new System.Timers.Timer();
            _timer.AutoReset = true;
            _timer.Interval = 1000;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();

            Logger.LogHeavyTrace("Creating a new instance for task: " + _instanceName);

            try
            {
                if (_isStopRequested.WaitOne(10, true))
                {
                    Logger.LogHeavyTrace("Application is stopping. Not creating a new instance for task: " + _instanceName);
                }
                else
                {
                    RunTask();
                }
            }
            finally
            {
                _timer.Start();
            }
        }

        private void RunTask()
        {
            try
            {
                if (InitTask())
                {
                    ExecuteTask();
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
            finally
            {
                CleanupTask();
            }
        }

        protected abstract bool InitTask(); 
        protected abstract void CleanupTask();
        protected abstract void ExecuteTask();
    }
}
