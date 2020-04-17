using GSP.Shared.Utils.Initialization.Constants;
using Microsoft.Extensions.Configuration;

namespace GSP.Shared.Utils.Initialization
{
    public static class ConfigurationBuilder
    {
        public static IConfigurationRoot Create(
            string basePath, string settingFileName = InitializationConstants.SettingFileName)
        {
            IConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(settingFileName, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}