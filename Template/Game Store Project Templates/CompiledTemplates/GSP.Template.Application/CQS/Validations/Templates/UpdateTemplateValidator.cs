using FluentValidation;
using $safeprojectname$.CQS.Commands.$domainName$s;
using static GSP.$projectPlainName$.Data.Context.Constants.DbColumnConstraintConstants;

namespace $safeprojectname$.CQS.Validations.$domainName$s
{
    public class Update$domainName$Validator : AbstractValidator<Update$domainName$Command>
    {
        public Update$domainName$Validator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}