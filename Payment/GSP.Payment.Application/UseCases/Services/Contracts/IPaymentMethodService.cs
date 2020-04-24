using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;

namespace GSP.Payment.Application.UseCases.Services.Contracts
{
    public interface IPaymentMethodService
    {
        Task<GetPaymentMethodDto> AddAsync(AddPaymentMethodDto addPaymentMethodDto, CancellationToken ct = default);

        Task<IImmutableList<GetPaymentMethodDto>> GetListByAccountIdAsync(long accountId, CancellationToken ct = default);
    }
}