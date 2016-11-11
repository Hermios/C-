using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ServiceLocator
{
    public interface IServiceLocator
    {
        void add<T>() where T : IService;
        IService get<T>() where T : IService;
    }
}
