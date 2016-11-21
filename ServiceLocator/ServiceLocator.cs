using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator _serviceLocator;
        private Dictionary<Type,IService> services;
        private ServiceLocator()
        {
            services = new Dictionary<Type, IService>();
        }
        public static IServiceLocator getServiceLocator()
        {
            if (_serviceLocator == null)
                _serviceLocator = new ServiceLocator();
            return _serviceLocator;
        }

        public void add<T>(params object[] args) where T : IService
        {
            if (!services.ContainsKey(typeof(T)))
            {
                T service = (T)Activator.CreateInstance(typeof(T));
                service.initService(this,args);
                services.Add(typeof(T), service);
                
            }
        }

        public T get<T>() where T : IService
        {
            return (T)services[typeof(T)];
        }
    }
}
