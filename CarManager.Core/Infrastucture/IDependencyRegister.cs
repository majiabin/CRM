using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CarManager.Core.Infrastucture
{
    public interface IDependencyRegister
    {
        void RegisterType(IUnityContainer container);
        
    }
}
