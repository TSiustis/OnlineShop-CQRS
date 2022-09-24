﻿using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Order.Queries.GetOrders;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.Handlers.Orders.GetOrders;
public class GetOrdersQueryHandlerTests
{
    private readonly Mock<IReadRepository<Order>> _orderReadRepositoryMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture = new();

    public GetOrdersQueryHandlerTests()
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
        var orders = _fixture.CreateMany<Order>()
            .ToList();

        var command = new GetOrdersQuery();

        _orderReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()))
            .ReturnsAsync(orders);

        var sut = new GetOrdersQueryHandler(_orderReadRepositoryMock.Object, _mapper);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        _orderReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNoOrdersInDatabase_ThrowsNotFoundError()
    {
        // Arrange
        var command = new GetOrdersQuery();

        _orderReadRepositoryMock
            .Setup(call => call.Get(It.IsAny<CancellationToken>()));

        var sut = new GetOrdersQueryHandler(_orderReadRepositoryMock.Object, _mapper);

        // Act
        Func<Task> func = async () => await sut.Handle(command, CancellationToken.None);


        // Assert
        _orderReadRepositoryMock.Verify(
            call => call.Get(It.IsAny<CancellationToken>()),
            Times.Never);

        await func.Should().ThrowAsync<NotFoundException>();
    }
}
