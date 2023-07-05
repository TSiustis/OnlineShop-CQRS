using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Products.Queries.GetProduct;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.GetProduct;
public class GetProductQueryHandlerTests
{
    private readonly Mock<IReadRepository<Product>> _productReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetProductQueryHandlerTests()
    {
        _productReadRepositoryMock = new Mock<IReadRepository<Product>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductProfile()); 
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_RetrievesProductFromDatabase()
    {
        // Arrange
        const int id = 1;
        var product = _fixture.Create<Product>();

        var command = new GetProductQuery(id);

        _productReadRepositoryMock
            .Setup(call => call.Get(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);

        var sut = new GetProductQueryHandler(_productReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _productReadRepositoryMock.Verify(
            call => call.Get(id, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNoProductsInDatabase_ThrowsNotFoundError()
    {
        // Arrange
        const int id = 1;

        var command = new GetProductQuery(id);

        _productReadRepositoryMock
            .Setup(call => call.Get(id, It.IsAny<CancellationToken>()));

        var sut = new GetProductQueryHandler(_productReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        _productReadRepositoryMock.Verify(
            call => call.Get(id, It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
