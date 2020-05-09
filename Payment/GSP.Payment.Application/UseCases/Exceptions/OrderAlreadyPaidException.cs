using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Payment.Application.UseCases.Exceptions
{
    public class OrderAlreadyPaidException : BusinessLogicException
    {
        public OrderAlreadyPaidException(string message)
            : base(message)
        {
        }

        public OrderAlreadyPaidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OrderAlreadyPaidException()
        {
        }

        public override string ErrorCode { get; } = "OrderAlreadyPaid";

        public override string ErrorMessage { get; } = "Order already paid.";
    }
}