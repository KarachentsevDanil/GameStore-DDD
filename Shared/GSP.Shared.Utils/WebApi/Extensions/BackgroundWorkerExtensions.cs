using GSP.Shared.Utils.WebApi.Sessions.Extensions;
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

            return services;
        }
    }
}