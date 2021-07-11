using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class DataAccess : IDataAccess
    {
        ILog _logger;
        public DataAccess()
        {
            ILogFactory LogFactory = new ILogFactory();
            _logger = LogFactory.GetILog();
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            _logger.LogDebug("Loading data");

            int i = 5;
            _logger.LogDebug("i: " + i);
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            _logger.LogDebug("Saving data");
        }
    }
}
