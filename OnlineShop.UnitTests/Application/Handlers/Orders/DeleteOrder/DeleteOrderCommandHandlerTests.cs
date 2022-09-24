namespace OnlineShop.UnitTests.Application.Handlers.Orders.DeleteOrder;

using Moq;
using OnlineShop.Domain.Interfaces;
using Xunit;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Application.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Order>> _orderWriteRepositoryMock;

    public DeleteOrderCommandHandlerTests()
    {
        _orderWriteRepositoryMock = new Mock<IWriteRepository<Order>>();
    }

    [Fact]
    public async Task Handle_WhenPayloadIsValid_DeletesOrderFromDatabase()
    {
        // Arrange
        int id = 1;

        var command = new DeleteOrderCommand(id);

        _orderWriteRepositoryMock
            .Setup(call => call.Delete(id))
            .Verifiable();

        _orderWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new DeleteOrderCommandHandler(_orderWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _orderWriteRepositoryMock.Verify(
            call => call.Delete(id),
            Times.Once);

        _orderWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
