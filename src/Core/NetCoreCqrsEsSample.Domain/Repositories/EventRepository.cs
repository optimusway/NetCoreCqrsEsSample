using System;
using NetCoreCqrsEsSample.Domain.Core;
using NetCoreCqrsEsSample.Domain.EventStore;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public class EventRepository<T> : IEventRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStore _eventStore;

        public EventRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById(Guid aggregateId)
        {
            // var events = _eventStore.GetEvents(aggregateId);
            var events = new Events.IEvent[] { }; // just for testing purpose
            var aggregate = new T();
            aggregate.LoadFromHistory(events);

            return aggregate;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _eventStore.Save(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }
    }
}