namespace NetCoreCqrsEsSample.Events.Counter
{
    public class CounterIncremented : BaseEvent
    {
        public readonly int Value;

        public CounterIncremented(int value)
        {
            Value = value;
        }
    }
    public class CounterDecremented : BaseEvent
    {
        public readonly int Value;
        
        public CounterDecremented(int value)
        {
            Value = value;
        }
    }
}