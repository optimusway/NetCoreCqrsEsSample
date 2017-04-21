using System.Threading.Tasks;
using NetCoreCqrsEsSample.Domain.Models;

namespace NetCoreCqrsEsSample.Domain.Repositories
{
    public interface ICounterRepo
    {
        Counter Get();

        Task<Counter> GetAsync();
    }
}