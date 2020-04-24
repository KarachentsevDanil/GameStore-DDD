namespace GSP.Payment.Application.UseCases.DTOs.PaymentMethods
{
    public class AddPaymentMethodDto
    {
        public long AccountId { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderFullName { get; set; }

        public string Expiration { get; set; }

        public string Cvv { get; set; }
    }
}