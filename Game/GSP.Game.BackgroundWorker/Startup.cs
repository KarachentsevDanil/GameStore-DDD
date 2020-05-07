using GSP.Game.BackgroundWorker.Extensions;
using GSP.Game.Data.Context;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.BackgroundWorker
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
            services.AddGspBackgroundWorker();

            services.ConfigureDatabase<GameDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.RegisterAzureServiceBus(Configuration);

            services.RegisterBackgroundWorkerDependencies();
        }
    }
}