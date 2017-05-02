using NetCoreCqrsEsSample.Domain.Core;
using NetCoreCqrsEsSample.Events.Counter;

namespace NetCoreCqrsEsSample.Domain.Models
{
    public class Counter : AggregateRoot
    {
        public int Value { get; private set; }

        public Counter() { }

        public Counter(int initialValue = 0)
        {
            Value = initialValue;
        }

        public void Increment() => ApplyChange(new CounterIncremented(Value + 1));
        public void Decrement() => ApplyChange(new CounterDecremented(Value - 1));

        public void Apply(CounterIncremented e)
        {
            Value = e.Value;
        }

        public void Apply(CounterDecremented e)
        {
            Value = e.Value;
        }

        protected override void RegisterAppliers()
        {
            RegisterApplier<CounterIncremented>(Apply);
            RegisterApplier<CounterDecremented>(Apply);
        }
    }
}