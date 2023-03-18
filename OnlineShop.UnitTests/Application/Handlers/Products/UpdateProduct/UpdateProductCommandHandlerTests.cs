using AutoFixture;
using Moq;
using OnlineShop.Application.Products.Commands.UpdateProduct;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.UpdateProduct;
public class UpdateProductCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Product>> _productWriteRepositoryMock;
    private readonly Fixture _fixture = new();

    public UpdateProductCommandHandlerTests()
    {
        _productWriteRepositoryMock = new Mock<IWriteRepository<Product>>();
    }

    [Fact]
    public async Task Handle_WhenPayloadIsValid_UpdatesProductInDatabase()
    {
        // Arrange
        var productInputDto = _fixture.Create<ProductInputDto>();

        var command = new UpdateProductCommand(productInputDto);

        _productWriteRepositoryMock
            .Setup(call => call.Update(It.IsAny<Product>()))
            .Verifiable();

        _productWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new UpdateProductCommandHandler(_productWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _productWriteRepositoryMock.Verify(
            call => call.Update(It.IsAny<Product>()),
            Times.Once);

        _productWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
