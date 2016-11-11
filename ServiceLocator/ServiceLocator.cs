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

        }
        public static IServiceLocator getServiceLocator()
        {
            if (_serviceLocator == null)
                _serviceLocator = new ServiceLocator();
            return _serviceLocator;
        }

        public void add<T>() where T : IService
        {
            if (!services.ContainsKey(typeof(T)))
                services.Add(typeof(T), (T)Activator.CreateInstance(typeof(T)));
        }

        public IService get<T>() where T : IService
        {
            return (IService)services[typeof(T)];
        }
    }
}
