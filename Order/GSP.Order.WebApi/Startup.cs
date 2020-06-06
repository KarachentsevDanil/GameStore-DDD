using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.CQS.Validations.Orders;
using GSP.Order.Data.Context;
using GSP.Order.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.WebApi
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
            app.UseGspApplicationBuilder<Startup>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspWebApi<AddOrderToGameValidator, AddOrderToGameCommand>(Configuration);

            services.ConfigureDatabase<OrderDbContext>(Configuration);

            services.RegisterCoreDependencies();

            services.RegisterApplicationDependencies(Configuration);

            services.AddEventBus(Configuration);
        }
    }
}