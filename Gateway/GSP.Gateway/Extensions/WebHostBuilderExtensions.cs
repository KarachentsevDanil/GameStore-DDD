using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GSP.Gateway.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddGatewayConfigurationFiles(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile(
                        $"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json",
                        optional: true,
                        reloadOnChange: true)
                    .AddJsonFile("ocelot-configuration.json")
                    .AddEnvironmentVariables();
            });
        }
    }
}