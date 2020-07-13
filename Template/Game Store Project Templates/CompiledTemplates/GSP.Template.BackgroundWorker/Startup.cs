using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using GSP.$projectPlainName$.Application.Extensions;
using $safeprojectname$.Extensions;
using GSP.$projectPlainName$.Data.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
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

            services.Add$domainName$DataLayer(Configuration);

            services.Add$domainName$ApplicationLayer();

            services.Add$domainName$HealthChecks(Configuration);

            services.AddEventBus(Configuration);

            services.Add$domainName$BackgroundWorkerLayer();
        }
    }
}