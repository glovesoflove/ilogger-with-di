using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class Bravo : ILogAbs, IBravo
    {
        IDataAccess _dataAccess;

        public Bravo(IDataAccess dataAccess)
        {
            _logger = new ILog(this.GetType().ToString());
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
