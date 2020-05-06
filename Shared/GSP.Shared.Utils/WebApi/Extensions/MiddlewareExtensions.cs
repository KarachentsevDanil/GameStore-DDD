using GSP.Shared.Utils.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}