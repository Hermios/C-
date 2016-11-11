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

        private ServiceLocator() 
        {
        
        }
        public static IServiceLocator getServiceLocator()
        {
            if (_serviceLocator == null)
                _serviceLocator = new ServiceLocator();
            return _serviceLocator;
        }
    }
}
