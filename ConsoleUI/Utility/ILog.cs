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


        public void LogDebug(params object[] msg)
        {
            string message = "";
            foreach(object o in msg)
            {
                message += o.ToString();
            }
            _ILogger.LogDebug("Class: " + ClassName + " Method: " + GetMethodName() + " " + message + ".");
        }

        public void LogInfo(params object[] msg)
        {
            string message = "";
            foreach (object o in msg)
            {
                message += o.ToString();
            }
            _ILogger.LogInformation("Class: " + ClassName + " Method: " + GetMethodName() + " " + message + ".");
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
