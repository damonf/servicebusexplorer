
using System.Reflection;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public class AppSettings : AppSettingsBase, IAppSettings
    {
        public string ServiceBusConnectionString =>
            GetSetting("Microsoft.ServiceBus.ConnectionString");

        public int AutoRefreshIntervalMs => GetSetting<int>(MethodBase.GetCurrentMethod().Name);
        public string AppPath => GetSetting(MethodBase.GetCurrentMethod().Name);
    }
}
