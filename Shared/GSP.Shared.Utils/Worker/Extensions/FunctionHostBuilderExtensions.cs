using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace GSP.Shared.Utils.Worker.Extensions
{
    public static class FunctionHostBuilderExtensions
    {
        public static IFunctionHostBuilder SetupApplication(
            this IFunctionHostBuilder hostBuilder,
            Action<IServiceCollection, ICommandRegistry, object> setupAction)
        {
            hostBuilder.Setup((sc, cr) =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                       .AddEnvironmentVariables();

                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IsLocal")))
                {
                    configurationBuilder = configurationBuilder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                }

                IConfiguration config = configurationBuilder.Build();

                sc.AddLogging();

                sc.RegisterFunctionSettings(config);

                setupAction(sc, cr, config);
            });

            return hostBuilder;
        }
    }
}