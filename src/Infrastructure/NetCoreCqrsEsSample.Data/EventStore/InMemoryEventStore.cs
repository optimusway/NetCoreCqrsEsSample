using System;
using System.Collections.Generic;
using NetCoreCqrsEsSample.Domain.EventStore;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Data.EventStore
{
    public class InMemoryEventStore : IEventStore
    {
        public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Save(Guid id, IEnumerable<IEvent> enumerable, int expectedVersion)
        {
            throw new NotImplementedException();
        }
    }
}