using Microsoft.Extensions.Logging;
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
        ILog _logger;

        public Bravo(IDataAccess dataAccess)
        {
            ILogFactory LogFactory = new ILogFactory();
            _logger = LogFactory.GetILog();
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
