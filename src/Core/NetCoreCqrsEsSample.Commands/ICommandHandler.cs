using System.Threading.Tasks;

namespace NetCoreCqrsEsSample.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
         void Handle(T Command);
         Task HandleAsync(T Command);
    }
}