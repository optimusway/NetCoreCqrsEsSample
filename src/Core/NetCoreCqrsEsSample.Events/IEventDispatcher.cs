namespace NetCoreCqrsEsSample.Events
{
    public interface IEventDispatcher
    {
        void Dispatch<T>(params T[] events) where T : IEvent;
    }
}