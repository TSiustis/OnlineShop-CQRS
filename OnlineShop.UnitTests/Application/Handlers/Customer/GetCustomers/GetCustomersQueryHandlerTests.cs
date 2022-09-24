namespace OnlineShop.UnitTests.Application.Handlers.Customer.GetCustomers;

using AutoFixture;
using Moq;
using OnlineShop.Domain.Interfaces;
using Xunit;
using OnlineShop.Domain.Entities.Customers;
using AutoMapper;
using OnlineShop.Application.Profiles;
using OnlineShop.Application.Customer.Queries.GetCustomers;
using FluentAssertions;
using OnlineShop.Application.Common.CustomExceptions;

public class GetCustomersQueryHandlerTests
{
    private readonly Mock<IReadRepository<Customer>> _customerReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetCustomersQueryHandlerTests()
    {
        _customerReadRepositoryMock = new Mock<IReadRepository<Customer>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomerProfile()); //your automapperprofile 
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_IfDataInDb_ReturnsAllCustomers()
    {
        // Arrange
        var customers = _fixture.CreateMany<Customer>()
            .ToList();

        var command = new GetCustomersQuery();

        _customerReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()))
            .ReturnsAsync(customers);

        var sut = new GetCustomersQueryHandler(_customerReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _customerReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_IfNoDataInDb_ThrowsNotFoundException()
    {
        // Arrange
        var query = new GetCustomersQuery();

        _customerReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()));

        var sut = new GetCustomersQueryHandler(_customerReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () => await sut.Handle(query, CancellationToken.None);

        // Assert
        _customerReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
