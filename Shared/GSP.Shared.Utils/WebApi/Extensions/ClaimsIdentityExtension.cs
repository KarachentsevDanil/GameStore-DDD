using System.Security.Claims;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class ClaimsIdentityExtension
    {
        public static long? GetUserIfOrDefaultId(this ClaimsPrincipal claimsPrincipal)
        {
            string idValue = ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst("Id")?.Value;

            if (long.TryParse(idValue, out long id))
            {
                return id;
            }

            return default;
        }

        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            string idValue = ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst("Id")?.Value;

            if (long.TryParse(idValue, out long id))
            {
                return id;
            }

            return default;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}