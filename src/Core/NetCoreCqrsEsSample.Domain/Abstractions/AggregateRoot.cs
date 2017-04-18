using System;
using System.Collections.Generic;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Domain.Abstractions
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();

        public Guid Id { get; protected set; }

        public int Version { get; protected set; }

        public IEnumerable<IEvent> GetUncommittedChanges() => _changes;

        public void MarkChangesAsCommited() => _changes.Clear();

        public void LoadFromHistory(IEnumerable<IEvent> events)
        {
            foreach (var e in events)
            {
                ApplyChange(e, false);
            }
        }

        protected void ApplyChange(IEvent @event) => ApplyChange(@event, true);

        private void ApplyChange(IEvent @event, bool isNew)
        {
            ((dynamic)this).Apply(@event);
            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}