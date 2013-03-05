using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPMedia.Runtime
{
    public delegate void ListChangedHandler<T>(T obj);

    public class ListWithEvents<T> : List<T>
    {
        object _lock = new object();

        public event ListChangedHandler<T> Adding = null;
        public event ListChangedHandler<T> Removing = null;

        public event ListChangedHandler<T> Added = null;
        public event ListChangedHandler<T> Removed = null;

        public event MethodInvoker Clearing = null;
        public event MethodInvoker Cleared = null;

        public new void Clear()
        {
            lock (_lock)
            {
                if (Clearing != null)
                    Clearing();

                base.Clear();

                if (Cleared != null)
                    Cleared();
            }
        }

        public new void Add(T obj)
        {
            lock (_lock)
            {
                if (Adding != null)
                    Adding(obj);

                base.Add(obj);

                if (Added != null)
                    Added(obj);
            }
        }

        public new void Remove(T obj)
        {
            lock (_lock)
            {
                if (Removing != null)
                    Removing(obj);

                base.Remove(obj);

                if (Removed != null)
                    Removed(obj);
            }
        }

        public ListWithEvents() : base()
        {
        }
    }
}
