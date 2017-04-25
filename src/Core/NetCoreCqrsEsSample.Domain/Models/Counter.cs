using System;
using NetCoreCqrsEsSample.Domain.Abstractions;
using NetCoreCqrsEsSample.Events.Counter;

namespace NetCoreCqrsEsSample.Domain.Models
{
    public class Counter : AggregateRoot
    {
        public int Value { get; private set; }

        public Counter() { }

        public Counter(int initialValue = 0)
        {
            this.Value = initialValue;
        }

        public void Increment() => ApplyChange(new CounterIncremented(this.Value + 1));
        public void Decrement() => ApplyChange(new CounterDecremented(this.Value - 1));

        public void Apply(CounterIncremented e)
        {
            this.Value = e.Value;
        }

        public void Apply(CounterDecremented e)
        {
            this.Value = e.Value;
        }

        protected override void RegisterAppliers()
        {
            RegisterApplier<CounterIncremented>(Apply);
            RegisterApplier<CounterDecremented>(Apply);
        }
    }
}