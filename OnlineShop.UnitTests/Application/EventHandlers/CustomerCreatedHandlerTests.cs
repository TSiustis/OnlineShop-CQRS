using AutoFixture;
using Moq;
using OnlineShop.Application.EventHandlers;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    public class CustomerCreatedHandlerTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_ShouldAddAndSaveCustomer_WhenCalled()
        {
            // Arrange
            var customer = _fixture.Create<Customer>();

            var customerCreatedEvent = new CustomerCreated(customer);
            var domainEventNotification = new DomainEventNotification<CustomerCreated>(customerCreatedEvent);

            var mockCustomerReadRepository = new Mock<IReadRepository<Customer>>();
            mockCustomerReadRepository.Setup(x => x.Add(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            mockCustomerReadRepository.Setup(x => x.SaveChanges(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var handler = new CustomerCreatedHandler(mockCustomerReadRepository.Object);

            // Act
            await handler.Handle(domainEventNotification, CancellationToken.None);

            // Assert
            mockCustomerReadRepository.Verify(x => x.Add(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), Times.Once);
            mockCustomerReadRepository.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

