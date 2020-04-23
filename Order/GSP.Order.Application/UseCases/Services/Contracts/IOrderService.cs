using GSP.Order.Application.UseCases.DTOs.Orders;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.UseCases.Services.Contracts
{
    public interface IOrderService
    {
        Task<GetOrderDto> AddAsync(AddOrderDto order, CancellationToken ct = default);

        Task<GetOrderDto> CompleteAsync(CompleteOrderDto order, CancellationToken ct = default);

        Task<GetOrderDto> AddOrderGameAsync(OrderGameDto orderGame, CancellationToken ct = default);

        Task<GetOrderDto> DeleteOrderGameAsync(OrderGameDto orderGame, CancellationToken ct = default);

        Task<GetOrderDto> GetCurrentByAccountIdAsync(long accountId, CancellationToken ct = default);

        Task<IImmutableList<GetOrderDto>> GetListByAccountIdAsync(long accountId, CancellationToken ct = default);
    }
}