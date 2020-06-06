using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Common.Sessions.Models;
using Microsoft.AspNetCore.Http;

namespace GSP.Shared.Utils.WebApi.Sessions
{
    public class WebApiRequestInfoAccessor : IGspRequestInfoAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public WebApiRequestInfoAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public GspRequestInfoModel RequestInfo => CreateRequestInfoModel(_accessor.HttpContext?.Request);

        private static GspRequestInfoModel CreateRequestInfoModel(HttpRequest request)
        {
            if (request == null)
            {
                return default;
            }

            var ip = request.HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = request.Headers["User-Agent"];

            return new GspRequestInfoModel(ip, userAgent);
        }
    }
}