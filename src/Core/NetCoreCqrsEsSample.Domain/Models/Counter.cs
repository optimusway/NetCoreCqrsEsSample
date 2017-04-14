using NetCoreCqrsEsSample.Domain.Abstractions;

namespace NetCoreCqrsEsSample.Domain.Models
{
    public class Counter : AggregateRoot
    {
        public Counter(int initialValue = 0)
        {
            this.Value = initialValue;
        }

        public int Value { get; private set; }

        public void Increment() => this.Value += 1;
        public void Decrement() => this.Value -= 1;
    }
}