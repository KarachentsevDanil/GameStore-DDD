using System;

namespace GSP.Account.Application.Exceptions
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