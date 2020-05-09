using System;

namespace GSP.Shared.Utils.Application.UseCases.Exceptions
{
    public class ItemNotFoundException : BusinessLogicException
    {
        public ItemNotFoundException(string message)
            : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ItemNotFoundException()
        {
        }

        public override string ErrorCode { get; } = "ItemNotFound";

        public override string ErrorMessage { get; } = "Requested item doesn't exist.";
    }
}