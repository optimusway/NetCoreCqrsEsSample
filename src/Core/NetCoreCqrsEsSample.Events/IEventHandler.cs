using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Events
{
    public interface IEventHandler<T> where T: IEvent
    {
         Task HandleAsync(T @event);
    }
}