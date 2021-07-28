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
        LogFactory LoggerFactory = new LogFactory();

        public Bravo(IDataAccess dataAccess)
        {
            _logger = LoggerFactory.GetILog();
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
