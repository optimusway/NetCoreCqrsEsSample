using System;
using System.Threading;

namespace NetCoreCqrsEsSample.Service.Host
{
    public class App
    {
        private readonly string[] args;
        private readonly IServiceHostFactory factory;
        private readonly ManualResetEvent _reset = new ManualResetEvent(false);

        public App(string[] args, IServiceHostFactory factory)
        {
            this.factory = factory;
            this.args = args;
        }

        public static void Run(string[] args, IServiceHostFactory factory)
        {
            var app = new App(args, factory);
            app.Start();
        }

        private void Start()
        {
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                _reset.Set();
            };
            _reset.WaitOne();
        }

        private void Stop() => _reset.Set();
    }
}