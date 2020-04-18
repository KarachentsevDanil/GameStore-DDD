using GSP.Shared.Utils.Application.CQS.Models.Validations;
using System;

namespace GSP.Shared.Utils.Application.CQS.Exceptions
{
    public class ValidationHandlerException : Exception
    {
        public ValidationHandlerException(string message)
            : base(message)
        {
        }

        public ValidationHandlerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ValidationHandlerException()
        {
        }

        public ValidationHandlerException(ValidationErrorsResponse validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorsResponse ValidationErrors { get; }
    }
}