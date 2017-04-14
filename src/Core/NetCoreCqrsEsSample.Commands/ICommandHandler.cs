using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
         Task HandleAsync(T Command);
    }
}