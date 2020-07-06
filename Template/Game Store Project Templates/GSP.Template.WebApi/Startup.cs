using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using GSP.Template.Application.CQS.Handlers.Commands.Templates;
using GSP.Template.Application.CQS.Validations.Templates;
using GSP.Template.Data.Context;
using GSP.Template.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Template.WebApi
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
            services.AddGspWebApi<AddTemplateValidator, AddTemplateCommandHandler>(Configuration);

            services.ConfigureDatabase<TemplateDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.AddTemplateHealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}