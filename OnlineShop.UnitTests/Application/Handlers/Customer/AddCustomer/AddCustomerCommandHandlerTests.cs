using AutoFixture;
using Moq;
using OnlineShop.Application.Customer.Commands.AddCustomer;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Customer.AddCustomer;

public class AddCustomerCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Domain.Entities.Customers.Customer>> _customerWriteRepositoryMock;
    private readonly Fixture _fixture = new ();

    public AddCustomerCommandHandlerTests()
    {
        _customerWriteRepositoryMock = new Mock<IWriteRepository<Domain.Entities.Customers.Customer>>();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_SavesCustomerToDatabase()
    {

        // Arrange
        var customerInputDto = _fixture.Create<CustomerInputDto>();

        var command = new AddCustomerCommand(customerInputDto);

        _customerWriteRepositoryMock
            .Setup(call => call.Add(It.IsAny<Domain.Entities.Customers.Customer>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        _customerWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new AddCustomerCommandHandler(_customerWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);
        

        // Assert
        _customerWriteRepositoryMock.Verify(
            call => call.Add(It.IsAny<Domain.Entities.Customers.Customer>(), It.IsAny<CancellationToken>()),
            Times.Once);

        _customerWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
