namespace OnlineShop.UnitTests.Application.Handlers.Customer.GetCustomer;

using AutoFixture;
using Moq;
using Domain.Interfaces;
using Xunit;
using Domain.Entities.Customers;
using AutoMapper;
using OnlineShop.Application.Profiles;
using FluentAssertions;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryHandlerTests
{
    private readonly Mock<IReadRepository<Customer>> _customerReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetCustomerQueryHandlerTests()
    {
        _customerReadRepositoryMock = new Mock<IReadRepository<Customer>>();
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
        const int id = 1;
        var customer = _fixture.Build<Customer>()
            .With(cust => cust.Id, id)
            .Create();

        var query = new GetCustomerQuery(id);

        _customerReadRepositoryMock
            .Setup(call => call.Get(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var sut = new GetCustomerQueryHandler(_customerReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(query, CancellationToken.None);


        // Assert
        _customerReadRepositoryMock.Verify(
            call => call.Get(id, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_IfNoDataInDb_ThrowsNotFoundException()
    {
        // Arrange
        const int id = 1;
        var query = new GetCustomerQuery(id);

        _customerReadRepositoryMock
            .Setup(call => call.Get(id, It.IsAny<CancellationToken>()));

        var sut = new GetCustomerQueryHandler(_customerReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () => await sut.Handle(query, CancellationToken.None);

        // Assert
        _customerReadRepositoryMock.Verify(
            call => call.Get(id, It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
