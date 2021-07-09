using ConsoleUI.Utility;
using Serilog;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    public class BusinessLogic : IBusinessLogic
    {
        IDataAccess _dataAccess;
        IBravo b;
        static ILoggy l;

        public BusinessLogic(ILoggy l, IDataAccess dataAccess, IBravo b)
        {
            BusinessLogic.l = l;
            _dataAccess = dataAccess;
            this.b = b;
        }

        public void ProcessData(string[] s)
        {
            l.LogDebug("Starting the processing of data.");
            //l.Warning("Test Log...Wait!");
            //l.Warning("Format {0}", 10);
            //l.LogBkColor("Format {0}", 10, ConsoleColor.Red);

            l.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            l.LogDebug("Finished processing of the data.");

            //intending to use a processor specific to (#issue1) 
            string t = "123";

            //(#strategy) 
            //IProcessor p = new Numbers();
            //IProcessor p = new Letters();

            //(ILogger with Dependency Injection #ilogger-di)
            //_logger.BkColor("Hello, {Name}! How are you {Today}? Pi is {Pi}", "World", "Today", 3.14159, LoggerExtensions.BackgroundBrightRed);

            //p.Process(t);

            l.LogDebug("running Bravo");
            b.run(s);
        }
    }
}
