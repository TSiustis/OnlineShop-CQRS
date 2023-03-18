using AutoFixture;
using Castle.Core.Resource;
using Moq;
using OnlineShop.Application.EventHandlers;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    public class CustomerUpdatedHandlerTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_ShouldUpdateAndSaveCustomer_WhenCalled()
        {
            //Arrange
            var customer = _fixture.Create<Customer>();
            var customerUpdatedEvent = new CustomerUpdated(customer);
            var domainEventNotification = new DomainEventNotification<CustomerUpdated>(customerUpdatedEvent);

            var mockCustomerReadRepository = new Mock<IReadRepository<Customer>>();
            mockCustomerReadRepository.Setup(x => x.Update(customer));
            mockCustomerReadRepository.Setup(x => x.SaveChanges(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var handler = new CustomerUpdatedHandler(mockCustomerReadRepository.Object);

            // Act
            await handler.Handle(domainEventNotification, CancellationToken.None);

            // Assert
            mockCustomerReadRepository.Verify(x => x.Update(customer), Times.Once);
            mockCustomerReadRepository.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
