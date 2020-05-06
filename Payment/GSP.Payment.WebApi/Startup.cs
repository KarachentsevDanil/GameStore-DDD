using GSP.Payment.Application.CQS.Validations.PaymentHistories;
using GSP.Payment.Data.Context;
using GSP.Payment.WebApi.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi<CreatePaymentHistoryValidator>(Configuration);

            services.AddLogging();

            services.ConfigureDatabase<PaymentDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.RegisterAzureServiceBus(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", nameof(Configuration));
            });
        }
    }
}