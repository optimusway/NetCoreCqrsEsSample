using System.Collections.Generic;

namespace NetCoreCqrsEsSample.Events
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}