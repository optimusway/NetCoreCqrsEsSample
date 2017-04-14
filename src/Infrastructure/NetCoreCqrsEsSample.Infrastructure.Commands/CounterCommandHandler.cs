using System.Threading.Tasks;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Domain.Services;

namespace NetCoreCqrsEsSample.Infrastructure.Commands
{
    public class CounterCommandHandler : ICommandHandler<IncrementCommand>,
                                        ICommandHandler<DecrementCommand>
    {
        private readonly ICounterService _service;
        public CounterCommandHandler(ICounterService service)
        {
            this._service = service;

        }

        public Task HandleAsync(IncrementCommand command)
        {
            var counter = _service.Get();
            counter.Increment();
            
            return Task.CompletedTask;
        }
        
        public Task HandleAsync(DecrementCommand command)
        {
            var counter = _service.Get();
            counter.Decrement();
            
            return Task.CompletedTask;
        }
    }
}