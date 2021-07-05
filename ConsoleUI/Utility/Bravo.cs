using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class Bravo : IBravo
    {
        private  ILog Log;
        IDataAccess _dataAccess;

        public Bravo(IDataAccess dataAccess)
        {
            Log = new ILog(this.GetType().ToString());
            _dataAccess = dataAccess;
        }

        public void run(string[] s)
        {
            Console.WriteLine("Bravo::run()");
        }
    }
}
