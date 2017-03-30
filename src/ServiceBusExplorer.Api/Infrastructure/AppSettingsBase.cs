using System;
using System.Configuration;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public abstract class AppSettingsBase
    {
        protected static string GetSetting(string name) => GetSetting<string>(name);

        protected static T GetSetting<T>(string name)
        {
            var setting = ConfigurationManager.AppSettings.Get(name.Replace("get_", ""));

            if (setting == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}
