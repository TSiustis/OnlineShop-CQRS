using FluentValidation;

namespace OnlineShop.Application.Products.Queries.GetProduct;
public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
