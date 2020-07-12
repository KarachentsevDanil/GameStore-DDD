using GSP.Rate.Application.CQS.Handlers.Commands.Rates;
using GSP.Rate.Application.CQS.Validations.Rates;
using GSP.Rate.Application.Extensions;
using GSP.Rate.Data.Extensions;
using GSP.Rate.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.WebApi
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
            services.AddGspWebApi<CreateRateValidator, CreateRateCommonHandler>(Configuration);

            services.AddRateDataLayer(Configuration);

            services.AddRateApplicationLayer();

            services.AddRateHealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}