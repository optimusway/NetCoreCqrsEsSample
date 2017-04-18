using System;

namespace NetCoreCqrsEsSample.Service.Host
{
    public interface IServiceHostFactory: IDisposable
    {
         IDisposable Create();
    }
}