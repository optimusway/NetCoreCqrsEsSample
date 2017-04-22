using System.Reflection;
using Autofac;
using NetCoreCqrsEsSample.Commands;
using NetCoreCqrsEsSample.Infrastructure.Commands;

namespace NetCoreCqrsEsSample.Api.IoC
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CounterCommandHandler)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}