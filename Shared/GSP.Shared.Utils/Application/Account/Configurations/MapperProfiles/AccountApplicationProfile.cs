using AutoMapper;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Domain.Account.Entities;

namespace GSP.Shared.Utils.Application.Account.Configurations.MapperProfiles
{
    public class AccountApplicationProfile : Profile
    {
        public AccountApplicationProfile()
        {
            CreateMap<CreateAccountCommand, AddAccountDto>();
            CreateMap<UpdateAccountCommand, UpdateAccountDto>();
            CreateMap<SharedAccount, GetAccountDto>();
        }
    }
}