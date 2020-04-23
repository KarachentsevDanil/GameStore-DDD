using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class UserDoesNotHaveActiveOrderException : Exception
    {
        public UserDoesNotHaveActiveOrderException()
        {
        }

        public UserDoesNotHaveActiveOrderException(string message)
            : base(message)
        {
        }

        public UserDoesNotHaveActiveOrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}