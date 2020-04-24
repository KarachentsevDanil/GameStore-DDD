using GSP.Shared.Utils.Common.Helpers;
using GSP.Shared.Utils.Domain.Base;

namespace GSP.Payment.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public PaymentMethod(long accountId)
        {
            AccountId = accountId;
        }

        private PaymentMethod()
        {
        }

        public long AccountId { get; private set; }

        public string CardNumber { get; private set; }

        public string CardHolderFullName { get; private set; }

        public string Expiration { get; private set; }

        public string Cvv { get; private set; }

        public void Encrypt(string cardNumber, string cardHolderFullName, string expiration, string cvv)
        {
            CardNumber = StringEncryptionHelper.Encrypt(cardNumber, cvv);
            CardHolderFullName = StringEncryptionHelper.Encrypt(cardHolderFullName, cvv);
            Expiration = StringEncryptionHelper.Encrypt(expiration, cvv);
            Cvv = StringEncryptionHelper.Encrypt(cvv);
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