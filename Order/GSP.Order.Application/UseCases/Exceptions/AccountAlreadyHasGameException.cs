using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountAlreadyHasGameException : BusinessLogicException
    {
        public AccountAlreadyHasGameException()
        {
        }

        public AccountAlreadyHasGameException(string message)
            : base(message)
        {
        }

        public AccountAlreadyHasGameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "GameAlreadyBought";

        public override string ErrorMessage { get; } = "This game already bought for account.";
    }
}