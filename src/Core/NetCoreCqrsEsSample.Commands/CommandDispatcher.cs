using System.Threading.Tasks;
using Autofac;

namespace NetCoreCqrsEsSample.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            var _handler = _context.Resolve<ICommandHandler<T>>();
            await _handler.HandleAsync(command);
        }
    }
}