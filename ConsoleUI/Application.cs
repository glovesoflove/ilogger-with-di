using System;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        IBusinessLogic _businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Run(string[] s)
        {
            _businessLogic.ProcessData(s);
            Console.WriteLine("ehlo");
        }
    }
}
