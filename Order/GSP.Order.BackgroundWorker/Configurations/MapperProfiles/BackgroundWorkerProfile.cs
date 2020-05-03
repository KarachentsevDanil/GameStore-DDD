using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.BackgroundWorker.Events.Accounts;
using GSP.Order.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Application.Account.CQS.Commands;

namespace GSP.Order.BackgroundWorker.Configurations.MapperProfiles
{
    public class BackgroundWorkerProfile : Profile
    {
        public BackgroundWorkerProfile()
        {
            CreateMap<AccountCreatedEvent, CreateAccountCommand>();
            CreateMap<AccountUpdatedEvent, UpdateAccountCommand>();

            CreateMap<GameCreatedEvent, CreateGameCommand>();
            CreateMap<GameUpdatedEvent, UpdateGameCommand>();
        }
    }
}