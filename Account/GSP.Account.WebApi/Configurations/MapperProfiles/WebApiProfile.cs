using AutoMapper;
using GSP.Account.Application.DTOs;
using GSP.Account.Domain.Events;
using GSP.Account.WebApi.Bus.Messages;
using GSP.Account.WebApi.Commands;

namespace GSP.Account.WebApi.Configurations.MapperProfiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<CreateAccountCommand, CreateAccountDto>();

            CreateMap<LoginToAccountCommand, LoginAccountDto>();

            CreateMap<UpdateAccountCommand, UpdateAccountDto>();

            CreateMap<AccountUpdatedEvent, AccountUpdatedMessage>();
            
            CreateMap<GetAccountDto, AccountCreatedMessage>();
        }
    }
}