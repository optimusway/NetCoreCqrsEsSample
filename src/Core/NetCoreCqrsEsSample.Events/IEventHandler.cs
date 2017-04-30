using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Events
{
    public interface IEventHandler<T> : IHandler where T : IEvent
    {
        Task HandleAsync(T @event);
    }

    public interface IHandler { }
}