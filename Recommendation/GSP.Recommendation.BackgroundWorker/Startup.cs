using GSP.Recommendation.Application.Extensions;
using GSP.Recommendation.BackgroundWorker.Extensions;
using GSP.Recommendation.Data.Extensions;
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
            app.UseGspBackgroundWorkerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspBackgroundWorker();

            services.AddRecommendationDataLayer(Configuration);

            services.AddRecommendationApplicationLayer(Configuration);

            services.AddEventBus(Configuration);

            services.AddRecommendationHealthChecks(Configuration);

            services.AddRecommendationBackgroundWorker();
        }
    }
}