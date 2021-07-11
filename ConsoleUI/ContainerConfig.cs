using Autofac;
using ConsoleUI.Utility;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Reflection;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            builder.RegisterType<ILog>().As<ILog>();
            builder.RegisterType<Bravo>().As<IBravo>();
            builder.RegisterType<DataAccess>().As<IDataAccess>();
            builder.RegisterType<Configuration>().As<IConfiguration>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(ConsoleUI.Utility)))
            //.Where(t => t.Namespace.Contains("Utility"))
            // .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            builder.RegisterType<Context>().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IStrategy)))
                   .Where(t => typeof(IStrategy).IsAssignableFrom(t))
                   .AsSelf();
            builder.Register<Func<ESomeEnum, IStrategy>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return (someEnum) =>
                {
                    switch (someEnum)
                    {
                        case ESomeEnum.UseStrategyA:
                            return cc.Resolve<ConcreteStrategyA>();
                        case ESomeEnum.UseStrategyB:
                            return cc.Resolve<ConcreteStrategyB>();
                        default:
                            throw new ArgumentException();
                    }
                };
            });

            return builder.Build();
        }
    }
}
