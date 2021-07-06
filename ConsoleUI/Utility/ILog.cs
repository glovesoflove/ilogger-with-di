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
            string message;
            if(msg.GetLength(0) - 1 > 0)
            {
                object[] args = new object[msg.GetLength(0) - 1];
                Array.Copy(msg, 1, args, 0, msg.GetLength(0) - 1);
                message = String.Format(msg[0].ToString(), args);
            }
            else
            {
                message = msg[0].ToString();
            }

            _ILogger.LogDebug("Class: " + ClassName + " Method: " + GetMethodName() + " " + message + ".");
        }

        public void LogInfo(params object[] msg)
        {
            string message = "";
            if (msg.GetLength(0) - 1 > 0)
            {
                object[] args = new object[msg.GetLength(0) - 1];
                Array.Copy(msg, 1, args, 0, msg.GetLength(0) - 1);
                message = String.Format(msg[0].ToString(), args);
            }
            else
            {
                message = msg[0].ToString();
            }
            _ILogger.LogInformation("Class: " + ClassName + " Method: " + GetMethodName() + " " + message + ".");
        }

        public void LogBkColor(params object[] msg)
        {
            string message = "";
            if (msg.GetLength(0) - 1 > 0)
            {
                object[] args = new object[msg.GetLength(0) - 2];
                Array.Copy(msg, 1, args, 0, msg.GetLength(0) - 2);
                message = String.Format(msg[0].ToString(), args);
            }
            else
            {
                message = msg[0].ToString();
            }
            ConsoleColor CColor = Console.BackgroundColor;
            Console.BackgroundColor = (ConsoleColor)msg[msg.GetLength(0) - 1];
            _ILogger.LogInformation("Class: " + ClassName + " Method: " + GetMethodName() + " " + message + ".");

           // Console.BackgroundColor = CColor;
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
