using AutoMapper;
using GSP.Rate.BackgroundWorker.Events.Accounts;
using GSP.Shared.Utils.Application.Account.CQS.Commands;

namespace GSP.Rate.BackgroundWorker.Configurations.MapperProfiles
{
    public class BackgroundWorkerProfile : Profile
    {
        public BackgroundWorkerProfile()
        {
            CreateMap<AccountCreatedEvent, CreateAccountCommand>();
            CreateMap<AccountUpdatedEvent, UpdateAccountCommand>();
        }
    }
}