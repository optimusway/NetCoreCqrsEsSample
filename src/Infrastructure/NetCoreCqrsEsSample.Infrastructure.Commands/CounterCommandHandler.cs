using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
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
            this._context = context;
            this._repo = _context.Resolve<IEventRepo<Counter>>();
        }

        public void HandleAsync(IncrementCommand command)
        {
            var counter = new Counter(42);
            // _repo.GetById(Guid.NewGuid());
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