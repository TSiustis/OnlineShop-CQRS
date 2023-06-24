using FluentValidation;

namespace OnlineShop.Application.Order.Queries.GetOrders;
public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
{
    public GetOrdersQueryValidator()
    {
        RuleFor(query => query.PageNumber)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(query => query.PageSize)
            .NotEmpty()
            .GreaterThan(1);
    }
}
