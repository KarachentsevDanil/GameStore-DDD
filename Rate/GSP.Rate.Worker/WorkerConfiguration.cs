using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using GSP.Rate.Data.Context;
using GSP.Rate.Worker.Constants;
using GSP.Rate.Worker.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Base.Constants;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.Worker.Account.Commands;
using GSP.Shared.Utils.Worker.Extensions;
using Microsoft.Extensions.Configuration;

namespace GSP.Rate.Worker
{
    public class WorkerConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .SetupApplication((serviceCollection, commandRegistry, c) =>
                {
                    IConfiguration config = (IConfiguration)c;

                    serviceCollection.ConfigureDatabase<RateDbContext>(config);

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
                            AzureServiceBusConstants.AccountUpdatedSubscription)));
        }
    }
}
