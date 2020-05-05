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

            CreateMap<UpdateGameOrderCountCommand, UpdateGameOrdersCountDto>()
                .ForMember(p => p.GameId, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.OrdersCount, m => m.MapFrom(p => p.OrderCount));

            CreateMap<UpdateGameRatingCommand, UpdateGameRatingDto>()
                .ForMember(p => p.GameId, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.ReviewsCount, m => m.MapFrom(p => p.ReviewCount));

            CreateMap<CreateOrderCommand, AddOrderDto>();

            CreateMap<GetRecommendedGamesQuery, GetRecommendedGamesQueryDto>();
        }
    }
}