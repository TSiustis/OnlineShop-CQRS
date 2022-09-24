using FluentValidation;

namespace OnlineShop.Application.Customer.Commands.UpdateCustomer;
public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
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
        RuleFor(query => query.Address)
            .NotNull();
    }
}
