using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Services;

namespace NetCoreCqrsEsSample.Services.CounterService
{
    public class CounterService: ICounterService
    {
        public Counter Get() => new Counter();
    }
}