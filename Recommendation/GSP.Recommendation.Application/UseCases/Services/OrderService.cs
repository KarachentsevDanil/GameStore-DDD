using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Domain.Entities;
using GSP.Recommendation.Domain.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.UseCases.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRecommendationUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        public OrderService(IRecommendationUnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddAsync(AddOrderDto addOrder, CancellationToken ct = default)
        {
            _logger.LogInformation("Add order {@Order}", addOrder);

            ICollection<OrderGame> orderGames = addOrder.Games.Select(q => new OrderGame(q.OrderId, q.GameId)).ToList();

            CompletedOrder order = new CompletedOrder(addOrder.Id, addOrder.AccountId, addOrder.CreatedAt, orderGames);

            _unitOfWork.OrderRepository.Create(order);

            await _unitOfWork.SaveAsync(ct);
        }
    }
}