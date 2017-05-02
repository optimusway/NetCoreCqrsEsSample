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
        private readonly IEventRepo<Counter> _repo;
        private readonly IComponentContext _context;

        public CounterCommandHandler(IComponentContext context)
        {
            _context = context;
            _repo = _context.Resolve<IEventRepo<Counter>>();
        }

        public void HandleAsync(IncrementCommand command)
        {
            var counter = _repo.GetById(Guid.NewGuid());
            counter.Increment();

            _repo.Save(counter, counter.Version + 1);
        }

        public void HandleAsync(DecrementCommand command)
        {
            var counter = _repo.GetById(Guid.NewGuid());
            counter.Decrement();

            _repo.Save(counter, counter.Version + 1);
        }
    }
}