namespace OnlineShop.UnitTests.Application.Handlers.Orders.AddOrder;

using AutoFixture;
using Moq;
using OnlineShop.Domain.Interfaces;
using Xunit;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Application.Order.Commands.AddOrder;
using OnlineShop.Application.Order.Dto;
using AutoMapper;
using OnlineShop.Application.Profiles;

public class AddOrderCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Order>> _orderWriteRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public AddOrderCommandHandlerTests()
    {
        _orderWriteRepositoryMock = new Mock<IWriteRepository<Order>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductProfile());
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_SavesOrderToDatabase()
    {
        // Arrange
        var orderInputDto = _fixture.Create<OrderInputDto>();

        var command = new AddOrderCommand(orderInputDto);

        _orderWriteRepositoryMock
            .Setup(call => call.Add(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        _orderWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new AddOrderCommandHandler(_orderWriteRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _orderWriteRepositoryMock.Verify(
            call => call.Add(It.IsAny<Order>(), It.IsAny<CancellationToken>()),
            Times.Once);

        _orderWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
