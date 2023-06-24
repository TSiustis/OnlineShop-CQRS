using FluentValidation;

namespace OnlineShop.Application.Products.Queries.GetProducts;
public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(query => query.PageNumber)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(query => query.PageSize)
            .NotEmpty()
            .GreaterThan(1);
        RuleFor(query => query.SearchQuery)
            .NotEmpty()
            .NotNull();
    }
}
