using System;
using System.Collections.Generic;
using System.Text;

namespace OPMedia.Runtime.ServiceHelpers
{
    public enum ServiceCommand
    {
        None = 128,
        
        QueryStatus,
        Reconfigure,
    }

    public abstract class ServiceHelperBase
    {
        public ServiceHelperBase()
        {
        }

        public void Start()
        {
            StartInternal();
        }

        public void Stop()
        {
            StopInternal();
        }

        protected abstract void StartInternal();
        protected abstract void StopInternal();
    }
}
