using NetCoreCqrsEsSample.Domain.Models;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public interface ICounterRepo
    {
        Counter Get();
    }
}