using Musala.BDD.Tests.Utilities.Configuration;
using Driver;
using TechTalk.SpecFlow;
using static Driver.BrowserFactory;
using OpenQA.Selenium.Chrome;
using System;

namespace Musala.BDD.Tests.Hooks
{
    [Binding]
    public sealed class GlobalHooks
    {
        private static CustomWebDriver _globalDriver;
        [BeforeTestRun]
        public static void StartBrwoser(TestThreadContext testThreadContext)
        {               
            _globalDriver = BrowserFactory.GetBrowser();
            testThreadContext.Add("driver", _globalDriver);
            /*            ChromeOptions options = new ChromeOptions();
                        options.AddArgument("no-sandbox");

                        ChromeDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(130));*/

        }

        [AfterTestRun]
        public static void StopBrowser()
        {
            _globalDriver.QuitBrowser();
        }
    }
}
