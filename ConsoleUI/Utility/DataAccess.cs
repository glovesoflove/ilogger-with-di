using System;

namespace ConsoleUI.Utility
{
    public class DataAccess : IDataAccess
    {
        ILoggy _logger;
        public DataAccess(ILoggy logger)
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
