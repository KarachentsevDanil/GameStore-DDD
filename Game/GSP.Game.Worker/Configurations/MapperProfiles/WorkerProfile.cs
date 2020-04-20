using AutoMapper;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Worker.Commands;

namespace GSP.Game.Worker.Configurations.MapperProfiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<GameOrdersCountUpdatedCommand, UpdateGameOrdersCountCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.GameId))
                .ForMember(p => p.OrdersCount, opt => opt.MapFrom(p => p.CountOfOrders));

            CreateMap<GameRatingUpdatedCommand, UpdateGameRatingCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.GameId))
                .ForMember(p => p.ReviewsCount, opt => opt.MapFrom(p => p.CountOfReviews));
        }
    }
}