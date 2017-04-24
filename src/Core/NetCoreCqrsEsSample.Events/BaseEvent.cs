namespace NetCoreCqrsEsSample.Events
{
    public class BaseEvent : IEvent
    {
        public int Version { get; set; }
    }
}