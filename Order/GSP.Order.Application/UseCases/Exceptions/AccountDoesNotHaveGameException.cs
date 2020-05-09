using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountDoesNotHaveGameException : BusinessLogicException
    {
        public AccountDoesNotHaveGameException()
        {
        }

        public AccountDoesNotHaveGameException(string message)
            : base(message)
        {
        }

        public AccountDoesNotHaveGameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "AccountDoesNotHaveGame";

        public override string ErrorMessage { get; } = "This game is not in bucket";
    }
}