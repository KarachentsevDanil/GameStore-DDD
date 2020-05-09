using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class OrderDoesNotHaveGamesException : BusinessLogicException
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

        public override string ErrorCode { get; } = "BucketIsEmpty";

        public override string ErrorMessage { get; } = "Bucket is empty";
    }
}