using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Searching;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Searches
{
    public class SearchValidator : AbstractValidator<SearchModel>
    {
        public SearchValidator(GridTypeModel gridTypeModel)
        {
            RuleForEach(p => p.SearchFields)
                .NotEmpty()
                .Must(p => IsSearchFieldValid(p, gridTypeModel))
                .WithMessage($"You can search only by these {gridTypeModel.TextProperties.ToStringList()} properties.");
        }

        private bool IsSearchFieldValid(string field, GridTypeModel gridTypeModel)
        {
            return gridTypeModel.TextProperties.Contains(field);
        }
    }
}