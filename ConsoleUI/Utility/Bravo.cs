using Serilog;
using System;

namespace ConsoleUI.Utility
{
    public enum ESomeEnum
    {
        UseStrategyA,
        UseStrategyB,
    }

    public class Bravo : IBravo
    {
        IDataAccess _dataAccess;
        ILoggy log;

        public Bravo(ILoggy log, IDataAccess dataAccess)
        {
            this.log = log;
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
