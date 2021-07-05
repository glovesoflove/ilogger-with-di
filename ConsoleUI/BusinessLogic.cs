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
        private ILog Log;

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


            Log.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            Log.LogDebug("Finished processing of the data.");
            Log.LogDebug("running Bravo");
            b.run(s);
            

        }
    }
}
