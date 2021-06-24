using ConsoleUI.Utility;

namespace ConsoleUI
{
    public class BusinessLogic : IBusinessLogic
    {
        ILoggy _logger;
        IDataAccess _dataAccess;
        IBravo b;

        public BusinessLogic(ILoggy logger, IDataAccess dataAccess, IBravo b)
        {
            _logger = logger;
            _dataAccess = dataAccess;
            this.b = b;
        }

        public void ProcessData(string[] s)
        {
            _logger.LogDebug("Starting the processing of data.");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.LogDebug("Finished processing of the data.");
            _logger.LogDebug("running Bravo");
            b.run(s);

        }
    }
}
