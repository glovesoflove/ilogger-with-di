using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;



namespace ConsoleUI.Utility
{
    public class Loggy : ILoggy
    {
        static ILogger l;
        static IConfiguration c;

        public Loggy(IConfiguration c)
        {
            Loggy.c = c;
            var res = c.confroot();
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(res)
                    //.Enrich.FromLogContext()
                    .Enrich.WithCaller()
                    //.WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message} (at {Caller}){NewLine}{Exception}")
                    .CreateLogger();

                //Log.Information("Logger Initialized");
                //Log.Debug("Logger Initialized");
                //Log.Error("Logger Initialized");
                //Log.Logger.BkColor("Hello, {Name}! How are you {Today}? Pi is {Pi}", "World", "Today", 3.14159, LoggerExtensions.BackgroundBrightRed);
                //Log.Logger.BkColor("Hello World", LoggerExtensions.BackgroundBrightGreen);
                //Log.Logger.BkColor("Hello World. Today is {date}", DateTime.Now, LoggerExtensions.BackgroundBrightMagenta);

                l = Log.Logger;
            }
        }

        public void LogDebug(string s)
        {
            l.Debug(s);
        }
    }

    static class LoggerCallerEnrichmentConfiguration
    {
        public static LoggerConfiguration WithCaller(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<CallerEnricher>();
        }
    }

    class CallerEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var skip = 3;
            while (true)
            {
                var stack = new StackFrame(skip);
                if (!stack.HasMethod())
                {
                    logEvent.AddPropertyIfAbsent(new LogEventProperty("Caller", new ScalarValue("<unknown method>")));
                    return;
                }

                var method = stack.GetMethod();
                if (method.DeclaringType != null)
                {
                    if (method.DeclaringType.Assembly != typeof(Log).Assembly
                        && method.DeclaringType.Name != "SerilogLogger"
                        && method.DeclaringType.Name != "Logger"
                        //&& method.DeclaringType.Name !=  "ConstructorParameterBinding"
                        //&& method.DeclaringType.Name != "ReflectionActivator"
                        && !method.DeclaringType.FullName.Contains("Autofac"))
                    //&& method.DeclaringType.Assembly != typeof(Microsoft.Extensions.Logging.Logger<>).Assembly)
                    {
                        var caller = $"{method.DeclaringType.FullName}.{method.Name}({string.Join(", ", method.GetParameters().Select(pi => pi.ParameterType.FullName))})";
                        logEvent.AddPropertyIfAbsent(new LogEventProperty("Caller", new ScalarValue(caller)));
                        return;
                    }
                }
                skip++;
            }
        }
    }

    static class LoggerExtensions
    {
        public const string BackgroundBlack = "\u001b[40m";
        public const string BackgroundRed = "\u001b[41m";
        public const string BackgroundGreen = "\u001b[42m";
        public const string BackgroundYellow = "\u001b[43m";
        public const string BackgroundBlue = "\u001b[44m";
        public const string BackgroundMagenta = "\u001b[45m";
        public const string BackgroundCyan = "\u001b[46m";
        public const string BackgroundWhite = "\u001b[47m";
        public const string BackgroundBrightBlack = "\u001b[40;1m";
        public const string BackgroundBrightRed = "\u001b[41;1m";
        public const string BackgroundBrightGreen = "\u001b[42;1m";
        public const string BackgroundBrightYellow = "\u001b[43;1m";
        public const string BackgroundBrightBlue = "\u001b[44;1m";
        public const string BackgroundBrightMagenta = "\u001b[45;1m";
        public const string BackgroundBrightCyan = "\u001b[46;1m";
        public const string BackgroundBrightWhite = "\u001b[47;1m";

        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        public static void BkColor(
          this ILogger logger,
          string messageTemplate,
          params object[] args)
        {
            // Get the color they chose
            string CurrentColor = (string)args[args.GetLength(0) - 1];

            // Get rid of the color parameter now as it will break the Serilog parser
            args[args.GetLength(0) - 1] = "";

            // Prepend our color code to every argument (tested with strings and numbers)
            for (int i = 0; i < args.GetLength(0); i++)
            {
                args[i] = CurrentColor + args[i];
            }

            // Find all the arguments looking for the close bracket
            List<int> indexes = messageTemplate.AllIndexesOf("}");
            int iterations = 0;
            // rebuild messageTemplate with our color-coded arguments
            // Note: we have to increase the index on each iteration based on the previous insertion of
            // a color code
            foreach (var i in indexes)
            {
                messageTemplate = messageTemplate.Insert(i + 1 + (iterations++ * CurrentColor.Length), CurrentColor);
            }

            // Prefix the entire message template with color code
            string bkg = CurrentColor + messageTemplate;

            // Log it with a context
            logger.ForContext("IsImportant", true)
              .Information(bkg, args);
        }
    }
}




