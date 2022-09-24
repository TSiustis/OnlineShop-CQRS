using AutoFixture;
using FluentAssertions;
using OnlineShop.Application.Products.Commands.AddProduct;
using OnlineShop.Application.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Products.AddProduct;
public class AddProductCommandValidatorTests
{
    private readonly AddProductCommandValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Validate_IfInvalidId_HasErrors()
    {
        // Arrange
        var orderInputDto = _fixture.Build<ProductInputDto>()
            .Without(o => o.Id)
            .Create();

        var command = new AddProductCommand(orderInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_IfInvalidName_HasErrors()
    {
        // Arrange
        var orderInputDto = _fixture.Build<ProductInputDto>()
            .Without(o => o.Name)
            .Create();

        var command = new AddProductCommand(orderInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public void Validate_IfValidData_HasNoErrors()
    {
        // Arrange
        var customerInputDto = _fixture.Create<ProductInputDto>();

        var command = new AddProductCommand(customerInputDto);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
