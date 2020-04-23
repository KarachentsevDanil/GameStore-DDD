using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using GSP.Order.Data.Context;
using GSP.Order.Worker.Commands;
using GSP.Order.Worker.Constants;
using GSP.Order.Worker.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Constants;
using GSP.Shared.Utils.Common.ServiceBus.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.Worker.Account.Commands;
using GSP.Shared.Utils.Worker.Extensions;
using Microsoft.Extensions.Configuration;

namespace GSP.Order.Worker
{
    public class WorkerConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .SetupApplication((serviceCollection, commandRegistry, c) =>
                {
                    IConfiguration config = (IConfiguration)c;

                    serviceCollection.ConfigureDatabase<OrderDbContext>(config);

                    serviceCollection.RegisterCoreDependencies();

                    serviceCollection.RegisterApplicationDependencies();

                    serviceCollection.RegisterAzureServiceBus(config);

                    commandRegistry.Discover<WorkerConfiguration>();
                })
                .Authorization(authorization => authorization
                    .AuthorizationDefault(AuthorizationTypeEnum.Function))
                .Functions(functions => functions
                    .ServiceBus(ServiceBusConstants.ConnectionName, serviceBus => serviceBus
                        .SubscriptionFunction<AccountCreatedCommand>(
                            AzureServiceBusConstants.AccountTopicName,
                            AzureServiceBusConstants.AccountCreatedSubscription)
                        .SubscriptionFunction<AccountUpdatedCommand>(
                            AzureServiceBusConstants.AccountTopicName,
                            AzureServiceBusConstants.AccountUpdatedSubscription)
                        .SubscriptionFunction<GameCreatedCommand>(
                            AzureServiceBusConstants.GameTopicName,
                            AzureServiceBusConstants.GameCreatedSubscription)
                        .SubscriptionFunction<GameUpdatedCommand>(
                            AzureServiceBusConstants.GameTopicName,
                            AzureServiceBusConstants.GameUpdatedSubscription)));
        }
    }
}