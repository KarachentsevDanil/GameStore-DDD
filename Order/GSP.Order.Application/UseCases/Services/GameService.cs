using AutoMapper;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.Domain.Entities;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.UseCases.Services
{
    public class GameService : BaseService<IOrderUnitOfWork, Game, GetGameDto, AddGameDto, UpdateGameDto>, IGameService
    {
        public GameService(IOrderUnitOfWork unitOfWork, IBaseRepository<Game> repository, IMapper mapper, ILogger<Game> logger)
            : base(unitOfWork, repository, mapper, logger)
        {
        }

        public async Task<IImmutableList<GetGameDto>> GetGameByAccountIdAsync(long accountId, CancellationToken ct = default)
        {
            Logger.LogInformation("Get games by user account id, {AccountId}", accountId);

            var games = await UnitOfWork.OrderGameRepository.GetListByAccountId(accountId, ct);

            return Mapper.Map<ICollection<GetGameDto>>(games).ToImmutableList();
        }

        protected override Game MapEntity(AddGameDto itemDto)
        {
            return new Game(itemDto.Id, itemDto.Name, itemDto.Description, itemDto.Price, itemDto.PhotoUri, itemDto.IconUri);
        }

        protected override void UpdateEntity(UpdateGameDto itemDto, Game entity)
        {
            entity.Update(itemDto.Name, itemDto.Description, itemDto.Price, itemDto.PhotoUri, itemDto.IconUri);
        }
    }
}