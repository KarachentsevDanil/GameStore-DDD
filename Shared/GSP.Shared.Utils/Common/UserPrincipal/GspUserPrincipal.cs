using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Common.UserPrincipal.Models;

namespace GSP.Shared.Utils.Common.UserPrincipal
{
    public class GspUserPrincipal : IGspUserPrincipal
    {
        public GspUserAccountModel User { get; set; }

        public void SetCurrentUserAccount(long id, string email)
        {
            User = new GspUserAccountModel(id, email);
        }
    }
}