using FluentValidation;
using GSP.Order.Application.CQS.Commands.Orders;

namespace GSP.Order.Application.CQS.Validations.Orders
{
    public class AddOrderToGameValidator : AbstractValidator<AddOrderToGameCommand>
    {
        public AddOrderToGameValidator()
        {
            RuleFor(p => p.AccountId)
                .GreaterThan(0);

            RuleFor(p => p.GameId)
                .GreaterThan(0);
        }
    }
}