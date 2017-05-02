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

        public void Dispatch<TEvent>(params TEvent[] events) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                var handler = _context.Resolve<IEventHandler<TEvent>>();
                handler.Handle(@event);
            }
        }
    }
}