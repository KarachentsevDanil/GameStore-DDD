using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using GSP.$projectPlainName$.Application.CQS.Handlers.Commands.$domainName$s;
using GSP.$projectPlainName$.Application.CQS.Validations.$domainName$s;
using GSP.$projectPlainName$.Application.Extensions;
using GSP.$projectPlainName$.Data.Extensions;
using $safeprojectname$.Extensions;
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
            app.UseGspApplicationBuilder<Startup>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspWebApi<Add$domainName$Validator, Add$domainName$CommandHandler>(Configuration);

            services.Add$domainName$DataLayer(Configuration);

            services.Add$domainName$ApplicationLayer();

            services.Add$domainName$HealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}