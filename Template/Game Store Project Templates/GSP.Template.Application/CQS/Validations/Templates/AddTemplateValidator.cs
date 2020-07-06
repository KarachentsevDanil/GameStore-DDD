using FluentValidation;
using GSP.Template.Application.CQS.Commands.Templates;
using static GSP.Template.Data.Context.Constants.DbColumnConstraintConstants;

namespace GSP.Template.Application.CQS.Validations.Templates
{
    public class AddTemplateValidator : AbstractValidator<AddTemplateCommand>
    {
        public AddTemplateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}