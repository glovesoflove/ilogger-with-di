using Autofac;
using ConsoleUI.Utility;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            //builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<Bravo>().As<IBravo>();
            builder.RegisterType<DataAccess>().As<IDataAccess>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(ConsoleUI.Utility)))
            //.Where(t => t.Namespace.Contains("Utility"))
            // .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
