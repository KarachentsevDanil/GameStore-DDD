using AutoMapper;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Domain.Account.Entities;

namespace GSP.Order.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateAccountCommand, AddAccountDto>();
            CreateMap<UpdateAccountCommand, UpdateAccountDto>();
            CreateMap<SharedAccount, GetAccountDto>();
        }
    }
}