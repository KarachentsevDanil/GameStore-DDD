using GSP.Gateway.Configurations;
using GSP.Gateway.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Gateway
{
    public class Startup
    {
        private readonly OcelotConfiguration _ocelotConfiguration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _ocelotConfiguration = configuration.GetOcelotConfiguration();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGspGateway(Configuration, _ocelotConfiguration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseGspGateway(Configuration, _ocelotConfiguration);
        }
    }
}