﻿using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCoreCqrsEsSample.Api.IoC;
using NetCoreCqrsEsSample.Data.EventStore;
using NetCoreCqrsEsSample.Data.InMemory;
using NetCoreCqrsEsSample.Domain.EventStore;
using NetCoreCqrsEsSample.Domain.Models;
using NetCoreCqrsEsSample.Domain.Repositories;
using NetCoreCqrsEsSample.Events;

namespace NetCoreCqrsEsSample.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<ICounterRepo, CounterRepo>();
            // services.AddSingleton<IEventRepo, EventRepo>();

            var builder = new ContainerBuilder();
            builder.RegisterModule<CommandModule>();

            builder.RegisterGeneric(typeof(EventRepo<>))
                .As(typeof(IEventRepo<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<InMemoryEventStore>().As<IEventStore>().InstancePerLifetimeScope();
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().InstancePerLifetimeScope();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
