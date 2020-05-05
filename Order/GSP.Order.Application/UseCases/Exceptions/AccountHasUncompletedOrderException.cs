using GSP.Shared.Utils.Application.Exceptions;
using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class AccountHasUncompletedOrderException : BusinessLogicException
    {
        public AccountHasUncompletedOrderException()
        {
        }

        public AccountHasUncompletedOrderException(string message)
            : base(message)
        {
        }

        public AccountHasUncompletedOrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "CurrentOrderAlreadyExists";

        public override string ErrorMessage { get; } = "Account already has active order.";
    }
}