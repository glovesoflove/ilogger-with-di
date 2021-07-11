using Microsoft.Extensions.Configuration;

namespace ConsoleUI.Utility
{
    public interface IConfiguration
    {
        IConfigurationRoot confroot();
    }
}