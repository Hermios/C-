using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ServiceMessenger
{
    public class Subscription<T> : ISubscriptions where T : IMessage
    {
        public Type MessageType { get { return typeof(T); } }
        
        public Action<T> Callback { get; set; }

        void ISubscriptions.InvokeMethod(IMessage args)
        {
            Callback.Invoke((T)args);
        }
    }

}
