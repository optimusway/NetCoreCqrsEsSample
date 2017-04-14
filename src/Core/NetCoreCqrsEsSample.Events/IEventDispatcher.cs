using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Events
{
    public interface IEventDispatcher
    {
         Task DispatchAsync<T>(params T[] events) where T: IEvent;
    }
}