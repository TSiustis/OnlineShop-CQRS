using AutoFixture;
using Moq;
using OnlineShop.Application.EventHandlers;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Xunit;

namespace OnlineShop.UnitTests.Application.EventHandlers
{
    public class ProductUpdatedHandlerTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handler_ShouldUpdateProduct_WhenCalled()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            var domainEvent = new ProductUpdated(product);
            var notification = new DomainEventNotification<ProductUpdated>(domainEvent);
            var cancellationToken = CancellationToken.None;

            var readRepositoryMock = new Mock<IReadRepository<Product>>();
            readRepositoryMock.Setup(repo => repo.Update(product)).Verifiable();
            readRepositoryMock.Setup(repo => repo.SaveChanges(cancellationToken)).Verifiable();

            var handler = new ProductUpdatedHandler(readRepositoryMock.Object);

            // Act
            await handler.Handle(notification, cancellationToken);

            // Assert
            readRepositoryMock.Verify(x => x.Update(product), Times.Once);
            readRepositoryMock.Verify(x => x.SaveChanges(cancellationToken), Times.Once);
        }
    }
}
