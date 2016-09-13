using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Cache;
using CarManager.Core.Infrastucture;
using Microsoft.Practices.Unity;

namespace CarManager.Service
{
    public class InfrastructureRegister : IDependencyRegister
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<ICacheManager, RedisCacheManager>();
            //container.RegisterType<ILogger, NullLogger>();
        }
    }
}
