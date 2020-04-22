using AutoMapper;
using GSP.Rate.Application.Configurations.MapperProfiles;
using GSP.Rate.Application.UseCases.Services;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Data.UnitOfWorks;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Worker.Account.Configurations.MapperProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.Worker.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRateUnitOfWork, RateUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile), typeof(AccountWorkerProfile));
            serviceCollection.AddScoped<IAccountService, AccountService<RateUnitOfWork>>();
            serviceCollection.AddScoped<IRateService, RateService>();

            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly);

            return serviceCollection;
        }
    }
}