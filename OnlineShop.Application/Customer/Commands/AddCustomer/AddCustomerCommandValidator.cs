using FluentValidation;

namespace OnlineShop.Application.Customer.Commands.AddCustomer;
public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
{
    public AddCustomerCommandValidator()
    {
        RuleFor(query => query.FirstName)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(query => query.LastName)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(query => query.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(query => query.PhoneNumber)
            .NotEmpty()
            .MaximumLength(15);
    }
}
