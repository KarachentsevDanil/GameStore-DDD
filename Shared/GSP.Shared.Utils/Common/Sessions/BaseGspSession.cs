using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Common.Sessions.Models;

namespace GSP.Shared.Utils.Common.Sessions
{
    public abstract class BaseGspSession : IGspSession
    {
        private readonly IGspRequestInfoAccessor _requestInfoAccessor;

        protected BaseGspSession(IGspRequestInfoAccessor requestInfoAccessor)
        {
            _requestInfoAccessor = requestInfoAccessor;
        }

        public abstract long AccountId { get; }

        public abstract string Email { get; }

        public virtual GspRequestInfoModel RequestInfo => _requestInfoAccessor.RequestInfo;

        public GspUserAccountModel ToUserAccountModel()
        {
            return new GspUserAccountModel(AccountId, Email);
        }
    }
}