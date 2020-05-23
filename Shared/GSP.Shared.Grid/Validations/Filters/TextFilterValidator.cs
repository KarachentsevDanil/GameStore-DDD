using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class TextFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public TextFilterValidator()
        {
            RuleFor(p => p.TextFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.Value)
                .NotNull()
                .NotEmpty()
                .When(p => p.TextFilterOption != TextFilterOption.Blank && p.TextFilterOption != TextFilterOption.NotBlank);
        }
    }
}