using FluentValidation;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Models;
using GSP.Shared.Grid.Validations.Filters;

namespace GSP.Shared.Grid.Validations.Columns
{
    public class ColumnValidator<TGridColumn, TFilterType> : AbstractValidator<TGridColumn>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        public ColumnValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsPropertyNameExists(gridTypeModel, p))
                .WithMessage($"You can use only {gridTypeModel.PropertyNames.ToStringList()} properties for column.");

            RuleFor(p => p)
                .Must(p => IsTotalCalculationAllowed(gridTypeModel, p.PropertyName))
                .When(p => p.IsCalculateTotalNeeded)
                .WithMessage($"Total calculation allowed only for {gridTypeModel.CalculablePropertyNames.ToStringList()} properties.");

            RuleFor(p => p.Direction)
                .IsInEnum()
                .When(p => p.Direction.HasValue);

            RuleFor(p => p)
                .Must(p => IsSortingAllowed(gridTypeModel, p.PropertyName))
                .When(p => p.Direction.HasValue)
                .WithMessage($"Sorting allowed only for {gridTypeModel.SortablePropertyNames.ToStringList()} properties.");

            RuleFor(p => p)
                .Must(p => IsFilteringAllowed(gridTypeModel, p.PropertyName))
                .When(p => p.Filter != null)
                .WithMessage($"Filtering allowed only for {gridTypeModel.SortablePropertyNames.ToStringList()} properties.");

            RuleFor(p => p.Filter)
                .SetValidator(new BaseFilterValidator<TFilterType>(gridTypeModel))
                .When(p => p.Filter != null);
        }

        private bool IsPropertyNameExists(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.PropertyNames.Contains(propertyName);
        }

        private bool IsTotalCalculationAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.PropertyNames.Contains(propertyName);
        }

        private bool IsSortingAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.SortablePropertyNames.Contains(propertyName);
        }

        private bool IsFilteringAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.FilterablePropertyNames.Contains(propertyName);
        }
    }
}