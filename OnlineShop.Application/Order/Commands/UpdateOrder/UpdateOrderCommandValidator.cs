///<summary>
///Validator for UpdateOrderCommand.
/// </summary>
namespace OnlineShop.Application.Order.Commands.UpdateOrder;

using FluentValidation;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
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
