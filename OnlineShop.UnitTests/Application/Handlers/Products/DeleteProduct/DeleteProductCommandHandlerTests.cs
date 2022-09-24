using AutoFixture;
using Moq;
using OnlineShop.Application.Products.Commands.DeleteProduct;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.DeleteProduct;
public class DeleteProductCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Product>> _productWriteRepositoryMock;
    private readonly Fixture _fixture = new();

    public DeleteProductCommandHandlerTests()
    {
        _productWriteRepositoryMock = new Mock<IWriteRepository<Product>>();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_DeletesProductFromDatabase()
    {
        // Arrange
        int id = 1;

        var command = new DeleteProductCommand(id);

        _productWriteRepositoryMock
            .Setup(call => call.Delete(id))
            .Verifiable();

        _productWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new DeleteProductCommandHandler(_productWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _productWriteRepositoryMock.Verify(
            call => call.Delete(id),
            Times.Once);

        _productWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
