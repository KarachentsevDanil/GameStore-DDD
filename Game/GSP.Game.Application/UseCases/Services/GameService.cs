using AutoMapper;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Entities.ValueObjects;
using GSP.Game.Domain.Models.FilterParams;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.UseCases.Services
{
    public class GameService : BaseService<IGameUnitOfWork, GameBase, GetGameDto, AddGameDto, UpdateGameDto>, IGameService
    {
        public GameService(IGameUnitOfWork unitOfWork, IMapper mapper, ILogger<GameBase> logger)
            : base(unitOfWork, unitOfWork.GameRepository, mapper, logger)
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

        public async Task<GetGameDto> UpdateOrdersCountAsync(UpdateGameOrdersCountDto itemDto, CancellationToken ct = default)
        {
            return await UpdateAsync(itemDto, UpdateOrdersCount, ct);
        }

        public async Task<GetGameDto> UpdateRatingAsync(UpdateGameRatingDto itemDto, CancellationToken ct = default)
        {
            return await UpdateAsync(itemDto, UpdateRating, ct);
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
            entity.GameDetails.UpdateGameDetails(details.Name, details.Price, details.Description, details.ReleaseDate, details.AgeRestrictionSystem);
            entity.Update(updateItemDto.GenreId, updateItemDto.DeveloperStudioId, updateItemDto.PublisherId);
        }

        private async Task<GetGameDto> UpdateAsync<TUpdateItem>(
            TUpdateItem item,
            Action<GameBase, TUpdateItem> updateEntity,
            CancellationToken ct)
            where TUpdateItem : BaseUpdateItemDto
        {
            Logger.LogInformation($"Update game with id = {item.Id}");

            GameBase dbEntity = await EntityRepository.GetAsync(item.Id, ct);

            if (dbEntity == null)
            {
                Logger.LogInformation($"Game with id {item.Id} doesn't exist");
                throw new ItemNotFoundException();
            }

            updateEntity(dbEntity, item);

            EntityRepository.Update(dbEntity);

            await UnitOfWork.SaveAsync(ct);

            return Mapper.Map<GetGameDto>(dbEntity);
        }

        private void UpdateOrdersCount(GameBase game, UpdateGameOrdersCountDto itemDto)
        {
            game.GameDetails.UpdateOrderCount(itemDto.OrdersCount);
        }

        private void UpdateRating(GameBase game, UpdateGameRatingDto itemDto)
        {
            game.GameDetails.UpdateRating(itemDto.AverageRating, itemDto.ReviewsCount);
        }
    }
}