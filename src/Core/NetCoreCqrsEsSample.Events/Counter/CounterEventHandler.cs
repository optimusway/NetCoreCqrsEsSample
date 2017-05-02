using System;

namespace NetCoreCqrsEsSample.Events.Counter
{
    public class CounterEventHandler : IEventHandler<CounterIncremented>
    {
        public void Handle(CounterIncremented @event)
        {
            Console.WriteLine(@event.Value);
        }
    }
}