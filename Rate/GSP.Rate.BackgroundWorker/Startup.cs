using GSP.Rate.Application.Extensions;
using GSP.Rate.BackgroundWorker.Extensions;
using GSP.Rate.Data.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.BackgroundWorker
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
            app.UseGspBackgroundWorkerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspBackgroundWorker();

            services.AddRateDataLayer(Configuration);

            services.AddRateApplicationLayer();

            services.AddEventBus(Configuration);

            services.AddRateHealthChecks(Configuration);

            services.AddRateBackgroundWorker();
        }
    }
}