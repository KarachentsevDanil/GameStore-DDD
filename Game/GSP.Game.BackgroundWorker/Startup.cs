using GSP.Game.Application.Extensions;
using GSP.Game.BackgroundWorker.Extensions;
using GSP.Game.Data.Context;
using GSP.Game.Data.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
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
            app.UseGspBackgroundWorkerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspBackgroundWorker();

            services.AddGameDataLayer(Configuration);

            services.AddGameApplicationLayer();

            services.AddGameHealthChecks(Configuration);

            services.AddEventBus(Configuration);

            services.AddGameBackgroundWorker();
        }
    }
}