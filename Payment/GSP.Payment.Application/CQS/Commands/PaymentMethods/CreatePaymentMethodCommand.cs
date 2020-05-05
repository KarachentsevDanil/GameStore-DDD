using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Payment.Application.CQS.Commands.PaymentMethods
{
    public class CreatePaymentMethodCommand : BaseCreateItemCommand<GetPaymentMethodDto>
    {
        public long AccountId { get; set; }

        public string Name { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderFullName { get; set; }

        public string Expiration { get; set; }

        public string Cvv { get; set; }
    }
}