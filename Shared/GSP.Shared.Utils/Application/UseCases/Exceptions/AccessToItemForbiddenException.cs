using System;

namespace GSP.Shared.Utils.Application.UseCases.Exceptions
{
    public class AccessToItemForbiddenException : BusinessLogicException
    {
        public AccessToItemForbiddenException(string message)
            : base(message)
        {
        }

        public AccessToItemForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AccessToItemForbiddenException()
        {
        }

        public override string ErrorCode { get; } = "AccessToEntityForbidden";

        public override string ErrorMessage { get; } = "Account doesn't have access to entity.";
    }
}