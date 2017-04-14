using NetCoreCqrsEsSample.Domain.Models;

namespace NetCoreCqrsEsSample.Domain.Services
{
    public interface ICounterService
    {
        Counter Get();
    }
}