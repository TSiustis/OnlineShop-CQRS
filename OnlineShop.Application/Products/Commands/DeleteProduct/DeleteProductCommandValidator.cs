///<summary>
///Validator for DeleteProductCommandValidator.
/// </summary>
using FluentValidation;

namespace OnlineShop.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}
