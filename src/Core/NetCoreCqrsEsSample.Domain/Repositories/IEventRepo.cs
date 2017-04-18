using System;
using NetCoreCqrsEsSample.Domain.Abstractions;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public interface IEventRepo<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid aggregateId);
    }
}