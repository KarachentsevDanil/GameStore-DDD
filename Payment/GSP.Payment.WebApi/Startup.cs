using GSP.Payment.Application.CQS.Commands.PaymentHistories;
using GSP.Payment.Application.CQS.Validations.PaymentHistories;
using GSP.Payment.Application.Extensions;
using GSP.Payment.Data.Extensions;
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

            services.AddPaymentDataLayer(Configuration);

            services.AddPaymentApplicationLayer();

            services.AddPaymentHealthChecks(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}