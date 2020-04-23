using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountAlreadyHasGameException : Exception
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
    }
}