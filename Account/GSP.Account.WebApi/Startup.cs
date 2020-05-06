using GSP.Account.Application.CQS.Handlers.Commands;
using GSP.Account.Application.CQS.Validators;
using GSP.Account.Data.Context;
using GSP.Account.WebApi.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
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
            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.ConfigureDatabase<AccountDbContext>(Configuration);

            services.AddGspWebApi<CreateAccountValidator, CreateAccountCommandHandler>(Configuration);

            services.RegisterAzureServiceBus(Configuration);
        }
    }
}
