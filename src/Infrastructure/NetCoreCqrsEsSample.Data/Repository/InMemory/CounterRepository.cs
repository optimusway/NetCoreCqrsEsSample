using System;
using System.Threading.Tasks;
using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Repositories;

namespace NetCoreCqrsEsSample.Data.Repository.InMemory
{
    public class CounterRepository : ICounterRepo
    {
        public Counter Get()
        {
            throw new NotImplementedException();
        }

        public Task<Counter> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}