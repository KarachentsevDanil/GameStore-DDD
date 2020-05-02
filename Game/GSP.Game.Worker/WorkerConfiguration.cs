using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using GSP.Game.Data.Context;
using GSP.Game.Worker.Commands;
using GSP.Game.Worker.Constants;
using GSP.Game.Worker.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Base.Constants;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.Worker.Extensions;
using Microsoft.Extensions.Configuration;

namespace GSP.Game.Worker
{
    public class WorkerConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .SetupApplication((serviceCollection, commandRegistry, c) =>
                {
                    IConfiguration config = (IConfiguration)c;

                    serviceCollection.ConfigureDatabase<GameDbContext>(config);

                    serviceCollection.RegisterCoreDependencies();

                    serviceCollection.RegisterApplicationDependencies();

                    serviceCollection.RegisterAzureServiceBus(config);

                    commandRegistry.Discover<WorkerConfiguration>();
                })
                .Authorization(authorization => authorization
                    .AuthorizationDefault(AuthorizationTypeEnum.Function))
                .Functions(functions => functions
                    .ServiceBus(ServiceBusConstants.ConnectionName, serviceBus => serviceBus
                        .SubscriptionFunction<GameOrdersCountUpdatedCommand>(
                            AzureServiceBusConstants.GameTopicName,
                            AzureServiceBusConstants.GameOrdersCountUpdatedSubscription)
                        .SubscriptionFunction<GameRatingUpdatedCommand>(
                            AzureServiceBusConstants.GameTopicName,
                            AzureServiceBusConstants.GameRatingUpdatedSubscription)));
        }
    }
}
