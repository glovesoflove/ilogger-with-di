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
        private readonly ILogger _logger;

        public BusinessLogic(ILogger logger, IDataAccess dataAccess, IBravo b)
        {
            _logger = logger;
            _dataAccess = dataAccess;
            this.b = b;
        }

        public void ProcessData(string[] s)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);

            var currentMethodName = sf.GetMethod();
            _logger.LogDebug("Class: " + this.GetType().ToString() + " Method: " + "[Method name]"+ "Starting the processing of data.");
            _logger.LogInformation("Test Log...Wait!");
            _logger.LogInformation("Class: " + this.GetType().ToString() + " Method: " + currentMethodName.ToString() + "Starting the processing of data.");
            _logger.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.LogDebug("Finished processing of the data.");
            _logger.LogDebug("running Bravo");
            b.run(s);
            

        }
    }
}
