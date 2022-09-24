using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Order.Queries.GetOrder;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Orders.GetOrder;
public class GetOrderQueryHandlerTests
{
    private readonly Mock<IReadRepository<Order>> _orderReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetOrderQueryHandlerTests()
    {
        _orderReadRepositoryMock = new Mock<IReadRepository<Order>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new OrderProfile()); //your automapperprofile 
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_RetrievesOrder()
    {
        // Arrange
        int id = 1;
        var order = _fixture.Create<Order>();

        var command = new GetOrderQuery(id);

        _orderReadRepositoryMock
            .Setup(call => call.Get(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        var sut = new GetOrderQueryHandler(_orderReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _orderReadRepositoryMock.Verify(
            call => call.Get(id, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNoOrdersInDatabase_ThrowsNotFoundError()
    {
        // Arrange
        int id = 1;
        var command = new GetOrderQuery(id);

        _orderReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()));

        var sut = new GetOrderQueryHandler(_orderReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () => await sut.Handle(command, CancellationToken.None);


        // Assert
        _orderReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
