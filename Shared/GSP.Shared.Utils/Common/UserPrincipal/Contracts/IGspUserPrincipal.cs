using GSP.Shared.Utils.Common.UserPrincipal.Models;

namespace GSP.Shared.Utils.Common.UserPrincipal.Contracts
{
    public interface IGspUserPrincipal
    {
        GspUserAccountModel User { get; }

        void SetCurrentUserAccount(long id, string email);
    }
}