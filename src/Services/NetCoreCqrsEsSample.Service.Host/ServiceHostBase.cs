using System;

namespace NetCoreCqrsEsSample.Service.Host
{
    public abstract class ServiceHostBase : IDisposable
    {
        public abstract void Dispose();
    }
}