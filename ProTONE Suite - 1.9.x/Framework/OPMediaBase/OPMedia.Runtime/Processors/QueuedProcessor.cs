using System;
using System.Collections.Generic;
using System.Text;

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
        private Queue<QueueRequest> requestQueue = new Queue<QueueRequest>();

        public void EnqueueRequest(QueueRequest req)
        {
            lock (requestQueue)
            {
                requestQueue.Enqueue(req);
            }
        }

        public QueuedProcessor() : base()
        {
        }

        protected sealed override bool ProcessInternal()
        {
            if (requestQueue.Count > 0)
            {
                lock (requestQueue)
                {
                    QueueRequest req = requestQueue.Dequeue();
                    if (req != null)
                    {
                        req.Process();
                    }
                }
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
