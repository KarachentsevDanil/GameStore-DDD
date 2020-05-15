using GSP.Shared.Utils.WebApi.Extensions;
using GSP.WepApi.Aggregator.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.WepApi.Aggregator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseAggregatorApiExceptionHandler();
            app.UseGspApiAggregatorApplicationBuilder<Startup>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspWebApiAggregator<Startup>(Configuration);
            services.AddWepApiAggregator(Configuration);
        }
    }
}
