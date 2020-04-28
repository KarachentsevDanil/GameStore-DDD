using System;

namespace GSP.Payment.Application.UseCases.Exceptions
{
    public class CvvIsWrongException : Exception
    {
        public CvvIsWrongException(string message)
            : base(message)
        {
        }

        public CvvIsWrongException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CvvIsWrongException()
        {
        }
    }
}