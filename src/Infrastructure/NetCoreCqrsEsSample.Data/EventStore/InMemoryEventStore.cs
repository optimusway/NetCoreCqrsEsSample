using System;
using System.Collections.Generic;
using System.Linq;
using NetCoreCqrsEsSample.Domain.EventStore;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Data.EventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<EventDescriptor>> _store = new Dictionary<Guid, List<EventDescriptor>>();
        private readonly IEventDispatcher _dispatcher;

        private struct EventDescriptor
        {
            public readonly Guid Id;
            public readonly IEvent EventData;
            public readonly int Version;

            public EventDescriptor(Guid id, IEvent eventData, int version)
            {
                Id = id;
                EventData = eventData;
                Version = version;
            }
        }

        public InMemoryEventStore(IEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        {
            List<EventDescriptor> events;
            if (!_store.TryGetValue(aggregateId, out events))
            {
                throw new AggregateNotFoundException();
            }

            return events.Select(e => e.EventData);
        }

        public void Save(Guid id, IEnumerable<IEvent> events, int expectedVersion)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_store.TryGetValue(id, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _store.Add(id, eventDescriptors);
            }
            else if (eventDescriptors.Last().Version != expectedVersion && expectedVersion != -1)
            {
                throw new ConcurencyException();
            }

            var i = expectedVersion;

            foreach (var @event in events)
            {
                @event.Version = ++i;
                eventDescriptors.Add(
                    new EventDescriptor(id, @event, i)
                );

                _dispatcher.Dispatch((dynamic)@event);
            }
        }
    }

    internal class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException()
        {
        }

        public AggregateNotFoundException(string message) : base(message)
        {
        }

        public AggregateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    internal class ConcurencyException : Exception
    {
        public ConcurencyException()
        {
        }

        public ConcurencyException(string message) : base(message)
        {
        }

        public ConcurencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}