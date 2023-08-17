using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Musala.BDD.Tests.Utilities.Configuration
{
    public static class ConfigManager
    {
        private static Config _config;

        public static Config Config
        {
            get
            {
                if (_config != null)
                {
                    return _config;
                }

                var configuration = GetIConfigurationRoot();
                _config = new Config
                {
                    AppUrl = configuration["AppUrl"],
                    BrowserType = configuration.GetSection("Environment")["BrowserType"]
                };

                return _config;
            }
        }


        private static IConfigurationRoot GetIConfigurationRoot(string jsonFileName = "appsettings") =>
            new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Substring(6) + "\\Resources\\Settings")
                    .AddJsonFile($"{jsonFileName}.json", optional: false, reloadOnChange: true)
                    .Build();
    }
}


