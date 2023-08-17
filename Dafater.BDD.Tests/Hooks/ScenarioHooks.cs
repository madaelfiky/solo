using Musala.BDD.Tests.Utilities.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace Musala.BDD.Tests.Hooks
{
    [Binding]
    public sealed class ScenarioHooks : TestState
    {
        private readonly static string _appUrl = ConfigManager.Config.AppUrl;
        public ScenarioHooks(TestThreadContext testThreadContext, ScenarioContext scenarioContext) : base(testThreadContext, scenarioContext)
        {
        }

        [BeforeScenario]
        public void GoToUrl()
        {
            driver.GoToUrl(_appUrl);
        }

        [AfterScenario]
        public void StopBrowser()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
