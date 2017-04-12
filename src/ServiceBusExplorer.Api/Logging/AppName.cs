using System;
using System.Linq;
using System.Reflection;

namespace ServiceBusExplorer.Api.Logging
{
    public class AppName
    {
        public AppName(Assembly assembly)
        {
            Name = GetAppName(assembly);
            Version = assembly.GetName().Version;
        }

        public string Name { get; }
        public Version Version { get; }

        private static string GetAppName(Assembly assembly)
        {
            var attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute));
            var assemblyTitleAttribute = attributes.SingleOrDefault() as AssemblyTitleAttribute;
            return assemblyTitleAttribute?.Title;
        }
    }
}
