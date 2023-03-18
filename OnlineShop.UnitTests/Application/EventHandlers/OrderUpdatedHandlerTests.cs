using AutoFixture;
using Moq;
using OnlineShop.Application.EventHandlers;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    public class OrderUpdatedHandlerTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_ShouldUpdateAndSaveOrder_WhenCalled()
        {
            // Arrange
            var order = _fixture.Create<Order>();

            var orderUpdatedEvent = new OrderUpdated(order);
            var domainEventNotification = new DomainEventNotification<OrderUpdated>(orderUpdatedEvent);

            var mockOrderReadRepository = new Mock<IReadRepository<Order>>();
            mockOrderReadRepository.Setup(x => x.Update(order));
            mockOrderReadRepository.Setup(x => x.SaveChanges(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var handler = new OrderUpdatedHandler(mockOrderReadRepository.Object);

            // Act
            await handler.Handle(domainEventNotification, CancellationToken.None);

            // Assert
            mockOrderReadRepository.Verify(x => x.Update(order), Times.Once);
            mockOrderReadRepository.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
