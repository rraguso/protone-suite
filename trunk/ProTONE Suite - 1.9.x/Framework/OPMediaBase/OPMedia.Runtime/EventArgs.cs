using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime
{
    public class EventArgs<T> : System.EventArgs
    {
        public T Data { get; private set; }

        public EventArgs(T data)
            : base()
        {
            this.Data = data;
        }
    }
}
