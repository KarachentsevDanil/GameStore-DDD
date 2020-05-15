using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;

namespace GSP.Shared.Utils.Common.Sessions
{
    public class GspClaimsSession : BaseGspSession
    {
        public GspClaimsSession(IGspPrincipalAccessor principalAccessor, IGspRequestInfoAccessor requestInfoAccessor)
            : base(requestInfoAccessor)
        {
            PrincipalAccessor = principalAccessor;
        }

        public override long? AccountId => PrincipalAccessor.Principal?.GetUserIfOrDefaultId();

        public override string Email => PrincipalAccessor.Principal?.GetUserEmail();

        protected IGspPrincipalAccessor PrincipalAccessor { get; }
    }
}