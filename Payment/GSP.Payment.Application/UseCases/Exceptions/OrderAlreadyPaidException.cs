using System;

namespace GSP.Payment.Application.UseCases.Exceptions
{
    public class OrderAlreadyPaidException : Exception
    {
        public OrderAlreadyPaidException(string message)
            : base(message)
        {
        }

        public OrderAlreadyPaidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OrderAlreadyPaidException()
        {
        }
    }
}