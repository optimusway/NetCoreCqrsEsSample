namespace NetCoreCqrsEsSample.Events
{
    public interface IEvent
    {
        int Version { get; set; }
    }
}