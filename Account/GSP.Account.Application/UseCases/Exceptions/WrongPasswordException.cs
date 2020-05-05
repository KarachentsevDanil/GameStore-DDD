using GSP.Shared.Utils.Application.Exceptions;
using System;

namespace GSP.Account.Application.UseCases.Exceptions
{
    public class WrongPasswordException : BusinessLogicException
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message)
            : base(message)
        {
        }

        public WrongPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "WrongPassword";

        public override string ErrorMessage { get; } = "You've entered wrong password.";
    }
}