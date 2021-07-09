using Autofac;
using ConsoleUI.Utility;
using System;

namespace ConsoleUI
{

    public interface IStrategy { void Do(); }
    public class ConcreteStrategyA : IStrategy { public void Do() { Console.WriteLine("Called ConcreteStrategyA.Do()"); } };
    public class ConcreteStrategyB : IStrategy { public void Do() { Console.WriteLine("Called ConcreteStrategyB.Do()"); } };


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main init");
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run(args, scope);
            }

            Console.ReadLine();
        }
    }
}
