using Driver;
using TechTalk.SpecFlow;

namespace Musala.BDD.Tests.Hooks
{
    public class TestState
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TestThreadContext _testThreadContext;
        public readonly CustomWebDriver driver;

        public TestState(TestThreadContext testThreadContext, ScenarioContext scenarioContext)
        {
            _testThreadContext = testThreadContext;
            _scenarioContext = scenarioContext;
            this.driver = _testThreadContext.Get<CustomWebDriver>("driver");
        }
        public void AddDataToTransfare(string key, string value)
        {
            if (_scenarioContext.ContainsKey(key))
            {
                _scenarioContext.Remove(key);
            }
            _scenarioContext.Add(key, value);
        }
        public object GetTransferedData(string key)
        {
            return _scenarioContext.Get<object>(key);
        }
    }
}

