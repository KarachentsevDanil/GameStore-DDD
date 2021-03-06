﻿using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class TextFilterValidator : AbstractValidator<Filter>
    {
        public TextFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.TextFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.Value)
                .NotNull()
                .NotEmpty()
                .When(p => p.TextFilterOption != TextFilterOption.Blank && p.TextFilterOption != TextFilterOption.NotBlank);

            RuleFor(p => p)
                .Must(p => IsTextProperty(gridTypeModel, p.PropertyName))
                .WithMessage($"Only text properties are allowed for this type of filer {gridTypeModel.TextProperties.ToStringList()}.");
        }

        private static bool IsTextProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.TextProperties.Contains(propertyName);
        }
    }
}