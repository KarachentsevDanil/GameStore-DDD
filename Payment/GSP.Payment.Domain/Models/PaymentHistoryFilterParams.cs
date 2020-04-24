using GSP.Shared.Utils.Common.Models.FilterParams;

namespace GSP.Payment.Domain.Models
{
    public class PaymentHistoryFilterParams : PaginationFilterParams
    {
        public long AccountId { get; set; }
    }
}