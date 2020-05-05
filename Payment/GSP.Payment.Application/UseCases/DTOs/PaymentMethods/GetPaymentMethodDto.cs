using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Payment.Application.UseCases.DTOs.PaymentMethods
{
    public class GetPaymentMethodDto : BaseGetItemDto
    {
        public long AccountId { get; set; }

        public string Name { get; set; }
    }
}