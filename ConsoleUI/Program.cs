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
            DataAccess da = new DataAccess();
            var container = ContainerConfig.Configure();
            Bravo b = new Bravo(da);
            BusinessLogic BL = new BusinessLogic(da, b);
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
