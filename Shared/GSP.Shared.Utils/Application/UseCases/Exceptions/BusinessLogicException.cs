using System;

namespace GSP.Shared.Utils.Application.Exceptions
{
    public abstract class BusinessLogicException : Exception
    {
        protected BusinessLogicException(string message)
            : base(message)
        {
        }

        protected BusinessLogicException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessLogicException()
        {
        }

        public abstract string ErrorCode { get; }

        public abstract string ErrorMessage { get; }
    }
}