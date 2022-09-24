using FluentValidation;

namespace OnlineShop.Application.Customer.Queries.GetCustomer;
public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}
