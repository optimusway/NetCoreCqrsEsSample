using System;
using Autofac;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Domain.Repositories;

namespace NetCoreCqrsEsSample.Infrastructure.Commands.Counter
{
    public class CounterCommandHandler : ICommandHandler<IncrementCommand>,
                                         ICommandHandler<DecrementCommand>
    {
        private readonly IEventRepository<Domain.Models.Counter> _repository;
        private readonly IComponentContext _context;

        public CounterCommandHandler(IComponentContext context)
        {
            _context = context;
            _repository = _context.Resolve<IEventRepository<Domain.Models.Counter>>();
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