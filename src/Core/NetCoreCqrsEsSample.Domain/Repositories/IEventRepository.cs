using System;
using NetCoreCqrsEsSample.Domain.Abstractions;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public interface IEventRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid aggregateId);
    }
}