using System;
using Microsoft.AspNetCore.Mvc;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Infrastructure.Commands;

namespace NetCoreCqrsEsSample.Api.Controllers
{
    [Route("api/[controller]")]
    public class CounterController
    {
        private readonly ICommandDispatcher _dispatcher;

        public CounterController(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        [Route("inc")]
        public void Increment()
        {
            _dispatcher.DispatchAsync(new IncrementCommand());
        }
    }
}