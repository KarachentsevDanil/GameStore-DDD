using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Shared.Utils.Application.CQS.Queries;

namespace GSP.Payment.Application.CQS.Queries.PaymentHistories
{
    public class GetPaymentHistoriesQuery : BaseGetPagedListQuery<GetPaymentHistoryDto>
    {
        public long AccountId { get; set; }
    }
}