using GSP.WepApi.Aggregator.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GSP.WepApi.Aggregator.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static string GetAuthorizationHeaderOrDefault(this IHttpContextAccessor httpContextAccessor)
        {
            var isExists = httpContextAccessor.HttpContext.Request.Headers.TryGetValue(
                HeaderConstants.Authorization,
                out StringValues authorizationHeader);

            if (isExists)
            {
                return authorizationHeader;
            }

            return string.Empty;
        }
    }
}