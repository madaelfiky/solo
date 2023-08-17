using Musala.BDD.Tests.Utilities.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace Driver
{
    public class BrowserFactory
    {
        private readonly static string _binaryPaath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private readonly static string _browserType = ConfigManager.Config.BrowserType;

        public static CustomWebDriver GetBrowser()
        {
            IWebDriver driver;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            switch (_browserType.ToUpper())
            {
                case "FireFox":
                    driver = new FirefoxDriver(_binaryPaath);
                    break;
                case "CHROME":

                    //driver = new ChromeDriver(_binaryPaath);

                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(_binaryPaath), options, TimeSpan.FromMinutes(3));
                    break;
                default:
                    throw new Exception("Unknow browser type " + _browserType);

            }

            
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();

            return new CustomWebDriver(driver);
        }
    }
}
