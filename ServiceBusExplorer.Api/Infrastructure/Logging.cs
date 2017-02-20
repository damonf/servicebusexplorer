using Serilog;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public static class Logging
    {
        public static void Initialize(AppName appName)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            Log.Information("{App} {Version} Started", appName.Name, appName.Version);
        }

        public static void CloseAndFlush(AppName appName)
        {
            Log.Information("{App} {Version} Stopped", appName.Name, appName.Version);
            Log.CloseAndFlush();
        }
    }
}
