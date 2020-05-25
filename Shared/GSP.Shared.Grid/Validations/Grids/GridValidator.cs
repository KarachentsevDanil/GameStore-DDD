using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Stores.Contracts;
using GSP.Shared.Grid.Stores.Models;
using GSP.Shared.Grid.Validations.Filters;
using GSP.Shared.Grid.Validations.Groups;
using GSP.Shared.Grid.Validations.Paginations;
using GSP.Shared.Grid.Validations.Searches;
using GSP.Shared.Grid.Validations.Sorting;
using GSP.Shared.Grid.Validations.Summaries;

namespace GSP.Shared.Grid.Validations.Grids
{
    public class GridValidator<TGrid, TEntity, TFilterType> : AbstractValidator<TGrid>
        where TGrid : IGrid<TEntity, TFilterType>
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

            RuleForEach(p => p.Filters)
                .SetValidator(new BaseFilterValidator<TFilterType>(gridTypeModel));

            RuleForEach(p => p.SortingOptions)
                .SetValidator(new SortingValidator(gridTypeModel));

            RuleForEach(p => p.Summaries)
                .SetValidator(new SummaryValidator(gridTypeModel));

            RuleForEach(p => p.GroupSummaries)
                .SetValidator(new GroupSummaryValidator(gridTypeModel));

            RuleForEach(p => p.Groups)
                .SetValidator(new GroupValidator(gridTypeModel));

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