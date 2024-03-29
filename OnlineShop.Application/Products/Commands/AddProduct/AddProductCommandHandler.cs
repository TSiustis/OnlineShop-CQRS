﻿///<summary>
///Handler for AddProductComand.
/// </summary>
using MediatR;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Products.Commands.AddProduct;

using OnlineShop.Domain.Events;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly IWriteRepository<Product> _productWriteRepository;

    public AddProductCommandHandler(IWriteRepository<Product> productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }
    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Id, request.Name, request.Description, request.Price, request.Stock, request.Category, request.ImageUri);

        await _productWriteRepository.Add(product, cancellationToken);

        product.DomainEvents.Add(new ProductCreated(product));

        await _productWriteRepository.SaveChanges(cancellationToken);

        product.DomainEvents.Add(new ProductCreated(product));

        return await Unit.Task;
    }
}
