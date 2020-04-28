using GSP.Shared.Utils.Common.Helpers;
using GSP.Shared.Utils.Domain.Base;
using Microsoft.OpenApi.Writers;

namespace GSP.Payment.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        private PaymentMethod(long accountId, string cardNumber, string cardHolderFullName, string expiration, string cvv)
        {
            AccountId = accountId;
            CardNumber = cardNumber;
            CardHolderFullName = cardHolderFullName;
            Expiration = expiration;
            Cvv = cvv;
        }

        private PaymentMethod()
        {
        }

        public long AccountId { get; private set; }

        public string CardNumber { get; private set; }

        public string CardHolderFullName { get; private set; }

        public string Expiration { get; private set; }

        public string Cvv { get; private set; }

        public static PaymentMethod Create(long accountId, string cardNumber, string cardHolderFullName, string expiration, string cvv)
        {
            var paymentMethod = new PaymentMethod(accountId, cardNumber, cardHolderFullName, expiration, cvv);

            paymentMethod.Encrypt();

            return paymentMethod;
        }

        public void Encrypt()
        {
            CardNumber = StringEncryptionHelper.Encrypt(CardNumber, Cvv);
            CardHolderFullName = StringEncryptionHelper.Encrypt(CardHolderFullName, Cvv);
            Expiration = StringEncryptionHelper.Encrypt(Expiration, Cvv);
            Cvv = StringEncryptionHelper.Encrypt(Cvv);
        }

        public void Decrypt(string cvv)
        {
            CardNumber = StringEncryptionHelper.Decrypt(CardNumber, cvv);
            CardHolderFullName = StringEncryptionHelper.Decrypt(CardHolderFullName, cvv);
            Expiration = StringEncryptionHelper.Decrypt(Expiration, cvv);
            Cvv = StringEncryptionHelper.Decrypt(Cvv);
        }
    }
}