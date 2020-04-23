using AutoMapper;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Exceptions;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.Domain.Entities;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.UseCases.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetOrderDto> AddAsync(AddOrderDto order, CancellationToken ct = default)
        {
            _logger.LogInformation("Add new order for account={AccountId}", order.AccountId);

            OrderBase currentOrder = await _unitOfWork.OrderRepository.GetCurrentOrderAsync(order.AccountId, ct);

            if (currentOrder != null)
            {
                _logger.LogInformation("User {AccountId} already has uncompleted order", order.AccountId);
                throw new AccountHasUncompletedOrderException();
            }

            OrderBase newOrder = new OrderBase(order.AccountId);

            _unitOfWork.OrderRepository.Create(newOrder);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetOrderDto>(newOrder);
        }

        public async Task<GetOrderDto> CompleteAsync(CompleteOrderDto order, CancellationToken ct = default)
        {
            _logger.LogInformation("Complete current order for account={AccountId}", order.AccountId);

            OrderBase currentOrder = await _unitOfWork.OrderRepository.GetCurrentOrderAsync(order.AccountId, ct);

            ValidateCompletedOrder(currentOrder, order.AccountId);

            currentOrder.CompleteOrder();

            _unitOfWork.OrderRepository.Update(currentOrder);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetOrderDto>(currentOrder);
        }

        public async Task<GetOrderDto> AddOrderGameAsync(OrderGameDto orderGame, CancellationToken ct = default)
        {
            _logger.LogInformation(
                "Add game to active order for user, {AccountId}, {GameId}",
                orderGame.AccountId,
                orderGame.GameId);

            OrderBase currentOrder = await GetCurrentOrderAsync(orderGame.AccountId, ct);

            await ValidateAddingGameToOrderAsync(currentOrder, orderGame.GameId, ct);

            currentOrder.AddGame(orderGame.GameId);

            _unitOfWork.OrderRepository.Update(currentOrder);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetOrderDto>(currentOrder);
        }

        public async Task<GetOrderDto> DeleteOrderGameAsync(OrderGameDto orderGame, CancellationToken ct = default)
        {
            _logger.LogInformation(
                "Remove game from active order for user, {AccountId}, {GameId}",
                orderGame.AccountId,
                orderGame.GameId);

            OrderBase currentOrder = await GetCurrentOrderAsync(orderGame.AccountId, ct);

            ValidateRemovingGameFromOrder(orderGame, currentOrder);

            _unitOfWork.OrderRepository.Update(currentOrder);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetOrderDto>(currentOrder);
        }

        public async Task<GetOrderDto> GetCurrentByAccountIdAsync(long accountId, CancellationToken ct = default)
        {
            _logger.LogInformation("Get current order by AccountId, {AccountId}", accountId);

            OrderBase currentOrder = await GetCurrentOrderAsync(accountId, ct);

            return _mapper.Map<GetOrderDto>(currentOrder);
        }

        public async Task<IImmutableList<GetOrderDto>> GetListByAccountIdAsync(long accountId, CancellationToken ct = default)
        {
            _logger.LogInformation("Get orders by AccountId {AccountId}", accountId);

            ICollection<OrderBase> orders = await _unitOfWork.OrderRepository.GetListByAccountId(accountId, ct);

            return _mapper.Map<ICollection<GetOrderDto>>(orders).ToImmutableList();
        }

        public async ValueTask<int> GetOrderCountByGameIdAsync(long gameId, CancellationToken ct = default)
        {
            _logger.LogInformation("Get order count by game id - {GameId}", gameId);
            return await _unitOfWork.OrderGameRepository.GetOrderCountByGameIdAsync(gameId, ct);
        }

        private void ValidateRemovingGameFromOrder(OrderGameDto orderGame, OrderBase currentOrder)
        {
            bool isRemoved = currentOrder.RemoveGame(orderGame.GameId);

            if (!isRemoved)
            {
                _logger.LogInformation(
                    "Current order doesn't have game - {OrderId}, {GameId}",
                    currentOrder.Id,
                    orderGame.AccountId);
                throw new AccountDoesNotHaveGameException();
            }
        }

        private void ValidateCompletedOrder(OrderBase currentOrder, long accountId)
        {
            if (currentOrder == null)
            {
                _logger.LogInformation("User {AccountId} doesn't have active order", accountId);
                throw new UserDoesNotHaveActiveOrderException();
            }

            if (currentOrder.Games.Any())
            {
                _logger.LogInformation("Order {OrderId} doesn't have games", currentOrder.Id);
                throw new OrderDoesNotHaveGamesException();
            }
        }

        private async Task ValidateAddingGameToOrderAsync(OrderBase currentOrder, long gameId, CancellationToken ct)
        {
            bool isGameAlreadyExists =
                await _unitOfWork.OrderGameRepository.IsExists(currentOrder.AccountId, gameId, ct);

            if (isGameAlreadyExists)
            {
                _logger.LogInformation("Account {AccountId} already has game {GameId}", currentOrder.AccountId, gameId);
                throw new AccountAlreadyHasGameException();
            }
        }

        private async Task<OrderBase> GetCurrentOrderAsync(long accountId, CancellationToken ct)
        {
            OrderBase order = await _unitOfWork.OrderRepository.GetCurrentOrderAsync(accountId, ct);

            if (order == null)
            {
                _logger.LogInformation("User {AccountId} doesn't have active order", accountId);
                throw new UserDoesNotHaveActiveOrderException();
            }

            return order;
        }
    }
}