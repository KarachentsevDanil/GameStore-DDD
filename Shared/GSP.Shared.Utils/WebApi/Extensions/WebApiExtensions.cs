using FluentValidation.AspNetCore;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Extensions;
using GSP.Shared.Utils.WebApi.Sessions.Extensions;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class WebApiExtensions
    {
        public static IServiceCollection AddGspWebApi<TValidationAssemblyType, TMediatorHandlersAssemblyType>(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();

            services.AddControllers()
                .AddNewtonsoftJson(option => { option.UseCamelCasing(true); })
                .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<TValidationAssemblyType>();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwagger();

            services.AddJwtBearerAuthentication(configuration);

            services.AddMediatR(typeof(TMediatorHandlersAssemblyType).Assembly);

            services.AddGspSession();

            services.AddAudit();

            services.AddDateTimeService();

            services.AddResourceRegistryStore(configuration);

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }

        public static IServiceCollection AddGspWebApiAggregator<TValidationAssemblyType>(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();

            services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<TValidationAssemblyType>();
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwagger();

            services.AddJwtBearerAuthentication(configuration);

            return services;
        }

        public static IApplicationBuilder UseGspApplicationBuilder<TStartup>(this IApplicationBuilder app)
        {
            app.UseApiExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksUI();
                endpoints.MapHealthChecks("health-check-api", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(TStartup).AssemblyQualifiedName);
            });

            return app;
        }

        public static IApplicationBuilder UseGspApiAggregatorApplicationBuilder<TStartup>(this IApplicationBuilder app)
        {
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(TStartup).AssemblyQualifiedName);
            });

            return app;
        }
    }
}