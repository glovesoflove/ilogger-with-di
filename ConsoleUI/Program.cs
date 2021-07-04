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
            string[] s = { "test test"};
            ILoggerFactory _Factory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddConsole();
            }
                                                                      );
            
            ILogger _ILogger = _Factory.CreateLogger<Program>();
            DataAccess da = new DataAccess(_ILogger);
            var container = ContainerConfig.Configure();
            Bravo b = new Bravo(_ILogger, da);
            BusinessLogic BL = new BusinessLogic(_ILogger, da, b);
            BL.ProcessData(s);

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var app = scope.Resolve<IApplication>();
            //    app.Run(args);
            //}

            Console.ReadLine();
        }
    }
}
