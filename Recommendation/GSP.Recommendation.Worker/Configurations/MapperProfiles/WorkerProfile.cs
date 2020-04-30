using AutoMapper;
using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.Worker.Commands;

namespace GSP.Recommendation.Worker.Configurations.MapperProfiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<GameOrdersCountUpdatedCommand, UpdateGameOrderCountCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.GameId))
                .ForMember(p => p.OrderCount, opt => opt.MapFrom(p => p.CountOfOrders));

            CreateMap<GameRatingUpdatedCommand, UpdateGameRatingCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.GameId))
                .ForMember(p => p.ReviewCount, opt => opt.MapFrom(p => p.CountOfReviews));
        }
    }
}