using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Events
{
    public interface IEventDispatcher
    {
         Task DispatchAsync<T>(T @event) where T: IEvent;
         Task DispatchManyAsync<T>(params T[] @event) where T: IEvent;
    }
}