using Musala.BDD.Tests.Hooks;
using Solo.BDD.Tests.Selenium.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using Solo.BDD.Tests.Selenium.Pages;

namespace Umrah.BDD.Tests.Steps
{
    [Binding]
    public sealed class SoloStepDef : TestState
    {
        public SoloStepDef(TestThreadContext testThreadContext, ScenarioContext scenarioContext) : base(testThreadContext, scenarioContext)
        {
        }

        [Given(@"the user Enters solo credentials")]
        public void GivenTheUserEntersSoloCredentials()
        {
            new SoloPage(driver).GivenTheUserEnterallCredentials();
        }

        [When(@"user clicks files")]
        public void WhenUserClicksFiles()
        {
            new SoloPage(driver).WhenUserNavigateToFilesPage();
        }

        [When(@"user upload files")]
        public void WhenUserUploadFiles()
        {
            new SoloPage(driver).WhenUserUploadFile();
        }


        [Then(@"files should be uploaded successfully")]
        public void ThenFilesShouldBeUploadedSuccessfully()
        {
            new SoloPage(driver).CheckThatTheFileIsUploaded();
        }




    }
}
