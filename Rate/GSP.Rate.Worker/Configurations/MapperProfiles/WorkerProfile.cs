using AutoMapper;
using GSP.Rate.Application.CQS.Commands.Accounts;
using GSP.Rate.Worker.Commands;

namespace GSP.Rate.Worker.Configurations.MapperProfiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<AccountCreatedCommand, CreateAccountCommand>();
            CreateMap<AccountUpdatedCommand, UpdateAccountCommand>();
        }
    }
}