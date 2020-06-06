using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class NumberFilterValidator : AbstractValidator<Filter>
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

        private static bool IsNumericProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.NumericProperties.Contains(propertyName);
        }
    }
}