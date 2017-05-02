using System;
using System.Collections.Generic;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Domain.Core
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();
        private readonly Dictionary<Type, Action<IEvent>> _eventAppliers = new Dictionary<Type, Action<IEvent>>();

        public Guid Id { get; protected set; }

        public int Version { get; protected set; }

        public IEnumerable<IEvent> GetUncommittedChanges() => _changes;

        protected AggregateRoot()
        {
            RegisterAppliers();
        }

        public void MarkChangesAsCommited() => _changes.Clear();

        public void LoadFromHistory(IEnumerable<IEvent> events)
        {
            foreach (var e in events)
            {
                ApplyChange(e, false);
            }
        }

        protected abstract void RegisterAppliers();

        protected void RegisterApplier<TEvent>(Action<TEvent> eventApplier) where TEvent : IEvent
        {
            _eventAppliers.Add(typeof(TEvent), x => eventApplier((TEvent)x));
        }

        protected void ApplyChange(IEvent @event) => ApplyChange(@event, true);

        private void ApplyChange(IEvent @event, bool isNew)
        {
            if (!_eventAppliers.TryGetValue(@event.GetType(), out var eventApplier))
            {
                throw new Exception($"The Apply method for the {@event.GetType().Name} event is not registered");
            }
            eventApplier(@event);
            
            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}