using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Worker.Commands;

namespace GSP.Order.Worker.Configurations.MapperProfiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<GameCreatedCommand, CreateGameCommand>();
            CreateMap<GameUpdatedCommand, UpdateGameCommand>();
        }
    }
}