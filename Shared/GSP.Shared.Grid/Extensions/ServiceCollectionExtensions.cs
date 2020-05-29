using FluentValidation;
using GSP.Shared.Grid.Expressions;
using GSP.Shared.Grid.Expressions.Contracts;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Stores;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Stores.Contracts;
using GSP.Shared.Grid.Grids;
using GSP.Shared.Grid.Stores;
using GSP.Shared.Grid.Stores.Contracts;
using GSP.Shared.Grid.Validations.Grids;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Grid.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGridTypeStore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGridTypeStore, GridTypeStore>();
            return serviceCollection;
        }

        public static IServiceCollection AddGrid<TEntity, TGrid>(this IServiceCollection serviceCollection)
            where TGrid : BaseGrid<TEntity>
        {
            serviceCollection.AddSingleton<IFilterExpressionGeneratorStore<TEntity>, FilterExpressionGeneratorStore<TEntity>>();
            serviceCollection.AddSingleton<IGridExpressionGenerator<TEntity>, GridExpressionGenerator<TEntity>>();
            serviceCollection.AddSingleton<IValidator<TGrid>, GridValidator<TGrid, TEntity>>();
            return serviceCollection;
        }
    }
}