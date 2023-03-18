///<summary>
///Handler for UpdateProductCommand.
/// </summary>
using MediatR;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Products.Commands.UpdateProduct;

using OnlineShop.Domain.Events;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IWriteRepository<Product> _productWriteRepository;

    public UpdateProductCommandHandler(IWriteRepository<Product> productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Id, request.Name, request.Description, request.Price, request.Stock, request.Category);

        _productWriteRepository.Update(product);

        product.DomainEvents.Add(new ProductUpdated(product));

        await _productWriteRepository.SaveChanges(cancellationToken);

        return Unit.Value;
    }
}
