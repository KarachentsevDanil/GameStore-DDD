using AutoMapper;
using GSP.Account.Application.CQS.Bus.Messages;
using GSP.Account.Application.CQS.Commands;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Domain.Entities;
using GSP.Account.Domain.Events;

namespace GSP.Account.Application.Configurations.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<AccountBase, GetAccountDto>();

            CreateMap<CreateAccountCommand, CreateAccountDto>();

            CreateMap<LoginToAccountCommand, LoginAccountDto>();

            CreateMap<UpdateAccountCommand, UpdateAccountDto>();

            CreateMap<AccountUpdatedEvent, AccountUpdatedMessage>();

            CreateMap<GetAccountDto, AccountCreatedMessage>();
        }
    }
}