using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class NumberFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public NumberFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.NumberFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.Value)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption != NumberFilterOption.Between);

            RuleFor(p => p.FirstOperand)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption == NumberFilterOption.Between);

            RuleFor(p => p.SecondOperand)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption == NumberFilterOption.Between);

            RuleFor(p => p)
                .Must(p => IsNumericProperty(gridTypeModel, p.PropertyName))
                .WithMessage($"Only numeric properties are allowed for this type of filer {gridTypeModel.NumericProperties.ToStringList()}.");
        }

        private bool IsNumericProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.DateTimeProperties.Contains(propertyName);
        }
    }
}