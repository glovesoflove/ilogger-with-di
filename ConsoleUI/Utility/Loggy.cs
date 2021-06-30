using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleUI.Utility
{
    public class Logger : ILoggy
    {
        ILogger lug;

        public Logger()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                //.Enrich.FromLogContext()
                .Enrich.WithCaller()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message} (at {Caller}){NewLine}{Exception}")
                .CreateLogger();

            Log.Information("Logger Initialized");
            Log.Debug("Logger Initialized");
            Log.Error("Logger Initialized");

            lug = Log.Logger;
        }

        public void Logsy(string message)
        {

        }

        public void LogDebug(string s)
        {
            lug.Debug(s);
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
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
                        && !method.DeclaringType.FullName.Contains("Autofac")
                        && method.DeclaringType.Assembly != typeof(Microsoft.Extensions.Logging.Logger<>).Assembly)
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

}
