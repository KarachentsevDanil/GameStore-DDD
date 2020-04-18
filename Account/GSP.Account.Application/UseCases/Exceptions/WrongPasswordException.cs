using System;

namespace GSP.Account.Application.UseCases.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message)
            : base(message)
        {
        }

        public WrongPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}