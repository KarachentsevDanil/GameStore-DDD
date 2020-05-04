﻿using AutoMapper;
using FluentValidation;
using GSP.Order.Application.Configurations.MapperProfiles;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.CQS.Validations.Orders;
using GSP.Order.Application.UseCases.Services;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.BackgroundWorker.Configurations.MapperProfiles;
using GSP.Order.BackgroundWorker.EventHandlers.Accounts;
using GSP.Order.BackgroundWorker.EventHandlers.Games;
using GSP.Order.BackgroundWorker.EventHandlers.Orders;
using GSP.Order.BackgroundWorker.Events.Accounts;
using GSP.Order.BackgroundWorker.Events.Games;
using GSP.Order.BackgroundWorker.Events.Orders;
using GSP.Order.Data.UnitOfWorks;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.Account.Configurations.MapperProfiles;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.BackgroundWorker.Extensions
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
            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly, typeof(CreateOrderCommand).Assembly);

            serviceCollection.AddAutoMapper(typeof(ApplicationProfile), typeof(AccountApplicationProfile), typeof(BackgroundWorkerProfile));

            serviceCollection.AddScoped<IAccountService, AccountService<IOrderUnitOfWork>>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();

            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountUpdatedEvent>, AccountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameCreatedEvent>, GameCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameUpdatedEvent>, GameUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<OrderPaidEvent>, OrderPaidEventHandler>();

            serviceCollection.AddSingleton<IValidator<AddOrderToGameCommand>, AddOrderToGameValidator>();
            serviceCollection.AddSingleton<IValidator<RemoveOrderToGameCommand>, RemoveOrderToGameValidator>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterBackgroundWorkerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<AccountUpdatedEvent, IIntegrationEventHandler<AccountUpdatedEvent>>>();
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<GameCreatedEvent, IIntegrationEventHandler<GameCreatedEvent>>>();
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<GameUpdatedEvent, IIntegrationEventHandler<GameUpdatedEvent>>>();
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<OrderPaidEvent, IIntegrationEventHandler<OrderPaidEvent>>>();

            return serviceCollection;
        }
    }
}