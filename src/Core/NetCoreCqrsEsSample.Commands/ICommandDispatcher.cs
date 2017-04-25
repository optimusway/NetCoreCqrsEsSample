using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Commands
{
    public interface ICommandDispatcher
    {
         void DispatchAsync<T>(T Command) where T: ICommand;
    }
}