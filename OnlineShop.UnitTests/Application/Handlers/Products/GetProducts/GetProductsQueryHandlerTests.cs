using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Products.Queries.GetProducts;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.GetProducts;
public class GetProductsQueryHandlerTests
{
    private readonly Mock<IReadRepository<Product>> _productReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetProductsQueryHandlerTests()
    {
        _productReadRepositoryMock = new Mock<IReadRepository<Product>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductProfile());
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_RetrievesProductsFromDatabase()
    {
        // Arrange
        var product = _fixture.CreateMany<Product>()
            .ToList();

        var command = new GetProductsQuery();

        _productReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);

        var sut = new GetProductsQueryHandler(_productReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _productReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNoProductsInDatabase_ThrowsNotFoundError()
    {
        // Arrange
        var product = _fixture.CreateMany<Product>()
            .ToList();

        var command = new GetProductsQuery();

        _productReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()));

        var sut = new GetProductsQueryHandler(_productReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () =>  await sut.Handle(command, CancellationToken.None);


        // Assert
        _productReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
