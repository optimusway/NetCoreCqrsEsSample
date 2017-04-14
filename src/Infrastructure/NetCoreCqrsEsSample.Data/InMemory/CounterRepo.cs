using System;
using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Repositories;

namespace NetCoreCqrsEsSample.Data.InMemory
{
    public class CounterRepo : ICounterRepo
    {
        public Counter Get()
        {
            throw new NotImplementedException();
        }
    }
}