using System;

namespace GSP.Payment.Application.UseCases.Exceptions
{
    public class AccessToPaymentMethodForbiddenException : Exception
    {
        public AccessToPaymentMethodForbiddenException(string message)
            : base(message)
        {
        }

        public AccessToPaymentMethodForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AccessToPaymentMethodForbiddenException()
        {
        }
    }
}