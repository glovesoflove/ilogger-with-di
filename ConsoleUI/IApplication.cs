using Autofac;

namespace ConsoleUI
{
    public interface IApplication
    {
        void Run(string[] args, ILifetimeScope scope);
    }
}