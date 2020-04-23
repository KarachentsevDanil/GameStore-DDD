using AutoMapper;
using GSP.Order.Application.Configurations.MapperProfiles;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Application.UseCases.Services;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.Data.UnitOfWorks;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Order.Worker.Configurations.MapperProfiles;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Worker.Account.Configurations.MapperProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.Worker.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile), typeof(AccountWorkerProfile), typeof(WorkerProfile));
            serviceCollection.AddScoped<IAccountService, AccountService<OrderUnitOfWork>>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();

            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly, typeof(CreateGameCommand).Assembly);

            return serviceCollection;
        }
    }
}