using Microsoft.Extensions.Logging;
using System;

namespace ConsoleUI.Utility
{
    public class DataAccess : IDataAccess
    {
        ILog Log;
        public DataAccess()
        {
            Log = new ILog(this.GetType().ToString());
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            Log.LogDebug("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            Log.LogDebug("Saving data");
        }
    }
}
