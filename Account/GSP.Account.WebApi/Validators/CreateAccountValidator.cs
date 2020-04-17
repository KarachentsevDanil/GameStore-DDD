﻿using FluentValidation;
using GSP.Account.WebApi.Commands;

namespace GSP.Account.WebApi.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(t => t.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(t => t.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(t => t.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(t => t.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }
}