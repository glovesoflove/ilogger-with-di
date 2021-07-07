using ConsoleUI.Utility;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    public class BusinessLogic : ILogAbs, IBusinessLogic
    {
        IDataAccess _dataAccess;
        IBravo b;

        public BusinessLogic(IDataAccess dataAccess, IBravo b)
        {
            Log = new ILog(this.GetType().ToString());
            _dataAccess = dataAccess;
            this.b = b;
        }

        public void ProcessData(string[] s)
        {

            Log.LogDebug("Starting the processing of data.");
            Log.LogInfo("Test Log...Wait!");
            Log.LogInfo("Format {0}", 10);
            Log.LogBkColor("Format {0}", 10, ConsoleColor.Red);

            Log.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            Log.LogDebug("Finished processing of the data.");
            //intending to use a processor specific to (#issue1) 
            string t = "123";

            //(#strategy) 
            IProcessor p = new Numbers();
            IProcessor p2 = new Letters();

            //(ILogger with Dependency Injection #ilogger-di)
            //updated string to correct string formating
            Log.LogBkColor("Hello, {0}! How are you {1}? Pi is {2}", "World", "Today", 3.14159, ConsoleColor.DarkRed);

            p.Process(t);
            p2.Process(t);
            Log.LogDebug("running Bravo");
            b.run(s);


            

        }
    }
}
