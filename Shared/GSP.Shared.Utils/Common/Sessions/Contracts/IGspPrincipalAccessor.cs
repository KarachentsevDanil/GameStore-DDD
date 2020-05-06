using System.Security.Claims;

namespace GSP.Shared.Utils.Common.Sessions.Contracts
{
    public interface IGspPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}