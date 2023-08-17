using Musala.BDD.Tests.Hooks;
using Musala.BDD.Tests.Selenium.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using Umrah.BDD.Tests.Selenium.Pages;

namespace Umrah.BDD.Tests.Steps
{
    [Binding]
    public sealed class UmrahStepDef : TestState
    {
        public UmrahStepDef(TestThreadContext testThreadContext, ScenarioContext scenarioContext) : base(testThreadContext, scenarioContext)
        {
        }

        [Given(@"the user Enters credentials")]
        public void GivenUserEntersCredentials()
        {
            new UmrahPage(driver).GivenTheUserEnterallCredentials();
        }

        [When(@"user Change language to arabic")]
        public void WhenUserChangeLanguageToArabic()
        {

            new UmrahPage(driver).WhenUserChangeLanguageToArabic();

        }

        [When(@"user Change language to arabic2")]
        public void WhenUserChangeLanguageToArabic2()
        {

            new UmrahPage(driver).WhenUserChangeLanguageToArabic2();

        }

        [Then(@"assert langauage is changed")]
        public void ThenValidationMessageShouldAppearsThatYoureHuman()
        {

            new UmrahPage(driver).AssertLanguageIsChanged(); 
        }




    }
}
