using System.Reflection;
using Autofac;
using NetCoreCqrsEsSample.Data.EventStore;
using NetCoreCqrsEsSample.Domain.EventStore;
using NetCoreCqrsEsSample.Domain.Repositories;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Api.IoC
{
    public class EventModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(IEventHandler<>)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EventRepository<>))
                .As(typeof(IEventRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<InMemoryEventStore>()
                .As<IEventStore>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventDispatcher>()
                .As<IEventDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}