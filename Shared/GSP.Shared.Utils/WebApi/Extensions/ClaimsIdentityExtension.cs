using System.Security.Claims;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class ClaimsIdentityExtension
    {
        private const string UserIdClaimName = "Id";

        public static long? GetUserIfOrDefaultId(this ClaimsPrincipal claimsPrincipal)
        {
            string idValue = claimsPrincipal.GetClaimValue(UserIdClaimName);

            if (long.TryParse(idValue, out long id))
            {
                return id;
            }

            return default;
        }

        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            string idValue = claimsPrincipal.GetClaimValue(UserIdClaimName);

            if (long.TryParse(idValue, out long id))
            {
                return id;
            }

            return default;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue(ClaimTypes.Email);
        }

        public static string GetClaimValue(this ClaimsPrincipal claimsPrincipal, string claimName)
        {
            return ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst(claimName)?.Value;
        }
    }
}