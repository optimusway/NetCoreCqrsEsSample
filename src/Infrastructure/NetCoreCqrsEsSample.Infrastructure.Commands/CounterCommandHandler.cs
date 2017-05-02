using System;
using Autofac;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Repositories;

namespace NetCoreCqrsEsSample.Infrastructure.Commands
{
    public class CounterCommandHandler : ICommandHandler<IncrementCommand>,
                                         ICommandHandler<DecrementCommand>
    {
        private readonly IEventRepository<Counter> _repository;
        private readonly IComponentContext _context;

        public CounterCommandHandler(IComponentContext context)
        {
            _context = context;
            _repository = _context.Resolve<IEventRepository<Counter>>();
        }

        public void HandleAsync(IncrementCommand command)
        {
            var counter = _repository.GetById(Guid.NewGuid());
            counter.Increment();

            _repository.Save(counter, counter.Version + 1);
        }

        public void HandleAsync(DecrementCommand command)
        {
            var counter = _repository.GetById(Guid.NewGuid());
            counter.Decrement();

            _repository.Save(counter, counter.Version + 1);
        }
    }
}