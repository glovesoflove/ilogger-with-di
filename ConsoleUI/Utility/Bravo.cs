using System;

namespace ConsoleUI.Utility
{
    public class Bravo : IBravo
    {
        ILoggy _logger;
        IDataAccess _dataAccess;

        public Bravo(ILoggy logger, IDataAccess dataAccess)
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
