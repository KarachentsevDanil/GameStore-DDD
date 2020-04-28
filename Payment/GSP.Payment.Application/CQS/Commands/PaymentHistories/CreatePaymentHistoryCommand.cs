using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Payment.Application.CQS.Commands.PaymentHistories
{
    public class CreatePaymentHistoryCommand : BaseCreateItemCommand<GetPaymentHistoryDto>
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }

        public long PaymentMethodId { get; set; }

        public float Amount { get; set; }

        public string Cvv { get; set; }
    }
}