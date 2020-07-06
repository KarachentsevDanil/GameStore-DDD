using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using GSP.Template.BackgroundWorker.Extensions;
using GSP.Template.Data.Context;
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

            services.ConfigureDatabase<TemplateDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.AddTemplateHealthChecks(Configuration);

            services.AddEventBus(Configuration);

            services.RegisterBackgroundWorkerDependencies();
        }
    }
}