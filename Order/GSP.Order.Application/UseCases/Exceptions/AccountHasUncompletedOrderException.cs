using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountHasUncompletedOrderException : Exception
    {
        public AccountHasUncompletedOrderException()
        {
        }

        public AccountHasUncompletedOrderException(string message)
            : base(message)
        {
        }

        public AccountHasUncompletedOrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}