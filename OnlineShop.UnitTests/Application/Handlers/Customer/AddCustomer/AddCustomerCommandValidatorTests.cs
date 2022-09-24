using AutoFixture;
using FluentAssertions;
using OnlineShop.Application.Customer.Commands.AddCustomer;
using OnlineShop.Application.Customer.Dto;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Customer;

public class AddCustomerCommandValidatorTests
{
    private readonly AddCustomerCommandValidator _validator = new ();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Validate_IfInvalidPhoneNumber_HasErrors()
    {
        // Arrange
        var customerInputDto = _fixture.Build<CustomerInputDto>()
            .With(c => c.Email, "test@mail.com")
            .With(c => c.PhoneNumber, "+40712345678111111")
            .Create();

        var command = new AddCustomerCommand(customerInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfInvalidEmail_HasErrors()
    {
        // Arrange
        var customerInputDto = _fixture.Build<CustomerInputDto>()
            .With(c => c.Email, "test.com")
            .With(c => c.PhoneNumber, "+40712345678")
            .Create();

        var command = new AddCustomerCommand(customerInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfValidData_HasNoErrors()
    {
        // Arrange
        var customerInputDto = _fixture.Build<CustomerInputDto>()
            .With(c => c.Email, "test@mail.com")
            .With(c => c.PhoneNumber, "+40712345678")
            .Create();

        var command = new AddCustomerCommand(customerInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
