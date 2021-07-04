using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class Bravo : IBravo
    {
        private readonly ILogger _logger;
        IDataAccess _dataAccess;

        public Bravo(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
