using System;

namespace StandardTools.ServiceMessenger
{
    public interface ISubscriptions
    {
        Type MessageType { get; }
        
        void InvokeMethod(IMessage args);
    }
}
