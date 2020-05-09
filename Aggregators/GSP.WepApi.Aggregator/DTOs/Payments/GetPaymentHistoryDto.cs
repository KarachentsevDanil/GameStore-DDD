namespace GSP.WepApi.Aggregator.DTOs.Payments
{
    public class GetPaymentHistoryDto
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long PaymentMethodId { get; set; }

        public float Amount { get; set; }
    }
}