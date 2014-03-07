using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OPMedia.Runtime.Processors
{
    public abstract class Processor : IDisposable
    {
        private Thread _processorThread = null;

        public bool IsStarted
        {
            get
            {
                return (_processorThread != null &&
                    (_processorThread.ThreadState == ThreadState.Running ||
                     _processorThread.ThreadState == ThreadState.WaitSleepJoin));
            }
        }

        public void Start()
        {
            if (_processorThread == null && CanStart())
            {
                if (CanStart())
                {
                    _processorThread = new Thread(new ThreadStart(ProcessorThreadLoop));
                    _processorThread.Start();

                    OnStarted();
                }
            }
        }

        protected abstract bool CanStart();
        protected abstract void OnStarted();

        public void Stop()
        {
            if (IsStarted)
            {
                if (CanStop())
                {
                    _processorThread.Abort();
                    OnStopped();
                }
            }
        }

        protected abstract bool CanStop();
        protected abstract void OnStopped();

        public Processor()
        {
        }


        private void ProcessorThreadLoop()
        {
            while (true)
            {
                if (!ProcessInternal())
                    break;

                Thread.Sleep(100);
            }
        }

        protected abstract bool ProcessInternal();

        #region IDisposable Members

        public void Dispose()
        {
            Stop();
        }

        #endregion
    }
}
