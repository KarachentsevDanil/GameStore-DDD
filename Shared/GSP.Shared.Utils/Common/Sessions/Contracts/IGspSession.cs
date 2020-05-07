using GSP.Shared.Utils.Common.Sessions.Models;

namespace GSP.Shared.Utils.Common.Sessions.Contracts
{
    public interface IGspSession
    {
        long? AccountId { get; }

        string Email { get; }

        GspRequestInfoModel RequestInfo { get; }

        GspUserAccountModel GetUserAccountOrDefault();
    }
}