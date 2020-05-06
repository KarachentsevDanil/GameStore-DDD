using GSP.Gateway.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GSP.Gateway
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .AddGatewayConfigurationFiles()
                .UseStartup<Startup>();
    }
}