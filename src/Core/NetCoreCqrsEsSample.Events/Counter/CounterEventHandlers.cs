using System;
using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Events.Counter
{
    public class CounterEventHandlers :
        IEventHandler<CounterIncremented>,
        IEventHandler<CounterDecremented>
    {
        public Task HandleAsync(CounterIncremented e)
        {
            Console.WriteLine(e.Value);
            return Task.CompletedTask;
        }

        public Task HandleAsync(CounterDecremented e)
        {
            return Task.CompletedTask;
        }
    }
}