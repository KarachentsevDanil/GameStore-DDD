using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountDoesNotHaveGameException : Exception
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
    }
}