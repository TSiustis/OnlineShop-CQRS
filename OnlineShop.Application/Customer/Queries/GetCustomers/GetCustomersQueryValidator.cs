using FluentValidation;

namespace OnlineShop.Application.Customer.Queries.GetCustomers;
public class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
{
    public GetCustomersQueryValidator()
    {
        RuleFor(query => query.PageNumber)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(query => query.PageSize)
            .NotEmpty()
            .GreaterThan(1);
    }
}