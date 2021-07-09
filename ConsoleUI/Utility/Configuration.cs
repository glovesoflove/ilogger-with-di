using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Utility
{
    public class Configuration : IConfiguration
    {
        static IConfigurationRoot c;

        public Configuration()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            c = builder.Build();

            //g.Configuration(res);
        }

        public IConfigurationRoot confroot()
        {
            return c;
        }



        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
