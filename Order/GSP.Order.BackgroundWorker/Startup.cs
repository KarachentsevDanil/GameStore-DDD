using GSP.Order.BackgroundWorker.Extensions;
using GSP.Order.Data.Context;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.BackgroundWorker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseApiExceptionHandler();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.ConfigureDatabase<OrderDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.RegisterAzureServiceBus(Configuration);

            services.RegisterBackgroundWorkerDependencies();
        }
    }
}