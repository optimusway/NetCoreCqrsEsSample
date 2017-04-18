using System;
using NetCoreCqrsEsSample.Domain.Abstractions;
using NetCoreCqrsEsSample.Domain.EventStore;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public class EventRepo<T>: IEventRepo<T> where T: AggregateRoot, new()
    {
        private readonly IEventStore _eventStore;

        public EventRepo(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public T GetById(Guid aggregateId)
        {
            var events = _eventStore.GetEvents(aggregateId);
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