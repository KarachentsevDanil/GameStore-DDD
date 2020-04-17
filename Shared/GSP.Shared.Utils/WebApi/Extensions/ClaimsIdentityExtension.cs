using System.Security.Claims;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class ClaimsIdentityExtension
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            string idValue = ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst("Id")?.Value;

            if (int.TryParse(idValue, out int id))
            {
                return id;
            }

            return default;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst("Email")?.Value;
        }
    }
}