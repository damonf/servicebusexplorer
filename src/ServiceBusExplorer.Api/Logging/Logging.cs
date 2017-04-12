using System.Reflection;
using Serilog;

namespace ServiceBusExplorer.Api.Logging
{
    public static class Logger
    {
        public static void Initialize(Assembly assembly)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            var appName = new AppName(assembly);
            Log.Information("{App} {Version} Started", appName.Name, appName.Version);
        }

        public static void CloseAndFlush(Assembly assembly)
        {
            var appName = new AppName(assembly);
            Log.Information("{App} {Version} Stopped", appName.Name, appName.Version);
            Log.CloseAndFlush();
        }
    }
}
