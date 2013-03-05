using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Core.GlobalEvents
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited=false)]
    public class EventSinkAttribute : Attribute
    {
        public List<string> EventNames { get; private set; }

        public EventSinkAttribute(params string[] eventNames)
        {
            if (eventNames != null)
            {
                if (!eventNames.Contains(EventDispatch.AllEvents))
                {
                    EventNames = new List<string>(eventNames);
                    return;
                }

                // The caller has explicitely specified to wait for all events.
                // In this case don't create the events list.
            }

            EventNames = null;
        }
    }
}
