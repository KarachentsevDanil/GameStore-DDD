using FluentValidation;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Validations.Filters;

namespace GSP.Shared.Grid.Validations.Columns
{
    public class ColumnValidator<TGridColumn, TFilterType> : AbstractValidator<TGridColumn>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        public ColumnValidator()
        {
            RuleFor(p => p.PropertyName)
                .NotEmpty();

            RuleFor(p => p.Filter)
                .SetValidator(new BaseFilterValidator<TFilterType>());
        }
    }
}