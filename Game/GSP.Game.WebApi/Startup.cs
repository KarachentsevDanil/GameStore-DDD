using GSP.Game.Application.CQS.Handlers.Commands.Games;
using GSP.Game.Application.CQS.Validations.Games;
using GSP.Game.Application.Extensions;
using GSP.Game.Data.Extensions;
using GSP.Game.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.WebApi
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
            services.AddGspWebApi<AddGameValidator, CreateGameCommandHandler>(Configuration);

            services.AddGameDataLayer(Configuration);

            services.AddGameApplicationLayer();

            services.AddGameHealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}