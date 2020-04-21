using AutoMapper;
using GSP.Rate.Application.CQS.Commands.Accounts;
using GSP.Rate.Application.CQS.Commands.Rates;
using GSP.Rate.Application.CQS.Queries.Rates;
using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Models;

namespace GSP.Rate.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateAccountCommand, AddAccountDto>();
            CreateMap<UpdateAccountCommand, UpdateAccountDto>();
            CreateMap<Account, GetAccountDto>();

            CreateMap<CreateRateCommand, AddRateDto>();
            CreateMap<UpdateRateCommand, UpdateRateDto>();
            CreateMap<GetRateListQuery, RateFilterParams>();
            CreateMap<RateBase, GetRateDto>();
        }
    }
}