using GSP.Account.Application.CQS.Validators;
using GSP.Account.Data.Context;
using GSP.Account.WebApi.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddWebApi<CreateAccountValidator>(Configuration);

            services.AddLogging();

            services.ConfigureDatabase<AccountDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies();

            services.RegisterAzureServiceBus(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseApiExceptionHandler();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", nameof(Configuration));
            });
        }
    }
}