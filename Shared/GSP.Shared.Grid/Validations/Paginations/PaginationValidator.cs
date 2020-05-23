using FluentValidation;
using GSP.Shared.Grid.Pagination.Models;

namespace GSP.Shared.Grid.Validations.Paginations
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