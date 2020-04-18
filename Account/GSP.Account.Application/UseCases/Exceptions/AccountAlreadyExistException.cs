using System;

namespace GSP.Account.Application.UseCases.Exceptions
{
    public class AccountAlreadyExistException : Exception
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
    }
}