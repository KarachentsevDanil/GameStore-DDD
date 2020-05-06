using GSP.Shared.Utils.Common.Sessions.Models;

namespace GSP.Shared.Utils.Common.Sessions.Contracts
{
    public interface IGspRequestInfoAccessor
    {
        GspRequestInfoModel RequestInfo { get; }
    }
}