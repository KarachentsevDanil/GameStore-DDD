using FluentValidation;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Models;
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
            var gridTypeModel = gridTypeStore.GetGridTypeModel(typeof(TEntity));

            RuleFor(p => p.Pagination)
                .NotNull()
                .SetValidator(new PaginationValidator());

            RuleFor(p => p.Search)
                .SetValidator(new SearchValidator(gridTypeModel));

            RuleFor(p => p.Columns)
                .NotNull();

            RuleForEach(p => p.Columns)
                .SetValidator(new ColumnValidator<TGridColumn, TFilterType>(gridTypeModel));

            RuleForEach(p => p.IncludeEntities)
                .NotEmpty()
                .Must(p => IsIncludedEntityValid(gridTypeModel, p))
                .WithMessage($"You can include only {gridTypeModel.IncludedEntities.ToStringList()} entities.");
        }

        private bool IsIncludedEntityValid(GridTypeModel gridTypeModel, string includedEntity)
        {
            return gridTypeModel.IncludedEntities.Contains(includedEntity);
        }
    }
}