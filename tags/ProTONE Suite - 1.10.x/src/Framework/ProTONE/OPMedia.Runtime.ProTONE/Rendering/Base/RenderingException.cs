using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OPMedia.Runtime.ProTONE.Rendering.Base
{
    public class RenderingException : Exception
    {
        public static RenderingException FromException(Exception ex)
        {
            if (ex is RenderingException)
            {
                return ex as RenderingException;
            }

            return new RenderingException(ex.Message, ex.InnerException);
        }

        public RenderingException()
            : base()
        {
        }

        public RenderingException(String message)
            : base(message)
        {
        }

        public RenderingException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RenderingException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }

    }

    public class RenderingExceptionEventArgs : HandledEventArgs
    {
        public RenderingException RenderingException { get; protected set; }

        public RenderingExceptionEventArgs(RenderingException ex)
        {
            RenderingException = ex;
        }
    }
}
