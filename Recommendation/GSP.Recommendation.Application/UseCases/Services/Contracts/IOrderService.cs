using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.UseCases.Services.Contracts
{
    public interface IOrderService
    {
        Task AddAsync(AddOrderDto addOrder, CancellationToken ct = default);
    }
}