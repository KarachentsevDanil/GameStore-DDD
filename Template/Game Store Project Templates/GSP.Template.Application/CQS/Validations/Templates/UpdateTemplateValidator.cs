using FluentValidation;
using GSP.Template.Application.CQS.Commands.Templates;
using static GSP.Template.Data.Context.Constants.DbColumnConstraintConstants;

namespace GSP.Template.Application.CQS.Validations.Templates
{
    public class UpdateTemplateValidator : AbstractValidator<UpdateTemplateCommand>
    {
        public UpdateTemplateValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}