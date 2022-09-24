using FluentValidation;

namespace OnlineShop.Application.Customer.Commands.DeleteCustomer;
public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}
