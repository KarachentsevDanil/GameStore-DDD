using GSP.WepApi.Aggregator.Configurations;
using GSP.WepApi.Aggregator.Middleware;
using GSP.WepApi.Aggregator.Services;
using GSP.WepApi.Aggregator.Services.Api.Contracts;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Extensions.Http;
using Refit;
using System;

namespace GSP.WepApi.Aggregator.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddWepApiAggregator(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddApiRefitClient<IGameApiClient>(configuration, "GameApi");
            serviceCollection.AddApiRefitClient<IOrderApiClient>(configuration, "OrderApi");
            serviceCollection.AddApiRefitClient<IPaymentHistoryApiClient>(configuration, "PaymentHistoryApi");
            serviceCollection.AddApiRefitClient<IRateApiClient>(configuration, "RateApi");
            serviceCollection.AddApiRefitClient<IRecommendationApiClient>(configuration, "RecommendationApi");

            serviceCollection.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
            serviceCollection.AddScoped<IRateService, RateService>();
            serviceCollection.AddScoped<IRecommendationService, RecommendationService>();

            return serviceCollection;
        }

        public static IServiceCollection AddApiRefitClient<TClient>(
            this IServiceCollection serviceCollection, IConfiguration configuration, string sectionName)
            where TClient : class
        {
            ApiClientConfiguration apiClientConfiguration = new ApiClientConfiguration();
            configuration.Bind(sectionName, apiClientConfiguration);

            RefitSettings refitSettings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(apiClientConfiguration.RetryCount, d => TimeSpan.FromSeconds(apiClientConfiguration.WaitDuration));

            serviceCollection.AddRefitClient<TClient>(refitSettings)
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = apiClientConfiguration.BaseUrl;
                })
                .AddPolicyHandler(retryPolicy);

            return serviceCollection;
        }

        public static IApplicationBuilder UseAggregatorApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebApiAggregatorErrorHandlingMiddleware>();
        }
    }
}