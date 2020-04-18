namespace GSP.Shared.Utils.Application.CQS.Models.Validations
{
    public class ValidationError
    {
        public string ErrorCode { get; set; }

        public string Property { get; set; }

        public string Message { get; set; }
    }
}