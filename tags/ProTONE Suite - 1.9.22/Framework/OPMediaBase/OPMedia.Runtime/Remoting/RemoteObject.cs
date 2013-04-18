using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core;

namespace OPMedia.Runtime.Remoting
{
    public interface IRemoteObject
    {
        void Ping();
        void SendRequest(SerializableObject request);
    }

    [Serializable]
    public class RemoteObject : MarshalByRefObject, IRemoteObject
    {
        public const string EventName = "RemoteRequest";

        public void Ping() 
        { 
        }

        public void SendRequest(SerializableObject request)
        {
            EventDispatch.DispatchEvent(RemoteObject.EventName, request);
        }
    }

    [Serializable]
    public class SerializableObject
    {
    }

    [Serializable]
    public class RemoteString : SerializableObject
    {
        public static RemoteString Empty = new RemoteString(string.Empty);

        public string Value = string.Empty;

        public override bool Equals(object obj)
        {
            RemoteString str = obj as RemoteString;
            return (str != null && str.Value == this.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public RemoteString(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return "<null>";
            }
            else if (Value == string.Empty)
            {
                return "<Empty>";
            }
            else
                return Value;
        }
    }
}
