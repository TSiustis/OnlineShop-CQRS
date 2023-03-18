///<summary>
///Validator for UpdateProductCommand.
/// </summary>
using FluentValidation;

namespace OnlineShop.Application.Products.Commands.UpdateProduct;
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(255);
    }
}
