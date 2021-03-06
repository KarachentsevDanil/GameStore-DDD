using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using GSP.Template.Application.Extensions;
using GSP.Template.BackgroundWorker.Extensions;
using GSP.Template.Data.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Template.BackgroundWorker
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

            services.AddTemplateDataLayer(Configuration);

            services.AddTemplateApplicationLayer();

            services.AddTemplateHealthChecks(Configuration);

            services.AddEventBus(Configuration);

            services.AddTemplateBackgroundWorkerLayer();
        }
    }
}