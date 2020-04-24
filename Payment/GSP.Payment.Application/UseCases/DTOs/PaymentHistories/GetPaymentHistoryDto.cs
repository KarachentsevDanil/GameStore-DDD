using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Payment.Application.UseCases.DTOs.PaymentHistories
{
    public class GetPaymentHistoryDto : BaseGetItemDto
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }

        public long PaymentMethodId { get; set; }

        public float Amount { get; set; }
    }
}