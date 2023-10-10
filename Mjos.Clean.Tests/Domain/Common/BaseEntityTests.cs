using Mjos.Clean.Domain.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjos.Clean.Tests.Domain.Common
{
    public class BaseEntityTests
    {
        [Fact]
        public void AddDomainEvent_AddsEventToList()
        {
            // Arrange
            var entity = new Mock<BaseEntity>();
            var domainEvent = new Mock<BaseEvent>();

            // Act
            entity.Object.AddDomainEvent(domainEvent.Object);

            // Assert
            Assert.Contains(domainEvent.Object, entity.Object.DomainEvents);
        }

        [Fact]
        public void RemoveDomainEvent_RemovesEventFromList()
        {
            // Arrange
            var entity = new Mock<BaseEntity>();
            var domainEvent = new Mock<BaseEvent>();
            entity.Object.AddDomainEvent(domainEvent.Object);

            // Act
            entity.Object.RemoveDomainEvent(domainEvent.Object);

            // Assert
            Assert.DoesNotContain(domainEvent.Object, entity.Object.DomainEvents);
        }

        [Fact]
        public void ClearDomainEvents_ClearsEventList()
        {
            // Arrange
            var entity = new Mock<BaseEntity>();
            var domainEvent1 = new Mock<BaseEvent>();
            var domainEvent2 = new Mock<BaseEvent>();
            entity.Object.AddDomainEvent(domainEvent1.Object);
            entity.Object.AddDomainEvent(domainEvent2.Object);

            // Act
            entity.Object.ClearDomainEvents();

            // Assert
            Assert.Empty(entity.Object.DomainEvents);
        }
    }
}
