using System;

namespace ConsoleUI.Utility
{
    public class DataAccess : IDataAccess
    {
        static ILoggy l;

        public DataAccess(ILoggy l)
        {
            DataAccess.l = l;
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            l.LogDebug("Loading data");

            int i = 5;
            l.LogDebug("i: " + i);
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            l.LogDebug("Saving data");
        }
    }
}
