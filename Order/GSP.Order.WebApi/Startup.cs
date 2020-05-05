using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Data.Context;
using GSP.Order.WebApi.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GSP.Order.WebApi
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
            services.AddWebApi<CreateOrderCommand>(Configuration);

            services.AddLogging();

            services.ConfigureDatabase<OrderDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies(Configuration);

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