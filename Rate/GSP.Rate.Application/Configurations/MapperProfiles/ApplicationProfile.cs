using AutoMapper;
using GSP.Rate.Application.CQS.Commands.Rates;
using GSP.Rate.Application.CQS.Queries.Rates;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Models;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Domain.Account.Entities;

namespace GSP.Rate.Application.Configurations.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateAccountCommand, AddAccountDto>();
            CreateMap<UpdateAccountCommand, UpdateAccountDto>();
            CreateMap<SharedAccount, GetAccountDto>();

            CreateMap<CreateRateCommand, AddRateDto>();
            CreateMap<UpdateRateCommand, UpdateRateDto>();
            CreateMap<GetRateListQuery, RateFilterParams>();
            CreateMap<RateBase, GetRateDto>();
        }
    }
}