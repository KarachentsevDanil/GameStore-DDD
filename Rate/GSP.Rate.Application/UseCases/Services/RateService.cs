using AutoMapper;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Models;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.UseCases.Services
{
    public class RateService : BaseService<IRateUnitOfWork, RateBase, GetRateDto, AddRateDto, UpdateRateDto>, IRateService
    {
        public RateService(IRateUnitOfWork unitOfWork, IBaseRepository<RateBase> repository, IMapper mapper, ILogger<RateBase> logger)
            : base(unitOfWork, repository, mapper, logger)
        {
        }

        public async ValueTask<double> GetAverageRatingByGameIdAsync(long gameId, CancellationToken ct = default)
        {
            Logger.LogInformation("Get average rating by game={GameId}", gameId);

            return await UnitOfWork.RateRepository.GetAverageRatingByGameIdAsync(gameId, ct);
        }

        public async ValueTask<int> GetCountOfReviewByGameIdAsync(long gameId, CancellationToken ct = default)
        {
            Logger.LogInformation("Get count of ratings by game={GameId}", gameId);

            return await UnitOfWork.RateRepository.GetCountByGameIdAsync(gameId, ct);
        }

        public async Task<PagedCollection<GetRateDto>> GetListByFilterParamsAsync(RateFilterParams filterParams, CancellationToken ct = default)
        {
            Logger.LogInformation("Get list of ratings by filterParams={@FilterParams}", filterParams);

            var dbResult = await UnitOfWork.RateRepository.GetByFilterParamsAsync(filterParams, ct);

            var ratings = Mapper.Map<ICollection<GetRateDto>>(dbResult.Items).ToImmutableList();

            return new PagedCollection<GetRateDto>(ratings, dbResult.TotalCount);
        }

        protected override RateBase MapEntity(AddRateDto addItemDto)
        {
            return RateBase.Create(addItemDto.GameId, addItemDto.AccountId, addItemDto.Comment, addItemDto.Rating);
        }

        protected override void UpdateEntity(UpdateRateDto updateItemDto, RateBase entity)
        {
            entity.Update(updateItemDto.Comment, updateItemDto.Rating);
        }
    }
}