using System;
using System.Collections.Generic;
using System.Linq;
using NetCoreCqrsEsSample.Events.Counter;

namespace NetCoreCqrsEsSample.Events
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        private readonly Dictionary<Type, List<Func<IHandler>>> _handlerFactories = new Dictionary<Type, List<Func<IHandler>>>();

        public EventHandlerFactory()
        {
            RegisterHandlerFactories();
        }

        private void RegisterHandlerFactories()
        {
            RegisterHandlerFactoryWithTypes(
                () => new CounterEventHandlers(),
                typeof(CounterIncremented), typeof(CounterDecremented)
            );
        }

        private void RegisterHandlerFactoryWithTypes(Func<IHandler> handler, params Type[] types)
        {
            foreach (var type in types)
            {
                _handlerFactories.Add(type, new List<Func<IHandler>> { handler });
            }
        }

        public IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (_handlerFactories.TryGetValue(typeof(TEvent), out var handlerFactories))
            {
                handlerFactories.Select(h => (IEventHandler<TEvent>)h());
            }
            return new List<IEventHandler<TEvent>>();
        }
    }
}