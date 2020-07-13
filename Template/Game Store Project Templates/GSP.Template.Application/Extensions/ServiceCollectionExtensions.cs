using AutoMapper;
using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Template.Application.Configurations.MapperProfiles;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.CQS.Validations.Templates;
using GSP.Template.Application.UseCases.Services;
using GSP.Template.Application.UseCases.Services.Contracts;
using GSP.Template.Domain.Entities;
using GSP.Template.Domain.Grids;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GSP.Template.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTemplateApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<ITemplateService, TemplateService>();
            serviceCollection.AddGridTypeStore();
            serviceCollection.AddGrid<TemplateBase, TemplateGrid>();
            serviceCollection.TryAddSingleton<IValidator<AddTemplateCommand>, AddTemplateValidator>();
            serviceCollection.TryAddSingleton<IValidator<UpdateTemplateCommand>, UpdateTemplateValidator>();
            return serviceCollection;
        }
    }
}