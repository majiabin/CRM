using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CarManager.Core.Infrastucture
{
    public class ServiceContainer
    {
        static Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>();
        public static IUnityContainer Current
        {
            get { return Container.Value; }
        }

        public static T Resolve<T>() where T : class
        {
            return Container.Value.Resolve<T>();
        }

        public static IEnumerable<T> ResolevAll<T>() where T : class
        {
            return Container.Value.ResolveAll<T>();
        }
    }
}
