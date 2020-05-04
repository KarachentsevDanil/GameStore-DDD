using System;

namespace GSP.Rate.Application.UseCases.Exceptions
{
    public class RateAlreadyExistsException : Exception
    {
        public RateAlreadyExistsException(string message)
            : base(message)
        {
        }

        public RateAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RateAlreadyExistsException()
        {
        }
    }
}