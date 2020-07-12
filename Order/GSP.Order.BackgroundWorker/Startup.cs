using GSP.Order.Application.Extensions;
using GSP.Order.BackgroundWorker.Extensions;
using GSP.Order.Data.Context;
using GSP.Order.Data.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
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
            app.UseGspBackgroundWorkerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspBackgroundWorker();

            services.AddOrderDataLayer(Configuration);

            services.AddOrderApplicationLayer(Configuration);

            services.AddEventBus(Configuration);

            services.AddOrderHealthChecks(Configuration);

            services.AddOrderBackgroundWorker();
        }
    }
}