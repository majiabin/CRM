using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Infrastucture;
using Microsoft.Practices.Unity;

namespace CarManager.Data
{
    public class RepositoryRgister : IDependencyRegister
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IDbContext, CarDbContext>();
           
        }
    }


}
