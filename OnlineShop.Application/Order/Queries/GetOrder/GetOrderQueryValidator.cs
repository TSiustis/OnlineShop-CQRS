///<summary>
///Validator for GetOrderQuery.
/// </summary>
namespace OnlineShop.Application.Order.Queries.GetOrder
{
    using FluentValidation;

    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
