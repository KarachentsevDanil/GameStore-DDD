using GSP.Payment.Application.CQS.Commands.PaymentHistories;
using GSP.Payment.Application.CQS.Validations.PaymentHistories;
using GSP.Payment.Data.Context;
using GSP.Payment.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Payment.WebApi
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
            services.AddGspWebApi<CreatePaymentHistoryValidator, CreatePaymentHistoryCommand>(Configuration);

            services.ConfigureDatabase<PaymentDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.AddEventBus(Configuration);
        }
    }
}