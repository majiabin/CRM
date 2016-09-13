using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Config
{
    public class RedisCacheElement : ConfigurationElement
    {
        private const string EnablePropertyName = "enable";
        private const string ConnectionStringPropery = "connectionString";

        [ConfigurationProperty(EnablePropertyName, IsRequired = true)]
        public bool Enable
        {
            get { return (bool)base[EnablePropertyName]; }
            set { base[EnablePropertyName] = value; }

        }

        [ConfigurationProperty(EnablePropertyName, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)base[ConnectionStringPropery]; }
            set { base[ConnectionStringPropery] = value; }
        }
    }
}
