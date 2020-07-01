using GSP.Shared.Utils.WebApi.Sessions.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class BackgroundWorkerExtensions
    {
        public static IServiceCollection AddGspBackgroundWorker(this IServiceCollection services)
        {
            services.AddLogging();

            services.AddHttpContextAccessor();

            services.AddGspSession();

            services.AddAudit();

            services.AddDateTimeService();

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder UseGspBackgroundWorkerBuilder(this IApplicationBuilder app)
        {
            app.UseApiExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();
                endpoints.MapHealthChecks("health-check-api", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            return app;
        }
    }
}