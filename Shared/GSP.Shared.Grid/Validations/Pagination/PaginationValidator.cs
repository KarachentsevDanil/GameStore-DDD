using FluentValidation;
using GSP.Shared.Grid.Models.Pagination;

namespace GSP.Shared.Grid.Validations.Pagination
{
    public class PaginationValidator : AbstractValidator<PaginationModel>
    {
        public PaginationValidator()
        {
            RuleFor(p => p.PageNumber)
                .GreaterThan(0);

            RuleFor(p => p.PageSize)
                .GreaterThan(0);
        }
    }
}