using FluentValidation;
using $safeprojectname$.CQS.Commands.$domainName$s;
using static GSP.$projectPlainName$.Data.Context.Constants.DbColumnConstraintConstants;

namespace $safeprojectname$.CQS.Validations.$domainName$s
{
    public class Add$domainName$Validator : AbstractValidator<Add$domainName$Command>
    {
        public Add$domainName$Validator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}