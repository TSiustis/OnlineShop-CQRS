using AutoFixture;
using FluentAssertions;
using OnlineShop.Application.Order.Commands.UpdateOrder;
using OnlineShop.Application.Order.Dto;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Orders.UpdateOrder;

public class UpdateOrderCommandValidatorTests
{
    private readonly UpdateOrderCommandValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Validate_IfInvalidAddress_HasErrors()
    {
        // Arrange
        var orderInputDto = _fixture.Build<OrderInputDto>()
            .Without(o => o.Address)
            .Create();

        var command = new UpdateOrderCommand(orderInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfInvalidAmount_HasErrors()
    {
        // Arrange
        var orderInputDto = _fixture.Build<OrderInputDto>()
            .Without(o => o.Amount)
            .Create();

        var command = new UpdateOrderCommand(orderInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfInvalidItems_HasErrors()
    {
        // Arrange
        var orderInputDto = _fixture.Build<OrderInputDto>()
            .Without(o => o.Items)
            .Create();

        var command = new UpdateOrderCommand(orderInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfValidData_HasNoErrors()
    {
        // Arrange
        var customerInputDto = _fixture.Create<OrderInputDto>();

        var command = new UpdateOrderCommand(customerInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
