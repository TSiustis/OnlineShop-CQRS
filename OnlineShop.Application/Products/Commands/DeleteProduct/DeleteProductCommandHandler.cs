///<summary>
///Handler for DeleteProductCommand.
/// </summary>
using MediatR;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IWriteRepository<Domain.Entities.Products.Product> _productRepository;

    public DeleteProductCommandHandler(IWriteRepository<Domain.Entities.Products.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _productRepository.Delete(request.Id);

        await _productRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
