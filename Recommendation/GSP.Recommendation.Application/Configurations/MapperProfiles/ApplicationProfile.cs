using AutoMapper;
using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.Application.CQS.Commands.Orders;
using GSP.Recommendation.Application.CQS.Queries.Recommendations;
using GSP.Recommendation.Application.UseCases.DTOs.Games;
using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using GSP.Recommendation.Application.UseCases.DTOs.Recommendations;

namespace GSP.Recommendation.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateGameCommand, AddGameDto>();
            CreateMap<UpdateGameOrderCountCommand, UpdateGameOrdersCountDto>();
            CreateMap<UpdateGameRatingCommand, UpdateGameRatingDto>();

            CreateMap<CreateOrderCommand, AddOrderDto>();

            CreateMap<GetRecommendedGamesQuery, GetRecommendedGamesQueryDto>();
        }
    }
}