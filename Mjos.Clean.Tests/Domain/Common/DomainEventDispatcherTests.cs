
using Mjos.Clean.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Xunit;

namespace Mjos.Clean.Tests.Domain.Common
{
    public class TestEntity : BaseEntity
    {
        // Add any additional properties or methods needed for testing
    }
    public class DomainEventDispatcherTests
    {
        [Fact]
        public async Task DispatchAndClearEvents_DispatchEventsForEntities_CallsMediatorPublishForEachEvent()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var dispatcher = new DomainEventDispatcher(mediatorMock.Object);

            var entity1 = new TestEntity();
            var entity2 = new TestEntity();

            var domainEvent1 = new Mock<BaseEvent>().Object;
            var domainEvent2 = new Mock<BaseEvent>().Object;

            entity1.AddDomainEvent(domainEvent1);
            entity2.AddDomainEvent(domainEvent2);

            var entitiesWithEvents = new List<BaseEntity> { entity1, entity2 };

            // Act
            await dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            // Assert
            mediatorMock.Verify(m => m.Publish(domainEvent1, default), Times.Once);
            mediatorMock.Verify(m => m.Publish(domainEvent2, default), Times.Once);

            Assert.Empty(entity1.DomainEvents);
            Assert.Empty(entity2.DomainEvents);
        }

        [Fact]
        public async Task DispatchAndClearEvents_NoEntitiesWithEvents_DoesNotCallMediatorPublish()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var dispatcher = new DomainEventDispatcher(mediatorMock.Object);

            var entity1 = new TestEntity();
            var entity2 = new TestEntity();

            var entitiesWithEvents = new List<BaseEntity> { entity1, entity2 };

            // Act
            await dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.IsAny<BaseEvent>(), default), Times.Never);

            Assert.Empty(entity1.DomainEvents);
            Assert.Empty(entity2.DomainEvents);
        }

    }
}
