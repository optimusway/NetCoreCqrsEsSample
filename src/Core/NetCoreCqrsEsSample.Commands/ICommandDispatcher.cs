using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Commands
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T Command) where T: ICommand;
    }
}