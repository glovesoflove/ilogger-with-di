using ConsoleUI.Utility;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    public class BusinessLogic : IBusinessLogic
    {
        IDataAccess _dataAccess;
        IBravo b;
        ILog _logger;

        public BusinessLogic(IDataAccess dataAccess, IBravo b)
        {
            ILogFactory LogFactory = new ILogFactory();
            _logger = LogFactory.GetILog();
            _dataAccess = dataAccess;
            this.b = b;
        }

        public void ProcessData(string[] s)
        {

            _logger.LogDebug("Starting the processing of data.");
            _logger.LogInfo("Test Log...Wait!");
            _logger.LogInfo("Format {0}", 10);
            _logger.LogBkColor("Format {0}", 10, ConsoleColor.Red);

            _logger.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.LogDebug("Finished processing of the data.");

            //intending to use a processor specific to (#issue1) 
            string t = "123";

            //(#strategy) 
            IProcessor p = new Numbers();


            //IProcessor p = new Letters();

            //(ILogger with Dependency Injection #ilogger-di)
            _logger.LogBkColor("Hello, {0}! How are you {1}? Pi is {2}", "World", "Today", 3.14159, ConsoleColor.Red);

            p.Process(t);

            _logger.LogDebug("running Bravo");
            b.run(s);


            

        }
    }
}
