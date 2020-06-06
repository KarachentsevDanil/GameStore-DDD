using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class DateFilterValidator : AbstractValidator<Filter>
    {
        public DateFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.DateFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.SelectedStartDate)
                .NotNull()
                .When(p => p.DateFilterOption == DateFilterOption.DateRange);

            RuleFor(p => p.SelectedEndDate)
                .NotNull()
                .When(p => p.DateFilterOption == DateFilterOption.DateRange);

            RuleFor(p => p)
                .Must(p => IsDateTimeProperty(gridTypeModel, p.PropertyName))
                .WithMessage($"Only date time properties are allowed for this type of filer {gridTypeModel.DateTimeProperties.ToStringList()}.");
        }

        private static bool IsDateTimeProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.DateTimeProperties.Contains(propertyName);
        }
    }
}