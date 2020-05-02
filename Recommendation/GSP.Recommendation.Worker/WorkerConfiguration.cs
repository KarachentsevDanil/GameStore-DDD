using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Worker.Commands;
using GSP.Recommendation.Worker.Constants;
using GSP.Recommendation.Worker.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Base.Constants;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.Worker.Extensions;
using Microsoft.Extensions.Configuration;

namespace GSP.Recommendation.Worker
{
    public class WorkerConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .SetupApplication((serviceCollection, commandRegistry, c) =>
                {
                    IConfiguration config = (IConfiguration)c;

                    serviceCollection.ConfigureDatabase<RecommendationDbContext>(config);

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
