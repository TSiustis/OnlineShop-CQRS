namespace OnlineShop.UnitTests.Application.Handlers.Customer.UpdateCustomer;

using AutoFixture;
using Moq;
using OnlineShop.Domain.Interfaces;
using Xunit;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Application.Customer.Commands.UpdateCustomer;
using AutoMapper;
using OnlineShop.Application.Profiles;

public class UpdateCustomerCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Customer>> _customerWriteRepositoryMock;
    private readonly Fixture _fixture = new();

    public UpdateCustomerCommandHandlerTests()
    {
        _customerWriteRepositoryMock = new Mock<IWriteRepository<Customer>>();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_SavesCustomerToDatabase()
    {

        // Arrange
        var customerInputDto = _fixture.Create<CustomerInputDto>();

        var command = new UpdateCustomerCommand(customerInputDto);

        _customerWriteRepositoryMock
            .Setup(call => call.Update(It.IsAny<Customer>()))
            .Verifiable();

        _customerWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new UpdateCustomerCommandHandler(_customerWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);


        // Assert
        _customerWriteRepositoryMock.Verify(
            call => call.Update(It.IsAny<Customer>()),
            Times.Once);

        _customerWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
