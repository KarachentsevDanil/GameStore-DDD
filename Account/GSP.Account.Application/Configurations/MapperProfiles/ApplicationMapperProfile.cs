using AutoMapper;
using GSP.Account.Application.DTOs;
using GSP.Account.Domain.Entities;

namespace GSP.Account.Application.Configurations.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<AccountBase, GetAccountDto>();
        }
    }
}