using System;

namespace NetCoreCqrsEsSample.Domain.Abstractions
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; protected set; }

        public int Version { get; protected set; }
    }
}