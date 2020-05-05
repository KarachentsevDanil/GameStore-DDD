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

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.ConfigureDatabase<AccountDbContext>(Configuration);

            services.AddWebApi<CreateAccountValidator>(Configuration);

            services.AddLogging();

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

            app.UseGspUserInitializer();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", nameof(Configuration));
            });
        }
    }
}
