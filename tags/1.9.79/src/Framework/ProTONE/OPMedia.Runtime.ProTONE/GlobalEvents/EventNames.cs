using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime.ProTONE.GlobalEvents
{
    public class EventNames : OPMedia.Core.EventNames
    {
        public const string MediaRendererException = "MediaRendererException";
        public const string MediaStateChanged = "MediaStateChanged";
        public const string MediaRendererHeartbeat = "MediaRendererHeartbeat";
        public const string MediaRendererClock = "MediaRendererClock";
    }
}
