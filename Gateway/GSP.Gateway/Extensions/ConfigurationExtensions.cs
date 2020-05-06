using GSP.Gateway.Configurations;
using Microsoft.Extensions.Configuration;

namespace GSP.Gateway.Extensions
{
    public static class ConfigurationExtensions
    {
        public static OcelotConfiguration GetOcelotConfiguration(this IConfiguration configuration)
        {
            var ocelotConfiguration = new OcelotConfiguration();
            configuration.Bind(nameof(OcelotConfiguration), ocelotConfiguration);
            return ocelotConfiguration;
        }
    }
}