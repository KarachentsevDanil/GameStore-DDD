using System.Collections.Generic;

namespace GSP.Shared.Utils.Application.CQS.Models.Validations
{
    public class ValidationErrorsResponse
    {
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}