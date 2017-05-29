namespace NetCoreCqrsEsSample.Events.Counter
{
    public class CounterIncremented : IEvent
    {
        public int Version { get; set; }
    }
    
    public class CounterDecremented : IEvent
    {
        public int Version { get; set; }
    }
}