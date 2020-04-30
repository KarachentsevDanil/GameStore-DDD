using AutoMapper;
using GSP.Recommendation.Application.CQS.Queries.Recommendations;
using GSP.Recommendation.Application.UseCases.DTOs.Recommendations;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.CQS.Handlers.Queries.Recommendations
{
    public class GetRecommendedGamesQueryHandler : BaseResponseHandler<GetRecommendedGamesQuery, IEnumerable<long>>
    {
        private readonly IMapper _mapper;

        private readonly IRecommendationService _recommendationService;

        public GetRecommendedGamesQueryHandler(
            ILogger<GetRecommendedGamesQuery> logger,
            IMapper mapper,
            IRecommendationService recommendationService)
            : base(logger)
        {
            _mapper = mapper;
            _recommendationService = recommendationService;
        }

        protected override async Task<IEnumerable<long>> ExecuteAsync(GetRecommendedGamesQuery request, CancellationToken ct)
        {
            GetRecommendedGamesQueryDto queryDto = _mapper.Map<GetRecommendedGamesQueryDto>(request);
            return await _recommendationService.GetRecommendedGamesAsync(queryDto, ct);
        }
    }
}