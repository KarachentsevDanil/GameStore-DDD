using AutoMapper;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Worker.Account.Commands;

namespace GSP.Shared.Utils.Worker.Account.Configurations.MapperProfiles
{
    public class AccountWorkerProfile : Profile
    {
        public AccountWorkerProfile()
        {
            CreateMap<AccountCreatedCommand, CreateAccountCommand>();
            CreateMap<AccountUpdatedCommand, UpdateAccountCommand>();
        }
    }
}