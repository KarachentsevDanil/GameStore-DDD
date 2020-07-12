using GSP.Account.Application.CQS.Handlers.Commands;
using GSP.Account.Application.CQS.Validators;
using GSP.Account.Application.Extensions;
using GSP.Account.Data.Extensions;
using GSP.Account.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.WebApi
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
            services.AddGspWebApi<CreateAccountValidator, CreateAccountCommandHandler>(Configuration);

            services.AddAccountHealthChecks(Configuration);

            services.AddAccountDataLayer(Configuration);

            services.AddAccountApplicationLayer();

            services.AddEventBus(Configuration);
        }
    }
}