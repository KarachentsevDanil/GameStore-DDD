using GSP.Shared.Utils.Application.UseCases.Exceptions;
using System;

namespace GSP.Order.Application.UseCases.Exceptions
{
    public class UserDoesNotHaveActiveOrderException : BusinessLogicException
    {
        public UserDoesNotHaveActiveOrderException()
        {
        }

        public UserDoesNotHaveActiveOrderException(string message)
            : base(message)
        {
        }

        public UserDoesNotHaveActiveOrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ErrorCode { get; } = "AccountDoesNotActiveOrder";

        public override string ErrorMessage { get; } = "Please create new order.";
    }
}