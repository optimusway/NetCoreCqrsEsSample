using System;
using System.Collections.Generic;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Domain.EventStore
{
    public interface IEventStore
    {
        IEnumerable<IEvent> GetEvents(Guid aggregateId);
        void Save(Guid id, IEnumerable<IEvent> enumerable, int expectedVersion);
    }
}