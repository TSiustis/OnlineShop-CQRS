using AutoFixture;
using Moq;
using OnlineShop.Application.Products.Commands.AddProduct;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.AddProduct;
public class AddProductCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Product>> _productWriteRepositoryMock;
    private readonly Fixture _fixture = new();

    public AddProductCommandHandlerTests()
    {
        _productWriteRepositoryMock = new Mock<IWriteRepository<Product>>();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_SavesProductToDatabase()
    {
        // Arrange
        var productInputDto = _fixture.Create<ProductInputDto>();

        var command = new AddProductCommand(productInputDto);

        _productWriteRepositoryMock
            .Setup(call => call.Add(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        _productWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new AddProductCommandHandler(_productWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _productWriteRepositoryMock.Verify(
            call => call.Add(It.IsAny<Product>(), It.IsAny<CancellationToken>()),
            Times.Once);

        _productWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
