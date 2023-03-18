using Moq;
using OnlineShop.Application.EventHandlers;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    internal class ProductUpdatedHandlerTests
    {
        public class ProductCreatedHandlerTests
        {
            [Fact]
            public async Task Handler_ShouldUpdateProduct_WhenCalled()
            {
                // Arrange
                var product = new Product(0, "Test Product");
                var domainEvent = new ProductCreated(product);
                var notification = new DomainEventNotification<ProductCreated>(domainEvent);
                var cancellationToken = CancellationToken.None;

                var readRepositoryMock = new Mock<IReadRepository<Product>>();
                readRepositoryMock.Setup(repo => repo.Update(product)).Verifiable();
                readRepositoryMock.Setup(repo => repo.SaveChanges(cancellationToken)).Verifiable();

                var handler = new ProductCreatedHandler(readRepositoryMock.Object);

                // Act
                await handler.Handle(notification, cancellationToken);

                // Assert
                readRepositoryMock.Verify(x => x.Update(product), Times.Once);
                readRepositoryMock.Verify(x => x.SaveChanges(cancellationToken), Times.Once);
            }
        }
    }
}
