using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ServiceLocator
{
    public interface IService
    {
        void initService(IServiceLocator serviceLocator,params object[]  args);
    }
}
