﻿namespace OnlineShop.UnitTests.Application.Handlers.Orders.UpdateOrder;

using AutoFixture;
using Moq;
using OnlineShop.Domain.Interfaces;
using Xunit;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Application.Order.Dto;
using AutoMapper;
using OnlineShop.Application.Profiles;
using OnlineShop.Application.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandlerTests
{
    private readonly Mock<IWriteRepository<Order>> _orderWriteRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public UpdateOrderCommandHandlerTests()
    {
        _orderWriteRepositoryMock = new Mock<IWriteRepository<Order>>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new OrderProfile()); 
        });
        _mapper = mockMapper.CreateMapper();
    }


    [Fact]
    public async Task Handle_WhenPayloadIsValid_UpdatesOrder()
    {
        // Arrange
        var orderInputDto = _fixture.Create<OrderInputDto>();

        var command = new UpdateOrderCommand(orderInputDto);

        _orderWriteRepositoryMock
            .Setup(call => call.Update(It.IsAny<Order>()))
            .Verifiable();

        _orderWriteRepositoryMock
            .Setup(call => call.SaveChanges(default))
            .Verifiable();

        var sut = new UpdateOrderCommandHandler(_orderWriteRepositoryMock.Object);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _orderWriteRepositoryMock.Verify(
            call => call.Update(It.IsAny<Order>()),
            Times.Once);

        _orderWriteRepositoryMock.Verify(
            call => call.SaveChanges(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
