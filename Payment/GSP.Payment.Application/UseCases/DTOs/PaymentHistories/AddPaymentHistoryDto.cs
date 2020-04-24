namespace GSP.Payment.Application.UseCases.DTOs.PaymentHistories
{
    public class AddPaymentHistoryDto
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }

        public long PaymentMethodId { get; set; }

        public float Amount { get; set; }

        public string Cvv { get; set; }
    }
}