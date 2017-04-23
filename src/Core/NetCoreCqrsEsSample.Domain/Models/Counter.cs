using NetCoreCqrsEsSample.Domain.Abstractions;
using NetCoreCqrsEsSample.Events.Counter;

namespace NetCoreCqrsEsSample.Domain.Models
{
    public class Counter : AggregateRoot
    {
        public int Value { get; private set; }
        
        public Counter(int initialValue = 0)
        {
            this.Value = initialValue;
        }

        public void Increment() => this.Value += 1;
        public void Decrement() => this.Value -= 1;

        public void Apply(Incremented @event)
        {

        }

        public void Apply(Decremented @event)
        {

        }
    }
}