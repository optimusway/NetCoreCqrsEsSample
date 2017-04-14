using System.Threading.Tasks;
using Autofac;

namespace NetCoreCqrsEsSample.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _context;

        public EventDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task DispatchAsync<T>(params T[] events) where T : IEvent
        {
            foreach (var @event in events)
            {
                var handler = _context.Resolve<IEventHandler<T>>();
                await handler.HandleAsync(@event);
            }
        }
    }
}