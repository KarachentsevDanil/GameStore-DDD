using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class ListFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public ListFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.ListFilterOption)
                .NotNull()
                .IsInEnum();

            RuleForEach(p => p.Values)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p)
                .Must(p => IsTextProperty(gridTypeModel, p.PropertyName))
                .WithMessage($"Only text properties are allowed for this type of filer {gridTypeModel.TextProperties.ToStringList()}.");
        }

        private bool IsTextProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.TextProperties.Contains(propertyName);
        }
    }
}