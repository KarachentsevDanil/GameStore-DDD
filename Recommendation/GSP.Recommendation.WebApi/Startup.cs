using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.Application.CQS.Handlers.Commands.Games;
using GSP.Recommendation.Data.Context;
using GSP.Recommendation.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.WebApi
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
            app.UseGspApplicationBuilder<Startup>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspWebApi<CreateGameCommand, CreateGameCommandHandler>(Configuration);

            services.ConfigureDatabase<RecommendationDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies(Configuration);

            services.AddRecommendationHealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}