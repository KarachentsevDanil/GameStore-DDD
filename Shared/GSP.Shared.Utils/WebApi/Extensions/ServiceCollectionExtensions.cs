using GSP.Shared.Utils.Common.Date;
using GSP.Shared.Utils.Common.Date.Contracts;
using GSP.Shared.Utils.Data.Context.Audit;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAudit(this IServiceCollection service)
        {
            service.AddScoped<IAuditService, AuditService>();
            return service;
        }

        public static IServiceCollection AddDateTimeService(this IServiceCollection service)
        {
            service.AddScoped<IDateTimeService, DateTimeService>();
            return service;
        }
    }
}