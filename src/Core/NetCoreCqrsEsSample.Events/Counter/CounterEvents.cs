namespace NetCoreCqrsEsSample.Events.Counter
{
    public class Incremented : IEvent
    {
        public int Version { get; set; }
    }

    public class Decremented : IEvent
    {
        public int Version { get; set; }
    }
}