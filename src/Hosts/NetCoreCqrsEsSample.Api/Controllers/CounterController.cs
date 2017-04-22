using System.Threading.Tasks;
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

        public async Task Get()
        {
            await _dispatcher.DispatchAsync(new IncrementCommand());
        }
    }
}