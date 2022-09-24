using FluentValidation;

namespace OnlineShop.Application.Order.Commands.AddOrder;
public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(command => command.Address)
            .NotNull();

        RuleFor(command => command.Amount)
            .GreaterThan(0)
            .NotNull();

        RuleFor(command => command.Items)
            .NotEmpty();

        RuleFor(command => command.PaymentType)
            .NotNull();

        RuleFor(command => command.ShippedAt)
            .NotNull();
    }
}
