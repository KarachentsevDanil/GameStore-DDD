using GSP.Shared.Utils.Common.Sessions.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GSP.Shared.Utils.WebApi.Sessions
{
    public class WebApiPrincipalAccessor : IGspPrincipalAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public WebApiPrincipalAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ClaimsPrincipal Principal => _accessor.HttpContext.User;
    }
}