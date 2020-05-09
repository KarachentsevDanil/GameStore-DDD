using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Account.Application.UseCases.Exceptions
{
    public class AccountNotFoundException : BusinessLogicException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string message)
            : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "AccountNotFound";

        public override string ErrorMessage { get; } = "Account with this email doesn't exist in system";
    }
}