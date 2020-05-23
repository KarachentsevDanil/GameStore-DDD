using FluentValidation;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Stores.Contracts;
using GSP.Shared.Grid.Validations.Columns;
using GSP.Shared.Grid.Validations.Paginations;
using GSP.Shared.Grid.Validations.Searches;

namespace GSP.Shared.Grid.Validations.Grids
{
    public class GridValidator<TGrid, TEntity, TGridColumn, TFilterType> : AbstractValidator<TGrid>
        where TGrid : IGrid<TEntity, TGridColumn, TFilterType>
        where TGridColumn : IGridColumn<TFilterType>
        where TFilterType : IFilter
    {
        public GridValidator(IGridTypeStore gridTypeStore)
        {
            RuleFor(p => p.Pagination)
                .NotNull()
                .SetValidator(new PaginationValidator());

            RuleFor(p => p.Search)
                .SetValidator(new SearchValidator());

            RuleFor(p => p.Columns)
                .NotNull();

            RuleForEach(p => p.Columns)
                .SetValidator(new ColumnValidator<TGridColumn, TFilterType>());

            RuleForEach(p => p.IncludeEntities)
                .NotEmpty();
        }
    }
}