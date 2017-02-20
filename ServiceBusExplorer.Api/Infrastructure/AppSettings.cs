
namespace ServiceBusExplorer.Api.Infrastructure
{
    public class AppSettings : AppSettingsBase, IAppSettings
    {
        //public string ServiceBusConnectionString =>
        //    GetSetting(MethodBase.GetCurrentMethod().Name);

        public string ServiceBusConnectionString =>
            GetSetting("Microsoft.ServiceBus.ConnectionString");
    }
}
