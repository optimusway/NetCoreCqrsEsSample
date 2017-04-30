using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;

namespace NetCoreCqrsEsSample.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _context;
        private readonly IEventHandlerFactory _factory;

        public EventDispatcher(IComponentContext context, IEventHandlerFactory factory)
        {
            _factory = factory;
            _context = context;
        }
        public async Task DispatchAsync<T>(params T[] events) where T : IEvent
        {
            foreach (var @event in events)
            {
                // var handler = _context.Resolve<IEventHandler<Counter.CounterIncremented>>();
                // await handler.HandleAsync(@event as Counter.CounterIncremented);
                var handlers = _factory.Resolve<T>(@event);
                foreach (var eventHandler in handlers)
                {
                    await eventHandler.HandleAsync(@event);
                }
            }
        }

        public async Task Dispatch<T>(T @event) where T : IEvent
        {
            var handler = _context.Resolve<IEventHandler<T>>();
            await handler.HandleAsync(@event);
        }
    }
}