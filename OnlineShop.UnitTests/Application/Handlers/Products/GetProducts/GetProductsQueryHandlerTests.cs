using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Products.Queries.GetProducts;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Orders;
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
        var products = _fixture.CreateMany<Product>()
            .ToList();

        var query = new GetProductsQuery();

        _productReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<PaginationFilter<Product>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaginatedResult<Product>(products, 1, 10, 10));

        var sut = new GetProductsQueryHandler(_productReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(query, CancellationToken.None);


        // Assert
        _productReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<PaginationFilter<Product>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
    
}
