using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    sealed class DependencyInjectionConfig
    {
        private static DependencyInjectionConfig _instance;
        private static readonly object _lock = new object();

        public static DependencyInjectionConfig Instance()
        {
            if (_instance == null)
            {
                lock (_lock) 
                {
                    if (_instance == null) 
                    {
                        _instance = new DependencyInjectionConfig();
                    }
                }
            }

            return _instance;
        }

        public void ConfigurateServices()
    }
}
