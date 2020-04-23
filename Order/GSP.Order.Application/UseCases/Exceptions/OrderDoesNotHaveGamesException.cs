using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class OrderDoesNotHaveGamesException : Exception
    {
        public OrderDoesNotHaveGamesException()
        {
        }

        public OrderDoesNotHaveGamesException(string message)
            : base(message)
        {
        }

        public OrderDoesNotHaveGamesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}