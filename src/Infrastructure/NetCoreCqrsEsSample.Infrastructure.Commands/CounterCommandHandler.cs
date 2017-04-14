using System;
using System.Threading.Tasks;
using NetCoreCqrsEsSample.Commands;

namespace NetCoreCqrsEsSample.Infrastructure.Commands
{
    public class CounterCommandHandler: ICommandHandler<IncrementCommand>,
                                        ICommandHandler<DecrementCommand>
    {
        public Task HandleAsync(DecrementCommand command)
        {
            throw new NotImplementedException();
        }

        Task ICommandHandler<IncrementCommand>.HandleAsync(IncrementCommand command)
        {
            throw new NotImplementedException();
        }
    }
}