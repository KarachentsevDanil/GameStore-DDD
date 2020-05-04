using System;

namespace GSP.Shared.Utils.Application.UseCases.Exceptions
{
    public class AccessToItemForbiddenException : Exception
    {
        public AccessToItemForbiddenException(string message)
            : base(message)
        {
        }

        public AccessToItemForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AccessToItemForbiddenException()
        {
        }
    }
}