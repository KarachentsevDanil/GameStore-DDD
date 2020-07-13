using AutoMapper;
using $safeprojectname$.CQS.Commands.$domainName$s;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using GSP.$projectPlainName$.Domain.Entities;

namespace $safeprojectname$.Configurations.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<$domainName$Base, Get$domainName$Dto>();
            CreateMap<Add$domainName$Command, Add$domainName$Dto>();
            CreateMap<Update$domainName$Command, Update$domainName$Dto>();
        }
    }
}