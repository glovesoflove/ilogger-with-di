using Autofac;
using ConsoleUI.Utility;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main init");
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run(args);
            }

            Console.ReadLine();
        }
    }
}
