using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace OPMedia.Runtime.Processors
{
    public abstract class QueueRequest
    {
        public QueueRequest()
        {
        }

        internal void Process()
        {
            ProcessInternal();
        }

        protected abstract void ProcessInternal();
    }

    public class QueuedProcessor : Processor
    {
        private ConcurrentQueue<QueueRequest> requestQueue = new ConcurrentQueue<QueueRequest>();

        public void EnqueueRequest(QueueRequest req)
        {
            requestQueue.Enqueue(req);
        }

        public QueuedProcessor() : base()
        {
        }

        protected sealed override bool ProcessInternal()
        {
            QueueRequest req = null;
            if (requestQueue.TryDequeue(out req) && req != null)
            {
                req.Process();
            }

            return true;
        }

        protected override bool CanStart()
        {
            return (requestQueue != null);
        }

        protected override void OnStarted()
        {
        }

        protected override bool CanStop()
        {
            return (requestQueue.Count != 0);
        }

        protected override void OnStopped()
        {
        }
    }
}
