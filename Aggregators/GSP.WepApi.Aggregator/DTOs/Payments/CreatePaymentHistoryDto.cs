namespace GSP.WepApi.Aggregator.DTOs.Payments
{
    public class CreatePaymentHistoryDto
    {
        public long OrderId { get; set; }

        public long PaymentMethodId { get; set; }

        public float Amount { get; set; }

        public string Cvv { get; set; }
    }
}