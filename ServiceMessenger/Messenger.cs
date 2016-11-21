using StandardTools.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardTools.ServiceMessenger
{
    public class Messenger : IService
    {
       
        private List<ISubscriptions> Subscriptions { get; set; }

        public Messenger()
        {
            Subscriptions = new List<ISubscriptions>();
        }

        public void Subscribe<T>(Action<T> callback) where T:IMessage
        {
            //Add to the subscriber list
            Subscriptions.Add(new Subscription<T>()
            {
               Callback = callback
            });
        }

        public void Send<T>(T message) where T:IMessage
        {
            //Get all subscribers that match the message and payload type
            IEnumerable<ISubscriptions> subs = Subscriptions.Where(x => x.MessageType == typeof(T));

            foreach (ISubscriptions sub in subs)
                sub.InvokeMethod(message);

        }

        public void initService(IServiceLocator serviceLocator, params object[] args)
        {
        }
    }
}
