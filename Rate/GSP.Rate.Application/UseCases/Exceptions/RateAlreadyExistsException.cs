using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Rate.Application.UseCases.Exceptions
{
    public class RateAlreadyExistsException : BusinessLogicException
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

        public override string ErrorCode { get; } = "RateAlreadyExists";

        public override string ErrorMessage { get; } = "You have already added rating to game. You can modify it.";
    }
}