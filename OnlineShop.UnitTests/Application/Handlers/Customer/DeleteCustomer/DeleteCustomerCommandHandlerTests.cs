namespace OnlineShop.UnitTests.Application.Handlers.Customer.DeleteCustomer;

using Moq;
using Domain.Interfaces;
using Xunit;
using Domain.Entities.Customers;
using OnlineShop.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Customer>> _customerWriteRepositoryMock;

    public DeleteCustomerCommandHandlerTests()
    {
        _customerWriteRepositoryMock = new Mock<IWriteRepository<Customer>>();
    }

    [Fact]
    public async Task Handle_WhenPayloadIsValid_DeletesCustomerFromDatabase()
    {
        // Arrange
        int id = 1;
        var command = new DeleteCustomerCommand(id);

        _customerWriteRepositoryMock
            .Setup(call => call.Delete(id))
            .Verifiable();

        _customerWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new DeleteCustomerCommandHandler(_customerWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _customerWriteRepositoryMock.Verify(
            call => call.Delete(id),
            Times.Once);

        _customerWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
