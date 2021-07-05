using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Utility
{
    class ILog
    {
        ILogger _ILogger;
        string ClassName;
        public ILog(string cName)
        {
            ILoggerFactory _Factory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddConsole();
            });
            _ILogger = _Factory.CreateLogger<Program>();
            ClassName = cName;
        }


        public void LogDebug(string msg)
        {
            _ILogger.LogDebug("Class: " + ClassName + " Method: " + GetMethodName() + " " + msg + ".");
        }

        public void LogInfo(string msg)
        {
            _ILogger.LogInformation("Class: " + ClassName + " Method: " + GetMethodName() + " " + msg + ".");
        }


        private string GetMethodName()
        {
            var st = new StackTrace();

            //Index 0 is this method (GetMethodName)
            //Index 1 is Log<kind>
            //Index 2 is the logging message
            var sf = st.GetFrame(2);

            var currentMethodName = sf.GetMethod();

            return currentMethodName.ToString();
        }


    }
}
