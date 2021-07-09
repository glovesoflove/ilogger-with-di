using Autofac;
using System;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        static IBusinessLogic _businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Run(string[] s, ILifetimeScope scope)
        {
            _businessLogic.ProcessData(s);
            scope.Resolve<Context>().DoSomething();

            Console.WriteLine("ehlo");
        }
    }
}
