using System;

namespace GSP.Shared.Grid.Exceptions
{
    public abstract class BaseGridException : Exception
    {
        protected BaseGridException(string message)
            : base(message)
        {
        }

        protected BaseGridException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BaseGridException()
        {
        }

        public string ErrorMessage { get; set; }
    }
}