using AutoMapper;
using FluentValidation;
using GSP.Order.Application.Configurations.MapperProfiles;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.CQS.Validations.Orders;
using GSP.Order.Application.UseCases.Services;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.Account.Configurations.MapperProfiles;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GSP.Order.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrderApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile), typeof(AccountApplicationProfile));

            serviceCollection.AddCache(configuration);

            serviceCollection.AddScoped<IAccountService, AccountService<IOrderUnitOfWork>>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();

            serviceCollection.TryAddSingleton<IValidator<AddOrderToGameCommand>, AddOrderToGameValidator>();
            serviceCollection.TryAddSingleton<IValidator<RemoveOrderToGameCommand>, RemoveOrderToGameValidator>();

            return serviceCollection;
        }
    }
}