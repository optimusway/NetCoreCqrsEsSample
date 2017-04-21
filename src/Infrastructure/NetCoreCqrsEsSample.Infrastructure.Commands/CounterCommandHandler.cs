using System.Threading.Tasks;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Domain.Repositories;
using NetCoreCqrsEsSample.Domain.Services;

namespace NetCoreCqrsEsSample.Infrastructure.Commands
{
    public class CounterCommandHandler : ICommandHandler<IncrementCommand>,
                                        ICommandHandler<DecrementCommand>
    {
        private readonly ICounterRepo _repo;
        
        public CounterCommandHandler(ICounterRepo repo)
        {
            this._repo = repo;

        }

        public async Task HandleAsync(IncrementCommand command)
        {
            var counter = await _repo.GetAsync();
            counter.Increment();
        }

        public async Task HandleAsync(DecrementCommand command)
        {
            var counter = await _repo.GetAsync();
            counter.Decrement();
        }
    }
}