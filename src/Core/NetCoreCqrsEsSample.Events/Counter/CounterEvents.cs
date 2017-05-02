namespace NetCoreCqrsEsSample.Events.Counter
{
    public class CounterIncremented : IEvent
    {
        public int Version { get; set; }
        public readonly int Value;

        public CounterIncremented(int value)
        {
            Value = value;
        }
    }
    
    public class CounterDecremented : IEvent
    {
        public int Version { get; set; }
        public readonly int Value;

        public CounterDecremented(int value)
        {
            Value = value;
        }
    }
}