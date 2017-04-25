using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Repositories;
using NetCoreCqrsEsSample.Domain.Services;

namespace NetCoreCqrsEsSample.Services.CounterService
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepo _repo;

        public CounterService(ICounterRepo repo)
        {
            _repo = repo;
        }
        public Counter Get() => _repo.Get();
    }
}