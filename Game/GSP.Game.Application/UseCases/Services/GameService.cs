using AutoMapper;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Entities.ValueObjects;
using GSP.Game.Domain.Models.FilterParams;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.UseCases.Services
{
    public class GameService : BaseService<IGameUnitOfWork, GameBase, GetGameDto, AddGameDto, UpdateGameDto>, IGameService
    {
        public GameService(IGameUnitOfWork unitOfWork, IBaseRepository<GameBase> repository, IMapper mapper, ILogger<GameBase> logger)
            : base(unitOfWork, repository, mapper, logger)
        {
        }

        public async Task<PagedCollection<GetGameDto>> GetPagedListAsync(GameFilterParamsDto filterParams, CancellationToken ct = default)
        {
            Logger.LogInformation("Game games by filter params {FilterParams}", filterParams);

            GameFilterParams dbFilterParams = Mapper.Map<GameFilterParams>(filterParams);

            PagedCollection<GameBase> dbGames =
                await UnitOfWork.GameRepository.GetByFilterParamsAsync(dbFilterParams, ct);

            return new PagedCollection<GetGameDto>(Mapper.Map<ICollection<GetGameDto>>(dbGames.Items).ToImmutableList(), dbGames.TotalCount);
        }

        protected override GameBase MapEntity(AddGameDto addItemDto)
        {
            GameDetailsDto details = addItemDto.GameDetails;

            GameDetails dbGameDetails =
                new GameDetails(details.Name, details.Price, details.Description, details.ReleaseDate, details.AgeRestrictionSystem);

            GameBase game = new GameBase(addItemDto.GenreId, addItemDto.DeveloperStudioId, addItemDto.PublisherId, dbGameDetails);

            game.AddAttachments(addItemDto.Attachments.Select(t => new GameAttachment(t.Type, t.LinkUri, t.Description)).ToList());

            return game;
        }

        protected override void UpdateEntity(UpdateGameDto updateItemDto, GameBase entity)
        {
            GameDetailsDto details = updateItemDto.GameDetails;
            entity.Update(updateItemDto.GenreId, updateItemDto.DeveloperStudioId, updateItemDto.PublisherId);
            entity.GameDetails.UpdateGameDetails(details.Name, details.Price, details.Description, details.ReleaseDate, details.AgeRestrictionSystem);
        }
    }
}