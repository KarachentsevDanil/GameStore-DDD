using System;
using GSP.Shared.Utils.Application.Exceptions;

namespace GSP.Account.Application.UseCases.Exceptions
{
    public class AccountAlreadyExistException : BusinessLogicException
    {
        public AccountAlreadyExistException()
        {
        }

        public AccountAlreadyExistException(string message)
            : base(message)
        {
        }

        public AccountAlreadyExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "AccountAlreadyExists";

        public override string ErrorMessage { get; } = "Account with this email already exists in system.";
    }
}