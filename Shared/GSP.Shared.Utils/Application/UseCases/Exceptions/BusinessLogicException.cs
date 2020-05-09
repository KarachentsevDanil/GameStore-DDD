using System;

namespace GSP.Shared.Utils.Application.UseCases.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message)
            : base(message)
        {
        }

        public BusinessLogicException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BusinessLogicException()
        {
        }

        public BusinessLogicException(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public virtual string ErrorCode { get; }

        public virtual string ErrorMessage { get; }
    }
}