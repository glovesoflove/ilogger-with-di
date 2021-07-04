using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            _logger.LogDebug("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            _logger.LogDebug("Saving data");
        }
    }
}
