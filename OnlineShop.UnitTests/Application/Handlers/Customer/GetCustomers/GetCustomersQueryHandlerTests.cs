using AutoFixture;
using Moq;
using Xunit;
using AutoMapper;
using OnlineShop.Application.Profiles;
using OnlineShop.Application.Customer.Queries.GetCustomers;
using FluentAssertions;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.UnitTests.Application.Handlers.Customer.GetCustomers;

public class GetCustomersQueryHandlerTests
{
    private readonly Mock<IReadRepository<Domain.Entities.Customers.Customer>> _customerReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetCustomersQueryHandlerTests()
    {
        _customerReadRepositoryMock = new Mock<IReadRepository<Domain.Entities.Customers.Customer>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomerProfile()); 
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_IfDataInDb_ReturnsAllCustomers()
    {
        // Arrange
        var customers = _fixture.CreateMany<Domain.Entities.Customers.Customer>()
            .ToList();

        var query = new GetCustomersQuery();

        _customerReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<PaginationFilter<Domain.Entities.Customers.Customer>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaginatedResult<Domain.Entities.Customers.Customer>(customers, 1, 10, 10));

        var sut = new GetCustomersQueryHandler(_customerReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(query, CancellationToken.None);

        // Assert
        _customerReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<PaginationFilter<Domain.Entities.Customers.Customer>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
