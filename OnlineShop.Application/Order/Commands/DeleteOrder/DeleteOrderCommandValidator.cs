using FluentValidation;

namespace OnlineShop.Application.Order.Commands.DeleteOrder;
public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}
