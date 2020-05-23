using FluentValidation;
using GSP.Shared.Grid.Searching;

namespace GSP.Shared.Grid.Validations.Searches
{
    public class SearchValidator : AbstractValidator<SearchModel>
    {
        public SearchValidator()
        {
            RuleForEach(p => p.SearchFields)
                .NotEmpty();
        }
    }
}