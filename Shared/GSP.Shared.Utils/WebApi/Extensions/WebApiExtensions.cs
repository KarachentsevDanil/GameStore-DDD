using FluentValidation.AspNetCore;
using GSP.Shared.Utils.WebApi.Sessions.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class WebApiExtensions
    {
        public static IServiceCollection AddWebApi<TStartup>(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<TStartup>();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwagger();

            services.AddJwtBearerAuthentication(configuration);

            services.AddMediatR(typeof(TStartup).Assembly);

            services.AddGspSession();

            return services;
        }
    }
}