using AutoFixture;
using Moq;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    public class OrderCreatedHandlerTests
    {
        private readonly Fixture _fixture = new ();

        [Fact]
        public async Task Handle_ShouldAddAndSaveOrder_WhenCalled()
        {
            // Arrange
            var order = _fixture.Create<Order>();

            var orderCreatedEvent = new OrderCreated(order);
            var domainEventNotification = new DomainEventNotification<OrderCreated>(orderCreatedEvent);

            var mockOrderReadRepository = new Mock<IReadRepository<Order>>();
            mockOrderReadRepository.Setup(x => x.Add(order, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            mockOrderReadRepository.Setup(x => x.SaveChanges(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var handler = new OrderCreatedHandler(mockOrderReadRepository.Object);

            // Act
            await handler.Handle(domainEventNotification, CancellationToken.None);

            // Assert
            mockOrderReadRepository.Verify(x => x.Add(order, It.IsAny<CancellationToken>()), Times.Once);
            mockOrderReadRepository.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
