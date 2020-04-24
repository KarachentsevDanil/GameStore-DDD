using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Domain.Models;
using GSP.Shared.Utils.Common.Models.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.UseCases.Services.Contracts
{
    public interface IPaymentHistoryService
    {
        Task<GetPaymentHistoryDto> AddAsync(AddPaymentHistoryDto addPaymentHistoryDto, CancellationToken ct = default);

        Task<PagedCollection<GetPaymentHistoryDto>> GetListByFilterParamsAsync(PaymentHistoryFilterParams filterParams, CancellationToken ct = default);
    }
}