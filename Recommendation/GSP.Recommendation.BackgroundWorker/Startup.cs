using GSP.Recommendation.BackgroundWorker.Extensions;
using GSP.Recommendation.Data.Context;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.BackgroundWorker
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

            services.ConfigureDatabase<RecommendationDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies(Configuration);

            services.AddEventBus(Configuration);

            services.RegisterBackgroundWorkerDependencies();
        }
    }
}