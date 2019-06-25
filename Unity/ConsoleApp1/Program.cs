using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Microsoft.Practices.Unity;

namespace UnityDemo
{
    class Program
    {
        private static IUnityContainer container = null;
        static void Main(string[] args)
        {
            RegisterContainer();
            var programmer = container.Resolve<IProgrammer>("CSharp");
            //var programmer = container.Resolve<IProgrammer>("VB");
            programmer.Working();
            Console.ReadKey();
        }
        private static void RegisterContainer()
         {
             container = new UnityContainer();
            UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
             config.Configure(container, "Programmer");
         }
}
}
