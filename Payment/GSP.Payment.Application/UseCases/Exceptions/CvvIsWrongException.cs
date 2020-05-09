using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Payment.Application.UseCases.Exceptions
{
    public class CvvIsWrongException : BusinessLogicException
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

        public override string ErrorCode { get; } = "CvvIsWrong";

        public override string ErrorMessage { get; } = "You've entered wrong Cvv code";
    }
}