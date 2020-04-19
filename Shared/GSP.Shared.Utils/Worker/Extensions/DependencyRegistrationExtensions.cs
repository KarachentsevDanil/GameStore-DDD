using GSP.Shared.Utils.Worker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.Worker.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static FunctionSettings RegisterFunctionSettings(
            this IServiceCollection services,
            IConfiguration config)
        {
            bool isDebug = config.GetValue("IsDebug", true);
            FunctionSettings settings = new FunctionSettings(isDebug);

            services.AddSingleton(settings);

            return settings;
        }
    }
}